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
            TipoCabania tipo = TipoCabania.FindById(obj.TipoCabaniaId);
            obj.TipoCabania = tipo;
            LibreriaContext.Cabania.Add(obj);
            LibreriaContext.SaveChanges();
        }

        public IEnumerable<Cabania> FindAll()
        {
            IEnumerable<Cabania> cabanias = LibreriaContext.Cabania.Include(o => o.TipoCabania).ToList();

            return cabanias;
        }

        public Cabania FindById(int id)
        {

            return LibreriaContext.Cabania.Include(cab => cab.TipoCabania).SingleOrDefault(cabania => cabania.Id == id);
        }

        public IEnumerable<Cabania> FindCabaña(string nombre, int tipoId, int cantidadPers, bool habilitada)
        {
            IEnumerable<Cabania> lista = LibreriaContext.Cabania.Include(o => o.TipoCabania);

            if (nombre != null) {
                lista.Where(cab => cab.Nombre == nombre);
                return lista.ToList();
            }if (tipoId != 0) {
                lista.Where(cab => cab.TipoCabaniaId == tipoId);
            }if (cantidadPers >= -1) { 
                lista.Where(cab => cab.CantidadPersonas >= cantidadPers);
            }if (habilitada) {
                lista.Where(cab => cab.Habilitada == habilitada);
            }
            return lista.ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cabania obj)
        {


        }

    }
}
