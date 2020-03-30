using System;
using static System.Console;

namespace classlib
{
    public class Cubo
    {
        private double superficie; 
        private double volumen;
        private double lado; 

        public Cubo(double ladoP)
        {
            this.lado = ladoP;
            superficie = 6 * ladoP * ladoP;
            volumen = superficie * ladoP; 
        } 

        public void imprimeDatos()
        {
            WriteLine($"Lado: {this.lado}, superficie: {this.superficie}, volumen: {this.volumen}");
        }
    }
}    