using System;
using System.Collections.Generic;
using EjemploApi.Business;
using EjemploApi.Business.Facade.Logic.Controllers;
using EjemploApi.Common.Logic;
using EjemploApi.DataAccess.Redis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EjemploApiIntegrationTest
{
    [TestClass]
    public class ApiIntedrationTest
    {
        private IUsuarioBlAsync usuarioBl;
        private UsuarioAsyncController controler;
        private readonly RedisDao<Usuario> redis = new RedisDao<Usuario>();
        private System.Net.Http.HttpClient client;


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

        [TestMethod]
        public async void AddAsyncApiTest()
        {
            var usuario = new Usuario { Id = 1, Nombre = "Pepe", Apellido = "Sanchez" };
            var key = "test";
            var resultcontroler = await controler.AddAsync(key, usuario);
            var result = resultcontroler.ExecuteAsync(new System.Threading.CancellationToken());
            var usuariodevuelto = result.Result.Content;

            Assert.AreEqual(key, result);
        }
    }
}
