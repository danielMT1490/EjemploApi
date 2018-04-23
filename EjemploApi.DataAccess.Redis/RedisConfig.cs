using EjemploApi.Common.Logic;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.DataAccess.Redis
{
    public class RedisConfig
    {
        //Lazy nos ejecuta la conexion de forma asincrona
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisConfig()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { ConfigurationTools.GetRedisEndPoint() }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}
