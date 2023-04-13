using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesTipoCabaña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;

using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{



    public class CabaniaController : Controller
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IListadoCabania ListadoCabania {get; set; }
        IWebHostEnvironment Env { get; set; }

        public CabaniaController(IAltaCabania altaCabania,IListadoTipoCabania listadoTipoCabania, IListadoCabania listadoCabania,IWebHostEnvironment webHostEnvironment)
        {
            AltaCabania = altaCabania;
            ListadoTipoCabania = listadoTipoCabania;
            ListadoCabania = listadoCabania;
            Env = webHostEnvironment;
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
            vm.TiposCabania = ListadoTipoCabania.ObtenerListado();
            return View(vm);
        }

        // POST: CabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaCabaniaViewModel VmAltaCabania)
        {
            try
            {
                string rutaWwwRoot = Env.WebRootPath;
                string rutaCarpeta = Path.Combine(rutaWwwRoot, "Imagenes");

                FileInfo file = new FileInfo(VmAltaCabania.Foto.FileName);
                string extension = file.Extension;

                string nomArchivo = VmAltaCabania.CabaniaNueva.Nombre.Replace(" ", "_") + extension;
                string rutaArchivo = Path.Combine(rutaCarpeta, nomArchivo);

                VmAltaCabania.CabaniaNueva.TipoCabaniaId = VmAltaCabania.IdTipoCabania;
                VmAltaCabania.CabaniaNueva.Foto = rutaArchivo;

                AltaCabania.Alta(VmAltaCabania.CabaniaNueva);

                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                VmAltaCabania.Foto.CopyTo(fs);

                return RedirectToAction(nameof(Index));
            }

            catch (NombreInvalidoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
    }
            catch (DescripcionInvalidaException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
}
            catch
            {
    ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
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
