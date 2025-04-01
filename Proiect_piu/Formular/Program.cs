﻿using agenda;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using incercare_tema;

namespace Formular
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Formular form1 = new Formular();
            form1.Show();
            Application.Run();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
        public class Formular : Form
        {
            private Label lblLungime;
            private TextBox txtLungime;

            private Label lblLatime;
            private TextBox txtLatime;

            private const int LATIME_CONTROL = 150;
            private const int DIMENSIUNE_PAS_Y = 30;
            private const int DIMENSIUNE_PAS_X = 170;

            public Formular()
            {

                string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
                string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                // setare locatie fisier in directorul corespunzator solutiei
                // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
                string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
               Administrare_client_fisier adminC = new Administrare_client_fisier(caleCompletaFisier);
                int nrClienti = 0;
                Persoana[] persoane = adminC.Get_persoane(out nrClienti);
                //setare proprietati
                this.Size = new Size(400, 200);
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(100, 100);
                this.Font = new Font("Arial", 9, FontStyle.Bold);
                this.ForeColor = Color.LimeGreen;
                this.Text = "Informatii dreptunghi";

                //adaugare control de tip Label pentru 'Lungime';
                lblLungime = new Label
                {
                    Width = LATIME_CONTROL,
                    Text = "Lungime:",
                    BackColor = Color.LightYellow
                };
                this.Controls.Add(lblLungime);

                //adaugare control de tip TextBox pentru 'Lungime';
                txtLungime = new TextBox
                {
                    Width = LATIME_CONTROL,
                    Left = DIMENSIUNE_PAS_X
                };
                //this.Controls.Add(txtLungime);


                //adaugare control de tip Label pentru 'Latime';
                lblLatime = new Label
                {
                    Width = LATIME_CONTROL,
                    Text = "Latime:",
                    Top = DIMENSIUNE_PAS_Y,
                    BackColor = Color.LightYellow
                };
                this.Controls.Add(lblLatime);

                //adaugare control de tip TextBox pentru 'Latime'
                txtLatime = new TextBox
                {
                    Width = LATIME_CONTROL,
                    Location = new Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y)
                };
                this.Controls.Add(txtLatime);

            }
        }
    }
}
