//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamSystem.Corso.DatabaseEDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class vOrdini
    {
        public string RagioneSociale { get; set; }
        public int IDCliente { get; set; }
        public string Nazione { get; set; }
        public Nullable<decimal> Fatturato { get; set; }
        public Nullable<System.DateTime> DataOrdine { get; set; }
        public Nullable<decimal> Importo { get; set; }
        public int IDOrdine { get; set; }
    }
}
