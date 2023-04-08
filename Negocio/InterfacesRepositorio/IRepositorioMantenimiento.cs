using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorioMantenimiento : IRepositorio<Mantenimiento>
    {
        public Mantenimiento FindByDate(DateTime d1, DateTime d2);
        public void Remove(Mantenimiento mantenimiento);
    }
}
