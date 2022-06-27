using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Classi.Codice
{
    public class Persona
    {
        public int test;
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public int GetEta()
        {
            return (DateTime.Now - this.DataNascita).Days;
        }

    }
}
