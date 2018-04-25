using Microsoft.VisualStudio.TestTools.UnitTesting;
using EjemploApi.Business.Facade.Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploApi.DataAccess.Redis;
using EjemploApi.Common.Logic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;

namespace EjemploApi.Business.Facade.Logic.Controllers.Tests
{
    [TestClass()]
    public class UsuarioAsyncControllerIntegrationTests
    {
        private StackExchange.Redis.IDatabase database;
        private IUsuarioBlAsync usuarioBl;
        private UsuarioAsyncController controler;

        [TestInitialize]
        public void Init()
        {
            database = RedisConfig.RedisCache;
            usuarioBl = new UsuarioBlAsync(new RedisDao<Usuario>());
            controler = new UsuarioAsyncController(usuarioBl);
        }

        [TestCleanup]
        public void Exit()
        {
            database.KeyDelete("test");
        }

        [DataRow(1,"Pepe","Sanchez")]
        [DataRow(2, "Juan", "Tomorrow")]
        [DataRow(3, "Dani", "Pacheco")]
        [DataRow(4, "Lara", "Croft")]
        [TestMethod]
        public  void AddAsyncApiTest(int id , string nombre , string apellido)
        {
            var usuario = new Usuario { Id=id, Nombre=nombre, Apellido=apellido };
            var key = "test";
            var resultcontroler = Task.Run(()=>controler.AddAsync(key, usuario)).GetAwaiter().GetResult() as OkNegotiatedContentResult<Usuario>;
            var alumnodevuelto = resultcontroler.Content;
            Assert.IsTrue(usuario.Equals(alumnodevuelto));

        }

        [DataRow(1, "Pepe", "Sanchez")]
        [DataRow(2, "Juan", "Tomorrow")]
        [DataRow(3, "Dani", "Pacheco")]
        [DataRow(4, "Lara", "Croft")]
        [TestMethod]
        public void GetAsyncApiTest(int id, string nombre, string apellido)
        {
            var usuario = new Usuario { Id = id, Nombre = nombre, Apellido = apellido };
            var key = "test";
            database.StringSet(key,JsonConvert.SerializeObject(usuario));
            var resultcontroler = Task.Run(() => controler.GetAsync(key)).GetAwaiter().GetResult() as OkNegotiatedContentResult<Usuario>;
            var alumnodevuelto = resultcontroler.Content;
            Assert.IsTrue(usuario.Equals(alumnodevuelto));
        }
    }
}