using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entity;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;

namespace Datos.Repositorios
{
    public class RepositorioCabania : IRepositorioCabania

    {
        public LibreriaContext LibreriaContext { get; set; }
        public RepositorioCabania(LibreriaContext libreriaContext)
        {
            LibreriaContext = libreriaContext;
        }

        public void Add(Cabania obj)
        {
            obj.Validar();
            LibreriaContext.Cabania.Add(obj);
            LibreriaContext.SaveChanges();
        }

        public IEnumerable<Cabania> FindAll()
        {
            throw new NotImplementedException();
        }

        public Cabania FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabania> FindCabaña(string nombre, TipoCabania tipo, int cantidadPers, bool habilitada)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cabania obj)
        {
            throw new NotImplementedException();
        }
    }
}
