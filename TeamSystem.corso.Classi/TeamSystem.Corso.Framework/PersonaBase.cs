using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    public class PersonaBase : ICloneable
    {
        public PersonaBase()
        {

        }
        public PersonaBase(string CodiceFiscale)
        {
            this.CodiceFiscale = CodiceFiscale;
            this.DataNascita = new DateTime(1999,1,1);
            this.NomeCognome = "N/A";

        }
        public string NomeCognome { get; set; }
        public string CodiceFiscale { get; set; }
        private DateTime _dataNascita;

        public virtual DateTime DataNascita
        {
            get { return _dataNascita; }
            set { 
                if (value >= DateTime.Now) 
                {
                    throw new DataNascitaException("EXCEPTION:  Data non valida!", value);
                }
                _dataNascita = value; }
        }

        public int GetEta()
        {
            return (DateTime.Now - this.DataNascita).Days;
        }

        public override string ToString()
        {
            return String.Format("PERSONA: {0} - {1} Anni: {2}", this.NomeCognome, this.CodiceFiscale, this.GetEta()/365);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
