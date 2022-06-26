using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Strutture
{
    //Dichiarazione di un ENUM (Preferibile specificare valori)
    enum Tipologia
    {
        DDT = 10,
        Fattura = 20,
        Preventivo = 30,
        Altro = 40

    }
    // Dichiarazione di una Struttura
    struct Cliente
    {   
        //property formato compatto
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        //property formato completo
        private string _partitaIVA;

        public string PartitaIVA
        {
            get { return _partitaIVA; }
            set {
                if (value.Length < 10)
                {
                    throw new Exception("Partita iva non corretta, minimo 10 caratteri");
                }
                _partitaIVA = value; 
            }
        }


    }
    internal class Program
    {   
        //Main per testare structs
        static void Main(String[] args)
        {
            Cliente c1 = new Cliente()
            {
                RagioneSociale = "Andrea Paffi",
                PartitaIVA = "235346"
            };
            
            // Invece di inizializzare ogni singolo campo posso usare le {}
             c1.RagioneSociale = "Nome cliente";
            // c1.PartitaIVA = "234567";
            Console.WriteLine(c1.RagioneSociale);
        }
        // Main per testare enum
        static void Main_enum(string[] args)
        {
            Tipologia t = Tipologia.DDT;
            if (t == Tipologia.DDT)
            {
                Console.WriteLine("ok");
            }

            //Visual Studio auto compila lo switch se uso un enum
            switch (t)
            {
                case Tipologia.DDT:
                    break;
                case Tipologia.Fattura:
                    break;
                case Tipologia.Preventivo:
                    break;
                case Tipologia.Altro:
                    break;
                default:
                    break;
            }
        }
    }
}
