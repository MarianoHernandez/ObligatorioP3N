using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabaña
{
    public class AltaCabania : IAltaCabania
    {
        public IRepositorioCabania Repo { get; set; }

        public AltaCabania(IRepositorioCabania repo) {

            Repo = repo;
        }


        public void Alta( Cabania cabania)
        {
            Repo.Add(cabania);
        }
    }
}
