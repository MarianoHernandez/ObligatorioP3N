using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesTipoCabaña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.ExcepcionesPropias;

namespace PresentacionMVC.Controllers
{



    public class CabaniaController : Controller
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IListadoCabania ListadoCabania { get; set; }

        public CabaniaController(IAltaCabania altaCabania, IListadoTipoCabania listadoTipoCabania, IListadoCabania listadoCabania) {
            AltaCabania = altaCabania;
            ListadoTipoCabania = listadoTipoCabania;
            ListadoCabania = listadoCabania;
        }


        // GET: CabaniaController
        public ActionResult Index()
        {
            IEnumerable<Cabania> cabanias = ListadoCabania.ListadoCabanias();
            return View(cabanias);
        }

        // GET: CabaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabaniaController/Create
        public ActionResult Create()
        {
            ViewBag.Tipos = ListadoTipoCabania.ObtenerListado();
            return View();
        }

        // POST: CabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string TipoCabania, Cabania cabania)
        {
            try
            {
                AltaCabania.Alta(TipoCabania,cabania);
                ViewBag.MensajeOk = "Crado con exito";
                return RedirectToAction(nameof(Index));
            }
            catch (NombreInvalidoException ex)
            {
                ViewBag.MensajeError = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            catch (DescripcionInvalidaException ex)
            {
                ViewBag.MensajeError = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.MensajeError = "Oops! Ocurrió un error inesperado";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CabaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CabaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
