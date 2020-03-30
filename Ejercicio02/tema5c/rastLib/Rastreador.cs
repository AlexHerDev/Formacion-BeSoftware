using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace rastlib
{
    public partial class Rastreador
    {
        private string path = "./"; 
        private string nombreFichero = "infoDirectory.txt";
        private List<string> lineas = new List<string>();

        private double totalTam = 0; 
        public Rastreador()
        {}

        public string Path { get => path; set => path = value; }
        public string NombreFichero { get => nombreFichero; set => nombreFichero = value; }
        public List<string> Linea { get => lineas; set => lineas = value; }
        public double TotalTam { get => totalTam; set => totalTam = value; }

        public bool saveInfo(string nombreFichero, List<string> lista)
        {
            StreamWriter fichero; 
            fichero = File.CreateText(nombreFichero);
                    
            foreach(var linea in lista) 
            {
                fichero.WriteLine(linea);    
            }

            fichero.Close(); 

            return true;     
        }
        
        public void getInfoFolder()
        {
            string[] allfiles = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);

            foreach(var file in allfiles)
            {
                FileInfo info = new FileInfo(file);
                
                string lineaEscribir = file + ",ext:" + info.Extension + ", tam:" + info.Length + "Bytes, path:" + info.FullName; 
                lineas.Add(lineaEscribir);
                //WriteLine(lineaEscribir);   

                totalTam += info.Length;  
            }
        }

        public void getInfoPath()
        {
            WriteLine("Inserte la ruta del directorio: "); 
            string namePath = ReadLine();
            path = namePath;
            getInfoFolder(); 
            saveInfo(nombreFichero, lineas);
        }

        public int getNumFiles()
        {
            return lineas.Capacity; 
        }

        public double getTam()
        {
            return TotalTam;         
        }
    }
}        