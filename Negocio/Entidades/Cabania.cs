
﻿using System;
﻿using Negocio.ExcepcionesPropias;
using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using Negocio.ExcepcionesPropias.Cabanias;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Entidades
{
    public class Cabania : IValidable
    {

        public int Id { get; set; }
        
        public TipoCabania TipoCabania { get; set; }
        public int TipoCabaniaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Habilitada { get; set; }
        public int Numero { get; set; }
        public int CantidadPersonas { get; set; }
        public string Foto { get; set; }
        private static int NumeroFoto { get; set; } = 1;

        public string SerializeNombreFoto(string nombreFoto) {
            
            this.Foto = nombreFoto.Replace(" ", "_");
            this.Foto += NumeroFoto;
            this.Foto += ".png";
            NumeroFoto++;
            return Foto;
        }


        public void Validar()
        {
            #region Validar Nombre
            string pattern = @"(?<=\s)[A-Za-z ]+(?=\s)";

            // Crea una instancia de Regex
            Regex regex = new Regex(pattern);

            // Busca coincidencias en la cadena de entrada
            Match match = regex.Match(Nombre);

            // Muestra los resultados
            if (match.Success)
            {
                throw new NombreInvalidoException("El nombre solo incluye caracteres alfabéticos y espacios embebidos, pero no al principio ni final");
            }
            if (string.IsNullOrEmpty(Nombre)) {

                throw new NombreInvalidoException("El nombre no puede ser nulo o vacío");

            }
            #endregion

            #region Validar Descripcion

            if (Descripcion.Length < 10 || Descripcion.Length > 500) {
                throw new DescripcionInvalidaException("La descripcion no puede tener menos de 10 caracteres ni mas de 500");
            }
            #endregion




        }
    }
}
