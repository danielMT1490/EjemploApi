using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.Common.Logic
{
    public class Usuario : IModel
    {

        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        #endregion

        public override bool Equals(object obj)
        {
            return obj is Usuario user &&
                   Id == user.Id &&
                   Nombre == user.Nombre &&
                   Apellido == user.Apellido;
        }
        public override int GetHashCode()
        {
            var hashCode = -818402288;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellido);
            return hashCode;
        }
    }
}
