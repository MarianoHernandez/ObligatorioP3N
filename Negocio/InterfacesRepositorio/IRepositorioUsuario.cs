using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Entidades;


namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        void  Login(Usuario usuario);
        void  Logout();
    }
}
