using System;
using static System.Console;

namespace classlib
{
    public class Coche 
    {
        private string marca;  
        private string modelo; 
        private string matricula; 
        private int bastidor;

        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public int Bastidor { get => bastidor; set => bastidor = value; }

        public Coche(string marc, string mod, string matr, int bast)
        {
            marca = marc; 
            modelo = mod; 
            matricula = matr; 
            bastidor = bast; 
        }
        public void visualizar()
        {
            WriteLine("DatosCoche: ");
            WriteLine($"marca: {marca}, modelo: {modelo}, matricula: {matricula}, bastidor{bastidor}");
        }
    }
}