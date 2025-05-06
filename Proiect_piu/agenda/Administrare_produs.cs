using incercare_tema;
using produs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace agenda
{
    public class Administrare_produs
    {
        private Calculator[] pcuri;
        private int nr_prod;
        private const int nr_max_produse = 100;

        public Administrare_produs()
        {
            pcuri = new Calculator[nr_max_produse];
            nr_prod = 0;
        }

        public void AddProd(Calculator pc)
        {
            pcuri[nr_prod] = pc;
            nr_prod++;
        }

        public Calculator[] Get_produse(out int nr_prod)
        {
            nr_prod = this.nr_prod;
            return pcuri;
        }

        public List<Calculator> Cautare_prod(string numeCautat = null, string marcaCautata = null,
                                           string tipCautat = null, Servicii[] serviciiCautate = null)
        {
            List<Calculator> rezultate = new List<Calculator>();

            foreach (Calculator prod in pcuri)
            {
                if (prod == null) continue;

                bool numeMatches = string.IsNullOrEmpty(numeCautat) ||
                                 prod.nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase);

                bool marcaMatches = string.IsNullOrEmpty(marcaCautata) ||
                                  prod.marca.Equals(marcaCautata, StringComparison.OrdinalIgnoreCase);

                bool tipMatches = string.IsNullOrEmpty(tipCautat) ||
                                prod.tip.Equals(tipCautat, StringComparison.OrdinalIgnoreCase);

                bool serviciiMatches = serviciiCautate == null || serviciiCautate.Length == 0 ||
                                     (prod.GetServicii().Intersect(serviciiCautate).Any());

                if (numeMatches && marcaMatches && tipMatches && serviciiMatches)
                {
                    rezultate.Add(prod);
                }
            }
            return rezultate;
        }
    }
}
