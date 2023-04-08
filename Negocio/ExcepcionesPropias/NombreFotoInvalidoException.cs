using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class NombreFotoInvalidoException : Exception
    {
        public NombreFotoInvalidoException() { }
        public NombreFotoInvalidoException(string message) : base(message) { }
        public NombreFotoInvalidoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
