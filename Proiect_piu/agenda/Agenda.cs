using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using produs;

namespace incercare_tema
{
    public class Agenda : Calculator
    {
        string cod;
        int pret;
        DateTime data_r;

        public Agenda()
        {
            cod = string.Empty;
            pret = 0;
            data_r = DateTime.MinValue;
        }

        public Agenda(string nume, string marca, string tip, Servicii[] servicii, string _cod, int _pret)
            : base(nume, marca, tip, servicii)
        {
            cod = _cod;
            pret = _pret;
            data_r = DateTime.Now;
        }

        public string Info_a()
        {
            string s = Info();
            return $"{s} Cod:{cod}, Data preluare:{data_r.ToShortDateString()}, Pret:{pret}";
        }
    }
}
