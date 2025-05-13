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
using System.Windows.Forms;

namespace Formular
{
    public partial class Form2 : Form
    {
        private TextBox txtNume;
        private TextBox txtMarca;
        private ListBox listBoxCalculatoare;
        private Administrare_produs_fisier adminCalc;
        private CheckBox[] serviceCheckBoxes;
        private RadioButton[] typeRadioButtons;

        public Form2()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier_pc"];
            adminCalc = new Administrare_produs_fisier(numeFisier);

            InitializeForm();
            InitializeControls();
        }

        private void InitializeForm()
        {
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);
            this.ForeColor = Color.Black;
            this.Text = "Gestionare Calculatoare Service";
            this.BackColor = Color.White;
            this.MinimumSize = new Size(800, 500);
        }

        private void InitializeControls()
        {
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
                SplitterDistance = 350,
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

            AddComputerControls(leftPanel);

            AddDisplayControls(rightPanel);

            mainSplitContainer.Panel1.Controls.Add(headerPanel);
            contentSplit.Panel1.Controls.Add(leftPanel);
            contentSplit.Panel2.Controls.Add(rightPanel);
            mainSplitContainer.Panel2.Controls.Add(contentSplit);

            this.Controls.Add(mainSplitContainer);
            this.Resize += (sender, e) => AdjustListBoxSize(rightPanel);
        }

        private void AddComputerControls(Panel panel)
        {
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
            panel.Controls.Add(lblAddComputer);

            Label lblNume = new Label
            {
                Text = "Nume calculator:",
                Top = lblAddComputer.Bottom + 20,
                Left = 20,
                Width = 200
            };
            panel.Controls.Add(lblNume);

            txtNume = new TextBox
            {
                Top = lblNume.Bottom + 5,
                Left = 20,
                Width = 200,
                Height = 30
            };
            panel.Controls.Add(txtNume);

            Label lblMarca = new Label
            {
                Text = "Marca:",
                Top = txtNume.Bottom + 20,
                Left = 20,
                Width = 200
            };
            panel.Controls.Add(lblMarca);

            txtMarca = new TextBox
            {
                Top = lblMarca.Bottom + 5,
                Left = 20,
                Width = 200,
                Height = 30
            };
            panel.Controls.Add(txtMarca);

            Label lblTip = new Label
            {
                Text = "Tip calculator:",
                Top = txtMarca.Bottom + 20,
                Left = 20,
                Width = 200
            };
            panel.Controls.Add(lblTip);

            typeRadioButtons = new RadioButton[3];
            string[] types = { "Gaming", "Office", "Home" };
            int topPosition = lblTip.Bottom + 5;

            for (int i = 0; i < types.Length; i++)
            {
                typeRadioButtons[i] = new RadioButton
                {
                    Text = types[i],
                    Top = topPosition,
                    Left = 20,
                    Width = 100,
                    Tag = types[i].ToLower()
                };
                panel.Controls.Add(typeRadioButtons[i]);
                topPosition += 30;
            }
            typeRadioButtons[0].Checked = true;

            Label lblServicii = new Label
            {
                Text = "Servicii:",
                Top = topPosition + 10,
                Left = 20,
                Width = 200
            };
            panel.Controls.Add(lblServicii);

            serviceCheckBoxes = new CheckBox[Enum.GetValues(typeof(Servicii)).Length];
            topPosition = lblServicii.Bottom + 5;

            foreach (Servicii service in Enum.GetValues(typeof(Servicii)))
            {
                int index = (int)service - 1;
                serviceCheckBoxes[index] = new CheckBox
                {
                    Text = service.ToString().Replace('_', ' '),
                    Top = topPosition,
                    Left = 20,
                    Width = 200,
                    Tag = service
                };
                panel.Controls.Add(serviceCheckBoxes[index]);
                topPosition += 30;
            }

            Button btnAdauga = new Button
            {
                Text = "Adaugă Calculator",
                Top = topPosition + 20,
                Left = 20,
                Width = 200,
                Height = 40,
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            btnAdauga.Click += BtnAdauga_Click;
            panel.Controls.Add(btnAdauga);

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
            panel.Controls.Add(btnCauta);

            Button btnEditare = new Button
            {
                Text = "Editare",
                Top = btnAdauga.Top,
                Left = btnAdauga.Right + 20,
                Width = btnAdauga.Width,
                Height = btnAdauga.Height,
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            btnEditare.Click += BtnEditare_Click;
            panel.Controls.Add(btnEditare);

            // New Delete button (placed to the right of Search button)
            Button btnStergere = new Button
            {
                Text = "Ștergere",
                Top = btnCauta.Top,
                Left = btnCauta.Right + 20,
                Width = btnCauta.Width,
                Height = btnCauta.Height,
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold)
            };
            btnStergere.Click += BtnStergere_Click;
            panel.Controls.Add(btnStergere);

            Button btnInapoi = new Button
            {
                Text = "Înapoi",
                Top = btnCauta.Bottom + 20,
                Left = btnCauta.Left,
                Width = btnCauta.Width,
                Height = btnCauta.Height,
                BackColor = btnAdauga.BackColor,
                FlatStyle = btnAdauga.FlatStyle,
                Font = btnAdauga.Font
            };
            btnInapoi.Click += (sender, e) => this.Close();
            panel.Controls.Add(btnInapoi);
        }

        private void AddDisplayControls(Panel panel)
        {
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
            panel.Controls.Add(btnAfiseaza);

            listBoxCalculatoare = new ListBox
            {
                Top = btnAfiseaza.Bottom + 20,
                Left = 20,
                Width = panel.Width + 280,
                Height = panel.Height - btnAfiseaza.Bottom - 50,
                Font = new Font("Comic Sans MS", 12),
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                IntegralHeight = false
            };
            panel.Controls.Add(listBoxCalculatoare);

            listBoxCalculatoare.SelectedIndexChanged += ListBoxCalculatoare_SelectedIndexChanged;

            btnAfiseaza.Click += (sender, e) => DisplayCalculatoare();

        }

        private void AdjustListBoxSize(Panel panel)
        {
            listBoxCalculatoare.Width = panel.Width + 280;
            int maxHeight = panel.Height - listBoxCalculatoare.Top - 20;
            listBoxCalculatoare.Height = maxHeight;
        }

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNume.Text) && !string.IsNullOrEmpty(txtMarca.Text))
            {
                string selectedType = typeRadioButtons.FirstOrDefault(r => r.Checked)?.Tag.ToString();

                List<Servicii> selectedServices = new List<Servicii>();
                foreach (var checkBox in serviceCheckBoxes)
                {
                    if (checkBox.Checked)
                    {
                        selectedServices.Add((Servicii)checkBox.Tag);
                    }
                }

                if (selectedServices.Count == 0)
                {
                    MessageBox.Show("Selectați cel puțin un serviciu!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Calculator newComputer = new Calculator(
                    txtNume.Text,
                    txtMarca.Text,
                    selectedType,
                    selectedServices.ToArray());

                adminCalc.AddProdus(newComputer);
                MessageBox.Show("Calculator adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
            }
            else
            {
                MessageBox.Show("Completați toate câmpurile!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearInput()
        {
            txtNume.Clear();
            txtMarca.Clear();
            typeRadioButtons[0].Checked = true;
            foreach (var checkBox in serviceCheckBoxes)
            {
                checkBox.Checked = false;
            }
        }

        private void DisplayCalculatoare()
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
                        listBoxCalculatoare.Items.Add(new ListBoxOb(calculator.Info(), calculator));
                    }
                }
                listBoxCalculatoare.EndUpdate();
            }
            else
            {
                listBoxCalculatoare.Items.Add("Nu există calculatoare în fișier!");
                listBoxCalculatoare.ForeColor = Color.Red;
            }
        }
        private class ListBoxOb
        {
            public string DisplayText { get; set; }
            public Calculator PC { get; set; }

            public ListBoxOb(string displayText, Calculator _pc)
            {
                DisplayText = displayText;
                PC = _pc;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }
        private void ListBoxCalculatoare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCalculatoare.SelectedIndex >= 0)
            {
                var selectedItem = listBoxCalculatoare.SelectedItem as ListBoxOb;
                if (selectedItem != null)
                {
                    Calculator calculatorSelectat = selectedItem.PC;
                    txtNume.Text = calculatorSelectat.nume;
                    txtMarca.Text = calculatorSelectat.marca;
                    foreach (var radioButton in typeRadioButtons)
                    {
                        radioButton.Checked = (radioButton.Tag.ToString() == calculatorSelectat.tip.ToLower());
                    }

                    foreach (var checkBox in serviceCheckBoxes)
                    {
                        checkBox.Checked = calculatorSelectat.GetServicii().Contains((Servicii)checkBox.Tag);
                    }
                }
            }
        }
        private void BtnEditare_Click(object sender, EventArgs e)
        {
            if (listBoxCalculatoare.SelectedIndex < 0)
            {
                MessageBox.Show("Selectați un calculator pentru editare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var Obselectat = listBoxCalculatoare.SelectedItem as ListBoxOb;
            if (Obselectat == null) return;
            Calculator originalComputer = Obselectat.PC;
            string TipSelec = typeRadioButtons.FirstOrDefault(r => r.Checked)?.Tag.ToString();
            List<Servicii> ServSelec = new List<Servicii>();
            foreach (var checkBox in serviceCheckBoxes)
            {
                if (checkBox.Checked)
                {
                    ServSelec.Add((Servicii)checkBox.Tag);
                }
            }

            if (ServSelec.Count == 0)
            {
                MessageBox.Show("Selectați cel puțin un serviciu!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Calculator updatedComputer = new Calculator(
                txtNume.Text,
                txtMarca.Text,
                TipSelec,
                ServSelec.ToArray());
            if (adminCalc.ActualizeazaProdus(originalComputer, updatedComputer))
            {
                MessageBox.Show("Calculator actualizat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayCalculatoare();
                ClearInput();
            }
            else
            {
                MessageBox.Show("Eroare la actualizarea calculatorului!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnStergere_Click(object sender, EventArgs e)
        {
            if (listBoxCalculatoare.SelectedIndex < 0)
            {
                MessageBox.Show("Selectați un calculator pentru ștergere!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = listBoxCalculatoare.SelectedItem as ListBoxOb;
            if (selectedItem == null) return;

            if (MessageBox.Show("Sigur doriți să ștergeți acest calculator?", "Confirmare ștergere",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (adminCalc.StergeProdus(selectedItem.PC))
                {
                    MessageBox.Show("Calculator șters cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayCalculatoare();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Eroare la ștergerea calculatorului!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnCauta_Click(object sender, EventArgs e)
        {
            string numeCautat = !string.IsNullOrEmpty(txtNume.Text) ? txtNume.Text.Trim() : null;
            string marcaCautata = !string.IsNullOrEmpty(txtMarca.Text) ? txtMarca.Text.Trim() : null;
            string tipCautat = typeRadioButtons.FirstOrDefault(r => r.Checked)?.Tag.ToString();

            List<Servicii> selectedServices = new List<Servicii>();
            foreach (var checkBox in serviceCheckBoxes)
            {
                if (checkBox.Checked)
                {
                    selectedServices.Add((Servicii)checkBox.Tag);
                }
            }
            Servicii[] serviciiCautate = selectedServices.ToArray();

            if (!string.IsNullOrEmpty(numeCautat) || !string.IsNullOrEmpty(marcaCautata) || serviciiCautate.Length > 0)
            {
                List<Calculator> rezultate = adminCalc.Cautare_prod(numeCautat, marcaCautata, tipCautat, serviciiCautate);
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
