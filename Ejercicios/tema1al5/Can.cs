using System;
using static System.Console;

namespace Ejercicio02
{
    public class Can:Mamifero 
    {   
        private int nivelLadrido; 
        public Can(string nombre, int edad, int numHuesos, int nivelLad):base(nombre, edad, numHuesos)
        { 
            this.nivelLadrido = nivelLad; 
        }

        public override string imprimirDatos() 
        {
            return "Nombre: " + nombre + ", edad: " + edad + ", numeroHuesos: " + numHuesos + " nivel ladridos: " + nivelLadrido; 
        }
    }
}