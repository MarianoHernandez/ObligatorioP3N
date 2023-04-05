using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.InterfacesDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio.Entidades
{
    public class TipoCabania:IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public decimal Costo { get; set; }

        public void Validar()
        {
            if (! Regex.IsMatch(Nombre, "^[a-zA-Z]+( [a-zA-Z]+)*$"))
            {
                throw new NombreInvalidoException("El nombre solo incluye caracteres alfabéticos y espacios embebidos, pero no al principio ni final)");
            }
            if (Descripcion.Length < 10 || Descripcion.Length > 200) {
                throw new DescripcionInvalidaException("La descripcion no puede tener menos de 10 caracteres ni mas de 500");
            }
            
        }
    }
}
