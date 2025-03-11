using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incercare_tema
{
    public class Calculator
    {
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
    }
}
