﻿using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entity;
using Negocio.Entidades;

namespace Datos.Repositorios
{
    public class RepositorioMantenimiento : IRepositorioMantenimiento
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioMantenimiento(LibreriaContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Mantenimiento FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Mantenimiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
