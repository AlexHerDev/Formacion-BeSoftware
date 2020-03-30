using System;
using System.IO;
using static System.Console;

namespace Ejercicio02
{
    public abstract class Revista
    {
        protected double precioVenta;
        protected double costoFabrica;
        protected string titulo; 

        public Revista(string titulo, double precio, double costo)
        {
            this.titulo = titulo;
            this.costoFabrica = costo; 
            this.precioVenta = precio; 
        }

        public abstract string imprimirDato();
    }
}    