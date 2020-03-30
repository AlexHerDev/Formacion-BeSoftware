using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace Ejercicio02
{
    public class Vendedor
    {
        private enum DiasAnio {
            Enero=0, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre, Noviembre, Diciembre
        };
        const int numMeses = 12; 
        private int[] ventas = new int[numMeses];
        private string nombre;
        private double totalVentas = 0;  
        
        public string Nombre { get => nombre; set => nombre = value; }
        public double TotalVentas { get => totalVentas; set => totalVentas = value; }

        public Vendedor()
        {}

        public void tomaDatos()
        {
           string ventasS; 
           WriteLine("Introduzca el nombre del vendedor: ");
           nombre = ReadLine();

           WriteLine($"Introduzca la cantidad de ventas para {(DiasAnio)0}: ");
           ventasS = ReadLine();

           int ventasI = Int32.Parse(ventasS);
           int tam = 12;
           double total = 0;  

           for(int i = 0; i<tam; i++)
           {
               ventas[i] = ventasI; 
               ventasI = new Random().Next(1, 10);
               ventasI *= ventas[i];   
               total += ventas[i]; 
           } 
           
           totalVentas = total;
        }    

        public void imprimeDatosDetallados()
        {
            for(int i = 0; i<numMeses; i++)
            {
                WriteLine($" {(DiasAnio)i} , numero ventas: {ventas[i]}");                
            }   
        }
    }    
}        