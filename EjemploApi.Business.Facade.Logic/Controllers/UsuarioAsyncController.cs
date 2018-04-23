using EjemploApi.Common.Logic;
using EjemploApi.DataAccess.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace EjemploApi.Business.Facade.Logic.Controllers
{
    public class UsuarioAsyncController : ApiController
    {
        private readonly IUsuarioBlAsync _usuarioBlAsync;
        /*
        public UsuarioAsyncController()
        {
            this._usuarioBlAsync = new UsuarioBlAsync(new RedisDao<Usuario>());
        }*/
        
        public UsuarioAsyncController(IUsuarioBlAsync usuarioBlAsync)
        {
            this._usuarioBlAsync = usuarioBlAsync;
        }

        [HttpGet()]
        public async Task<IHttpActionResult> GetAsync(string key)
        {
            //Thread.Sleep(10000);
            var result = await this._usuarioBlAsync.GetAsync(key);
            return Ok(result);
        }


        [HttpPost()]
        public async Task<IHttpActionResult> AddAsync(Usuario entity )
        {
            //Thread.Sleep(10000);
            var result=  await this._usuarioBlAsync.AddAsync(entity, "pepe");
            return Ok(result);
        }
    }
}
