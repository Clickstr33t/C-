using System;

namespace TeamSystem.Corso.Strutture.Codice
{
    // ***********DICHIARAZIONE STRUCTS *************
    struct Cliente
    {
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
