using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public class Fattura : IDocumento, IComparable, IComparable<Fattura>, ICloneable
    {
        public int CodiceDocumento { get ; set ; }
        public DateTime DataDocumento { get; set; }
        public string Contenuto { get; set; }

        public bool DocumentoValido()
        {
            throw new NotImplementedException();
        }

        // Implementazione di IComparable generico
        public int CompareTo(object obj)
        {
            if (obj is Fattura)
            {
                if (obj == null) return 1;

                Fattura other = (Fattura)obj;
                if (this.CodiceDocumento > other.CodiceDocumento)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }
            else
            {
                return -1;
            }
        }

        // Implementazione di IComparable Tipicizzato <Fattura>
        public int CompareTo(Fattura other)
        {
            if (this.CodiceDocumento > other.ImportoFattura)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return this.CodiceDocumento + " - " + this.ClienteFatturazione; 
        }
        // Implementazione IClonable
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //Posso implementare proprietà extra a quelle dell'interfaccia
        public string ClienteFatturazione { get; set; }
        public decimal ImportoFattura { get; set; }
    }
}

