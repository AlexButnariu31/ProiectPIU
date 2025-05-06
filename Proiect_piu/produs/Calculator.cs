using produs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace incercare_tema
{
    public class Calculator
    {
        private const char SEPARATOR_FISIER = ';';
        private const char SEPARATOR_SERVICII = ',';
        private const int MAX_SERVICII = 3;

        public Servicii[] serv { get; private set; }
        public string nume { get; set; }
        public string marca { get; set; }
        public string tip { get; set; }

        public Calculator()
        {
            nume = string.Empty;
            marca = string.Empty;
            tip = string.Empty;
            serv = Array.Empty<Servicii>();
        }

        public Calculator(string nume, string marca, string tip, Servicii[] servicii)
        {
            this.nume = nume;
            this.marca = marca;
            this.tip = tip;
            SetServicii(servicii);
        }

        public string Info()
        {
            string serviciiStr = serv.Length > 0 ? string.Join(", ", serv.Select(s => s.ToString())) : "Niciun serviciu";
            return $"Nume:{nume}, Marca:{marca}, Tip:{tip}, Servicii: {serviciiStr}";
        }

        public string Conv_sir_fisier()
        {
            string serviciiStr = serv.Length > 0 ? string.Join(SEPARATOR_SERVICII.ToString(), serv.Select(s => (int)s)) : "";
            return string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SEPARATOR_FISIER,
                (nume ?? "NECUNOSCUT"),
                (marca ?? "NECUNOSCUT"),
                (tip ?? "NECUNOSCUT"),
                serviciiStr);
        }

        public Calculator(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_FISIER);
            this.nume = dateFisier[0];
            this.marca = dateFisier[1];
            this.tip = dateFisier.Length > 2 ? dateFisier[2] : string.Empty;

            if (dateFisier.Length > 3 && !string.IsNullOrEmpty(dateFisier[3]))
            {
                var serviciiIds = dateFisier[3].Split(SEPARATOR_SERVICII)
                                              .Where(s => !string.IsNullOrEmpty(s))
                                              .Select(int.Parse)
                                              .ToArray();
                this.serv = serviciiIds.Select(id => (Servicii)id).ToArray();
            }
            else
            {
                this.serv = Array.Empty<Servicii>();
            }
        }

        public void SetServicii(Servicii[] servicii)
        {
            if (servicii == null || servicii.Length == 0)
            {
                serv = Array.Empty<Servicii>();
                return;
            }

            serv = servicii.Take(MAX_SERVICII).ToArray();
        }

        public Servicii[] GetServicii()
        {
            return serv;
        }
    }
}
