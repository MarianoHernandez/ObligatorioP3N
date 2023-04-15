using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabaña
{
    public class FindCabania : IFindCabania
    {
        IRepositorioCabania RepositorioCabania { get; set; }

        public FindCabania(IRepositorioCabania repositorioCabania) {
            RepositorioCabania = repositorioCabania;
        }

        public IEnumerable<Cabania> FindCabanias()
        {
            return RepositorioCabania.FindCabaña();
        }
    }
}
