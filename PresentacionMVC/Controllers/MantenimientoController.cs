﻿using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesMantenimientos;
using Aplicacion.AplicacionesTipoCabaña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using PresentacionMVC.Models;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PresentacionMVC.Controllers
{
    public class MantenimientoController : Controller
    {
        IAltaMantenimiento AltaMantenimiento { get; set; }
        IListadoMantenimiento ListadoMantenimiento { get; set; }
        IDeleteMantenimiento DeleteMantenimiento { get; set; }

        IListadoCabania ListadoCabania { get; set; }
        IWebHostEnvironment Env { get; set; }

        public MantenimientoController(IAltaMantenimiento altaMantenimiento, IListadoMantenimiento listadoMantenimiento, IDeleteMantenimiento deleteMantenimiento
           , IWebHostEnvironment webHostEnvironment, IListadoCabania listadoCabania)
        {
            AltaMantenimiento = altaMantenimiento;
            ListadoMantenimiento = listadoMantenimiento;
            DeleteMantenimiento = deleteMantenimiento;
            Env = webHostEnvironment;
            ListadoCabania = listadoCabania;
        }

        // GET: ManteniminetoController
        public ActionResult Index()
        {

            return View(ListadoMantenimiento.ListadoAllMantenimientos());
        }

        // GET: ManteniminetoController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: ManteniminetoController/Create
        public ActionResult Create()
        {
            AltaMantenimientoViewModel vm = new AltaMantenimientoViewModel();
            vm.cabanias = ListadoCabania.ListadoAllCabania();
            return View(vm);
        }

        // POST: ManteniminetoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaMantenimientoViewModel VmMantenimiento)
        {

            try
            {
                VmMantenimiento.MantenimientoNuevo.CabaniaId = VmMantenimiento.IdCabania;

                AltaMantenimiento.Alta(VmMantenimiento.MantenimientoNuevo);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
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

        public ActionResult FindById()
        {
            return View();
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
            catch (NoEncontradoException ex)
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
