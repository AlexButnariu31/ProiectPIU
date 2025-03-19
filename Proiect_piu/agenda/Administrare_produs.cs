using incercare_tema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda
{
    public class Administrare_produs
    {
        //private const int NR_MAX_STUDENTI = 50;

        //private Student[] studenti;
        //private int nrStudenti;
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

        public Calculator Cautare_prod(string nume_c, string marca_c)
        {
            Calculator prod_c;
            prod_c = new Calculator(nume_c, marca_c);
            foreach (Calculator prod in pcuri)
            {
                if (prod_c == prod)
                {
                    return prod_c;

                }

            }
            Calculator c;
            c = new Calculator(string.Empty, string.Empty);
            return c;
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
