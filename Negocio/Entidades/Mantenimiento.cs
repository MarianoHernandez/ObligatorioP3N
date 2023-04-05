using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ExcepcionesPropias;

namespace Negocio.Entidades 
{
    public class Mantenimiento : IValidable
    {
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public string trabajador { get; set; }
        public Cabania cabania { get; set; }
        public int idMantenimiento { get; set; }


        public void Validar()
        {
            if(descripcion.Length < 10 || descripcion.Length > 200)
            {
                throw new CaracteresDentroDeRango("La cantidad de caracteres debe de ser entre 10 y 200");
            }
            if (string.IsNullOrEmpty(descripcion))
            {
                throw new CampoVacioException("El campo no puede estar vacio");
            }
            if (fecha == DateTime.MinValue)
            {
                throw new CampoVacioException("El campo no puede estar vacio");
            }
            if (costo == 0)
            {
                throw new CampoVacioException("El campo no puede estar vacio o mayor a 0");
            }
            if (cabania == null)
            {
                throw new CampoVacioException("El campo no puede estar vacio");
            }
        }
    }
}
