using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamsystem.Corso.DatiLocali
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //=====================LETTURA DATI =====================
            //string percorso = @"c:\teamsystemtemp\dati\daElaborare\";
            //********* Come usare le KEY configurate in App.configy *********
            string percorso = System.Configuration.ConfigurationSettings.AppSettings["percorso"];
            if (!Directory.Exists(percorso))
            {
                Directory.CreateDirectory(percorso);
            }
            var files = Directory.GetFiles(percorso, "*.txt");
            foreach (var file in files)
            {
                Console.WriteLine(file);
                StreamReader f = new StreamReader(file);
                while (!f.EndOfStream)
                {
                    string dati = f.ReadLine();
                    Console.WriteLine(dati); 
                }
                f.Close();
                string nuovoNome = Path.GetFileName(file);
                nuovoNome = Path.ChangeExtension(file,"worked");
                File.Move(file, nuovoNome);
                Console.WriteLine("File spostato");

            }

            // ============== SCRITTURA DATI ===================
            //con append = false se il file esiste verra sovrascritto se true verranno aggiunte info
            StreamWriter fScrittura = new StreamWriter(percorso + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt", false);
            fScrittura.WriteLine("riga esempio");
            fScrittura.WriteLine("second riga esempio");
            fScrittura.Close();
        }
    }
}
