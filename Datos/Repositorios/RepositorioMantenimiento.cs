using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entity;
using Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Negocio.ExcepcionesPropias;

namespace Datos.Repositorios
{
    public class RepositorioMantenimiento : IRepositorioMantenimiento
    {

        public LibreriaContext Contexto { get; set; }
        public IRepositorioCabania Cabania { get; set; }
        public RepositorioMantenimiento(LibreriaContext ctx, IRepositorioCabania cabania)
        {
            Contexto = ctx;
            Cabania = cabania;
        }

        public void Add(Mantenimiento obj)
        {
            Cabania cab = Cabania.FindById(obj.CabaniaId);
            obj.cabania = cab;

            obj.Validar();
            Contexto.Mantenimiento.Add(obj);
            Contexto.SaveChanges();
            
        }

        public Mantenimiento FindByDate(DateTime d1, DateTime d2)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<Mantenimiento> FindAll()
        {            
            IEnumerable<Mantenimiento> mantenimiento = Contexto.Mantenimiento.ToList();
            return mantenimiento;
        }
        public void Remove(Mantenimiento mantenimiento)
        {
            Contexto.Mantenimiento.Remove(mantenimiento);
            Contexto.SaveChanges();
        }

        public Mantenimiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Mantenimiento obj)
        {
            Contexto.Mantenimiento.Update(obj);
            Contexto.SaveChanges();
        }

        void IRepositorio<Mantenimiento>.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
