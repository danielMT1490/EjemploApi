using System;
using System.Collections.Generic;
using System.Net.Http;
using EjemploApi.Business;
using EjemploApi.Business.Facade.Logic.Controllers;
using EjemploApi.Common.Logic;
using EjemploApi.DataAccess.Redis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;

namespace EjemploApi.Integration.Facade.Logic
{
    [TestClass]
    public class UnitTest1
    {
        private  IUsuarioBlAsync usuarioBl;
        private UsuarioAsyncController controler;
        private readonly RedisDao<Usuario> redis = new RedisDao<Usuario>();
        private HttpClient client;

        
        [TestInitialize]
        public void Init()
        {
            usuarioBl = new UsuarioBlAsync(redis);
            controler = new UsuarioAsyncController(usuarioBl);
        }

        [TestCleanup]
        public void Exit()
        {

        }
        /*public static IEnumerable<object[]> GetUsuarios(Usuario[] usuarios)
        {
            yield return new object[] { new Usuario { Id = 1, Nombre = "Pepe", Apellido = "Sanchez" } };
            yield return new object[] { new Usuario { Id = 2, Nombre = "Juan", Apellido = "Garcia" } };
            yield return new object[] { new Usuario { Id = 3, Nombre = "Dani", Apellido = "Tomorrow" } };
            yield return new object[] { new Usuario { Id = 4, Nombre = "Juan", Apellido = "Pepon" } };
            yield return new object[] { new Usuario { Id = 5, Nombre = "Lara", Apellido = "Croft" } };

        }
        [DataTestMethod]
        [DynamicData(nameof(GetUsuarios), DynamicDataSourceType.Method)]*/
        [TestMethod]
        public async void AddAsyncApiTest(Usuario usuario)
        {
            var key = "test";
            var resultcontroler = await controler.AddAsync(key,usuario);
            var result = resultcontroler.ExecuteAsync(new System.Threading.CancellationToken());
            var usuariodevuelto =result.Result.Content;

            Assert.AreEqual(key,result);
        }

       
    }
}
