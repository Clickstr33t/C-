using System;

namespace TeamSystem.Corso.Strutture.Codice
{
    // ***********DICHIARAZIONE STRUCTS *************
    struct Cliente
    {
        // **************** INIZIALIZZAZIONE EVENTI *****************
        /*
         Per creare un evento bisogna fare le seguent operazioni:
        1(EVENTO) - Dichiarare un DELEGATO con relativa firma all'interno della struttura
        2(EVENTO) - Dichiarare un EVENTO di tipo DELEGATO all'interno della struttura
        3(EVENTO) - Settare la condizione sul setter per lanciare l'evento >>> ATTENZIONE ricordati di mettere il controllo "if (OnCambioPIVA != null)"
        4(EVENTO) - Istanziare nel Main la struttura nel quale attaccare l'evento
        5(EVENTO) - Effettuare il subscribe dell'evento nell'instanza nel Main >> TAB genera in automatico l'evento
         */
        public delegate void CambioPIVADelegate(string VecchiaPiva, string NuovaPiva);  // 1(EVENTO) Dichiarazione DELEGATO
        public event CambioPIVADelegate OnCambioPIVA;                                   // 2(EVENTO) Dichiarazione EVENTO (Ricorda di inizializzare i costruttori della struttura) 


        //*******************PROPRIETA*************************

        // (prop + TABx2) property formato compatto
        public decimal Importo { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public string Nazione { get; set; }
        public int CodiceCliente { get; set; }


        // (propfull + TABx2) property formato completo con getter/setter
        private string _partitaIVA;

        public string PartitaIVA
        {
            get { return _partitaIVA; }
            set
            {
                if (value.Length < 10)
                {
                    throw new Exception("Partita iva non corretta, minimo 10 caratteri");
                }
                if (value!= _partitaIVA)            //3 (EVENTO) chiam l'evento se il nuovo valore è diverso dal precedente
                {
                    if (OnCambioPIVA != null)       //3 (EVENTO) controllo OnCambiPIVA sia stato effettivamente instanziato
                    {
                        OnCambioPIVA(_partitaIVA, value);
                    }
                }
                _partitaIVA = value;
            }
        }


        // **************COSTRUTTORI********************

        // (ctro +  TABx2) per generare un costruttore
        public Cliente(string piva)
        {
            // ======inizializzazione dei field========
            this._partitaIVA = piva;
            this.RagioneSociale = "Cliente appena generato";
            this.Indirizzo = "N/A";
            this.Nazione = "IT";
            this.CodiceCliente = 0;
            this.Importo = 0;
            this.OnCambioPIVA = null;

            // ========logica aggiuntiva============

            // per implementare il controllo della fullprop posso farlo solo dopo
            // averlo inizializzato
            PartitaIVA = piva;
        }
        public Cliente(string nome, string Indirizzo)
        {
            this._partitaIVA = "N/A";
            this.RagioneSociale = nome;
            this.Indirizzo = Indirizzo;
            this.Nazione = "IT";
            this.CodiceCliente = 0;
            this.Importo = 0;
            this.OnCambioPIVA = null;
        }
    }


    struct Ordine
    {
        public int CodiceCliente { get; set; }
        public int CodiceOrdine { get; set; }
        public decimal Importo  { get; set; }
        public DateTime DataOrdine { get; set; }

    }
}
