using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesTipoCabaña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{



    public class CabaniaController : Controller
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IListadoCabania ListadoCabania {get; set; }


        public CabaniaController(IAltaCabania altaCabania,IListadoTipoCabania listadoTipoCabania, IListadoCabania listadoCabania)
        {
            AltaCabania = altaCabania;
            ListadoTipoCabania = listadoTipoCabania;
            ListadoCabania = listadoCabania;
        }


        // GET: CabaniaController
        public ActionResult Index()
        {
            //ListadoCabania.ListadoAllCabania();
            return View(ListadoCabania.ListadoAllCabania());
        }

        // GET: CabaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabaniaController/Create
        public ActionResult Create()
        {
            AltaCabaniaViewModel vm = new AltaCabaniaViewModel();
            vm.tiposCabania = ListadoTipoCabania.ObtenerListado();
            return View(vm);
        }

        // POST: CabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaCabaniaViewModel VmAltaCabania)
        {
            try
            {
                VmAltaCabania.cabaniaNueva.TipoCabaniaId = VmAltaCabania.idTipoCabania;
                AltaCabania.Alta(VmAltaCabania.cabaniaNueva);
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
