using Aplicacion.AplicacionParametros;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class AltaTipoCabania : IAltaTipoCabania
    {
        public IRepositorioTipoCabania Repositorio { get; set; }
         public IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }

        public AltaTipoCabania(IRepositorioTipoCabania repo, IObtenerMaxMinDescripcion obtenerMaxMin) { 
            Repositorio = repo;
            ObtenerMaxMin = obtenerMaxMin;
        }

        public void Alta(TipoCabania tipoCabania)
        {
            Parametro param = ObtenerMaxMin.ObtenerMaxMinDescripcion("Tipo");
            TipoCabania.largoMaximo = param.ValorMaximo;
            TipoCabania.largoMinimo = param.ValorMinimo;
            Repositorio.Add(tipoCabania);
        }
    }
}
