using EjemploApi.Common.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.DataAccess.Redis
{
    public interface IGetAsync<T> where T : IModel
    {
        Task<T> GetAsync(string key);
    }
}
