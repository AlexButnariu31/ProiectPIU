using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using produs;
using agenda;
using incercare_tema;
using System.Configuration;
using System.IO;


namespace Formular
{
    public partial class Form1 : Form
    {
             private Label lblLungime;
        private TextBox txtLungime;


        private TextBox txtLatime;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;

        public Form1()
        {

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier_c"];
            Administrare_client_fisier adminC = new Administrare_client_fisier(numeFisier);
            int nrClienti = 0;
            Persoana[] persoane = adminC.Get_persoane(out nrClienti);


            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
            this.ForeColor = Color.Blue;
            this.Text = "Informatii clienti";
            this.BackColor = Color.White;

            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };


            Label lblHeader = new Label
    {
        Text = "Clienții ale căror produse sunt în service:",
        AutoSize = false,
        TextAlign = ContentAlignment.MiddleCenter,
        Dock = DockStyle.Top,
        Font = new Font("Comic Sans MS", 14, FontStyle.Bold),
        ForeColor = Color.Blue,
        Height = 50
    };
    mainPanel.Controls.Add(lblHeader);

    ListBox listBoxClienti = new ListBox
    {
        Dock = DockStyle.Fill,
        Font = new Font("Comic Sans MS", 12),
        ForeColor = Color.Blue,
        BorderStyle = BorderStyle.None,
        BackColor = Color.White
    };

    if (persoane != null && nrClienti > 0)
    {
        foreach (Persoana persoana in persoane)
        {
            if (persoana != null)
            {
                        listBoxClienti.Items.Add(persoana.Info_p());
            }
        }
    }
    else
    {
        listBoxClienti.Items.Add("Nu există clienți în fișier!");
        listBoxClienti.ForeColor = Color.Red;
    }

    mainPanel.Controls.Add(listBoxClienti);
    this.Controls.Add(mainPanel);
        }
    }
    
}
