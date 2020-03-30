using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using classlib;
using vendLib;
using rastlib; 

namespace tema5c
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*
            Trabajador Currito = new Trabajador("Edelmiro", 66, "478606644-T", 50000);
            Currito.visualiza();

            WriteLine("");

            double ladoCubo = 3.43; 
            Cubo cubo = new Cubo(ladoCubo); 
            cubo.imprimeDatos();

            WriteLine("");        
            int valorUno = 2, valorDos = 3; 

            Operaciones operaciones = new Operaciones();
            operaciones.ValorUno = valorUno; 
            operaciones.ValorDos = valorDos; 
            WriteLine($"suma: {operaciones.suma()}, resta: {operaciones.resta()}, multiplicacion: {operaciones.multiplicacion()}, division: {operaciones.division()} ");
        
            WriteLine("");

            Gastropodo caracol = new Gastropodo("Caracolo", 20, "conchaDura", "agua dulce");
            Can perroLadrador = new Can("Toby", 5, 300, 10);        
            WriteLine(caracol.imprimirDatos());
            WriteLine(perroLadrador.imprimirDatos());

            WriteLine("");

            Libro libroo = new Libro("soy un libro", 34.45, 33);
            WriteLine(libroo.imprimirDato());  

            */

            //Sobrecarga de métodos: 
            /*
            Suma suma = new Suma(); 
            Resta resta = new Resta();
            Multiplicacion mul = new Multiplicacion();

            int resultS = suma.sumame(1,2);
            int resultSdos = suma.sumame(1,2,3);

            int resultR = resta.restame(1,2);
            int resultRdos = resta.restame(1,2,3);

            int resultM = mul.multiplicame(1,2);
            int resultMdos = mul.multiplicame(1,2,3);

            WriteLine($"Suma 1: {resultS}, suma2: {resultSdos}");
            WriteLine($"Resta 1: {resultR}, resta2: {resultRdos}");
            WriteLine($"Mult 1: {resultM}, mult2: {resultMdos}");

            */
            /*
            WriteLine($"Introduzca vendedores: ");
            
            double totalVentas = 0;     
            int salir = 2;

            do {
                Vendedor vend = new Vendedor(); 
                vend.tomaDatos();
                vend.imprimeDatosDetallados();
                totalVentas += vend.TotalVentas; 

                WriteLine($"Desea salir? (Pulse 1 para salir y 2 para continuar) ");
                string salirS = ReadLine();
                salir = Int32.Parse(salirS);
            }while (salir != 1);

            WriteLine($"El total de ventas ha sido: {totalVentas}");
            */
            //rastreador.getInfoFolder();
            
            long ticksFirstMethod = 0;

            
            var primerMethod = System.Diagnostics.Stopwatch.StartNew();
            
            Rastreador rastreador = new Rastreador();
            primerMethod.Stop();
            rastreador.getInfoPath();
            ticksFirstMethod = primerMethod.ElapsedTicks;
            
            WriteLine($"Total archivos: {rastreador.getNumFiles()}"); 
            WriteLine($"Total tam: {rastreador.getTam()}"); 
            WriteLine($"Tiempo en ticks:{ticksFirstMethod}");
        }    
    }
}
