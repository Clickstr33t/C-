using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Eccezioni
{
    internal class Program
    {
        /// <summary>
        /// Crea un nuovo chiente
        /// </summary>
        /// <param name="PartitaIva">Inseire la partita iva</param>
        /// <returns>Il codice cliente</returns>
        /// <exception cref="Exception"></exception>
        static int CreaCliente(String PartitaIva)
        {
            //LANCIARE UN ECCEZIONE GENERICA PERSONALIZZATA
            if (PartitaIva.Length != 8)
            {
                throw new Exception("Partita IVA non corretta");
            }
            return 1;
        }
        static void Main(string[] args)
        {
            string percorso = @"C:\\testteamsystem\file.txt";
            StreamReader f = null;
            //GESTIONE CENTRALIZZATA DELL'ECCEZIONE
            try
            {
                            f = new StreamReader(percorso);
            Console.WriteLine("ok");
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    FileNotFoundException tmp = (FileNotFoundException)ex;
                    Console.WriteLine("File non trovato: "+ tmp.FileName);
                }
                if (ex is DirectoryNotFoundException)
                {
                    Console.WriteLine("Cartella non trovata");
                }
                {

                }
               
            }

        }


        static void Main_eccezioni(string[] args)
        {
            
            string percorso = @"C:\\testteamsystem\file.txt";
            StreamReader f = null;
            try
            {
                int ris = CreaCliente("AAA");
                //POSSO FARE TRY ANNIDATI E DECIDERE SE NON LANCIARE L'ECCEZIONE 
                //ATTENZIONE SE TOGLI IL PROGRAMMA CONTINUA SENZA LANCIARE EXCEPTION 
                try
                {
                    StreamReader f1 = new StreamReader(percorso);
                }
                catch (Exception){ }

            f = new StreamReader(percorso);
            Console.WriteLine("ok");

            }
            catch(DirectoryNotFoundException ex)
            {
                Console.WriteLine("ERRORE DIRECTORY NON TROVATA");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("ERRORE FILE NON TROVATO: " + ex.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRORE GENERICO: " + ex.Message);
                Console.WriteLine(ex.GetType().FullName);
            }
            finally
            {
                if (f != null)
                {
                    f.Close();
                }
                Console.WriteLine("PROCEDURA TERMINATA");
            }
        }
    }
}
