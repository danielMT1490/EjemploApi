using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.Common.Logic
{
    public class ConfigurationTools
    {
        public static string GetRedisEndPoint()
        {
            return ConfigurationManager.AppSettings["RedisConnString"];
        }
    }
}
