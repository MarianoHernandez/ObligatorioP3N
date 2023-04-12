using Negocio.Entidades;

namespace PresentacionMVC.Models
{
    public class AltaCabaniaViewModel
    { 
        public Cabania cabaniaNueva { get; set; }
        public IEnumerable<TipoCabania> tiposCabania { get; set; }
        public int idTipoCabania { get;set; }
    }
}
