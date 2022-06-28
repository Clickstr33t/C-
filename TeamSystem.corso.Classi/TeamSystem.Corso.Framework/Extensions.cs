using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSystem.Corso.Framework
{
    // ATTENZIONE SE NON VEDI L'EXTENSION METHOD CONTROLLA I RIFERIMENTI ED IL NAMESPACE
    public static class Extensions
    {
        public static bool isEmail(this string s)
        {
            return s.Contains("@");
        }

        public static bool isEmail(this string s, string dominio)
        {
            return s.Contains("@") && s.Contains(dominio);
        }
    }
}
