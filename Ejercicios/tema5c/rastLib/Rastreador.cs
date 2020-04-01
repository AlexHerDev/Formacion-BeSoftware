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

        private List<string> todo = new List<string>();

        private double totalTam = 0; 
        private double totalArchivos = 0; 

        public Rastreador() {}
        public string Path { get => path; set => path = value; }
        public string NombreFichero { get => nombreFichero; set => nombreFichero = value; }
        public double TotalTam { get => TotalTam1; set => TotalTam1 = value; }
        public double TotalArchivos { get => totalArchivos; set => totalArchivos = value; }
        public double TotalTam1 { get => totalTam; set => totalTam = value; }

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
            string[] AllDirectories = Directory.GetDirectories(Path, "*.*", SearchOption.AllDirectories);

            foreach(var directory in AllDirectories)
            {
                string lineaEscribir = directory;
                todo.Add(lineaEscribir); 
                TotalArchivos ++;

                string[] allfiles = Directory.GetFiles(lineaEscribir, "*.*", SearchOption.TopDirectoryOnly);
                foreach(var file in allfiles)
                {
                    FileInfo info = new FileInfo(file);
                
                    string nlineaEscribir = file + ", EXT:" + info.Extension + ", TAM:" + info.Length + " Bytes, PATH:" + info.FullName; 
                    
                    todo.Add(nlineaEscribir);
            
                    TotalTam1 += info.Length;  
                    TotalArchivos ++;
                }
            }
        }

        public void getInfoPath()
        {
            WriteLine("Inserte la ruta del directorio: "); 
            string namePath = ReadLine();
            path = namePath;
            getInfoFolder(); 
            saveInfo(nombreFichero, todo);
        }

        public double getNumFiles()
        {
            return TotalArchivos; 
        }

        public double getTam()
        {
            return TotalTam;         
        }
    }
}        