using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionParametros
{
    public class AltaParametro :IAltaParametro
    {

        public IRepositorioParametros Repo { get; set; }
        public AltaParametro(IRepositorioParametros repo)
        {

            Repo = repo;
        }


        public void Alta(Parametro param)
        {
            Repo.Add(param);
        }
    }
}
