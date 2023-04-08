using Aplicacion.AplicacionesMantenimientos;
using Aplicacion.AplicacionesTipoCabaña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;

namespace PresentacionMVC.Controllers
{
    public class MantenimientoController : Controller
    {
        IAltaMantenimiento AltaMantenimiento { get; set; }
        IListadoMantenimiento ListadoMantenimiento { get; set; }
        IDeleteMantenimiento DeleteMantenimiento { get; set; }

        public MantenimientoController(IAltaMantenimiento altaMantenimiento, IListadoMantenimiento listadoMantenimiento, IDeleteMantenimiento deleteMantenimiento)
        {
            AltaMantenimiento = altaMantenimiento;
            ListadoMantenimiento = listadoMantenimiento;
            DeleteMantenimiento = deleteMantenimiento;
        }

        // GET: ManteniminetoController
        public ActionResult Index()
        {
            IEnumerable<Mantenimiento> mantenimiento = ListadoMantenimiento.ObtenerListado();
            return View(mantenimiento);
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
                mantenimiento.Validar();
                AltaMantenimiento.Alta(mantenimiento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrio un error";
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
        public ActionResult Delete(Mantenimiento mantenimiento)
        {
            try
            {
                DeleteMantenimiento.DeleteMantenimiento(mantenimiento);
                return RedirectToAction(nameof(Index));
            }
            catch(NoEncontradoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrio un error";
                return View();
            }
        }
    }
}
