using System;
using System.IO;
using static System.Console;

namespace Ejercicio02
{
    public class Localizador 
    {
        private string directorioTemporal; 
        private string nombreMaquina;
        private string tiempoEncendido; 
        private string version; 

        public string NombreMaquina { get => nombreMaquina; set => nombreMaquina = value; }
        public string DirectorioTemporal { get => directorioTemporal; set => directorioTemporal = value; }
        public string TiempoEncendido { get => tiempoEncendido; set => tiempoEncendido = value; }
        public string Version { get => version; set => version = value; }

        
        public Localizador()
        {
            this.localizaDirectorioTemporal();
            this.extraeNombreMaquina();
            this.extraeTiempoEncendida();
            this.extraeVersionOS();
        }
        
        public void extraeNombreMaquina()
        {
            nombreMaquina = Environment.UserName;
        }

        public void extraeTiempoEncendida()
        {
            TiempoEncendido = Environment.TickCount.ToString();        
        }

        public void extraeVersionOS()
        {
            Version = Environment.Version.ToString(); 
        }

        public void localizaDirectorioTemporal()
        {
            directorioTemporal = Environment.CurrentDirectory.ToString();       
        }  

        public bool guardaEnArchivo(string nombreFichero)
        {
            bool salioBien = true;
            
            StreamWriter fichero; 
            fichero = File.CreateText(nombreFichero);
            
            fichero.WriteLine($"Nombre maquina: {nombreMaquina}");
            fichero.WriteLine($"TiempoEncendida: {tiempoEncendido} ms");
            fichero.WriteLine($"Version: {version}");

            fichero.Close();

            return salioBien; 
        }
    }
}