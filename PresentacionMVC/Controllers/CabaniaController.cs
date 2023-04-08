using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesTipoCabaña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;

namespace PresentacionMVC.Controllers
{



    public class CabaniaController : Controller
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }

        public CabaniaController(IAltaCabania altaCabania,IListadoTipoCabania listadoTipoCabania) {
            AltaCabania = altaCabania;
            ListadoTipoCabania = listadoTipoCabania;
        }


        // GET: CabaniaController
        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
