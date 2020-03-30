using System;
using static System.Console;

namespace classlib
{
    public class Multiplicacion 
    {   
        public Multiplicacion()
        {}
        public int multiplicame(int num1, int num2)
        {
            return num1 * num2;
        }

        public int multiplicame(int num1, int num2, int num3)
        {
            return num1 * num2 * num3;
        }
    }
}   