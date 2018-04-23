using EjemploApi.Common.Logic;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Reflection;

namespace EjemploApi.DataAccess.Redis
{
    public class RedisDao<T> : ISetAsync<T>, IGetAsync<T> where T : IModel
    {
        private readonly IDatabase _redis ;

        public RedisDao()
        {
            this._redis = RedisConfig.RedisCache;
        }
        public async Task<T> AddAsync(T entity ,string key)
        {
            //Ejecutar los metodos de forma asincrona
            await this._redis.StringSetAsync(key, JsonConvert.SerializeObject(entity));
            return await GetAsync(key);
        }

        public async Task<T> GetAsync(string key )
        {
            return JsonConvert.DeserializeObject<T>(await this._redis.StringGetAsync(key));
        }
    }
}
