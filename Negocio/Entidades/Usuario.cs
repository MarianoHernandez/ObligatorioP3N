using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ExcepcionesPropias;

namespace Negocio.Entidades
{
    public class Usuario : IValidable
    {
        public string email { get; set; }
        public string password { get; set; }
        public int Id { get; set; }

        public void Validar()
        {
            #region Validar Usuario

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new CampoVacioException("Los campos no pueden estar vacios");
            }

        #endregion
        }
    }
}
