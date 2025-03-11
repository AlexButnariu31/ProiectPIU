using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace incercare_tema
{
    public class Persoana
    {
        string nume;
        string prenume;

        public Persoana()
        {
            nume = string.Empty;
            prenume = string.Empty;
        }

        public Persoana(string _nume, string _prenume)
        {
            nume = _nume;
            prenume = _prenume;
        }

        public string Info_p()
        {
            return $"Nume: {nume}, Prenume: {prenume}";
        }
    }
}
