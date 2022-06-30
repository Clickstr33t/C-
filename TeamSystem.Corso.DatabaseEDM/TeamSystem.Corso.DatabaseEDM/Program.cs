using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.DatabaseEDM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ============== LETTURA DATI =========================

            // ********* DICHIARAZIONE DEL CONTESTO ***************

            //ctx sta per contesto (scelta semantica)
            CorsoTeamSystemEntities ctx = new CorsoTeamSystemEntities();
           
            // ************ QUERY NAZIONALITA' ITALIANA ************
            var clientiItalia = ctx.Clienti
                .Where(x => x.Nazione == "IT")
                .ToList();
            Console.WriteLine("CLIENTI DI NAZIONALITA' ITALIANA:");
            foreach (var cliente in clientiItalia)
            {
                Console.WriteLine(cliente);
                //Uso delle proprietà di navigazione:
                var ordiniCliente = cliente.Ordini.ToList();
                Console.WriteLine("ORDINI:");
                foreach (var ordine in ordiniCliente)
                {
                    Console.WriteLine("ID: " + ordine.IDOrdine);
                }
                Console.WriteLine("====================");
            }

            // ************** QUERY CLIENTE ID N.1*************

            var cliente1 = ctx.Clienti
                .Where(x => x.IDCliente == 1)
                .FirstOrDefault();
            Console.WriteLine("\nCLIENTI ID1:");
            if (cliente1 != null)
            {
                Console.WriteLine(cliente1);
            }

            // *********** QUERY STATS CON GROUP BY *********************

            var statistiche = ctx.Clienti
                .GroupBy(x => x.Nazione)
                .Select(x => new { naz = x.Key, tot = x.Sum(y => y.Fatturato) })
                .ToList();
            Console.WriteLine("\nFATTURATO PER NAZIONE:");
            foreach (var item in statistiche)
            {
                Console.WriteLine(item.naz + " - " + item.tot);
            }

            // *********** QUERY DI UNA VISTA **************

            Console.WriteLine("\nVista ordini:");
            foreach (var item in ctx.vOrdini)
            {
                Console.WriteLine(item.RagioneSociale + " - " + item.DataOrdine.ToString());
            }

            // ============SCRITTURA DATI =========================

            // *********** Aggiungere un cliente *************

            var nuovoCliente = new Clienti() { RagioneSociale = "Nuovo cliente", Nazione = "IT", Fatturato = 0 };
            ctx.Clienti.Add(nuovoCliente);

            // *********** Aggiungere un nuovo ordine ***********

            // IMPORTANTE STIAMO INSERENDO Clienti al posto di IDCliente PERCHE' STIAMO USANDO LE PROPRIETA DI NAVIGAZIONE
            var nuovoOrdine = new Ordini() { Importo = 3000, DataOrdine = DateTime.Now, Clienti = nuovoCliente };
            ctx.Ordini.Add(nuovoOrdine);

            // ********** Modificare un cliente *************
            var clienteDaModificare = ctx.Clienti.FirstOrDefault();
            if (clienteDaModificare != null)
            {
                clienteDaModificare.Fatturato = 1000;
                Console.WriteLine("Importo di " + clienteDaModificare.RagioneSociale + " modificato a 1000");
            }

            // ********** Rimuovere un cliente ***********
            var clientiDaCancellare = ctx.Clienti
                .Where(x => x.RagioneSociale == "Nuovo Cliente")
                .ToList();


            foreach (var cliente in clientiDaCancellare)
            {
                // ********** Prima devo rimuovere tutti gli ordini assocciati ******
                //STEP1 LI CERCO E LI INSERISCO IN UN LIST
                var ordiniDaCancellare = ctx.Ordini
                    .Where(x => x.IDCliente == cliente.IDCliente)
                    .ToList();
                //STEP2 LI ELIMINO
                foreach (var ordine in ordiniDaCancellare)
                {
                    ctx.Ordini.Remove(ordine);
                    Console.WriteLine("Rimosso ordine: " + ordine.IDOrdine);
                }

                // Ora che non ho conflitti di relazione posso eliminare il Cliente
                ctx.Clienti.Remove(cliente);
                Console.WriteLine("Rimosso Cliente: " + cliente.IDCliente);
            }


            // ************ SALVATAGGIO DB ******************
            try
            {
                ctx.SaveChanges(); //solo in questo momento si effettua il **** SALVATAGGIO **** effettivo
                // NOTA: il codice ID clienti viene generato dal database dopo aver salvato
                Console.WriteLine("Cliente aggiunto con ID: " + nuovoCliente.IDCliente);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERRORE: " + e.Message);
            }

            // ********* RICHIAMARE UNA CUSTOM STORE PROCEDURE ****************

            /*
             *  CREAZIONE SP (SQL CODE):
                create proc p_InserisciCiente @RagioneSociale varchar(100), @nazione varchar(100)
                as
                insert into Clienti(RagioneSociale, Nazione) values (@RagioneSociale, @nazione)
                
                APPENA CREATA LA SP AGGIORA L'EDM PER RICHIAMARLA DA VISUAL STUDIO

                CHIAMATA SP (SQL CODE):
                exec p_InserisciCiente 'Test SP','IT'
             */

            ctx.p_InserisciCiente("INSERIMENTO DA SP", "IT");


            /*
             Seconda Stor Preocedure
            
             CODICE:
            create proc p_GetClientiPerNazione @nazione varchar(50)
            as
            select * from Clienti where nazione = @nazione

            CHIAMATA SQL:
            exec p_GetClientiPerNazione "IT"
            */

            var clientiDaSP = ctx.p_GetClientiPerNazione("IT").ToList();
            foreach (var item in clientiDaSP)
            {
                Console.WriteLine("Da PS: " + item.RagioneSociale);
           }

            // video 1 giorno 4 41:06
        }
    }
}
 