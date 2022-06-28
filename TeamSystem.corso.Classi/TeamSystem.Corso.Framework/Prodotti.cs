using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public class Prodotti : List<Prodotto>, ICloneable
    {
        //PROPERTIES
        public decimal prezzoMedioProperty
        {
            get
            {
                return this.Average(x => x.PrezzoListino);
            }
        }

        public Prodotto getProdottoWithHighestPriceProperty
        {
            get { 
                return this.OrderByDescending(x => x.PrezzoListino).FirstOrDefault();
            }
        }

        //METHODS
        public Prodotto getProdottoByCodice(int CodiceProdotto)
        {
            return this.Where(x => x.CodiceProdotto == CodiceProdotto).FirstOrDefault();
        }

        public decimal prezzoMedio()
        {
                return this.Average(x => x.PrezzoListino);
        }

        public Prodotto getProdottoWithHighestPrice()
        {
                return this.OrderByDescending(x => x.PrezzoListino).FirstOrDefault();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
