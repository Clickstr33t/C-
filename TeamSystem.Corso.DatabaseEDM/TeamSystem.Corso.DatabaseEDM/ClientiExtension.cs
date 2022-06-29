using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.DatabaseEDM
{
    public partial class Clienti
    {
        public override string ToString()
        {
            return String.Format(
                "\n---------------------" +
                "\nNOME: {0}" +
                "\nNAZIONALITA': {1}" +
                "\nFATTURATO: {2}"
                , RagioneSociale, Nazione, Fatturato);
        }

   
    }
}
