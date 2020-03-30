using System;
using static System.Console;

namespace classlib
{
    public class Libro:Revista 
    {
        public Libro(string titulo, double precio, double costo):base(titulo, precio, costo)
        { }
        public override string imprimirDato()
        {
            return "El libro se llama: " + titulo + " con precio " + precioVenta; 
        }        
    
    }
}    