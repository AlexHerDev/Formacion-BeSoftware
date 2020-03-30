using System;
using static System.Console;

namespace classlib
{
    public class Mamifero:Animal 
    {   
        public int numHuesos; 
        public Mamifero(string nom, int edad, int numHuesosN):base(nom, edad)
        { 
            this.numHuesos = numHuesosN; 
        }

        public override string imprimirDatos() 
        {
            return "Nombre: " + nombre + ", edad: " + edad + ", numero de huesos: " + numHuesos; 
        }
          
    }
} 