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

        public UsuarioBlAsync(IGetAsync<Usuario> get, ISetAsync<Usuario> set)
        {
            this._get = get;
            this._set = set;
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
