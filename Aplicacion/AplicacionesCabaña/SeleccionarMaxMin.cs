using Negocio.Entidades;
using Negocio.InterfacesRepositorio;

namespace Aplicacion.AplicacionesCabaña
{
	public class SeleccionarMaxMin : ISeleccionarMaxMinDescripcion
	{
        public IRepositorioCabania Repo { get; set; }

        public SeleccionarMaxMin(IRepositorioCabania repo)
        {

            Repo = repo;
        }


        public void SeleccionarMaxMinDescripcion(int max,int min)
        {
            Repo.ValorDescripcion(max, min);
        }
    }
}

