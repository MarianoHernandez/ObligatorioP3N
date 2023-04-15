using Negocio.Entidades;

namespace PresentacionMVC.Models
{
    public class AltaMantenimientoViewModel
    {
        public Mantenimiento MantenimientoNuevo { get; set; }
        public IEnumerable<Cabania> cabanias { get; set; }

        public int IdCabania { get; set; }
    }
}
