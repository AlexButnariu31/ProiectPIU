using incercare_tema;
using produs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda
{
    public class Administrare_produs
    {
        private Calculator[] pcuri;
        private int nr_prod;
        private const int nr_max_produse = 100; //numarul de calculatoare (respectiv clienti) care poate fi primit in service in acelasi 
                                                //timp daca se vrea sa se mai adauge un calculator trebuie eliberat locul
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

        public List<Calculator> Cautare_prod(string numeCautat = null, string marcaCautata = null, Servicii? scopCautat = null)
        {
            List<Calculator> rezultate = new List<Calculator>();

            foreach (Calculator prod in pcuri)
            {
                if (prod == null) continue;

                bool numeMatches = string.IsNullOrEmpty(numeCautat) ||
                                 prod.nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase);

                bool marcaMatches = string.IsNullOrEmpty(marcaCautata) ||
                                  prod.marca.Equals(marcaCautata, StringComparison.OrdinalIgnoreCase);

                bool scopMatches = !scopCautat.HasValue ||
                                 prod.serv == scopCautat.Value;

                if (numeMatches && marcaMatches && scopMatches)
                {
                    rezultate.Add(prod);
                }
            }

            return rezultate;
        }
    }
}

