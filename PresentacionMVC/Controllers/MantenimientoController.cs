using Aplicacion.AplicacionesMantenimientos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;

namespace PresentacionMVC.Controllers
{
    public class MantenimientoController : Controller
    {
        IAltaMantenimiento AltaMantenimiento { get; set; }

        public MantenimientoController(IAltaMantenimiento altaMantenimiento)
        {
            AltaMantenimiento = altaMantenimiento;
        }
 
        // GET: ManteniminetoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManteniminetoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManteniminetoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManteniminetoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mantenimiento mantenimiento)
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

        // GET: ManteniminetoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManteniminetoController/Edit/5
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

        // GET: ManteniminetoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManteniminetoController/Delete/5
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
