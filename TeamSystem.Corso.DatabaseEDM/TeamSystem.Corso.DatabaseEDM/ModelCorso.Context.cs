﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CorsoTeamSystemEntities : DbContext
    {
        public CorsoTeamSystemEntities()
            : base("name=CorsoTeamSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<vOrdini> vOrdini { get; set; }
    
        public virtual int p_InserisciCiente(string ragioneSociale, string nazione)
        {
            var ragioneSocialeParameter = ragioneSociale != null ?
                new ObjectParameter("RagioneSociale", ragioneSociale) :
                new ObjectParameter("RagioneSociale", typeof(string));
    
            var nazioneParameter = nazione != null ?
                new ObjectParameter("nazione", nazione) :
                new ObjectParameter("nazione", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_InserisciCiente", ragioneSocialeParameter, nazioneParameter);
        }
    }
}