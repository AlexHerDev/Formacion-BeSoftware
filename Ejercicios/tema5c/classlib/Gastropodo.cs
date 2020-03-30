using System;
using static System.Console;

namespace classlib
{
    public class Gastropodo:Molusco 
    {   
        private string tipoAgua; 
        public Gastropodo(string nombre, int edad, string nombreConcha, string tipAgua):base(nombre, edad, nombreConcha)
        { 
            this.tipoAgua = tipAgua; 
        }

        public override string imprimirDatos() 
        {
            return "Nombre: " + nombre + ", edad: " + edad + ", nombreConcha: " + nombreConcha + "tipo de agua:" + tipoAgua; 
        }
    }
}