using EjemploApi.Common.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace EjemploApi.Business.Facade.LogicTests.Controllers
{
    [TestClass()]
    public class ClientTest
    {
        private HttpClient client;

        [TestInitialize]
        public void Init()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseApiUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestCleanup]
        public void Exit()
        {
            client.Dispose();
        }

        [DataRow(1, "Pepe", "Sanchez")]
        [DataRow(2, "Juan", "Tomorrow")]
        [DataRow(3, "Dani", "Pacheco")]
        [DataRow(4, "Lara", "Croft")]
        [DataTestMethod]
        public void Response(int id, string nombre, string apellido)
        {
            var usuarioenviado = new Usuario { Id = id, Nombre = nombre, Apellido = apellido };
            var key = "pepe";
            var responseSent = Task.Run(()=> client.PostAsJsonAsync<Usuario>($"/api/v1/UsuarioAsync/AddAsync?key={key}", usuarioenviado).GetAwaiter().GetResult() );
            responseSent.Result.EnsureSuccessStatusCode();

            var responseRecivied = Task.Run(()=> client.GetAsync($"/api/v1/UsuarioAsync/GetAsync?key={key}").GetAwaiter().GetResult());
            responseRecivied.Result.EnsureSuccessStatusCode();
            using (var content = responseRecivied.Result.Content)
            {
                var ususarioDevuelto = content.ReadAsAsync<Usuario>().GetAwaiter().GetResult();

                Assert.IsTrue(usuarioenviado.Equals(ususarioDevuelto));
            }

          
        }

       
    }
}
