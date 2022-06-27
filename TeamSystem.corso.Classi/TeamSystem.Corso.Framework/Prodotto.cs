using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public class Prodotto
    {
        static Random unit = new Random();
        public string NomeProdotto { get; set; }
        public int CodiceProdotto { get; set; }
        public decimal PrezzoListino { get; set; }
        public static int GeneraCodice()
        {
            return unit.Next(100);
        }
    }
}
