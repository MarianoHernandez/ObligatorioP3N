using Negocio.EntidadesAuxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorioParametros :IRepositorio<Parametro>
    {
        Parametro ObtenerParametrosCabania();
        Parametro ObtenerParametrosTipo();

    }
}
