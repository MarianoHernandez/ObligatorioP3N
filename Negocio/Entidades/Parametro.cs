using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Entidades
{
    public class Parametro :IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ValorMaximo { get; set; }
        public int ValorMinimo { get; set; }

        public void Validar()
        {
            if (ValorMaximo < ValorMinimo) {
                throw new Exception("El valor Maximo de la descripcion tiene que ser mayor al Menor");
            }
        }
    }
}
