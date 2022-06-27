using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public class Fattura : IDocumento
    {
        public int CodiceDocumento { get ; set ; }
        public DateTime DataDocumento { get; set; }
        public string Contenuto { get; set; }

        public bool DocumentoValido()
        {
            throw new NotImplementedException();
        }
        //Posso implementare proprietà extra a quelle dell'interfaccia
        public string ClienteFatturazione { get; set; }
        public decimal ImportoFattura { get; set; }
    }
}

