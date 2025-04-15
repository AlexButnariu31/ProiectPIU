using incercare_tema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda
{
    public class Administrare_client
    {
        
        private Persoana[] persoane;
        private int nr_clienti;
        private const int nr_max_clienti = 100; //numarul de clienti care poate fi primit in service in acelasi timp 
        public Administrare_client()
        {
            persoane = new Persoana[nr_max_clienti];
            nr_clienti = 0;
        }

        public void AddClient(Persoana pers)
        {
            persoane[nr_clienti] = pers;
            nr_clienti++;
        }

        public Persoana[] Get_client(out int nr_clienti)
        {
            nr_clienti = this.nr_clienti;
            return persoane;
        }

        public Persoana Cautare_client(string nume_c, string prenume_c)
        {
            if (string.IsNullOrEmpty(nume_c) && string.IsNullOrEmpty(prenume_c))
                return new Persoana(string.Empty, string.Empty);
            Persoana clientCautat = new Persoana(
                nume_c ?? string.Empty,
                prenume_c ?? string.Empty);
            foreach (Persoana client in persoane)
            {
                if (client == null) continue;

                bool numeMatches = string.IsNullOrEmpty(nume_c) ||
                                  client.nume.Equals(clientCautat.nume, StringComparison.OrdinalIgnoreCase);
                bool prenumeMatches = string.IsNullOrEmpty(prenume_c) ||
                                     client.prenume.Equals(clientCautat.prenume, StringComparison.OrdinalIgnoreCase);
                if (numeMatches && prenumeMatches)
                {
                    return client;
                }
            }
            return new Persoana(string.Empty, string.Empty);
        }
        public List<Persoana> Cautare_Nume_Prenume(string numeCautat, string prenumeCautat)
        {
            List<Persoana> rezultate = new List<Persoana>();

            foreach (Persoana client in persoane)
            {
                if (client == null) continue;

                bool numeMatches = string.IsNullOrEmpty(numeCautat) ||
                                 client.nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase);

                bool prenumeMatches = string.IsNullOrEmpty(prenumeCautat) ||
                                    client.prenume.Equals(prenumeCautat, StringComparison.OrdinalIgnoreCase);

                if (numeMatches && prenumeMatches)
                {
                    rezultate.Add(new Persoana(client.nume, client.prenume));
                }
            }

            return rezultate;
        }
    }
}
