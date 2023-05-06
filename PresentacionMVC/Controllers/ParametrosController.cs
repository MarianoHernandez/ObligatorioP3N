using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{
    public class ParametrosController : Controller
    {
        // GET: ParametrosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParametrosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: ParametrosController/Create
        public ActionResult Create()
        {
            ConiguracionDescripcionModel configuracion = new ConiguracionDescripcionModel();
            return View(configuracion);
        }

        // POST: ParametrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parametro param)
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

        // GET: ParametrosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParametrosController/Edit/5
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

        // GET: ParametrosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParametrosController/Delete/5
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
