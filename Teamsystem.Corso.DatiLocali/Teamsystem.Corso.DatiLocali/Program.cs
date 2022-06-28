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
            string percorso = @"c:\teamsystemtemp\dati\daElaborare\";
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

            }
        }
    }
}
