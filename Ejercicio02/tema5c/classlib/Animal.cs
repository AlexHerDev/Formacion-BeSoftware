using System;
using System.IO;
using static System.Console;

namespace classlib
{
    public class Animal
    {
        public string nombre;
        public int edad;  
        
        public Animal(string nom, int edad)
        {
            this.nombre = nom;
            this.edad = edad;  
        }

        public virtual string imprimirDatos() 
        {
            return "Nombre: " + nombre + " y edad: " + edad; 
        }
    }
}    