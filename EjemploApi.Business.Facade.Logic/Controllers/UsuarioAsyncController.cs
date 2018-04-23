using EjemploApi.Common.Logic;
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

        public UsuarioAsyncController(IUsuarioBlAsync usuarioBlAsync)
        {
            this._usuarioBlAsync = usuarioBlAsync;
        }

        public async Task<Usuario> GetAsync(string key)
        {
            Thread.Sleep(10000);
            return await this._usuarioBlAsync.GetAsync(key);
        }
        public async Task<Usuario> AddAsync(Usuario entity , string key)
        {
            Thread.Sleep(10000);
            return await this._usuarioBlAsync.AddAsync(entity, key);
        }
    }
}
