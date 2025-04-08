using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace incercare_tema
{
    public class Persoana
    {
        private const char SEPARATOR_FISIER = ';';

        public string nume { get; set; }
        public string prenume { get; set; }

        public Persoana()
        {
            nume = string.Empty;
            prenume = string.Empty;
        }

        public Persoana(string _nume, string _prenume)
        {
            nume = _nume;
            prenume = _prenume;
        }

        public string Info_p()
        {
            return $"Nume: {nume}, Prenume: {prenume}";
        }

        public string Conv_sir_fisier()
        {
            string obiect_pers_fis = string.Format("{1}{0}{2}{0}",
                SEPARATOR_FISIER,
                (nume ?? "NECUNOSCUT"),
                (prenume ?? "NECUNOSCUT")
                );
            return obiect_pers_fis;
        }

        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_FISIER);
            this.nume = dateFisier[0];
            this.prenume = dateFisier[1];
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Persoana p = (Persoana)obj;
            return (nume == p.nume) && (prenume == p.prenume);
        }

        public override int GetHashCode()
        {
            return (nume + prenume).GetHashCode();
        }
        /*
         * public string ConversieLaSir_PentruFisier()
    {
        string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}",
            SEPARATOR_PRINCIPAL_FISIER,
            IdStudent.ToString(),
            (Nume ?? " NECUNOSCUT "),
            (Prenume ?? " NECUNOSCUT "),
            (string.Join("|", note)));

        return obiectStudentPentruFisier;
    }


    public Student(string linieFisier)
    {
        var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

        //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
        this.IdStudent = Convert.ToInt32(dateFisier[ID]);
        this.Nume = dateFisier[NUME];
        this.Prenume = dateFisier[PRENUME];
        string[] vNote = dateFisier[3].Split('|');
        note = new int[vNote.Length];
        SetNote(vNote);
    }
         */
    }
}
