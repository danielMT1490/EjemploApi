﻿using EjemploApi.Common.Logic;
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
        
        public UsuarioAsyncController(IUsuarioBlAsync usuarioBlAsync)
        {
            this._usuarioBlAsync = usuarioBlAsync;
        }

        /// <summary>
        /// Return one Student for Redis
        /// </summary>
        /// <param name=<em>"key"</em>>Redis key of tables</param>
        /// <returns>Student Json Serialize</returns>
        [HttpGet()]
        public async Task<IHttpActionResult> GetAsync(string key)
        {
            try
            {
                var result = await this._usuarioBlAsync.GetAsync(key);
                if (result==null) return NotFound();
                else return Ok(result);

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
           
            
        }

        /// <summary>
        /// Add one Student in Redis
        /// </summary>
        /// <param name=<em>"key"</em>>Redis key of tables</param>
        /// <param name=<em>"entity"</em>>The student to save</param>
        /// <returns>Student Json Serialize</returns>
        [HttpPost()]
        public async Task<IHttpActionResult> AddAsync(string key ,Usuario entity )
        {
            try
            {
                var result = await this._usuarioBlAsync.AddAsync(entity, key).ConfigureAwait(false);
                if (result ==null)return NotFound();
                else return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            
            
          
        }
      

    }
}
