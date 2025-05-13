using incercare_tema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda
{
    public class Administrare_client_fisier
    {
        private const int nr_max_clienti = 100;
        private string nume_Fis;

        public Administrare_client_fisier(string nume_Fis)
        {
            this.nume_Fis = nume_Fis;
            Stream streamFisierText = File.Open(nume_Fis, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddClient(Persoana pers)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(nume_Fis, true))
            {
                streamWriterFisierText.WriteLine(pers.Conv_sir_fisier());
            }
        }

        public Persoana[] Get_persoane(out int nr_clienti)
        {
            Persoana[] clienti = new Persoana[nr_max_clienti];
            using (StreamReader streamReader = new StreamReader(nume_Fis))
            {
                string linieFisier;
                nr_clienti = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    clienti[nr_clienti++] = new Persoana(linieFisier);
                }
            }

            return clienti;
        }
        public bool ActualizeazaClient(Persoana vechi, Persoana nou)
        {
            try
            {
                int nrClienti;
                Persoana[] clienti = Get_persoane(out nrClienti);
                for (int i = 0; i < nrClienti; i++)
                {
                    if (clienti[i] != null && clienti[i].nume == vechi.nume && clienti[i].prenume == vechi.prenume)
                    {
                        clienti[i] = nou;
                        break;
                    }
                }
                File.WriteAllText(nume_Fis, string.Empty);
                foreach (var client in clienti)
                {
                    if (client != null)
                        AddClient(client);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StergeClient(Persoana deSters)
        {
            try
            {
                int nrClienti;
                Persoana[] clienti = Get_persoane(out nrClienti);
                List<Persoana> listaNoua = new List<Persoana>();
                foreach (var client in clienti)
                {
                    if (client != null && !(client.nume == deSters.nume && client.prenume == deSters.prenume))
                    {
                        listaNoua.Add(client);
                    }
                }
                File.WriteAllText(nume_Fis, string.Empty);
                foreach (var client in listaNoua)
                {
                    AddClient(client);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

