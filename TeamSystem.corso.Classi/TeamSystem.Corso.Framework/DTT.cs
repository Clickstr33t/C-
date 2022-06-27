using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public class DTT : IDocumento
    {
        public int CodiceDocumento { get ; set ; }
        public DateTime DataDocumento { get; set; }
        public string Contenuto { get ; set ; }

        public bool DocumentoValido()
        {
            throw new NotImplementedException();
        }
        public string ClienteSpedizione { get; set; }
        public DateTime DataSpedizione { get; set; }
    }
}
