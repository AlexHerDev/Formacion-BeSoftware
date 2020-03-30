using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio02
{
    enum Color {Yellow = 3, Blue, Green};
    enum DiasSemana {Lunes=1, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo};
   
   struct Pelicula{
       public string nombre;
       public DateTime fecha; 
       public double tamanio;
   }

   struct TipoPersona{
       public string nombre;
       public char inicial;
       public int edad; 
       public float Altura; 
    }
   struct cancionMP3{
       public string artista;
       public string titulo;
       public uint duracionSecs;
       public float tamanio;  
    }
    
    class Program
    {
        /*************************************************QUICKSORT*****************************************************/
        public static void quicksort(cancionMP3[] input, int low, int high)
        {
            int pivot_loc = 0;

            if (low < high)
            {
                pivot_loc = partition(input, low, high);
                quicksort(input, low, pivot_loc - 1);
                quicksort(input, pivot_loc + 1, high);
            }
        }
        public static void leeFichero(string nomFiche)
        {
            StreamReader fi; 
            string li; 
                
            try
            {
                fi = File.OpenText(nomFiche);
                do
                {
                    li = fi.ReadLine();
                    if (li != null)
                    {
                        WriteLine(li);
                    }               
                    } while (li != null);
                        fi.Close();  
                }                
            catch (Exception exp)
            {
                WriteLine("Ha habido un error {0}", exp.Message);            
            }
        }
        public static int partition(cancionMP3[] input, int low, int high)
        {
            uint pivot = input[high].duracionSecs;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (input[j].duracionSecs <= pivot)
                {
                    i++;
                    swap(input, i, j);
                }
            }
            swap(input, i + 1, high);
        return i + 1;
        }

        public static void swap(cancionMP3[] ar, int a, int b)
        {
            cancionMP3 temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
        }
        
        /*************************************************BINARY SEARCH*****************************************************/
        public static cancionMP3 binarySearch(cancionMP3 [] input, uint key, int min, int max)
        {
            cancionMP3 nulo; 
            nulo.artista = "Nulo";
            nulo.titulo = "Nulo";
            nulo.tamanio = 0; 
            nulo.duracionSecs = 0; 

            if (min > max)  
            {  
                return nulo;//Devolver No Encontrado    
            }  
            else  
            {  
                int mid = (min+max)/2;  
                if (key > input[mid].duracionSecs)  
                {  
                    //return ++mid; 
                    return input[mid]; 
                }  
                else if (key < input[mid].duracionSecs)  
                {  
                    return binarySearch(input, key, min, mid - 1);  
                }  
                else  
                {  
                    return binarySearch(input, key, mid + 1, max);  
                }  
            }
        }

        /*******************************************************************************************************************/
        
        ///<param name="num">El número de películas a visualizar.!-- Si es igual 0, se mostrarán todas.</param> 
        public static void visualizaPelicula(List<Pelicula> listaPelis, int num)
        {
            if(num == 0)
            {
                num = listaPelis.Count();
            }

            foreach(var Pelicula in listaPelis.Select((value, index) => new { value, index })) 
            {
                if(Pelicula.index <= num)
                {
                    string lineaAescribir = Pelicula.value.fecha +"  "+ Pelicula.value.tamanio +"  "+ Pelicula.value.nombre;     
                    WriteLine(lineaAescribir);            
                }
                else
                {
                    break;
                }     
            }         
        }

        public static bool grabaPeliculasEnArchivo(List<Pelicula> listaPelis, string nombreFichero)
        {
            StreamWriter fichero; 
            fichero = File.CreateText(nombreFichero);
                    
            foreach(var Pelicula in listaPelis) 
            {
                string lineaAescribir = Pelicula.fecha +"  "+ Pelicula.tamanio +"  "+ Pelicula.nombre;     
                fichero.WriteLine(lineaAescribir);    
            }

            fichero.Close(); 

            return true;        
        }           

        public static long TiempoEmpleado(DateTime horaInicial, DateTime horaFinal)
        {
            long ticksIniciales = horaInicial.Ticks;
            long ticksFinales = horaInicial.Ticks;

            return (ticksFinales - ticksIniciales);
        }

        public static int sumaSimple(int num, int num1)
        {
            return num + num1; 
        }

        public static int multiplicaSimple(int num, int num1)
        {
            return num * num1; 
        }

        public static double divideSimple(double num, double num1)
        {
            return num/num1;
        }

        public static double restoSimple(double numD, double numD2)
        {
            return numD%numD2;
        }

        public static void ponFechaCentrada(int x_inicial, int y_inicial)
        {
            DateTime fecha = DateTime.Now;

            //Se debería de calcular las coordenadas exactas para pintar 
            //justo en la mitad. 
            Console.SetCursorPosition(30 + 9, 22);
            WriteLine($"{fecha}");

            Console.SetCursorPosition(0,0);
        }
        public static void rellenaDatos(int x_inicial, int y_inicial, string [] datos)
        {
            int coord_x_cuadro_datos = 4;
            int coord_y_cuadro_datos = 9;

            int x_inicial_p = x_inicial + coord_x_cuadro_datos; 
            int y_inicial_p = y_inicial + coord_y_cuadro_datos; 

            int tam = datos.Length; 

            for(int i = 0; i<tam; i++)
            {
                Console.SetCursorPosition(x_inicial_p, y_inicial_p + i);
                WriteLine($"{datos[i]}");    
            }

            Console.SetCursorPosition(0,0);          
        }

        public static void dibujaPresentacion(int alto, int ancho, int x_inicial, int y_inicial)
        {
            int altoRectanguloCabezera = alto/6;
            int anchoSubCuadros = ancho - 6;             
            int x_inicial_cab = x_inicial + 3; 
            int y_inicial_cab = y_inicial + 1;
            int x_inicial_datos = x_inicial + 3; 
            int y_inicial_datos = y_inicial + 1 + altoRectanguloCabezera + 2; 
            
            CustomConsole.RectangleFromTop(ancho, alto, x_inicial, y_inicial, ConsoleColor.Cyan, useDoubleLines: true);
            CustomConsole.RectangleFromTop(anchoSubCuadros, altoRectanguloCabezera, x_inicial_cab, y_inicial_cab, ConsoleColor.Cyan, useDoubleLines: true);
            CustomConsole.RectangleFromTop(anchoSubCuadros, alto - altoRectanguloCabezera - 4, x_inicial_datos, y_inicial_datos, ConsoleColor.Cyan, useDoubleLines: true);        
        }
        public static void pintaCabezera(string nombreProyecto, string nombreDev, int x_inicial, int y_inicial)
        {
            System.DateTime fecha = DateTime.Now;
            
            int x_inicial_p = x_inicial + 4; 
            int y_inicial_p = y_inicial + 2; 
            
            var colorTinta = Console.ForegroundColor;

            Console.SetCursorPosition(x_inicial_p, y_inicial_p);
            WriteLine($"Fecha: {fecha.Day}/{fecha.Month}/{fecha.Year}");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x_inicial_p, y_inicial_p + 2);
            WriteLine($"NombreProyecto: {nombreProyecto}");
            Console.ForegroundColor = colorTinta;

            Console.SetCursorPosition(x_inicial_p, y_inicial_p + 4);
            WriteLine($"Dev: {nombreDev}");
            
            Console.SetCursorPosition(x_inicial_p + 68, y_inicial_p);
            WriteLine($"Hora: {fecha.Hour}:{fecha.Minute}:{fecha.Second}");
            
            Console.SetCursorPosition(0,0);
        }
        public static bool validaFormatoFechaEntrada(string fechaIni)
        {
            const int tamEntrada = 10;
            bool validado = true;

            if(fechaIni.Length != tamEntrada) 
            {
                validado = false; 
            }

            return validado;     
        }        
        public static void muestraFechas(DateTime [] fechasMostrar)
        {
            int tam = fechasMostrar.Length;

            for(int i = 0; i<tam; i++) 
            {
                WriteLine($"Fecha num {i+1}: {fechasMostrar[i]}");
            }       
        }
        
        public static bool compruebaFinDeSemana(DateTime fecha)
        {
            bool esFinDeSemana = false;

            if(fecha.DayOfWeek.ToString() == "Friday" || fecha.DayOfWeek.ToString() == "Saturday" || fecha.DayOfWeek.ToString() == "Sunday")
            {
                esFinDeSemana = true;   
            }

            return esFinDeSemana;
        }
        public static bool compruebaExistente(DateTime [] arrayFechas, DateTime fecha)
        {
            bool existe = false;
            int tam = arrayFechas.Length;
        
            for(int i=0; i<tam; i++)
            {
                if(fecha == arrayFechas[i]) 
                {
                    existe = true; 
                    break;
                }                       
            }

            return existe;       
        }
        
        public static Func<DateTime> diaRandom(DateTime fechaIni, DateTime fechaFin)
        {
            Random gen = new Random(); 
            int rango = ((TimeSpan)(fechaFin - fechaIni)).Days; 
            
            return () => fechaIni.AddDays(gen.Next(rango));
        }

        public static bool validaNumCuenta(string numCuenta)
        {
           string[] splited = numCuenta.Split('-');
            if (splited.Length != 4) splited = numCuenta.Split(' ');
            for(int i=0; i< splited.Length; i++)
            {
                if(splited[i].Length!=4) return false;
                     for(int j=0; j<4; j++)
                         if(splited[i][j]>57 || splited[i][j]<48) return false;
            }
            return true;
        }
        
        public static bool esDiaSemana(string dia)
        {
            bool esta = false;
            
            if(dia=="Lunes" || dia=="Martes" || dia=="Miércoles" || dia=="Jueves" || dia=="Viernes"
            || dia=="Sabado" || dia=="Domingo")
                esta = true;
            return esta; 
        } 
        public static bool esFinDeSemana(string dia)
        {
            bool es = false;
            
            if(dia=="Viernes" || dia=="Sabado" || dia=="Domingo")
                es = true;
            return es;
        }
        static void Main(string[] args)
        {
            /*
            double anchura = 2400.45;
            string nombre = "Mesa de trabajo";  
        
            Console.WriteLine($"{nombre} es {anchura} mm");
            Console.WriteLine($" int emplea {sizeof(int)} bytes");
            Console.WriteLine($"double emplea {sizeof(double)} bytes y puede almacenar numeros desde {double.MinValue:N0} a {double.MaxValue:N0} .");
            */

            // Uso de arriba para definir paths o string con /

            /*        
            Console.WriteLine("Introduce tu nombre");
            string entradaTeclado = Console.ReadLine(); 
            Console.WriteLine($"La entrada es: {entradaTeclado}");
            */

            /*
            Console.WriteLine("Presione una tecla");
            ConsoleKeyInfo tecla = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Tecla: {0}, Caracter: {1}, Modificador: {2}", arg0:tecla.Key, arg1:tecla.KeyChar, arg2:tecla.Modifiers);    
            */

            // La forma mas segura de mostrar variables a traves de write line es utilizando $

            //Sobre el tipo de estructura "Enum". Se inicializa el primer valor y los demás son +1. 
            /*
            Console.WriteLine(
                "General \t {0:G}\n" +
                "Defecto \t {0} (default = 'G')\n" +
                "Flags \t {0:F} (Flags or integer)\n" +
                "Numero Decimal \t {0:D}\n" +
                "Numero hexadecimal \t {0:X}\n", Color.Green
            );
            */

            //Formatos de salida 
            /*
            Console.Clear();
            Console.WriteLine(
                "\n\a \\a=Timbre \r \\r=Otra linea. \\n=nueva linea"        
            );
            Console.WriteLine(
                "\n\t \\t=texto tabulado"
            );
            Console.WriteLine(
                "\n \'texto entrecomillado v1\'"
            );
            Console.WriteLine(
                "\n \"Texto entrecomillado v2\""    
            );
            */

            //Modficaciones del terminal:
            /*
            Console.windowWidth 
            Console.windowHeight
            Console.setWindowSize
            */         

            //Tambien se puede elegir el sitio en concreto donde se mostraran los datos en consola 
            //y el cursor. 

            //Para parsear, en este caso de string a numero: int numero2 = Int32.Parse(unString) + 10; 

            //El tipo de dato object admite cualquier tipo de dato. Evitar su uso, solo en casos muy 
            //concreto

            //MATRICES: 
            /*
            int [,] matrix; 
            matrix = new int[4,1];

            matrix[0,0] = 23;
            matrix[1,0] = 33;
            matrix[2,0] = 4;
            matrix[3,0] = 1;

            //Tipos de nulos: 
            int? PodriaSerNulo = null; 
            */
            //Trabajar con argumentos  
            /*
            Clear();
            WriteLine($"Existen {args.Length} argumentos");
            foreach(string arg in args)
            {
                WriteLine(arg);
            }     
            */

            //EJERCICIO 1: 
            /*
            int valor = 3;
            int [] arrayNum; 
            arrayNum = new int[valor];
            int a = 0, b = 1, c = 2;

            arrayNum[0] = a;
            arrayNum[1] = b;
            arrayNum[2] = c;

            int suma = 0;
            int tamArr = arrayNum.Length;

            for(int i = 0; i<tamArr; i++)
            {
                suma += arrayNum[i];
            }

            Clear();
            WriteLine($"{suma}");
            */

            //EJERCICIO 2: 
            /*
            Clear();
            
            Console.WriteLine("Introduce tu nombre y ciudad por favor");
            string nombre = Console.ReadLine(); 
            string ciudad = Console.ReadLine();
            
            Console.WriteLine($"Gracias {nombre} de {ciudad}");
            */

            //EJERCICIO 3:
            //Clear();
            /*    
            Console.WriteLine("Introduce tu nombre y edad por favor");
            string nombre = Console.ReadLine(); 
            var edad = Console.ReadLine();
            
            Console.WriteLine($"Gracias {nombre} tienes {edad} años");
            */    
            //EJERCICIO 4:
            /*
            Console.WriteLine("Introduce dos numeros: ");
            string num1 = ReadLine(); 
            string num2 = ReadLine();

            int num_1 = Int32.Parse(num1);
            int num_2 = Int32.Parse(num2);
            int mayor = 0; 
            
            if (num_1 > num_2) mayor = num_1;
            else 
                if(num_1 < num_2) mayor = num_2;
                else mayor = -1;    
        
            if(mayor == -1) Console.WriteLine("Los numeros son iguales");
            else Console.WriteLine($"El mayor es {mayor}");    
            */

            //EJERCICIO 5: 
            /*
            WriteLine("Introduce un dia de la semana: ");
            string diaSemana = ReadLine();

            if(esDiaSemana(diaSemana))
                if(esFinDeSemana(diaSemana))
                    WriteLine("Es fin de semana"); 
                else 
                    WriteLine("No es fin de semana");       
            else  
                WriteLine("Dia de la semana incorrecto");
            */

            //Ejercicio 6 y 7:
            /*
            double precio = -1.0;
            while( precio < 0.0)
            {
                Clear();
                SetCursorPosition(10,20);
                WriteLine("Introduce el precio del producto deseado: ");
                string precioPre = ReadLine(); 
                precio = double.Parse(precioPre);
            }
            
            bool stop = false; 
            int formaPago = 0; 
            while(!stop) 
            {
                Clear();
                SetCursorPosition(10,20);
                WriteLine("Introduce la forma de pago, pulse 1 para tarjeta o 2 si es efectivo: ");        
                string formaPagoPre = ReadLine(); 
                formaPago = Int32.Parse(formaPagoPre);
                if(formaPago == 1 || formaPago==2) 
                    stop = true; 
                else 
                    stop = false;     
            }
            
            if(formaPago == 2) 
            {  
                bool cuentaCorrecta = false; 

                while(cuentaCorrecta != true)
                {
                    Clear();
                    SetCursorPosition(10,20);
                    WriteLine("Introduce el numero de cuenta: ");  
                    string numCuentaPre = ReadLine();  
                    cuentaCorrecta = validaNumCuenta(numCuentaPre);        
                }
            }
            */  
            
            //EJERCICIO 8 y 9: 
            /*
            int[] pares = new int[50];
            int[] divisibles = new int[33];    

            int contP = 0; 
            int contD = 0; 
            for(int i = 1; i<=100; i++) 
            {
                if(i%2 == 0) 
                { //WriteLine($"PAR: {i}");    
                    pares[contP] = i;
                    contP ++;
                }    
                if(i%3 == 0) 
                {//WriteLine($"DIVISIBLE ENTRE 3: {i}");
                    divisibles[contD] = i;
                    contD ++;
                }
            }    

            WriteLine("PARES");
            SetCursorPosition(0,20);
            WriteLine("DIVISIBLES ENTRE 3");
            for(int i = 0; i<pares.Length; i++)
            {
                WriteLine($"{pares[i]}");
            }

            // for(int i = 0; i<divisibles.Length; i++)
            // {
            //     SetCursorPosition(i,20);
            //     WriteLine($"{divisibles[i]}");
            // }
            */
            
            //EJERCICIO 10 Y 11:
            /*
            double sumaUltimos = 0;
            double sumaPrimeros = 0;  
            int index = 0; 
            foreach(string arg in args)
            { 
                if(index <= 2) {
                    double argInt = double.Parse(arg); 
                    sumaUltimos += argInt; 
                } else {
                    double argInt = double.Parse(arg); 
                    sumaPrimeros += argInt;         
                }
                index ++; 
            }
            double resultado = sumaUltimos / sumaPrimeros;

            WriteLine($"Resultado: {resultado}");   
            */

            //EJERCICIO 12:
            /*
            int empieza = 5437, tamMatrix = 20;
            int[] matrix = new int[tamMatrix];
            int cont = 0; 
            int suma = 0; 
            int producto = 1; 
            int totalIteracciones = empieza + matrix.Length; // ESTO ARREGLAR

            for(int i = empieza; i<totalIteracciones; i++) 
            {
                if(i%2 != 0) 
                {
                    WriteLine($"Matrix: {i}");
                    matrix[cont] = i; 

                    suma += matrix[cont];
                    producto *= matrix[cont];
                
                    cont ++;
                }    
            }
            
            //SET COLORS 
            WriteLine($"Suma: {suma}");
            WriteLine($"Producto: {producto}");   
            */

            //ESTRUCTURAS DE TIEMPO: DATETIME
            /*
            DateTime fecha = new DateTime(2020,03,09);
            WriteLine ($"{fecha}");

            DateTime fechaHoy = DateTime.Now;
            DateTime fechaAyer = DateTime.Today;
            DateTime fechaManiana = DateTime.Today.AddDays(1); 

            WriteLine ($"{fechaHoy.AddDays(-1)}");
            WriteLine ($"{fechaAyer.AddDays(1)}");

            int numeroDeDias = DateTime.DaysInMonth(2020, 2);
            WriteLine ($"El numero de dias de febrero de 2020 son: {numeroDeDias}");

            string horaActual = DateTime.Now.ToString("HH:MM:ss zzz dddd");
            WriteLine ($"{horaActual}");

            //int diaHoy = (int)System.DateTime.Now.DayOfMonth;
            DateTime diaHoy = DateTime.Now;

            WriteLine ($"Día actual: {diaHoy.Day}");
            */
           
            //ESTRUCTURAS CONDICIONALES: 
            /*
            var numeroRand = (new Random()).Next(1,2);
            WriteLine($"Numero aleatorio: {numeroRand}");
            
            //PARA PAUSAR EL SISTEMA: System.Threading.Thread.Sleep(20);
            const int valor = 5;
            double [] arrayNum; 
            arrayNum = new double[valor];

            double producto = 1; 

            WriteLine("Numeros aleatorios:");
            for(int i=0; i<valor; i++)
            {
                arrayNum[i] = numeroRand = (new Random()).Next(1,501);    
                producto *= arrayNum[i];
                WriteLine($"{arrayNum[i]}");    
            } 

            WriteLine($"Producto: {producto}"); 
            */

            //EJERCICIO 2: (tema 3)
            /*
            const int valor = 10;
            double [] arrayNum; 
            arrayNum = new double[valor];

            double producto = 1; 

            WriteLine("Numeros aleatorios:");
            for(int i=0; i<valor; i++)
            {
                arrayNum[i] = (new Random()).Next(-45738, 96431);    
                producto *= arrayNum[i];
                Write($"{arrayNum[i]} ");    
            } 
            WriteLine();
            WriteLine($"Producto: {producto:N0}");
            */
            /*
            string contrasenia = string.Empty;
            while(contrasenia != "A")
            {
                Write("Escribe pass: ");
                contrasenia = ReadLine();
            }       
            WriteLine("Lo has conseguido");
            */
    
            //Operadores Unarios:
            /*
            uint a = 5;
            var b = -a; 
            WriteLine(b);
            WriteLine(b.GetType());
            */

            //CONVERSIONES:     
            //IMPLICITA: 
            /*
                int a = 10; 
                double b = a; 
                WriteLine(b);
                WriteLine(b.GetType());

                double c = 9.8;
                int d = c; 
                WriteLine(d); // FALLO NO SE PUEDE HACER ESTE TIPO DE CONVERSIÓN DE DOUBLE A INT 
            */
            //EXPLICITA: 
            /*
                double g = 9.8; 
                //g = Math.Floor(g);
                int h = Convert.ToInt32(g);

                WriteLine($"g es {g} y h es {h}");
            */  
            //Cualquiera strings: 
            /*    
                int num = 32; 
                WriteLine(num.ToString());

                bool booleano = true; 
                WriteLine(booleano.ToString());
                
                DateTime ahora = DateTime.Now;
                WriteLine(ahora.ToString());

                object yo = new object();
                WriteLine(yo.ToString());
            */
            //De strings a numeros:
            /*
            int edad = int.Parse("27");
            DateTime cumpleanios = DateTime.Parse("4 de julio de 1980");

            WriteLine($"Naci hace {edad} anios");
            WriteLine($"Mi cumpleanios es: {cumpleanios}");
            */
            //Excepciones y errores (TRY, CATCH): 
            /*
            Write("INTRODUCE EDAD: ");
            string edadIntroducida = ReadLine();
            try
            {
                int edad = int.Parse(edadIntroducida);
                WriteLine($"Tienes {edad} anios");
            }
            catch (FormatException)
            {
                WriteLine("No es un formato valido"); //ESTE SERÍA EL MENSAJE DE LA EXCEPCION PARA FORMATEXCEPTION
            }
            catch (OverflowException)
            {
                WriteLine("Excepcion de rango"); //ESTE SERÍA EL MENSAJE DE LA EXCEPCION PARA FORMATEXCEPTION
            }
            catch (Exception ex)
            {
                WriteLine("Ha sucedido un error"); //MANDAR EXCEPCION
                WriteLine($"{ex.GetType()} dice que {ex.Message}");
            }
            */

            //EJERCICIO 1: 
            /*
            DateTime ini = new DateTime(2020,05,30);
            DateTime fin = new DateTime(2030,05,30); 
            
            TimeSpan dif = fin - ini; 
            WriteLine ($"{dif.ToString(@"dd\d\ hh\h\ mm\m\ ")} ");
            */
            
            //EJERCICIO 2: RELOJ 
            /*
            WriteLine("Introduce una hora para programar la alarma: ");
            string hora = ReadLine();
            WriteLine("Introduce los minutos para programar la alarma: ");
            string minutos = ReadLine();
            WriteLine("Introduce los segundos para programar la alarma: ");
            string segundos = ReadLine();
        
            string horaIntroducida = hora + ":" + minutos + ":" + segundos;

            while(true)
            {
                String hourMinute= DateTime.Now.ToString("HH:mm:ss");
                if(horaIntroducida == hourMinute)
                {
                    Clear();
                    SetCursorPosition(10,30);
                    WriteLine ($"{hourMinute}");
                    Console.Beep();
                }
                Clear();
                SetCursorPosition(10,10);
                WriteLine ($"{hourMinute}");
                System.Threading.Thread.Sleep(1000);       
            }
            */
            //EJERCICIO 4: Dia de nacimiento 
            /*
            WriteLine("Introduce tu dia de nacimiento: ");
            string dia = ReadLine();
            WriteLine("Introduce tu mes de nacimiento: ");
            string mes = ReadLine();
            WriteLine("Introduce tu anio de nacimiento: ");
            string anio = ReadLine();
            
            int diaE = Int32.Parse(dia);
            int mesE = Int32.Parse(mes);
            int anioE = Int32.Parse(anio);

            DateTime fechaNac = new DateTime(anioE, mesE, diaE);

            WriteLine($"Naciste en: {fechaNac.DayOfWeek}");
            */
            /*
            WriteLine("Introduce numero de días: ");
            string numDiasMes = ReadLine();
            
            WriteLine("Introduce numero de día de la semana del día 1: ");
            string diaSemana = ReadLine();

            int numDiasMesE = Int32.Parse(numDiasMes);
            int diaSemanaE = Int32.Parse(diaSemana);

            int [] meses; 

            switch(numDiasMesE)
            {
                case 28: 
                case 29: 
                    meses = new int[1];
                    calculaCombinaciones(meses, diaSemanaE);
                break;

                case 30: //4, 6, 9, 11
                    meses = new int[4];
                    meses[0] = 4;
                    meses[1] = 6;
                    meses[2] = 9;
                    meses[3] = 11;  
                    calculaCombinaciones(meses, diaSemanaE);  
                break; 

                case 31: //1, 3, 7, 8, 10, 12  
                    meses = new int[6];
                    meses[0] = 1;
                    meses[1] = 3;
                    meses[2] = 7;
                    meses[3] = 8;
                    meses[4] = 10; 
                    meses[5] = 12;     
                    calculaCombinaciones(meses, diaSemanaE);
                break;     
            }
            */ 

            //EJERCICIOS PARANOIC MODE  
            /*
            EJERCICIO A: 
            10 días aleatorios entre el 12/03/2020 y el 12/05/2020. NO PUEDEN SER VIERNES, SÁBADO NI DOMINGO!
            */
            String eleccion;
            int modo = 0; 
            do
            {   
                WriteLine("Introduzca: ");
                WriteLine("----> 1 <---- para los ejercicios A,C y D");
                WriteLine("----> 2 <---- para el B");
                WriteLine("----> 3 <---- para el 4B");
                WriteLine("----> 4 <---- para el 4B (mitad)");
                WriteLine("----> 5 <---- para el 4B (ejer. de tiempos)");
                WriteLine("----> 6 <---- para el 4D (Ficheros-Introdución)");
                WriteLine("----> 7 <---- para el 4D (Ficheros-Ejercicio)");
                WriteLine("----> 8 <---- para el 4D (Binario)");
                WriteLine("----> 9 <---- para CLASES");
                WriteLine("----> 10 <---- para systemEnv");
                eleccion = ReadLine();

                modo = Int32.Parse(eleccion);
                WriteLine($"modo: {modo}");
            }
            /*
            while(
                modo != 1 && 
                modo != 2 && 
                modo != 3 && 
                modo != 4 && 
                modo != 5 &&
                modo != 6 &&
                modo != 7 &&
                modo != 8
                );
            */
            while(
                modo != 7 && 
                modo != 8 &&
                modo != 9 &&
                modo != 10 
            );    
            Clear();

            switch (modo)
            {
                case 1:
                    string fechaIni;
                    string fechaFin;

                    do 
                    {
                        WriteLine("Introduce fecha inicial con formato dd-MM-yyyy: ");
                        fechaIni = ReadLine();
                    }
                    while(!validaFormatoFechaEntrada(fechaIni));

                    do{
                        WriteLine("Introduce fecha final con formato dd-MM-yyyy: ");
                        fechaFin = ReadLine();
                    }    
                    while(!validaFormatoFechaEntrada(fechaFin));
                
                    //OJO!!!: Se podría quedar en un bucle infinito si no existen tantos días que cumplan las 
                    //restricciones dadas.
                    WriteLine("Introduce cantidad de dias: ");
                    string Fechas = ReadLine();

                    int numFechas = Int32.Parse(Fechas);

                    DateTime fechaIniD = DateTime.ParseExact($"{fechaIni}", "dd-MM-yyyy",
                                            System.Globalization.CultureInfo.InvariantCulture);
                    DateTime fechaFinD = DateTime.ParseExact($"{fechaFin}", "dd-MM-yyyy",
                                            System.Globalization.CultureInfo.InvariantCulture);
                                            
                    var dameFechaRandom = diaRandom(fechaIniD,fechaFinD);  
                    DateTime randomDate;
                
                    DateTime [] arrayFechas; 
                    arrayFechas = new DateTime[numFechas];

                    var tiempoA = System.Diagnostics.Stopwatch.StartNew();
                    
                    for(int i = 0; i<numFechas; i++)
                    {
                        randomDate = dameFechaRandom();
                        while(compruebaExistente(arrayFechas, randomDate) )
                        {
                            randomDate = dameFechaRandom();    
                        }
                        
                        arrayFechas[i] = randomDate;             
                    }

                    tiempoA.Stop();
                    
                    muestraFechas(arrayFechas);  

                    /*
                    EJERCICIO C: 
                    Localiza los 10 últimos domingos que han sido 1 de mayo
                    */
                    
                    WriteLine("");
                    WriteLine("Localizando los 10 últimos domingos que han sido 1 de mayo");
                    int cantidad = 10; 
                    DateTime fechaHoy = DateTime.Now;
                    DateTime [] arrayDomingos;
                    arrayDomingos = new DateTime[cantidad];
                
                    int anio = fechaHoy.Year;
                    int day = 1;
                    int mes = 5;

                    DateTime domingoMayoAnioActual = new DateTime(anio, mes, day);
                    DateTime primerDomingo = domingoMayoAnioActual; 

                    var tiempoB = System.Diagnostics.Stopwatch.StartNew();

                    if(domingoMayoAnioActual > fechaHoy) 
                    {
                        primerDomingo = new DateTime(anio - 1, primerDomingo.Month, primerDomingo.Day);      
                    }

                    for(int i=0; i<cantidad; i++)
                    {
                        if(primerDomingo.DayOfWeek.ToString() == "Sunday")
                        {
                            arrayDomingos[i] = primerDomingo;          
                        } 
                        else 
                        {    
                            i--;
                        } 

                        primerDomingo = new DateTime(primerDomingo.Year - 1, primerDomingo.Month, primerDomingo.Day);     
                    }   
                    
                    tiempoB.Stop();

                    muestraFechas(arrayDomingos); 

                    long ticksThisTimeA = 0, ticksThisTimeB = 0;
                    long millisecsA = 0, millisecsB = 0; 

                    ticksThisTimeA = tiempoA.ElapsedTicks;
                    ticksThisTimeB = tiempoB.ElapsedTicks;

                    millisecsA = tiempoA.ElapsedMilliseconds;
                    millisecsB = tiempoB.ElapsedMilliseconds;

                    WriteLine("");
                    WriteLine($"Tiempo de ejecucion A: {millisecsA} ms");
                    WriteLine($"Tiempo de ejecucion B: {millisecsB} ms");

                    WriteLine($"Tiempo de ejecucion A: {ticksThisTimeA} en ticks");
                    WriteLine($"Tiempo de ejecucion B: {ticksThisTimeB} en ticks"); 
                break;
                
                case 2: 
                    WriteLine("Cuantos recuadros desea: 1 o 2");
                    string numRecS = ReadLine();

                    int numRec = Int32.Parse(numRecS);
                    
                    int alto = 30;
                    int ancho = 90; 
                    int x_inicial = 3; 
                    int y_inicial = 3;    
                    
                    dibujaPresentacion(alto, ancho, x_inicial, y_inicial);

                    string nombreProyecto = "Diseñando custom consola";
                    string nombreDev = "Alejandro Hernandez";
                    
                    pintaCabezera(nombreProyecto, nombreDev, x_inicial, y_inicial); 

                    int num = 10, num1 = 10; 
                    double numD = 2245, numD2 = 453; 

                    int resultadoSum = sumaSimple(num, num1);
                    int resultadoMul = multiplicaSimple(num, num1); 
                    double resultadoDiv = divideSimple(numD, numD2);
                    double resultadoResto = restoSimple(numD, numD2);

                    string[] datos = new string[4];
                    
                    datos[0] = "El resultado de la suma es: " + resultadoSum;
                    datos[1] = "El resultado de la multiplicacion es: " + resultadoMul;
                    datos[2] = "El resultado de la división es: " + resultadoDiv; 
                    datos[3] = "El resultado del resto es: " + resultadoResto;

                    rellenaDatos(x_inicial, y_inicial, datos);
                    ponFechaCentrada(x_inicial, y_inicial);
                break;
                case 3: //EJERCICIO 4B   
                    alto = 30;
                    ancho = 90; 
                    x_inicial = 3; 
                    y_inicial = 10;    
                    

                    WriteLine("Introduce Artista: ");
                    string artista = ReadLine();
                    WriteLine("Introduce Título: ");
                    string titulo = ReadLine();   
                    WriteLine("Introduce duración: ");
                    string duracion = ReadLine();
                    WriteLine("Introduce tamaño");
                    string tamanio = ReadLine();

                    uint duracionP = UInt32.Parse(duracion);
                    float tamanioP = float.Parse(tamanio);

                    cancionMP3 userSong; 
                    userSong.artista = artista; 
                    userSong.titulo = titulo; 
                    userSong.duracionSecs = duracionP; 
                    userSong.tamanio = tamanioP; 

                    //Clear(); 

                    dibujaPresentacion(alto, ancho, x_inicial, y_inicial);

                    nombreProyecto = "Ejercicios 4B";
                    nombreDev = "Alejandro Hernandez";
                    
                    pintaCabezera(nombreProyecto, nombreDev, x_inicial, y_inicial);
                    
                    /*
                    TipoPersona humano; 
                    humano.nombre = "AlejandroHer";
                    humano.inicial = 'A'; 
                    humano.edad = 27; 
                    humano.Altura = 1.76f;
                    */

                    string[] datosCuatroB = new string[4];
                    datosCuatroB[0] = "Artista: " + userSong.artista;
                    datosCuatroB[1] = "Titulo: " + userSong.titulo;
                    datosCuatroB[2] = "Duracion: " + userSong.duracionSecs + " segundos.";
                    datosCuatroB[3] = "Tamaño: " + userSong.tamanio + "KB";

                    rellenaDatos(x_inicial, y_inicial, datosCuatroB);
                break; 
                
                case 4: 
                    TipoPersona[] datosPersonas = new TipoPersona[100];
                
                    for(int i=0; i<100; i++)
                    {
                        TipoPersona humanoE;
                        humanoE.nombre = "AlejandroHer" + i;
                        humanoE.edad = 27 + i; 
                        humanoE.inicial = 'A'; 
                        humanoE.Altura = 1.76f;

                        datosPersonas[i] = humanoE; 
                    }
                break; 

                case 5:
                    const uint tamArrCanciones = 2000000; 
                   
                    alto = 30;
                    ancho = 90; 
                    x_inicial = 3; 
                    y_inicial = 10;

                    cancionMP3[] canciones = new cancionMP3[tamArrCanciones];

                    uint randomDuracion;
                    float randomTam;  

                    for (uint i = 0; i < tamArrCanciones; i++)
                    {
                        cancionMP3 Songs; 
                        Songs.artista = "asdfa" + i; 
                        Songs.titulo = "asas" + i; 
                        
                        randomDuracion = (uint) new Random().Next(1,60000);
                        randomTam = new Random().Next(1,60000);

                        Songs.duracionSecs = randomDuracion; 
                        Songs.tamanio = randomTam; 
                        canciones[i] = Songs; 
                    }

                    WriteLine("Pulse 1 para añadir cancion, 2 para mostrar todos los títulos y 3 para buscar por minutos: ");
                    string menuCancionesS = ReadLine();

                    int menuCanciones = Int32.Parse(menuCancionesS);

                    switch (menuCanciones) 
                    {
                        case 1:

                        break; 
                        
                        case 2:
                            int tamArr = canciones.Length;

                            for(int i = 0; i<tamArr; i++)
                            {
                                WriteLine($"{canciones[i].titulo}");
                            }

                        break; 

                        case 3:
                            
                            /*
                            WriteLine("Introduzca el rango máximo de minutos");
                            string menuTress = ReadLine();

                            uint minutos = uint.Parse(menuTress); 
                            uint secs = minutos * 60; 
                            */

                            tamArr = canciones.Length;
                                
                            //Búsqueda normal 
                            uint secs_uno = 30000;
                            uint secs_dos = 15000;
                            uint secs_tres = 45000;
                            uint secs_cuatro = 1000;
                            uint secs_cinco = 500;
                            uint secs_seis = 50000; 
                            

                            long ticksFirstMethod = 0, ticksSecondMethod = 0;

                            var primerMethod = System.Diagnostics.Stopwatch.StartNew();
                            uint uno = 0, dos = 0, tres = 0, cuatro = 0, cinco = 0, seis = 0;               

                            for(int i = 0; i<tamArr; i++)
                            {
                                if(canciones[i].duracionSecs < secs_uno) 
                                {
                                    /*
                                    WriteLine($"Artista: {canciones[i].artista}");
                                    WriteLine($"Titulo: {canciones[i].titulo}");
                                    WriteLine($"Duración: {canciones[i].duracionSecs}");
                                    WriteLine($"Tamaño: {canciones[i].tamanio}");    
                                    */
                                    uno = canciones[i].duracionSecs;
                                    i = tamArr;  
                                }
                            }

                            for(int i = 0; i<tamArr; i++)
                            {
                                if(canciones[i].duracionSecs < secs_dos) 
                                {
                                    /*
                                    WriteLine($"Artista: {canciones[i].artista}");
                                    WriteLine($"Titulo: {canciones[i].titulo}");
                                    WriteLine($"Duración: {canciones[i].duracionSecs}");
                                    WriteLine($"Tamaño: {canciones[i].tamanio}");    
                                    */
                                    dos = canciones[i].duracionSecs;
                                    i = tamArr;  
                                }
                            }    

                            for(int i = 0; i<tamArr; i++)
                            {
                                if(canciones[i].duracionSecs < secs_tres) 
                                {
                                    /*
                                    WriteLine($"Artista: {canciones[i].artista}");
                                    WriteLine($"Titulo: {canciones[i].titulo}");
                                    WriteLine($"Duración: {canciones[i].duracionSecs}");
                                    WriteLine($"Tamaño: {canciones[i].tamanio}");    
                                    */
                                    tres = canciones[i].duracionSecs;
                                    i = tamArr;  
                                }
                            }

                            for(int i = 0; i<tamArr; i++)
                            {
                                if(canciones[i].duracionSecs < secs_cuatro) 
                                {
                                    /*
                                    WriteLine($"Artista: {canciones[i].artista}");
                                    WriteLine($"Titulo: {canciones[i].titulo}");
                                    WriteLine($"Duración: {canciones[i].duracionSecs}");
                                    WriteLine($"Tamaño: {canciones[i].tamanio}");    
                                    */
                                    cuatro = canciones[i].duracionSecs;
                                    i = tamArr;  
                                }
                            }    

                            for(int i = 0; i<tamArr; i++)
                            {
                                if(canciones[i].duracionSecs < secs_cinco) 
                                {
                                    /*
                                    WriteLine($"Artista: {canciones[i].artista}");
                                    WriteLine($"Titulo: {canciones[i].titulo}");
                                    WriteLine($"Duración: {canciones[i].duracionSecs}");
                                    WriteLine($"Tamaño: {canciones[i].tamanio}");    
                                    */
                                    cinco = canciones[i].duracionSecs;
                                    i = tamArr;  
                                }
                            }    

                             for(int i = 0; i<tamArr; i++)
                            {
                                if(canciones[i].duracionSecs < secs_seis) 
                                {
                                    /*
                                    WriteLine($"Artista: {canciones[i].artista}");
                                    WriteLine($"Titulo: {canciones[i].titulo}");
                                    WriteLine($"Duración: {canciones[i].duracionSecs}");
                                    WriteLine($"Tamaño: {canciones[i].tamanio}");    
                                    */
                                    seis = canciones[i].duracionSecs;
                                    i = tamArr;  
                                }
                            }

                            primerMethod.Stop();
                            ticksFirstMethod = primerMethod.ElapsedTicks;
                        
                            var secondMethod = System.Diagnostics.Stopwatch.StartNew();

                            //ordena Array por duracion en segundos: 
                            //QUICKSORT 
                            quicksort(canciones, 0, canciones.Length-1);    
                            
                            //Busqueda límite: 
                            //(Es decir, obtener la primera casilla del vector en el que los segundos sea menor que los introducidos por el user)
                            //Binary Search
                            cancionMP3 unoB = binarySearch(canciones, secs_uno, 0, canciones.Length-1);
                            cancionMP3 dosB = binarySearch(canciones, secs_dos, 0, canciones.Length-1);
                            cancionMP3 tresB = binarySearch(canciones, secs_tres, 0, canciones.Length-1);
                            cancionMP3 cuatroB = binarySearch(canciones, secs_cuatro, 0, canciones.Length-1);
                            cancionMP3 cincoB = binarySearch(canciones, secs_cinco, 0, canciones.Length-1);
                            cancionMP3 seisB = binarySearch(canciones, secs_seis, 0, canciones.Length-1);

                            secondMethod.Stop();
                            ticksSecondMethod = secondMethod.ElapsedTicks;
                           
                            WriteLine("");
                            WriteLine($"Tamaño del array: {canciones.Length}"); 
                            
                            WriteLine("");
                            WriteLine($"Tiempo de ejecucion busqueda 1: {ticksFirstMethod} ticks"); 
                            WriteLine($"Tiempo de ejecucion busqueda 2: {ticksSecondMethod} ticks");
                            
                            WriteLine("");
                            WriteLine($"Datos a buscar: {secs_uno}, {secs_dos}, {secs_tres}, {secs_cuatro}, {secs_cinco}, {secs_seis}");
                            
                            WriteLine("");
                            WriteLine($"Datos correctos busqueda 1: {uno}");
                            WriteLine($"Datos correctos busqueda 1: {dos}");
                            WriteLine($"Datos correctos busqueda 1: {tres}");
                            WriteLine($"Datos correctos busqueda 1: {cuatro}");
                            WriteLine($"Datos correctos busqueda 1: {cinco}");
                            WriteLine($"Datos correctos busqueda 1: {seis}");
                            
                            WriteLine("");
                            WriteLine($"Datos correctos busqueda 2: {unoB.duracionSecs}");
                            WriteLine($"Datos correctos busqueda 2: {dosB.duracionSecs}");
                            WriteLine($"Datos correctos busqueda 2: {tresB.duracionSecs}");
                            WriteLine($"Datos correctos busqueda 2: {cuatroB.duracionSecs}");
                            WriteLine($"Datos correctos busqueda 2: {cincoB.duracionSecs}");
                            WriteLine($"Datos correctos busqueda 2: {seisB.duracionSecs}");
                        break;
                    }   
                break;
                case 6:
                    
                    /*
                    StreamWriter fichero; 
                    fichero = File.CreateText("Mi primer archivo.txt");
                    fichero.WriteLine("Esto es un línea");
                    fichero.Write("Esto es otra línea sin cambiar de línea. ");
                    fichero.WriteLine("Ultima línea");
                    fichero.Close();
                    
                    fichero = File.AppendText("Mi primer archivo.txt");
                    fichero.WriteLine("linea con appendText ");
                    fichero.Close();
                    */

                    /*
                    StreamReader fichero; 
                    string linea; 
                    fichero = File.OpenText("Mi primer archivo.txt");
                    linea = fichero.ReadLine();
                    WriteLine(linea);
                    WriteLine(fichero.ReadLine());
                    fichero.Close();
                    */ 

                    //Rutas de archivo: con el @ busca el archivo en el entorno. 
                    //string ruta = @"D:\NET CORE\ejemplo1.txt"; 

                    //Para saber si existe un archivo: 
                    /*
                    StreamReader fichero; 
                    string nombreFichero; 
 
                    while(true)
                    {
                        WriteLine("Introduce el nombre del fichero: "); 
                        nombreFichero = ReadLine();
                        if (nombreFichero == "salida")
                        {
                            break; 
                        }
                        if (File.Exists(nombreFichero))
                        {
                            fichero = File.OpenText(nombreFichero);
                            WriteLine ("La primera línea es: {0}", fichero.ReadLine());
                            fichero.Close();
                        } else 
                        {
                            WriteLine("No existe");
                        }
                    }
                    */
                    //Con excepciones:  Es la mejor forma de hacer
                    /*
                    StreamReader fichero; 
                    string nombreFichero;
                    string linea; 
                    WriteLine("Introduce el nombre del fichero: "); 
                    nombreFichero = ReadLine();

                    try
                    {
                        fichero = File.OpenText(nombreFichero);
                        do
                        {
                            linea = fichero.ReadLine();
                            if (linea != null)
                            {
                                WriteLine(linea);
                            }               
                        } while (linea != null);
                        fichero.Close();  
                    }
                    catch (Exception exp)
                    {
                        WriteLine("Ha habido un error {0}", exp.Message);            
                    }
                    */
                break;
                case 7:
                    StreamReader fichero; 
                    string linea; 
                    fichero = File.OpenText("disney2.txt");
                    List<Pelicula> peliculas = new List<Pelicula>(); 

                    do  
                    {
                        linea = fichero.ReadLine();
                        if (linea != null)
                        {
                            string nombre = "", fecha, tamP = ""; 
                            int rompo = 0; 
                            Pelicula leida;
                            
                            string[] lineaSeparada = linea.Split("  ");
                            
                            fecha = lineaSeparada[0] + " " + lineaSeparada[1];                               

                            leida.fecha = DateTime.ParseExact(fecha, "dd/MM/yyyy HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);


                            string tamYnombre = lineaSeparada[lineaSeparada.Length - 1];
                            
                            for(int i = 0; i<tamYnombre.Length; i++)
                            {
                                if(tamYnombre[i] == ' ')
                                {
                                    if(i == 0) continue;
                                    else 
                                    {
                                        rompo = i;
                                        break;
                                    }     
                                }
                                else 
                                {
                                    if(tamYnombre[i] == '.') continue; 
                                    else tamP = tamP + tamYnombre[i]; 
                                }  
                            }

                            leida.tamanio = double.Parse(tamP);

                            for(int i = rompo + 1; i<tamYnombre.Length; i++)   
                            {
                                nombre = nombre + tamYnombre[i];     
                            } 
                            
                            leida.nombre = nombre;

                            peliculas.Add(leida); 
                        }               
                         
                    } while (linea != null);

                    fichero.Close(); 

                    //Ordenar por tamanio
                    List<Pelicula> peliculasOrdenadasTam = peliculas.OrderByDescending(d => d.tamanio).ToList();
                    //Visualizar la lista resultante
                    WriteLine("Peliculas ordenadas por tamanio en orden descendiente:");
                    visualizaPelicula(peliculasOrdenadasTam, 10);
                    //Grabar en archivo 
                    string nombreNuevoF = "Disney2 ordenadas por Tam.txt";
                    if(!grabaPeliculasEnArchivo(peliculasOrdenadasTam, nombreNuevoF)) WriteLine("Error al grabar el archivo"); 

                    WriteLine("");

                    //Ordenar por fecha
                    List<Pelicula> peliculasOrdenadasFecha = peliculas.OrderByDescending(d => d.fecha).ToList();
                    //Visualizar la lista resultante
                    WriteLine("Peliculas ordenadas por fecha en orden descendiente:");
                    visualizaPelicula(peliculasOrdenadasFecha, 10);
                    //Grabar en archivo 
                    nombreNuevoF = "Disney2 ordenadas por Fecha.txt";
                    if(!grabaPeliculasEnArchivo(peliculasOrdenadasFecha, nombreNuevoF)) WriteLine("Error al grabar el archivo"); 

                break; 
                case 8:
                    //Ficheros binarios: 
                    /*
                    BinaryReader ficheroBinario;
                    string nombreFichero; 
                    SByte datoFichero;
                    byte datoFicheroB;
                    nombreFichero = "ejemplo.bmp";
                    ficheroBinario = new BinaryReader(File.Open(nombreFichero, FileMode.Open));
                    datoFichero = ficheroBinario.ReadSByte();    
                    datoFicheroB = ficheroBinario.ReadByte();    
                    WriteLine($"El byte leido es {datoFichero}");
                    WriteLine($"El byte leido es {datoFicheroB}");
                    ficheroBinario.Close();
                    */
                    /*
                    FileStream ficher;
                    string nombreFichero;
                    byte[] datosB;
                    int numByteLeidos; 
                    
                    int cantBytes = 10; 

                    nombreFichero = "ejemplo.bmp";
                    ficher = File.OpenRead(nombreFichero);
                    datosB = new byte[cantBytes];
                    int pos = 0; 
                    int cantidadLeer = cantBytes; 
                    numByteLeidos = ficher.Read(datosB, pos, cantidadLeer);
                    if (numByteLeidos < cantBytes)
                    {
                        WriteLine("No se han podido leer todos los bytes");
                    }    
                    else 
                    {
                        for(int i = 0; i<cantBytes; i++)
                            WriteLine("El byte de la pos {1} leido es {0}", datosB[i], i);
                    }
                    ficher.Close();
                    */
                    FileStream ficher;
                    string nombreFichero = "besoftware.pcx";
                    int anchoI, altoI, numColors = 0;

                    byte[] datosB;
                    int numByteLeidos; 
                    
                    int cantBytes = 75; 

                    ficher = File.OpenRead(nombreFichero);
                    datosB = new byte[cantBytes];
                
                    int pos = 0; 
                    int cantidadLeer = cantBytes; 
                    numByteLeidos = ficher.Read(datosB, pos, cantidadLeer);
                    
                    int anchura = (datosB[8] | (datosB[9] << 8) )+ 1;
                    int altura =  (datosB[10] | (datosB[11] << 8)) + 1;
                    numColors = datosB[3] * datosB[65];
                    if (numByteLeidos < cantBytes)
                    {
                        WriteLine("No se han podido leer todos los bytes");
                    }    
                    else 
                    {
                        for(int i = 0; i<cantBytes; i++)
                            WriteLine("El byte de la pos {1} leido es {0}", datosB[i], i);
                    }
                    ficher.Close();
                    WriteLine("Alto: {0}, ancho: {1}, numColors: 2 ^ {2} colores", anchura, altura, numColors);     
                break; 
                case 9:
                    
                    Persona unoP  = new Persona("Edelmiro", 33, "5467841C");
                    Persona dosP  = new Persona("Pepe", 14, "25786413J");
                    Persona tresP  = new Persona("Clara", 55, "74481473P");

                    unoP.visualiza();
                    dosP.visualiza();
                    tresP.visualiza();

                    Coche unoC = new Coche("Aud", "3'14", "44365F", 23255);
                    Coche dosC = new Coche("Aud1", "3'14dd", "4472275h", 5768);
                    Coche tresC = new Coche("Aud2", "3'14a", "443465d", 772354);
                    Coche cuatroC = new Coche("Aud3", "3'14ff", "44325L", 2222);

                    unoC.visualizar();
                    dosC.visualizar();
                    tresC.visualizar();

                    cuatroC.Marca = "asdfaf";
                    cuatroC.visualizar();

                break;

                case 11: 
                    Console.WriteLine("CurrentDirectory: {0}", Environment.CurrentDirectory);
                    Console.WriteLine("ExitCode: {0}", Environment.ExitCode);

                    Console.WriteLine("HasShutdownStarted: {0}", Environment.HasShutdownStarted);

                    //  <-- Keep this information secure! -->
                    Console.WriteLine("MachineName: {0}", Environment.MachineName);

                    Console.WriteLine("NewLine: {0}  first line{0}  second line{0}  third line",
                                        Environment.NewLine);

                    Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString());

                    Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);

                    //  <-- Keep this information secure! -->
                    Console.WriteLine("SystemDirectory: {0}", Environment.SystemDirectory);

                    Console.WriteLine("TickCount: {0}", Environment.TickCount);

                    //  <-- Keep this information secure! -->
                    Console.WriteLine("UserDomainName: {0}", Environment.UserDomainName);

                    Console.WriteLine("UserInteractive: {0}", Environment.UserInteractive);

                    //  <-- Keep this information secure! -->
                    Console.WriteLine("UserName: {0}", Environment.UserName);

                    Console.WriteLine("Version: {0}", Environment.Version.ToString());

                    Console.WriteLine("WorkingSet: {0}", Environment.WorkingSet);

                    string[] drives = Environment.GetLogicalDrives();
                    Console.WriteLine("GetLogicalDrives: {0}", String.Join(", ", drives));

                    Console.WriteLine("GetFolderPath: {0}", Environment.GetFolderPath(Environment.SpecialFolder.System));
                break;  

                case 12:

                    Localizador lol = new Localizador();
                    
                    string nomFiche = "datos sistema.txt";

                    if (lol.guardaEnArchivo(nomFiche))
                        WriteLine("Datos guardados correctamente"); 
                    else  WriteLine("Fallo al guardar"); 

                    leeFichero(nomFiche);
                
                break; 

                case 13:
                    
                    //Trabajador Currito = new Trabajador("Edelmiro", 66, "478606644-T", 50000);
                    //Currito.visualiza();
                    
                    //Libro libroo = new Libro("soy un libro", 34.45, 33);
                   // WriteLine(libroo.imprimirDato());  
                    
                    alto = 30;
                    ancho = 90; 
                    x_inicial = 3; 
                    y_inicial = 3;    
                    
                    dibujaPresentacion(alto, ancho, x_inicial, y_inicial);

                    nombreProyecto = "Clases";
                    nombreDev = "Alejandro Hernandez";
                    
                    pintaCabezera(nombreProyecto, nombreDev, x_inicial, y_inicial); 

                    
                    string[] datosAmostrar = new string[4];
                
                    Gastropodo caracol = new Gastropodo("Caracolo", 20, "conchaDura", "agua dulce");
                    Can perroLadrador = new Can("Toby", 5, 300, 10);
                    
                    datosAmostrar[0] = caracol.imprimirDatos();
                    datosAmostrar[1] = perroLadrador.imprimirDatos();

                    rellenaDatos(x_inicial, y_inicial, datosAmostrar); 

                break; 

                case 14:
                    double ladoCubo = 3.43; 
                    Cubo cubo = new Cubo(ladoCubo); 
                    cubo.imprimeDatos();
                
                    int valorUno = 2, valorDos = 3; 

                    Operaciones operaciones = new Operaciones();
                    operaciones.ValorUno = valorUno; 
                    operaciones.ValorDos = valorDos; 

                    WriteLine($"suma: {operaciones.suma()}, resta: {operaciones.resta()}, multiplicacion: {operaciones.multiplicacion()}, division: {operaciones.division()} ");
                break;

                case 10:

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
                break;   
            }               
        }    
    } 
}

