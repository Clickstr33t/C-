using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public interface IDocumento
    {
        int CodiceDocumento { get; set; }
        DateTime DataDocumento { get; set; }
        string Contenuto { get; set; }

        bool DocumentoValido();
    }
}
