﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSystem.Corso.Classi.Codice;
using TeamSystem.Corso.Framework;

namespace TeamSystem.Corso.Classi
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DTT doc1 = new DTT() { CodiceDocumento = 1, DataDocumento = DateTime.Now, ClienteSpedizione = "test"};
            Fattura doc2 = new Fattura() { CodiceDocumento = 2, DataDocumento = new DateTime(2022,06,25), ClienteFatturazione = "fatt" };

            // Ora è possibile effettuare una lista tipizzata secondo un interfaccia
            List<IDocumento> elencoDocs = new List<IDocumento>();
            elencoDocs.Add(doc1);
            elencoDocs.Add(doc2);
            // Posso effettuare query sfruttando solo che proprietà dichiarate nell'interfaccia
            var documentiNuovi = elencoDocs
                   .Where(x=> x.DataDocumento >= DateTime.Now.AddDays(-10))
                   .ToList();
            foreach (IDocumento documento in documentiNuovi)
            {   
                if (documento is DTT)
                {
                    Console.WriteLine("ClienteSpedizione: " + ((DTT)documento).ClienteSpedizione);
                }
                if (documento is Fattura)
                {
                    Console.WriteLine("ClienteFatturazione: " + ((Fattura)documento).ClienteFatturazione);
                }
            }
        }
        static void Main_Studio_Classi(string[] args)
        {
            // ATTENZIONE LE CLASSI VENGONO PASSATE PER RIFERIMENTO
            Persona p = new Persona() { Nome= "Andrea", Cognome ="Paffi", DataNascita=new DateTime(2001,1,1), test=2};
            Console.WriteLine(p.Cognome);
            Console.WriteLine("TEST: "+ p.test);
            Persona p1 = p;
            p.Cognome = "cambiato";
            // Dimostra che il che p1 non è una clonazione ma entrambi fanno riferimento alla stessa istanza
            Console.WriteLine(p1.Cognome);
            Console.WriteLine(p.Cognome);
            
            List<Persona> elenco = new List<Persona>();
            elenco.Add(p);
            Console.WriteLine(elenco.Count);

            Prodotto prod1 = new Prodotto() { CodiceProdotto=1, NomeProdotto="Prodotto1", PrezzoListino=5};

            // Chiamare il metodo statico di una classe statica 
            Console.WriteLine(Helper.NomeApplicazione);
            Console.WriteLine(Helper.CalcolaIVA(10000m));

            // Chiamare il metoto statico di una classe NON statica
            Console.WriteLine("NUMERI RANDOM DA UNO A 100:");
            Console.WriteLine(Prodotto.GeneraCodice());
            Console.WriteLine(Prodotto.GeneraCodice());
            Console.WriteLine(Prodotto.GeneraCodice());
            Console.WriteLine(Prodotto.GeneraCodice());

        }
    }
}