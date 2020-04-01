using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using static System.Console;

namespace genProjectLib
{
    public class GeneradorPro
    {
        private string nombreProyecto;
        private string nombreArchClases; 
        private string rutaProyecto; 
        private string rutaClassLib; 
        private string currentPath = "./"; 

        public GeneradorPro(string nombreProyecto, string nombreArchClases = null)
        {
            //Aquí podría contruir la ruta completa directamente 
            this.nombreProyecto = nombreProyecto; 
            this.nombreArchClases = nombreArchClases;
        
            this.rutaProyecto = nombreProyecto;
            
            if(nombreArchClases != null)
            {
                this.rutaClassLib = nombreProyecto + "/" + nombreArchClases + "Lib";
            }
        }

        public void creaCarpetasIniciales()
        {
            Directory.CreateDirectory(currentPath + rutaProyecto); 
            
            if(nombreArchClases != null)
            {
                Directory.CreateDirectory(currentPath + rutaClassLib);           
            }                   
        }

        public bool creaProyecto() 
        {

            //Dentro de la carpeta principial hacer "dotnet new console" 
            try
            {   
                ProcessStartInfo proc_start_info = new ProcessStartInfo();
                proc_start_info.FileName = "bash";
                proc_start_info.Arguments = "scriptNewConsole " + rutaProyecto;
                // -c allows to wait the command to be execute and exit

                proc_start_info.RedirectStandardOutput = true; //cambiar a true para que no salga nada 
                proc_start_info.UseShellExecute = false;
                proc_start_info.CreateNoWindow = true;

                Process proc = new Process();
                proc.StartInfo = proc_start_info;
                proc.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if(nombreArchClases != null)
            {
                try
                { 
                    //en lib, lanzar "dotnet new classLib" 
                    ProcessStartInfo proc_start_info = new ProcessStartInfo();
                    proc_start_info.FileName = "bash";
                    proc_start_info.Arguments = "scriptNewLib " + rutaClassLib;
                    // -c allows to wait the command to be execute and exit

                    proc_start_info.RedirectStandardOutput = true; //cambiar a true para que no salga nada 
                    proc_start_info.UseShellExecute = false;
                    proc_start_info.CreateNoWindow = true;

                    Process proc = new Process();
                    proc.StartInfo = proc_start_info;
                    proc.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }            
            }

            return true; 
        }

        public void crealo()
        {
            creaCarpetasIniciales();
            creaProyecto();
        }
    }
}        
