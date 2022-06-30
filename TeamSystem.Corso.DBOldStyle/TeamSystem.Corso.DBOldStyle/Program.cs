using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.DBOldStyle
{
    internal class Program
    {
        // ======== STUDIO GESTIONE TRADIZIONALE DEI DATA BASE ==============
        static void Main(string[] args)
        {
            // STEP 1 SQL Server, Oracle, Odbc, OleDB
            // STEP 2 Connection -> SqlConnection ,Oracle Connection, OdbcConnection
            // STEP 3 Command -> SqlCommand...... (SELECT, INSERT, etc..)
            // STEP 4 DataAdapter -> SqlAdapter..... (Prende in carico il comando e si interfaccia con il database e li trasmette al dataset)
            // STEP 5 DataSet(possiamo considerarlo un db in memoria), Database(tabella in memoria)

            /* 
             * DataSet (Oggetto di tipo disconnesso dal database ma che lavora in memeria)
             * (STRUTTURA)
             *      N. DataTable
             *          N. DataRow
             *              N. DataColumn
            */
            // Reader(Connesso) -> SqlReader.... è l'esecuzione di un command MA in maniera connessa

            // STEP 1 ============= SQL SERVER ===================
                // Crea un server SQL con Sql Server / Sql Server Managment Studio

            // STEP 2 ============= CONNESSIONE ==================

                // nella stringa di connesione posso scegliere tra:
                // - integrated security = true >>> entra con le credenziali di windows
                // - user id = sa; password=*******; se voglio l'ingresso con le credenziali
            string connessione = @"data source=.\SQLEXPRESS; database=CorsoTeamSystem; integrated security=true";
            SqlConnection cn = new SqlConnection(connessione);
            cn.StateChange += Cn_StateChange;
            cn.Open();  
            Console.WriteLine(cn.ServerVersion);
            cn.Close();

            // STEP 3 ============== COMMAND =================

            string nazione = "IT";
            /*
             ERRORE (I parmetri vanno passati con la@):
                SqlCommand cmd = new SqlCommand("select * from Clienti where Nazione= + nazione, cn);
             */
            SqlCommand cmd = new SqlCommand("select * from Clienti where Nazione= @nazione", cn);
            cmd.Parameters.Add("@nazione", System.Data.SqlDbType.VarChar).Value = nazione;

            // STEP 4 ============== DATAADAPTER ===============

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            // STEP 5 ============== DATASET ===================
            DataSet ds = new DataSet();
            da.Fill(ds, "ClientiItalia");  // MANDA IN ESECUZIONE IL COMMAND e POSSO MANDARLO AD UN DATA_SET/DATA_TABLES
            da.FillSchema(ds.Tables["ClientiItalia"], SchemaType.Source);
            // NOTA: Il metodo Fill apre e chiude la connessione automaticamente;


            // NOTA: Per ciclare con un Table.Rows se scrivo var item me lo tipizza come Object quindi devo specificare DataRow
            Console.WriteLine("TABELLA CLIENTI ITALA DEL DATASET ds:");
            foreach (DataRow item in ds.Tables["ClientiItalia"].Rows)
            {
                Console.WriteLine("Cliente: {0}, Fatturato: {1}", item["RagioneSociale"], item["Fatturato"]);
            }

            // Aggiungere un altra datatable "Ordini" nel dataset ds STEP3+SEP4+STEP5
            // STEP 3
            SqlCommand cmdOrdini = new SqlCommand("select * from Ordini", cn);
            // STEP 4
            SqlDataAdapter daOrdini = new SqlDataAdapter(cmdOrdini);
            // STEP 5
            daOrdini.Fill(ds, "Ordini");
            Console.WriteLine("TABELLA ORDINI DEL DATASET ds:");
            foreach (DataRow item in ds.Tables["Ordini"].Rows)
            {
                Console.WriteLine("ID: {0}, Data Ordine: {1}, Importo: {2}", item["IDOrdine"], item["DataOrdine"], item["Importo"]);
            }

            //RICERCA CON METODO SELECT DEL DATASET
            DataRow[] clienti = ds.Tables["ClientiItalia"].Select("IDCliente=1");
            if (clienti.Length > 0)
            {
                
                Console.WriteLine("RICERCA CON METODO SELECT DEL DATASET: " + clienti[0]["RagioneSociale"]);
            }
            
            //RICERCA CON ILMETODO ROW.FIND DEL DATA SET (CERCA AUTOMATICAMENTE LA CHIAVE PRIMARIA)
            // IMPORTANTE! : Se non hai fatto il Fillschema avrà importato solo i dati e non la struttura
            DataRow altroCliente = ds.Tables["ClientiItalia"].Rows.Find(3);
            if (altroCliente != null)
            {
                Console.WriteLine("RICERCA CON METODO ROWS.FIND: " + altroCliente["RagioneSociale"]);
            }

            // MODIFICA

            // Tecnica 2: Posso utilizzare direttamente codice SQL

            // Tecnica 1 (Modifico direttamentil DataSet poi effettuo il Fill dei dat):
            altroCliente["Fatturato"] = decimal.Parse(altroCliente["Fatturato"].ToString()) + 1000;
            // Aggiornare il database 
            SqlCommandBuilder cb = new SqlCommandBuilder(da);//Prende in attributo il DataAdapter per fargli sapere come sono i metodi InsertCommand UpdateCommand & DeleteCommand
            // SE NON USO SqlComandBuilder il metodo update non funziona
            try
            {
                da.Update(ds.Tables["ClientiItalia"]);
                Console.WriteLine("Cliente Aggiornato");
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore: " + e.Message);
            }
        }

        private static void Cn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Console.WriteLine("Cambio stato da {0} a {1}", e.OriginalState, e.CurrentState);
        }

    }
}
