using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public partial class Prodotto
    {
        static Random unit = new Random();
        public string NomeProdotto { get; set; }
        public int CodiceProdotto { get; set; }
        public decimal PrezzoListino { get; set; }
        public static int GeneraCodice()
        {
            return unit.Next(100);
        }

        public override string ToString()
        {
            return String.Format("CODE: {0} - NOME: {1} - PREZZO: {2}", this.CodiceProdotto,this.NomeProdotto,this.PrezzoListino);
        }
    }
}
