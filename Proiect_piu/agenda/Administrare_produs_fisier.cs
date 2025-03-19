using incercare_tema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda
{
    public class Administrare_produs_fisier
    {
        private const int nr_max_produse = 100;
        private string nume_Fis;

        public Administrare_produs_fisier(string nume_Fis)
        {
            this.nume_Fis = nume_Fis;
            Stream streamFisierText = File.Open(nume_Fis, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddProdus(Calculator calc)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(nume_Fis, true))
            {
                streamWriterFisierText.WriteLine(calc.Conv_sir_fisier());
            }
        }

        public Calculator[] Get_produse(out int nr_produse)
        {
            Calculator[] produse = new Calculator[nr_max_produse];
            using (StreamReader streamReader = new StreamReader(nume_Fis))
            {
                string linieFisier;
                nr_produse = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    produse[nr_produse++] = new Calculator(linieFisier);
                }
            }

            return produse;
        }
    }
}

