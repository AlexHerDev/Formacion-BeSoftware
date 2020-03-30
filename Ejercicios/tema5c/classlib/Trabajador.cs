using System;
using System.IO;
using static System.Console;


namespace classlib
{
    class Trabajador:Persona {
        private int Sueldo;

        public Trabajador(string nombre, int edad, string NIF, int sueldo):base(nombre, edad, NIF)
        {
            Sueldo = sueldo; 
        }

        public override void visualiza()
        {
            WriteLine($"Los datos son, nombre: {Nombre}, edad: {Edad}, nif: {NIF}, y el sueldo: {Sueldo}");
        } 
    }
}