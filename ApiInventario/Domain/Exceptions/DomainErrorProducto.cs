using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public static partial class DomainError
{
    public sealed class ProductoExisteException : DomainException
    {
        private ProductoExisteException(string mensaje) : base(mensaje) { }
       
        public static void Throw(string nombreProducto)
        {
            throw new ProductoExisteException($"El producto {nombreProducto} ya existe");
        }
    }
    
    public sealed class ProductoNoExisteException : DomainException
    {
        private ProductoNoExisteException(string mensaje) : base(mensaje) { }
       
        public static void Throw(string nombreProducto)
        {
            throw new ProductoNoExisteException($"El producto {nombreProducto} no existe");
        }
    }
}
