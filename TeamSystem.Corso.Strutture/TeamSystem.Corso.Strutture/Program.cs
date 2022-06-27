using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSystem.Corso.Strutture.Codice;

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

    internal class Program
    { 
        static List<Cliente> GetClienti()
        {
            List<Cliente> ris = new List<Cliente>();
            ris.Add(new Cliente()
            {
                CodiceCliente = 1,
                Importo = 4000,
                Nazione = "IT",
                RagioneSociale = "Cliente1",
            });
            ris.Add(new Cliente()
            {
                CodiceCliente = 2,
                Importo = 6000,
                Nazione = "IT",
                RagioneSociale = "Cliente2",
            });
            ris.Add(new Cliente()
            {
                CodiceCliente = 3,
                Importo = 1000,
                Nazione = "UK",
                RagioneSociale = "Cliente3",
            });
            ris.Add(new Cliente()
            {
                CodiceCliente = 4,
                Importo = 2500,
                Nazione = "UK",
                RagioneSociale = "Cliente4",
            });
            ris.Add(new Cliente()
            {
                CodiceCliente = 5,
                Importo = 10000,
                Nazione = "IT",
                RagioneSociale = "Cliente5",
            });
            return ris;

        }
        
        static List<Ordine> GetOrdini()
        {
            List<Ordine> ris = new List<Ordine>();
            ris.Add(new Ordine()
            {
                CodiceCliente = 1,
                CodiceOrdine = 1,
                Importo = 1000,
                DataOrdine = DateTime.Now
            });
            ris.Add(new Ordine()
            {
                CodiceCliente = 1,
                CodiceOrdine = 2,
                Importo = 2000,
                DataOrdine = DateTime.Now
            });
            ris.Add(new Ordine()
            {
                CodiceCliente = 2,
                CodiceOrdine = 3,
                Importo = 4000,
                DataOrdine = DateTime.Now
            });
            return ris;
        }

        // ===============Main per testare creazione di strutture con EVENTI ===========================
        static void Main(String[] args)
        {
            List<Cliente> Clienti = GetClienti();
            List<Ordine> Ordini = GetOrdini();

            var clienteConEvento = new Cliente() { PartitaIVA = "000111111111" };      // 4(EVENTO) - Istanza della struttura dove attaccare l'evento

            clienteConEvento.OnCambioPIVA += ClienteEvento_OnCambioPIVA;              // 5(EVENTO) - Subscribe dell'evento nella istanza (PREMI TAB PER GENERARE AUTOMATICAMENTE L'EVENTO)
            clienteConEvento.PartitaIVA = "ProvaCambioPartitaIVA";
            clienteConEvento.PartitaIVA = "UlterioreCambioPIVA";
        }

        // 5(EVENTO) - Metodo generato automaticamente premendo TAB
        private static void ClienteEvento_OnCambioPIVA(string VecchiaPiva, string NuovaPiva)
        {
            Console.WriteLine(string.Format("PIVA modificata da {0} a {1}", VecchiaPiva, NuovaPiva)); 
        }



        //===============Main per testare EXTENSION METHODS ==========================
        static void Main_Extension_Methods(String[] args)
        {
            List<Cliente> Clienti = GetClienti();
            List<Ordine> Ordini = GetOrdini();

            //*************QUERY CON EXTESION METHODS*****************

            //  EXE EXE EXE  Voglio otterenere una lista con soli clienti italiani
            //ToList() è un metodo di materializzazione da query a oggetto List            
            var clientiItalia = Clienti
                .Where(x => x.Nazione == "IT")
                .OrderByDescending(x => x.RagioneSociale)
                .ToList();

            foreach (var clienti in clientiItalia)
            {
                Console.WriteLine(clienti.RagioneSociale);
            }

            //  EXE EXE EXE  Voglio otternere il cliente con codice 1
            var cliente = Clienti
                .Where(x => x.CodiceCliente ==10)
                .FirstOrDefault(); // Se non trova nulla restituisce valore nullo
                //.First(); // Lancia un eccezione se la query non trova nulla .Last() fa lo stesso
            if (!string.IsNullOrEmpty(cliente.RagioneSociale))
            {
                Console.WriteLine(cliente.CodiceCliente + ": "+cliente.RagioneSociale);
            }

            //  EXE EXE EXE  Voglio sommare tutti gli importi dei clienti
            var sommaImporto = Clienti
                .Sum(x => x.Importo);
            Console.WriteLine(sommaImporto);

            //  EXE EXE EXE  Volgio restituire solo uno specifico campo
            var demo = Clienti
                //.Select(x => x.CodiceCliente)
                .Select(x => new { Cod = x.CodiceCliente, Rag = x.RagioneSociale })  //PER PIU CAMPI new + {camp1, campo2}
                .ToList();
            foreach (var item in demo)
            {
                Console.WriteLine(item.Cod + " - " + item.Rag);
            }

            // EXE EXE EXE  Vogliamo ottenere il risultato totale per nazione
            var statistiche = Clienti
                .GroupBy(x => x.Nazione)
                .Select(x => new {  Nazione = x.Key, 
                                    Somma = x.Sum(y => y.Importo),
                                    Conteggio = x.Count(),
                                    Media = x.Average(y => y.Importo)                
                                  })
                //.Where(x => x.Somma > 20000) // Posso applicare tutte le extenction methods
                .OrderByDescending(x => x.Conteggio)
                .ToList();
            foreach (var item in statistiche)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Nazione: " + item.Nazione);
                Console.WriteLine("Somma:" + item.Somma);
                Console.WriteLine("Conteggio:" + item.Conteggio);
                Console.WriteLine("Media:" + item.Media);
                Console.WriteLine("---------------------------");

            }

            //  EXE EXE EXE  Voglio fare un join della lista Clienti e Ordini

            var clientiOrdini = Clienti
                .Join(
                    Ordini,
                    x => x.CodiceCliente,
                    y => y.CodiceCliente,
                    (x, y) => new {
                        Cliente = x.CodiceCliente,
                        Nazione = x.Nazione,
                        Ordine = y.CodiceOrdine,
                        ImportoOrdine = y.Importo
                    }
                )
                //.Take(2) //Permette di selezionare il primo, i primi due etc..
                .ToList();

            foreach (var item in clientiOrdini)
            {
                Console.WriteLine(
                    "Cliente "+item.Cliente +
                    " di nazionalità " + item.Nazione +
                    " > Ordine "+ item.Ordine +
                    " di importo " + item.ImportoOrdine);
            }

            // EXE EXE EXE Voglio restituire il cliente con importo più alto

            var maxCliente = Clienti
                .Select(x => new
                {
                    ID = x.CodiceCliente,
                    Importo = x.Importo,
                })
                .OrderByDescending(x => x.Importo)
                .FirstOrDefault();
                

            Console.WriteLine(
                "ALTO IMPORTO Cliente: " + 
                maxCliente.ID +
                " Importo : " +
                maxCliente.Importo);

            // EXE EXE EXE Voglio restituire il cliente con importo più alto per singola nazione

            var maxPerNazione = Clienti
                .GroupBy(x => x.Nazione)
                .Select(x => new
                {
                    Nazione = x.Key,
                    Max = x.Max(y => y.Importo)
                })
                .ToList();

            Console.WriteLine("VALRE MASSIMO PER NAZIONE:");
            foreach (var item in maxPerNazione)
            {
                Console.WriteLine(item.Nazione + " >>> " + item.Max);
            }
     

            // ********** QUERY CON LINQ ***************

            var clientiDemo1 = (from x in Clienti
                               where x.Nazione == "IT"
                               select x)
                               .ToList();
            Console.WriteLine("*********  CON LINQ ***********");
            foreach (var item in clientiDemo1)
            {
                Console.WriteLine("Nome: " + item.RagioneSociale);
                Console.WriteLine("ID: " + item.CodiceCliente);
                Console.WriteLine("Nazione: " + item.Nazione);
                Console.WriteLine("-------------------");
            }
            Console.WriteLine("*********  CON LINQ ***********");
        }
        // ==============Main per testare COLLECTIONS ================
        static void Main_collections(String[] args)
        {

            //********ARRAY LIST**********
            ArrayList clienti = new ArrayList();
            clienti.Add(new Cliente() { RagioneSociale="Cliente1"});
            clienti.Add(new Cliente("1234567890"));
            // nell'array list posso aggiungere oggetti di vario tipo
            clienti.Add(DateTime.Now);

            /* nel seguente modo quando cicla un oggetto che non è Cliente lancia un eccezione
            foreach (Cliente c in clienti)
            {
                Console.WriteLine(c.RagioneSociale);
            }
            */
            //SOLUZIONE
            foreach (Object c in clienti)
            {   
                if (c is Cliente)
                {
                    Console.WriteLine(((Cliente)c).RagioneSociale);
                }
                else
                {
                   Console.WriteLine("Oggeto sconosciuto");
                }

            }

            //****+++++*****HASH TABLE*******++++*****
            Hashtable esempio = new Hashtable();
            esempio.Add(1, "esempio1");
            esempio.Add(2, DateTime.Now);
            esempio.Add("prova", 10);

            //PROBLEMA LIST E ASHTABLE POSSONO ESSER COMPILATI CON QUALSIASI OGGETTO
            //PER OVVIARE IL PROBLEMA USARE I GENERICS 

            //*********LISTE TIPICIZZATE (Generics) *************
            List<Cliente> elenco2 = new List<Cliente>();
            elenco2.Add(new Cliente("2121212121"));
            elenco2.Add(new Cliente("32324234342"));

            //Non devo fare nessun controllo/cast
            Cliente primo = elenco2[0];
            foreach (var item in elenco2)
            {
                Console.WriteLine(item.PartitaIVA);
            }
            
            //***********DICTIONARY****************
            Dictionary<int, Cliente> esempioDic = new Dictionary<int, Cliente>(); 
            esempioDic.Add(1, new Cliente("ProvaDictionary1"));
            esempioDic.Add(2, new Cliente("ProvaDictionary2"));

            var cx = esempioDic[2];

            Console.WriteLine(cx.PartitaIVA);
        }


        // =================== Main per testare STRUCTS =====================
        static void Main_Strutture(String[] args)
        {

            Cliente c1 = new Cliente()
            {
                RagioneSociale = "Andrea Paffi",
                PartitaIVA = "23534686987684"
            };
            
            // Invece di inizializzare ogni singolo campo posso usare le {}
             c1.RagioneSociale = "Nome cliente";
             //c1.PartitaIVA = "234567";
            Console.WriteLine(c1.RagioneSociale);

            Cliente c2 = new Cliente("1234567890");

            Cliente c3 = new Cliente("nome", "indirizzo");


        }
        // ==========================Main per testare ENUM ============================
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
