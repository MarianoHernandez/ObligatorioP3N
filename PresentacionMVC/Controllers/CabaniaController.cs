﻿using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesTipoCabaña;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;
using NuGet.Protocol;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{



    public class CabaniaController : Controller
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IListadoCabania ListadoCabania { get; set; }
        IBusquedaConFiltros BusquedaConFiltros { get; set; }
        IWebHostEnvironment Env { get; set; }
        IValidarSession ValidarLogin { get; set; }
        IObtenerMaxMinDescripcion SeleccionarMaxMin { get; set; }
        IFindByIdCabania encontrar { get; set; }

        public CabaniaController(IAltaCabania altaCabania,IObtenerMaxMinDescripcion seleccionarMaxMinDescripcion, IFindByIdCabania enco, IListadoTipoCabania listadoTipoCabania, IListadoCabania listadoCabania, IValidarSession validarSession, IWebHostEnvironment webHostEnvironment, IBusquedaConFiltros busquedaConFiltros)
        {
            AltaCabania = altaCabania;
            ListadoTipoCabania = listadoTipoCabania;
            ListadoCabania = listadoCabania;
            Env = webHostEnvironment;
            BusquedaConFiltros = busquedaConFiltros;
            ValidarLogin = validarSession;
            SeleccionarMaxMin = seleccionarMaxMinDescripcion;
            encontrar = enco;
        }


        // GET: CabaniaController
        public ActionResult Index()
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                IEnumerable<Cabania> cabanias = ListadoCabania.ListadoAllCabania();
                return View(cabanias);
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        // GET: CabaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabaniaController/Create
        public ActionResult Create()
        {

            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                AltaCabaniaViewModel vm = new AltaCabaniaViewModel();
                vm.TiposCabania = ListadoTipoCabania.ObtenerListado();
                return View(vm);
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        // POST: CabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaCabaniaViewModel VmAltaCabania)
        {
            try
            {
                VmAltaCabania.CabaniaNueva.Validar();

                string rutaWwwRoot = Env.WebRootPath;
                string rutaCarpeta = Path.Combine(rutaWwwRoot, "Imagenes");

                FileInfo file = new FileInfo(VmAltaCabania.Foto.FileName);
                string extension = file.Extension;

                string nomArchivo = VmAltaCabania.CabaniaNueva.Nombre.Replace(" ", "_") + extension;
                string rutaArchivo = Path.Combine(rutaCarpeta, nomArchivo);

                VmAltaCabania.CabaniaNueva.TipoCabaniaId = VmAltaCabania.IdTipoCabania;
                VmAltaCabania.CabaniaNueva.Foto = nomArchivo;



                AltaCabania.Alta(VmAltaCabania.CabaniaNueva);

                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                VmAltaCabania.Foto.CopyTo(fs);
                TempData["Bien"] = "Se creo la cabaña correctamente";
                return RedirectToAction(nameof(Index));
            }

            catch (NombreInvalidoException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
            catch (DescripcionInvalidaException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "Oops! Ocurrió un error inesperado";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CabaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                return View();
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
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
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                Cabania cab = encontrar.FindById(id);
                return View(cab);
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
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

        // GET: CabaniaController/Delete/5
        public ActionResult BusquedaFiltros()
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                BusquedaCabaniaViewModal BusquedaModal = new BusquedaCabaniaViewModal();
                BusquedaModal.TiposCabania = ListadoTipoCabania.ObtenerListado();
                return View(BusquedaModal);
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        // POST: CabaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BusquedaFiltros(string Nombre, int TipoID, int CantidadPersonas, bool Habilitada)
        {
            try
            {
                return RedirectToAction(nameof(MostrerFiltradas), new { Nombre, TipoID, CantidadPersonas, Habilitada });
            }
            catch
            {
                return View();
            }
        }

        // GET: CabaniaController/Delete/5
        public ActionResult MostrerFiltradas(string Nombre, int TipoID, int CantidadPersonas, bool Habilitada)
        {
            IEnumerable<Cabania> filtradas = BusquedaConFiltros.GetCabanias(Nombre, TipoID, CantidadPersonas, Habilitada);
            return View(filtradas);
        }

    }
}
