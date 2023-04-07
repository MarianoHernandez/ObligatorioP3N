using Aplicacion.AplicacionesTipoCabaña;
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

 

        public TipoCabaniaController(IAltaTipoCabania altaTipoCabania, IListadoTipoCabania listadoTipoCabania, IFindByName findByName, IDeleteTipo deleteTipo, IUpdateTipo updateTipo)
        {
            AltaTipoCabania = altaTipoCabania;
            ListadoTipoCabania = listadoTipoCabania;
            FindByName = findByName;
            DeleteTipo = deleteTipo;
            UpdateTipo = updateTipo;    
        }


        // GET: TipoCabaniaController
        public ActionResult Index()
        {
            IEnumerable<TipoCabania> tipos = ListadoTipoCabania.ObtenerListado();
            return View(tipos);
        }

        public ActionResult ShowOne(TipoCabania tipo)
        {
            return View(tipo);
        }
        
        public ActionResult FindOne() { 
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindOne(string nombre)
        {
            try
            {
                TipoCabania tipo = FindByName.FindOne(nombre);
                return RedirectToAction(nameof(ShowOne),tipo);
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
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
                return View();
            }
        }

        // GET: TipoCabaniaController/Details/5
        public ActionResult Details(string nombre)
        {
            TipoCabania tipo = FindByName.FindOne(nombre);
            return View(tipo);
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
                tipoCabania.Validar();
                AltaTipoCabania.Alta(tipoCabania);
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
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
                return View();
            }
        }

        // GET: TipoCabaniaController/Delete/5
        public ActionResult Delete(string nombre)
        {
            try
            {
                TipoCabania tipo = FindByName.FindOne(nombre);
                return View(tipo);
            }
            catch (NoEncontradoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
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
               
                DeleteTipo.DeleteTipo(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch (NoEncontradoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }

            
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Oops! Ocurrió un error inesperado";
                return View();
            }
        }

        // GET: TipoCabaniaController/Edit/5
        public ActionResult Edit(string nombre)
        {
            
            return View(FindByName.FindOne(nombre));
        }

        // POST: TipoCabaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string nombre, TipoCabania tipo)
        {
            try
            {
                UpdateTipo.Update(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
