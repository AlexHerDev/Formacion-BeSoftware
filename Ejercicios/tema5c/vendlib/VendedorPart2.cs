using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace vendLib
{
    public partial class Vendedor
    {
        public void imprimeDatosDetallados()
        {
            for(int i = 0; i<numMeses; i++)
            {
                WriteLine($" {(DiasAnio)i} , numero ventas: {ventas[i]}");                
            }   
        }
    }    
}        