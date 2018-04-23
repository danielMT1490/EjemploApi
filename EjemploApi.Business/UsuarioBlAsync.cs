using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploApi.Common.Logic;
using EjemploApi.DataAccess.Redis;

namespace EjemploApi.Business
{
    public class UsuarioBlAsync : IUsuarioBlAsync
    {
        private readonly IGetAsync<Usuario> _get;
        private readonly ISetAsync<Usuario> _set;

        public UsuarioBlAsync(RedisDao<Usuario> Redis)
        {
            this._get = Redis;
            this._set = Redis;
        }
        public async Task<Usuario> AddAsync(Usuario entity, string key)
        {
            return await _set.AddAsync(entity,key);
        }

        public async Task<Usuario> GetAsync(string key)
        {
            return await _get.GetAsync(key);
        }
    }
}
