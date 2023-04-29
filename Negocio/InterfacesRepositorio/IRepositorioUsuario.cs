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
        Usuario  Login(Usuario usuario);
        void GetUsuario(string email, string password);
        void  Logout();
    }
}
