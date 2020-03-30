using System;
using static System.Console;

namespace classlib
{
    public class Molusco:Animal 
    {   
        public string nombreConcha; 
        public Molusco(string nombre, int edad, string nombreConchaA):base(nombre, edad)
        { 
            this.nombreConcha = nombreConchaA; 
        }
        public override string imprimirDatos() 
        {
            return "Nombre: " + nombre + ", edad: " + edad + ", nombreConcha: " + nombreConcha; 
        }
    }
}