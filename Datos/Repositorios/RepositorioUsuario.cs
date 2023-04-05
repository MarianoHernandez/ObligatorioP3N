using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Datos.Entity;


namespace Datos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioUsuario(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Usuario obj)
        {
            obj.Validar();
            Contexto.Usuario.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Login(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
