using agenda;
using incercare_tema;
using produs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formular
{
    public partial class Form2: Form
    {
        private TextBox txtNume;
        private TextBox txtMarca;
        private ComboBox cmbServiciu;
        private ListBox listBoxCalculatoare;
        private Administrare_produs_fisier adminCalc;
        public Form2()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier_pc"];
            adminCalc = new Administrare_produs_fisier(numeFisier);

            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
            this.ForeColor = Color.Black; // Text negru
            this.Text = "Gestionare Calculatoare Service";
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
                BackColor = Color.LightGray
            };

            Label lblHeader = new Label
            {
                Text = "Gestionare Calculatoare Service",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Comic Sans MS", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Height = 50
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
            Label lblAddComputer = new Label
            {
                Text = "Adaugă Calculator Nou",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Comic Sans MS", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Width = 200,
                Height = 40
            };
            leftPanel.Controls.Add(lblAddComputer);
            Label lblNume = new Label
            {
                Text = "Nume calculator:",
                Top = lblAddComputer.Bottom + 20,
                Left = 20,
                Width = 200
            };
            leftPanel.Controls.Add(lblNume);

            txtNume = new TextBox
            {
                Top = lblNume.Bottom + 5,
                Left = 20,
                Width = 200,
                Height = 30
            };
            leftPanel.Controls.Add(txtNume);
            Label lblMarca = new Label
            {
                Text = "Marca:",
                Top = txtNume.Bottom + 20,
                Left = 20,
                Width = 200
            };
            leftPanel.Controls.Add(lblMarca);

            txtMarca = new TextBox
            {
                Top = lblMarca.Bottom + 5,
                Left = 20,
                Width = 200,
                Height = 30
            };
            leftPanel.Controls.Add(txtMarca);
            Label lblServiciu = new Label
            {
                Text = "Serviciu:",
                Top = txtMarca.Bottom + 20,
                Left = 20,
                Width = 200
            };
            leftPanel.Controls.Add(lblServiciu);

            cmbServiciu = new ComboBox
            {
                Top = lblServiciu.Bottom + 5,
                Left = 20,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbServiciu.Items.AddRange(Enum.GetNames(typeof(Servicii)));
            leftPanel.Controls.Add(cmbServiciu);
            Button btnAdauga = new Button
            {
                Text = "Adaugă Calculator",
                Top = cmbServiciu.Bottom + 30,
                Left = 20,
                Width = 200,
                Height = 40,
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            btnAdauga.Click += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(txtNume.Text) && !string.IsNullOrEmpty(txtMarca.Text) && cmbServiciu.SelectedItem != null)
                {
                    Calculator newComputer = new Calculator(
                        txtNume.Text,
                        txtMarca.Text)
                    {
                        serv = (Servicii)Enum.Parse(typeof(Servicii), cmbServiciu.SelectedItem.ToString())
                    };
                    adminCalc.AddProdus(newComputer);
                    MessageBox.Show("Calculator adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNume.Clear();
                    txtMarca.Clear();
                    cmbServiciu.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Completați toate câmpurile!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            leftPanel.Controls.Add(btnAdauga);

            Button btnCauta = new Button
            {
                Text = "Caută Calculator",
                Top = btnAdauga.Bottom + 20,
                Left = btnAdauga.Left,
                Width = btnAdauga.Width,
                Height = btnAdauga.Height,
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            btnCauta.Click += BtnCauta_Click;
            leftPanel.Controls.Add(btnCauta);

            Button btnInapoi = new Button
            {
                Text = "Înapoi",
                Top = btnCauta.Bottom + 20,
                Left = btnAdauga.Left,       
                Width = btnAdauga.Width,     
                Height = btnAdauga.Height,   
                BackColor = btnAdauga.BackColor, 
                FlatStyle = btnAdauga.FlatStyle,
                Font = btnAdauga.Font        
            };
            btnInapoi.Click += (sender, e) => this.Close();
            leftPanel.Controls.Add(btnInapoi);

            Button btnAfiseaza = new Button
            {
                Text = "Afișează Calculatoare",
                Top = 10,
                Left = 20,
                Width = 200,
                Height = 40,
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            rightPanel.Controls.Add(btnAfiseaza);
            listBoxCalculatoare = new ListBox
            {
                Top = btnAfiseaza.Bottom + 20,
                Left = 20,
                Width = rightPanel.Width + 480,
                Height = rightPanel.Height - btnAfiseaza.Bottom - 50,
                Font = new Font("Comic Sans MS", 12),
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                IntegralHeight = false
            };
            rightPanel.Controls.Add(listBoxCalculatoare);

            btnAfiseaza.Click += (sender, e) =>
            {
                int computerCount;
                Calculator[] computerList = adminCalc.Get_produse(out computerCount);

                listBoxCalculatoare.Items.Clear();
                if (computerList != null && computerCount > 0)
                {
                    listBoxCalculatoare.BeginUpdate();
                    foreach (Calculator calculator in computerList)
                    {
                        if (calculator != null)
                        {
                            listBoxCalculatoare.Items.Add(calculator.Info());
                        }
                    }
                    listBoxCalculatoare.EndUpdate();

                    int requiredHeight = (listBoxCalculatoare.Items.Count * listBoxCalculatoare.Font.Height) + 10;
                    int maxHeight = rightPanel.Height - btnAfiseaza.Bottom - 50;
                    listBoxCalculatoare.Height = Math.Min(requiredHeight, maxHeight);
                }
                else
                {
                    listBoxCalculatoare.Items.Add("Nu există calculatoare în fișier!");
                    listBoxCalculatoare.ForeColor = Color.Red;
                }
            };

            mainSplitContainer.Panel1.Controls.Add(headerPanel);
            contentSplit.Panel1.Controls.Add(leftPanel);
            contentSplit.Panel2.Controls.Add(rightPanel);
            mainSplitContainer.Panel2.Controls.Add(contentSplit);

            this.Controls.Add(mainSplitContainer);
            this.Resize += (sender, e) =>
            {
                listBoxCalculatoare.Width = rightPanel.Width - 60;
                int maxHeight = rightPanel.Height - btnAfiseaza.Bottom - 50;
                listBoxCalculatoare.Height = maxHeight;
            };
        }
        private void BtnCauta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNume.Text) ||!string.IsNullOrEmpty(txtMarca.Text) || cmbServiciu.SelectedItem != null)
            {
                string numeCautat = !string.IsNullOrEmpty(txtNume.Text) ? txtNume.Text.Trim() : null;
                string marcaCautata = !string.IsNullOrEmpty(txtMarca.Text) ? txtMarca.Text.Trim() : null;
                Servicii? serviciuCautat = cmbServiciu.SelectedItem != null
                    ? (Servicii)Enum.Parse(typeof(Servicii), cmbServiciu.SelectedItem.ToString())
                    : (Servicii?)null;
                Administrare_produs adminProd = new Administrare_produs();
                int nrProduse;
                Calculator[] produse = adminCalc.Get_produse(out nrProduse);

                foreach (var prod in produse)
                {
                    if (prod != null)
                        adminProd.AddProd(prod);
                }

                List<Calculator> rezultate = adminProd.Cautare_prod(numeCautat, marcaCautata, serviciuCautat);
                listBoxCalculatoare.Items.Clear();
                if (rezultate.Count > 0)
                {
                    listBoxCalculatoare.Items.Add($"Rezultate căutare ({rezultate.Count}):");
                    foreach (var calculator in rezultate)
                    {
                        listBoxCalculatoare.Items.Add(calculator.Info());
                    }
                    listBoxCalculatoare.ForeColor = Color.Black;
                }
                else
                {
                    listBoxCalculatoare.Items.Add("Nu s-au găsit calculatoare pentru criteriile specificate!");
                    listBoxCalculatoare.ForeColor = Color.Red;
                }
            }
            else
            {
                MessageBox.Show("Introduceți cel puțin un criteriu de căutare (nume, marcă sau serviciu)!",
                               "Eroare",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }
        }
    }
}
