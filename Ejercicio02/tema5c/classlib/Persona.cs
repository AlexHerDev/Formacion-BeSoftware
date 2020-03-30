using System;
using static System.Console;

namespace classlib
{
    public class Persona 
    {
        public string Nombre { get; set; }
        public int Edad { get; set; } 
        public string NIF { get; set; }
    
        void Cumpleanios()
        {
            Edad ++; 
        }

        public Persona(string nombre, int edad, string nif)
        {
            Nombre = nombre;
            Edad = edad; 
            NIF = nif;         
        }

        public virtual void visualiza()
        {
            WriteLine($"Los datos son, nombre: {Nombre}, edad: {Edad}, nif: {NIF}");
        }
    }
}