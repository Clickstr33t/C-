using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public sealed class Dirigent : Impiegato
    {
        public int NumeroPersoneGestite { get; set; }
    
    //non posso fare override di DataNascita perchè su impiegato è impostato su sealed
    }
}
