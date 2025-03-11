using agenda;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incercare_tema
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Calculator c1 =new Calculator("NitroV", "Acer");
            string s1 = c1.Info();
            Console.WriteLine(s1);
            Console.WriteLine();

            Agenda a1 = new Agenda("NitroV", "Acer", "34hgd4", 700);
            string s2 = a1.Info_a();
            Console.WriteLine(s2);
            Console.WriteLine();

            Persoana p1 = new Persoana("Butnariu", "Alexandru");
            string s3 = p1.Info_p();
            Console.WriteLine(s3);
            Console.WriteLine();
            */

            string n, p;
            Console.WriteLine($"Nume client:");
            n = Console.ReadLine();
            Console.WriteLine($"Prenume client:");
            p = Console.ReadLine();
            Persoana p2;
            p2 = new Persoana(n, p);
            string s = p2.Info_p();
            Console.WriteLine(s);
            Console.WriteLine();

            Calculator c2;
            string num_c, mar_c;
            Console.WriteLine($"Nume calculator:");
            num_c = Console.ReadLine();
            Console.WriteLine($"Marca calculator:");
            mar_c = Console.ReadLine();
            c2 = new Calculator(num_c,mar_c);
            string s4 = c2.Info();
            Console.WriteLine(s4);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Test vector administrare");     //este posibil sa modific sau sa scot complet versiunea actuala a 
                                                                //clasei Administrare_client_produs
            Console.WriteLine();
            Console.WriteLine();

            int numar_prod = 0;
            int nr;
            //string sir;
            //sir=Console.ReadLine();
            Administrare_client_produs admin_c_p = new Administrare_client_produs();
            Console.WriteLine($"Dati numarul de clienti + calculatoare care trebuie adaugate:");
            nr = int.Parse(Console.ReadLine());
            for(int i=0; i<nr;i++)
            {
                string _n, _p;
                Console.WriteLine($"Nume client {i}:");
                _n = Console.ReadLine();
                Console.WriteLine($"Prenume client {i}:");
                _p = Console.ReadLine();
                Persoana pers = new Persoana(_n, _p);
                string numc, marc;
                Console.WriteLine($"Nume calculator {i}:");
                numc = Console.ReadLine();
                Console.WriteLine($"Marca calculator {i}:");
                marc = Console.ReadLine();
                Calculator calc = new Calculator(numc, marc);
                admin_c_p.AddProd(pers, calc);
                Console.WriteLine();
            }
            Console.WriteLine();
            (Persoana[] persoane, Calculator[] pcuri) = admin_c_p.Get_produse(out numar_prod);
            Console.WriteLine($"Clientii si produsele sunt:");
            for(int c=0; c< numar_prod; c++)
            {
                string info_pers = persoane[c].Info_p();
                string info_calc = pcuri[c].Info();
                Console.WriteLine($"{info_pers} detine calculatorul: {info_calc}");
            }
            /*
             public static void AfisareStudenti(Student[] studenti, int nrStudenti)
        {
            Console.WriteLine("Studentii sunt:");
            for (int contor = 0; contor < nrStudenti; contor++)
            {
                string infoStudent = studenti[contor].Info();
                Console.WriteLine(infoStudent);
            }
        }
             */
        }
    }
}
