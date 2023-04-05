using Datos.Entity;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class RepositorioTipoCabania : IRepositorioTipoCabania
    {

        public LibreriaContext LibreriaContext { get; set; }
        public RepositorioTipoCabania(LibreriaContext libreriaContext) {
            LibreriaContext = libreriaContext;

        }
        public void Add(TipoCabania obj)
        {
            obj.Validar();
            LibreriaContext.TipoCabania.Add(obj);
            LibreriaContext.SaveChanges();
        }

        public IEnumerable<TipoCabania> FindAll()
        {
            return LibreriaContext.TipoCabania.ToList();
        }

        public TipoCabania FindById(int id)
        {
            throw new NotImplementedException();
        }

        public TipoCabania FindByName(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoCabania obj)
        {
            throw new NotImplementedException();
        }
    }
}
