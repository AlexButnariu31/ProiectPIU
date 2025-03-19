using agenda;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incercare_tema
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeFisier_c = ConfigurationManager.AppSettings["numeFisier_c"];
            Administrare_client_fisier adminclienti = new Administrare_client_fisier(numeFisier_c);
            string numeFisier_pc = ConfigurationManager.AppSettings["numeFisier_pc"];
            Administrare_produs_fisier adminprodus = new Administrare_produs_fisier(numeFisier_pc);
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

            //adminclienti.AddClient(p2);

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
            //adminprodus.AddProdus(c2);
            */

            
            Console.WriteLine($"Test vector administrare");     //este posibil sa modific sau sa scot complet versiunea actuala a 
                                                                //clasei Administrare_client_produs
            Console.WriteLine();
            Console.WriteLine();
            
            int numar_prod = 0;
            int nr;
            //string sir;
            //sir=Console.ReadLine();
            Administrare_client admin_c = new Administrare_client();
            Administrare_produs admin_p = new Administrare_produs();
            Console.WriteLine($"Dati numarul de clienti + calculatoare care trebuie adaugate:");
            nr = int.Parse(Console.ReadLine());
            for(int i=0; i<nr;i++)
            {
                string _n, _p;
                Console.WriteLine($"Nume client {i+1}:");
                _n = Console.ReadLine();
                Console.WriteLine($"Prenume client {i+1}:");
                _p = Console.ReadLine();
                Persoana pers = new Persoana(_n, _p);
                string numc, marc;
                Console.WriteLine($"Nume calculator {i+1}:");
                numc = Console.ReadLine();
                Console.WriteLine($"Marca calculator {i + 1}:");
                marc = Console.ReadLine();
                Calculator calc = new Calculator(numc, marc);
                //admin_c.AddClient(pers);
                //admin_p.AddProd(calc);
                adminclienti.AddClient(pers);
                adminprodus.AddProdus(calc);
                Console.WriteLine();

            }
            Console.WriteLine();
            Persoana[] persoane = admin_c.Get_client(out numar_prod);

            Calculator[] pcuri = admin_p.Get_produse(out numar_prod);

            Console.WriteLine($"Clientii si produsele sunt:");
            for(int c=0; c< numar_prod; c++)
            {
                string info_pers = persoane[c].Info_p();
                string info_calc = pcuri[c].Info();
                Console.WriteLine($"{info_pers} detine calculatorul: {info_calc}");
            }
            using (StreamReader sr = new StreamReader(numeFisier_c))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    Persoana p_1 = new Persoana(linie);
                    string info_p_1 = p_1.Info_p();
                    Console.WriteLine($"{info_p_1}");
                }
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
