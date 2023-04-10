using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;

namespace Datos.Repositorios
{
    public class RepositorioCabania : IRepositorioCabania

    {
        public LibreriaContext LibreriaContext { get; set; }
        public IRepositorioTipoCabania TipoCabania { get; set; }    
        public RepositorioCabania(LibreriaContext libreriaContext, IRepositorioTipoCabania tipoCabania)
        {
            LibreriaContext = libreriaContext;
            TipoCabania = tipoCabania;
        }

        public void Add( Cabania obj)
        {
            obj.Validar();
            obj.SerializeNombreFoto(obj.Nombre);
            TipoCabania tipo = TipoCabania.FindById(obj.IdTipoCabania);
            obj.TipoCabania = tipo;
            LibreriaContext.Cabania.Add(obj);
            LibreriaContext.SaveChanges();
        }

        public IEnumerable<Cabania> FindAll()
        {
            IEnumerable<Cabania> lista = LibreriaContext.Cabania.Include(o => o.TipoCabania).ToList();
            return lista;
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
