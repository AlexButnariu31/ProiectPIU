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
        int leftMargin = 20;
        int controlWidth = 200;

        public Form1()
        {

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier_c"];
            Administrare_client_fisier adminC = new Administrare_client_fisier(numeFisier);
            int nrClienti = 0;
            Persoana[] persoane = adminC.Get_persoane(out nrClienti);


            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
            this.ForeColor = Color.Blue;
            this.Text = "Informatii clienti";
            this.BackColor = Color.White;
            this.MinimumSize = new Size(800, 500);

            SplitContainer mainSplitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 70, 
                FixedPanel = FixedPanel.Panel1
            };

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightBlue
            };

            Label lblHeader = new Label
            {
                Text = "Gestionare clienți service",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Comic Sans MS", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            headerPanel.Controls.Add(lblHeader);

            SplitContainer contentSplit = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 250,
                FixedPanel = FixedPanel.None
            };

            Panel leftPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                BackColor = Color.WhiteSmoke,
                AutoScroll = true
            };

            Panel rightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                AutoScroll = true
            };

            Label lblAddClient = new Label
            {
                Text = "Adaugă Client Nou",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Comic Sans MS", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Width = 200,
                Height = 40
            };
            leftPanel.Controls.Add(lblAddClient);

            Label lblNume = new Label
            {
                Text = "Nume:",
                Top = lblAddClient.Bottom + 20,
                Left = 30,
                Width = 250
            };
            leftPanel.Controls.Add(lblNume);

            

            TextBox txtNume = new TextBox
            {
                Top = lblNume.Bottom + 5,
                Left = leftMargin,
                Width = controlWidth,
                Height = 32
            };
            leftPanel.Controls.Add(txtNume);

            Label lblPrenume = new Label
            {
                Text = "Prenume:",
                Top = txtNume.Bottom + 20,
                Left = 30,
                Width = 250
            };
            leftPanel.Controls.Add(lblPrenume);

            TextBox txtPrenume = new TextBox
            {
                Top = lblPrenume.Bottom + 5,
                Left = leftMargin,
                Width = controlWidth,
                Height = 32
            };
            leftPanel.Controls.Add(txtPrenume);

            Button btnAdauga = new Button
            {
                Text = "Adaugă Client",
                Top = txtPrenume.Bottom + 30,
                Left = leftMargin,
                Width = controlWidth,
                Height = 40,
                BackColor = Color.Lime,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            btnAdauga.Click += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(txtNume.Text) && !string.IsNullOrEmpty(txtPrenume.Text))
                {
                    Persoana newClient = new Persoana(txtNume.Text, txtPrenume.Text);
                    adminC.AddClient(newClient);
                    MessageBox.Show("Client adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNume.Clear();
                    txtPrenume.Clear();
                }
                else
                {
                    MessageBox.Show("Completați numele și prenumele!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            leftPanel.Controls.Add(btnAdauga);

            Button btnAfiseaza = new Button
            {
                Text = "Afisează Clienți",
                Top = 10,
                Left = 30,
                Width = 250,
                Height = 40,
                BackColor = Color.Lime,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            rightPanel.Controls.Add(btnAfiseaza);

            ListBox listBoxClienti = new ListBox
            {
                Top = btnAfiseaza.Bottom + 20,
                Left = 30,
                Width = rightPanel.Width + 120,
                Height = rightPanel.Height - btnAfiseaza.Bottom - 50,
                Font = new Font("Comic Sans MS", 12),
                ForeColor = Color.Blue,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                IntegralHeight = false
            };
            rightPanel.Controls.Add(listBoxClienti);

            btnAfiseaza.Click += (sender, e) =>
            {
                int clientCount;
                Persoana[] clientList = adminC.Get_persoane(out clientCount);

                listBoxClienti.Items.Clear();
                if (clientList != null && clientCount > 0)
                {
                    listBoxClienti.BeginUpdate();
                    foreach (Persoana persoana in clientList)
                    {
                        if (persoana != null)
                        {
                            listBoxClienti.Items.Add(persoana.Info_p());
                        }
                    }
                    listBoxClienti.EndUpdate();
                    int requiredHeight = (listBoxClienti.Items.Count * listBoxClienti.Font.Height) + 10;
                    int maxHeight = rightPanel.Height - btnAfiseaza.Bottom - 50;
                    listBoxClienti.Height = Math.Min(requiredHeight, maxHeight);
                }
                else
                {
                    listBoxClienti.Items.Add("Nu există clienți în fișier!");
                    listBoxClienti.ForeColor = Color.Red;
                }
            };

            Button btnCautare = new Button
            {
                Text = "Caută Client",
                Top = btnAdauga.Bottom + 20, 
                Left = 20,
                Width = 200,
                Height = 40,
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            leftPanel.Controls.Add(btnCautare);

            Label lblRezultatCautare = new Label
            {
                Top = btnCautare.Bottom + 20,
                Left = 20,
                Width = 200,
                AutoSize = true,
                Font = new Font("Comic Sans MS", 12),
                ForeColor = Color.Black
            };
            leftPanel.Controls.Add(lblRezultatCautare);

            btnCautare.Click += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(txtNume.Text) || !string.IsNullOrEmpty(txtPrenume.Text))
                {
                    Administrare_client adminClient = new Administrare_client();
                    int nrClient;
                    Persoana[] clienti = adminC.Get_persoane(out nrClient);
                    foreach (var client in clienti)
                    {
                        if (client != null)
                            adminClient.AddClient(client);
                    }

                    Persoana clientGasit = adminClient.Cautare_client(
                        txtNume.Text.Trim(),
                        txtPrenume.Text.Trim());
                    if (!string.IsNullOrEmpty(clientGasit.nume) || !string.IsNullOrEmpty(clientGasit.prenume))
                    {
                        lblRezultatCautare.Text = "Client găsit:\n" + clientGasit.Info_p();
                        lblRezultatCautare.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblRezultatCautare.Text = "Clientul nu a fost găsit!";
                        lblRezultatCautare.ForeColor = Color.Red;
                    }
                }
                else
                {
                    MessageBox.Show("Introduceți numele sau prenumele clientului!",
                                   "Eroare",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                }
            };


            mainSplitContainer.Panel1.Controls.Add(headerPanel);
            contentSplit.Panel1.Controls.Add(leftPanel);
            contentSplit.Panel2.Controls.Add(rightPanel);
            mainSplitContainer.Panel2.Controls.Add(contentSplit);

            this.Controls.Add(mainSplitContainer);

            this.Resize += (sender, e) =>
            {
                listBoxClienti.Width = rightPanel.Width - 60;
                listBoxClienti.Height = rightPanel.Height - btnAfiseaza.Bottom - 40;
            };
        }
    }
    
}
