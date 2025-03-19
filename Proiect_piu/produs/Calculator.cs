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

        string nume, marca ;

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
            return $"Nume:{nume}, Marca:{marca}";
        }

         public string Conv_sir_fisier()
        {
            string obiect_pers_fis = string.Format("{1}{0}{2}{0}",
                SEPARATOR_FISIER,
                (nume ?? "NECUNOSCUT"),
                (marca ?? "NECUNOSCUT")
                );
            return obiect_pers_fis;
        }

        public Calculator(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_FISIER);
            this.nume = dateFisier[0];
            this.marca = dateFisier[1];
        }
    }
}
