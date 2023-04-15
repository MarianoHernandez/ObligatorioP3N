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
        public string? descripcion { get; set; }
        public decimal costo { get; set; }
        public string? trabajador { get; set; }
        public Cabania cabania { get; set; }
        public int CabaniaId { get; set; }
        public int Id { get; set; }


        public void Validar()
        {
            #region Validar
            if (descripcion.Length < 10 || descripcion.Length > 200 || descripcion == null)
            {
                throw new CaracteresDentroDeRango("La cantidad de caracteres debe de ser entre 10 y 200");
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

            if (cabania.Id == Id)
            {
                if (Id > 3 && fecha == DateTime.Now)
                {
                    throw new MantenimientoInvalidoException("La Cabaña no puede tener mas de 3 mantenimientos en el dia");

                }

            }

            #endregion
        }
    }
}
