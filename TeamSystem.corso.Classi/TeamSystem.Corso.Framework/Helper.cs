using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    // Dichiarazione di una classe statica
    public static class Helper
    {
        public const string NomeApplicazione = "App Demo";
  

        // Tutti i metodi all'interno di una classe statica devono essere statici
        public static decimal CalcolaIVA(decimal valore)
        {
            return valore * 1.22m;
        }


    }
}
