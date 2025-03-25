using produs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incercare_tema
{
    public class Calculator
    {
        private const char SEPARATOR_FISIER = ';';
        public Servicii serv { get; set; }
        string nume { get; set; }
        string marca { get; set; }

        public Calculator()
        {
            nume = string.Empty;
            marca = string.Empty;
        }

        public Calculator(string nume, string marca)
        {
            this.nume = nume;
            this.marca = marca;
        }
        public string Info()
        {
            return $"Nume:{nume}, Marca:{marca}, Scopul aducerii: {serv}";
        }

         public string Conv_sir_fisier()
        {
            string obiect_pers_fis = string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_FISIER,
                (nume ?? "NECUNOSCUT"),
                (marca ?? "NECUNOSCUT"),
                serv);
            return obiect_pers_fis;
        }

        public Calculator(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_FISIER);
            this.nume = dateFisier[0];
            this.marca = dateFisier[1];
            serv = (Servicii)Enum.Parse(typeof(Servicii), dateFisier[2]);
        }
    }
}
