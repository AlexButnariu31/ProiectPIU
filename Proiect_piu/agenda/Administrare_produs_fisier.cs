using incercare_tema;
using produs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace agenda
{
    public class Administrare_produs_fisier
    {
        private const int nr_max_produse = 100;
        private string nume_Fis;
        private const char SEPARATOR_SERVICII = ',';

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

        public List<Calculator> Cautare_prod(string numeCautat = null, string marcaCautata = null,
                                           string tipCautat = null, Servicii[] serviciiCautate = null)
        {
            List<Calculator> rezultate = new List<Calculator>();
            Calculator[] produse;
            int nrProduse;

            produse = Get_produse(out nrProduse);

            foreach (Calculator prod in produse)
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
        public bool ActualizeazaProdus(Calculator vechi, Calculator nou)
        {
            try
            {
                int nrProduse;
                Calculator[] calculatoare = Get_produse(out nrProduse);
                for (int i = 0; i < nrProduse; i++)
                {
                    if (calculatoare[i] != null && calculatoare[i].nume == vechi.nume && calculatoare[i].marca == vechi.marca)
                    {
                        calculatoare[i] = nou;
                        break;
                    }
                }
                File.WriteAllText(nume_Fis, string.Empty);
                foreach (var calculator in calculatoare)
                {
                    if (calculator != null)
                        AddProdus(calculator);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StergeProdus(Calculator deSters)
        {
            try
            {
                int nrProduse;
                Calculator[] calculatoare = Get_produse(out nrProduse);
                List<Calculator> listaNoua = new List<Calculator>();
                foreach (var calculator in calculatoare)
                {
                    if (calculator != null && !(calculator.nume == deSters.nume && calculator.marca == deSters.marca))
                    {
                        listaNoua.Add(calculator);
                    }
                }
                File.WriteAllText(nume_Fis, string.Empty);
                foreach (var calculator in listaNoua)
                {
                    AddProdus(calculator);
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
