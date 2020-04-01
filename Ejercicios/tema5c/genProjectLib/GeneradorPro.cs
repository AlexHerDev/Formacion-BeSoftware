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
        private string currentPath = "./"; 

        public GeneradorPro(string nombreProyecto, string nombreArchClases = null)
        {
            this.nombreProyecto = nombreProyecto; 
            this.nombreArchClases = nombreArchClases;
        }

        public void creaCarpetasIniciales()
        {
            Directory.CreateDirectory(currentPath + nombreProyecto); 
            
            if(nombreArchClases != null)
            {
                Directory.CreateDirectory(currentPath + nombreProyecto + "/" + nombreArchClases + "Lib");           
            }                   
        }

        public bool creaProyecto() 
        {

            //Dentro de la carpeta principial hacer "dotnet new console" 
            try
            {   
                ProcessStartInfo proc_start_info = new ProcessStartInfo();
                proc_start_info.FileName = "bash";
                proc_start_info.Arguments = "scriptNewConsole " + nombreProyecto;
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
                    proc_start_info.Arguments = "scriptNewLib " + nombreProyecto + "/" + nombreArchClases + "Lib";
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
