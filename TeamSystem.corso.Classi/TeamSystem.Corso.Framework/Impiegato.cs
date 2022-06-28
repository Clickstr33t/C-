using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    
    public enum Uffici
    {
        Commerciale = 10,
        RD =20,
        Tecnico = 30
    }
    public class Impiegato : PersonaBase
    {
        public Impiegato()
        {

        }
        public Impiegato(string CodiceFiscale) : base(CodiceFiscale) // INVOCA IL COSTRUTTORE DELLA CLASSE BASE  potrei anche scrivre :base("***TESTO PERSONALIZZATO***")   
        {
            this.Matricola = "N/A";
            this.Ufficio = Uffici.Commerciale;
        }

        public string Matricola { get; set; }
        public Uffici Ufficio { get; set; }
        
        //Override di ToString() sfruttando l'ereditarietà
        public override string ToString()
        {
            return String.Format("{0} IMPIEGATO: {1}", base.ToString(), Matricola);
        }

        //Override di una prop
        private DateTime _dataNascita;
        public sealed override DateTime DataNascita {
            get
            {
                return _dataNascita;   
            }
            set
            {
                if (value < new DateTime(1980, 1, 1))
                {
                    throw new Exception("Inserire data di nascita valida.");
                }
                _dataNascita = value;
            } 
        }
    }
}
