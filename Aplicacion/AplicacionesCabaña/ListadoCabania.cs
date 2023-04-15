using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion.AplicacionesCabaña
{
    public class ListadoCabania : IListadoCabania
    {
        IRepositorioCabania Repositorio;

        public ListadoCabania(IRepositorioCabania repositorio)
        {
            Repositorio = repositorio;
        }

        public IEnumerable<Cabania> ListadoCabanias(string nombre, TipoCabania tipo, int cantidadPers, bool habilitada)
        {
            return Repositorio.FindCabaña(nombre,tipo,cantidadPers,habilitada);
        }
    }
}
