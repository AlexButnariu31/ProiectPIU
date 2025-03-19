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
            Persoana pers_c;
            pers_c = new Persoana(nume_c, prenume_c);
            foreach (Persoana prod in persoane)
            {
                if (pers_c == prod)
                {
                    return pers_c;

                }

            }
            Persoana p;
            p = new Persoana(string.Empty, string.Empty);
            return p;
        }
        /*
        public (Student[] studenti, Clase[] clase, int nrStudenti, int nrClase) GetStudentiSiClase()
        {
            int nrStudenti = this.nrStudenti;
            int nrClase = this.nrClase;

            return (studenti, clase, nrStudenti, nrClase);
        } 
        
        public void AddStudent(Student student)
        {
            studenti[nrStudenti] = student;
            nrStudenti++;
        }

        public Student[] GetStudenti(out int nrStudenti)
        {
            nrStudenti = this.nrStudenti;
            return studenti;
        }
        */
    }
}
