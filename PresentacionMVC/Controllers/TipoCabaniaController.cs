using Aplicacion.AplicacionesTipoCabaña;
using Datos.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;

namespace PresentacionMVC.Controllers
{
    public class TipoCabaniaController : Controller
    {
        IAltaTipoCabania AltaTipoCabania { get; set; }
        public TipoCabaniaController(IAltaTipoCabania altaTipoCabania)
        {
            AltaTipoCabania = altaTipoCabania;
        }


        // GET: TipoCabaniaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoCabaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoCabaniaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoCabania tipoCabania)
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

        // GET: TipoCabaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoCabaniaController/Edit/5
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

        // GET: TipoCabaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoCabaniaController/Delete/5
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
