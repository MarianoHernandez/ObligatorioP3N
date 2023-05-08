using Datos.Entity;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class RepositorioParametros : IRepositorioParametros
    {

        public LibreriaContext LibreriaContext { get; set; }
        public RepositorioParametros(LibreriaContext libreriaContext)
        {
            LibreriaContext = libreriaContext;
        }

        public Parametro ObtenerParametrosCabania()
        {
            return LibreriaContext.Parametro.Where(par => par.Nombre == "Cabania").SingleOrDefault();
        }

        public Parametro ObtenerParametrosTipo()
        {
            throw new NotImplementedException();
        }

        public void Add(Parametro obj)
        {
            obj.Validar();
            LibreriaContext.Parametro.Add(obj);
            LibreriaContext.SaveChanges();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Parametro FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parametro> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Parametro obj)
        {
            throw new NotImplementedException();
        }
    }
}
