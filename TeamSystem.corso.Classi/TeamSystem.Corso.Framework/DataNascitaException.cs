using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    // ========= CREAZIONE EXCEPTION CUSTOM ============ 
    public class DataNascitaException :Exception
    {
        public DateTime DataConErrore { get; set; }
        public DataNascitaException(string msg,DateTime data) : base(msg)
        {
            DataConErrore = data;
        }
    }
}
