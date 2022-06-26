using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Metodi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal valore = 100000;
            decimal valoreConIVA = CalcolaIVA(valore);
            Console.WriteLine(valoreConIVA);

            // INVOCAZIONE METODO CON DOPPIO OUTPUT
            DateTime i = new DateTime();
            bool esiste = ClienteEsistente(40, out i);
            if (esiste)
            {
                Console.WriteLine(i.ToString());
            }

            //INVOCAZIONE METODO CON PARAMETRO PER RIFERIMENTO
            Console.WriteLine("PRIMA: " + valore);
            ApplicaIVA(ref valore);
            Console.WriteLine("DOPO: " + valore);
        }
        /// <summary>
        /// Serve per calcolare l'importo comprensivo di IVA
        /// </summary>
        /// <param name="importo">Inseire l'importo in €</param>
        /// <returns>Restituisce il valore con IVA</returns>
        static decimal CalcolaIVA(decimal importo)
        {
            if (importo > 10000)
            {
                return importo * 1.22M;
            }
            else
            {
                return importo;
            }
        }
        /// <summary>
        /// Serve per calcolare l'IVA
        /// </summary>
        /// <param name="importo">Inserire l'importo</param>
        /// <param name="pIVA">Opzionale: standard 1.22m</param>
        /// <returns></returns>
        /// 
        //NOTA IL PARAMETRO pIVA IN QUESTO MODO é OPZIONALE
        static decimal CalcolaIVA(decimal importo, decimal pIVA=1.22m)
        {

            return importo * pIVA;
        }
        //DEFINIRE METODI CON DOPPIO OUTPUT
        static bool ClienteEsistente(int codice, out DateTime DataIscrizione)
        {
            bool ris = true;
            DataIscrizione = new DateTime(2001, 12, 5);
            return ris;
        }

        //PASSARE PARAMETRO PER RIFERIMENTO INVECE DI VALORE
        static void ApplicaIVA(ref decimal importo)
        {
            importo = importo * 1.22m;
        }
    }
}
