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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;

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

        public IEnumerable<Mantenimiento> FindByDateMantenimiento(DateTime d1, DateTime d2)
        {
            IEnumerable<Mantenimiento> mantenimientos = Contexto.Mantenimiento
                .Where(fec => fec.fecha.Date > d1 && fec.fecha.Date < d2)
                .ToList();
            return mantenimientos;
        }

        public IEnumerable<Mantenimiento> FindAll()
        {            
            IEnumerable<Mantenimiento> mantenimiento = Contexto.Mantenimiento
                .Include(man => man.cabania)
                .ThenInclude(cab => cab.TipoCabania)
                .ToList();
            return mantenimiento;
        }
        public void Remove(Mantenimiento mantenimiento)
        {
            Contexto.Mantenimiento.Remove(mantenimiento);
            Contexto.SaveChanges();
        }

        public void Update(Mantenimiento obj)
        {
            Contexto.Mantenimiento.Update(obj);
            Contexto.SaveChanges();
        }

        public Mantenimiento FindById(int id)
        {

            return Contexto.Mantenimiento.Find(id);
        }

        public IEnumerable<Mantenimiento> FindMantenimiento(DateTime Fecha1, DateTime Fecha2)
        {
            IEnumerable<Mantenimiento> lista = Contexto.Mantenimiento
                .Include(o => o.cabania)
                .Where(man => man.fecha > Fecha1 && man.fecha < Fecha2)
                .ToList();

            return lista;
        }
        void IRepositorio<Mantenimiento>.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
