using Negocio.Entidades;

namespace PresentacionMVC.Models
{
    public class AltaMantenimientoViewModel
    {
        public Mantenimiento MantenimientoNuevo { get; set; }
        public IEnumerable<Mantenimiento> mantenimiento { get; set; }
        public int IdMantenimiento { get; set; }
    }
}
