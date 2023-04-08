﻿    using Datos.Entity;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Datos.Repositorios
{
    public class RepositorioTipoCabania : IRepositorioTipoCabania
    {

        public LibreriaContext LibreriaContext { get; set; }
        public RepositorioTipoCabania(LibreriaContext libreriaContext) {
            LibreriaContext = libreriaContext;

        }
        public void Add(TipoCabania obj)
        {
            obj.Validar();
            LibreriaContext.TipoCabania.Add(obj);
            LibreriaContext.SaveChanges();
        }

        public IEnumerable<TipoCabania> FindAll()
        {
            return LibreriaContext.TipoCabania.ToList();
        }

        public TipoCabania FindByName(string nombre)
        {
            TipoCabania tipo = LibreriaContext.TipoCabania.SingleOrDefault(tipo => tipo.Nombre == nombre);
            if (tipo == null)
            {
                throw new NoEncontradoException("No se encontro el Tipo de Cabania");
            }
            return tipo;
        }

        public void Remove(TipoCabania tipo)
        {
            LibreriaContext.TipoCabania.Remove(tipo);
            LibreriaContext.SaveChanges();
        }
        public void Update(TipoCabania obj)
        {
            LibreriaContext.TipoCabania.Update(obj);
            LibreriaContext.SaveChanges();
        }

        #region Not Implemented

        public TipoCabania FindById(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
