using incercare_tema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda 
{
    public class Administrare_client_produs
    {
        //private const int NR_MAX_STUDENTI = 50;

        //private Student[] studenti;
        //private int nrStudenti;
        private Persoana[] persoane;
        private Calculator[] pcuri;
        private int nr_prod;
        private const int nr_max_produse = 100; //numarul de calculatoare (respectiv clienti) care poate fi primit in service in acelasi 
                                                //timp daca se vrea sa se mai adauge un calculator trebuie eliberat locul
        public Administrare_client_produs()
        {
            persoane = new Persoana[nr_max_produse];
            pcuri = new Calculator[nr_max_produse];
            nr_prod = 0;
        }

        public void AddProd(Persoana pers, Calculator pc)
        {
            persoane[nr_prod] = pers;
            pcuri[nr_prod] = pc;
            nr_prod++;
        }

        public (Persoana[], Calculator[]) Get_produse(out int nr_prod)
        {
            nr_prod = this.nr_prod;
            return (persoane,pcuri);
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
