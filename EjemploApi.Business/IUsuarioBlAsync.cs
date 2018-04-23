using EjemploApi.Common.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.Business
{
    public interface IUsuarioBlAsync
    {
        Task<Usuario> AddAsync(Usuario entity, string key);
        Task<Usuario> GetAsync(string key);
    }
}
