using System;
using static System.Console;

namespace classlib
{
    public class Operaciones
    {
        private int valorUno, valorDos; 

        public Operaciones() 
        {
            this.valorUno = 0;
            this.valorDos = 0;
        }

        public int ValorUno { get => valorUno; set => valorUno = value; }
        public int ValorDos { get => valorDos; set => valorDos = value; }
    
        public int suma()
        {
            return valorUno + valorDos;
        }

        public int resta()
        {
            return valorUno - ValorDos;
        }

        public int multiplicacion()
        {
            return valorUno * ValorDos; 
        }

        public int division()
        {
            int result = 0; 

            //MANDAR CODIGO ERROR SI VALORDOS == 0
            if(this.valorDos == 0) 
                return result;  
            else 
                return valorUno / valorDos; 
        }
    }
}    