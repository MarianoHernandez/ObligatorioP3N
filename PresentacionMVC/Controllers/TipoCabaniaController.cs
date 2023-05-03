    using Aplicacion.AplicacionesTipoCabaña;
using Aplicacion.AplicacionesUsuario;
using Datos.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;
using Newtonsoft.Json;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PresentacionMVC.Controllers
{
    public class TipoCabaniaController : Controller
    {
        IAltaTipoCabania AltaTipoCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IFindByName FindByName { get; set; }
        IDeleteTipo DeleteTipo { get; set; }
        IUpdateTipo UpdateTipo { get; set; }
        IValidarSession ValidarLogin { get; set; }



        public TipoCabaniaController(IAltaTipoCabania altaTipoCabania,IValidarSession validarSession, IListadoTipoCabania listadoTipoCabania, IFindByName findByName, IDeleteTipo deleteTipo, IUpdateTipo updateTipo)
        {
            AltaTipoCabania = altaTipoCabania;
            ListadoTipoCabania = listadoTipoCabania;
            FindByName = findByName;
            DeleteTipo = deleteTipo;
            UpdateTipo = updateTipo;    
            ValidarLogin = validarSession;
        }


        // GET: TipoCabaniaController
        public ActionResult Index()
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                IEnumerable<TipoCabania> tipos = ListadoTipoCabania.ObtenerListado();
                return View(tipos);
            }catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        public ActionResult ShowOne(TipoCabania tipo)
        {
            return View(tipo);
        }
        
        public ActionResult FindOne(string accion) { 
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                return View(); 
            }catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindOne(string nombre, string accion)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                TipoCabania tipo = FindByName.FindOne(nombre);
                if(accion == "Eliminar") return RedirectToAction(nameof(Delete),tipo);
                if(accion == "Modificar") return RedirectToAction(nameof(Edit),tipo);
                return RedirectToAction(nameof(ShowOne),tipo);
            }
            catch (NombreInvalidoException ex)
            {
                TempData["Error"] = ex.Message;
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
                return View();
            }
        }

        // GET: TipoCabaniaController/Details/5
        public ActionResult Details(string nombre)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                TipoCabania tipo = FindByName.FindOne(nombre);
                return View(tipo);
            }catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(ex);
            }
        }

        // GET: TipoCabaniaController/Create
        public ActionResult Create()
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

        // POST: TipoCabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoCabania tipoCabania)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                tipoCabania.Validar();
                AltaTipoCabania.Alta(tipoCabania);
                return RedirectToAction(nameof(Index));
            }
            catch (NombreInvalidoException ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            catch (DescripcionInvalidaException ex)
            {
                TempData["Error"] = ex.Message;
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
                return View();
            }
        }

        // GET: TipoCabaniaController/Delete/5
        public ActionResult Delete(string nombre)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                TipoCabania tipo = FindByName.FindOne(nombre);
                return View(tipo);
            }
            catch (NoEncontradoException ex)
            {
                TempData["Error"] = ex.Message;
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
                return View();
            }
        }

        // POST: TipoCabaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoCabania tipo)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                DeleteTipo.DeleteTipo(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch (NoEncontradoException ex)
            {
                TempData["Error"] = ex.Message;
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
                return View();
            }
        }

        // GET: TipoCabaniaController/Edit/5
        public ActionResult Edit(string nombre)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                return View(FindByName.FindOne(nombre));
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        // POST: TipoCabaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string nombre, TipoCabania tipoEditado)
        {
            try
            {
                string userEmail = HttpContext.Session.GetString("user");
                ValidarLogin.Validar(userEmail);
                TipoCabania tipo = FindByName.FindOne(nombre);
                tipo.Costo = tipoEditado.Costo;
                tipo.Descripcion = tipoEditado.Descripcion;
                tipo.Validar();
                UpdateTipo.Update(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch (LoginIncorrectoException ex)
            {
                TempData["Error"] = "Es necesario iniciar sesion";
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

    }
}
