using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace management_system
{
    public partial class AdmissionForm : Form
    {
        AdmissionClass register = new AdmissionClass();
        ManageClass management = new ManageClass();
        public AdmissionForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string mat = textBox_matricule.Text;
            string field = comboBox_field.Text;
            string level = comboBox_level.Text;
            string year = textBox_year.Text;

            if (textBox_matricule.Text == "" || textBox_year.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (register.insertRegister(mat, level, field, year))
                    {
                        showRegister();
                        button_clear.PerformClick();
                        MessageBox.Show("Inscription faite", "Nouvelle inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " \n L'insccription a été faite!", "Erreur d'ajout d'inscription", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string mat = textBox_matricule.Text;
            string field = comboBox_field.Text;
            string level = comboBox_level.Text;
            string year = textBox_year.Text;


           
                if (textBox_matricule.Text == "" || textBox_year.Text == "")
                {
                    MessageBox.Show("Champ(s) vide(s)", "Modification impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        try
                        {
                                if (register.updateRegister(mat, level, field, year))
                                {
                                    showRegister();
                                    button_clear.PerformClick();
                                    MessageBox.Show("Modification faite", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Erreur de modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    else
                        MessageBox.Show("Modification annulée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           
        }

       

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_matricule.Clear();
            textBox_year.Clear();
            comboBox_field.SelectedIndex = 0;
            comboBox_level.SelectedIndex = 0;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string mat = textBox_matricule.Text;

            if (textBox_matricule.Text == "")
            {
                MessageBox.Show("Champ Matricule vide", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (register.deleteRegister(mat))
                        {
                            showRegister();
                            button_clear.PerformClick();
                            MessageBox.Show("Suppression effectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Suppression annulée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void DataGridView_admission_Click(object sender, EventArgs e)
        {
            textBox_matricule.Text = DataGridView_admission.CurrentRow.Cells[0].Value.ToString();
            textBox_year.Text = DataGridView_admission.CurrentRow.Cells[3].Value.ToString(); 
            comboBox_level.Text = DataGridView_admission.CurrentRow.Cells[1].Value.ToString();
            comboBox_field.Text = DataGridView_admission.CurrentRow.Cells[2].Value.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_admission.DataSource = register.searchRegister(textBox_search.Text);
            //textBox_search.Clear();
        }

        public void showRegister()
        {
            DataGridView_admission.DataSource = register.getList(new MySqlCommand("SELECT * FROM `Inscription`"));

            comboBox_level.DataSource = management.getList(new MySqlCommand("SELECT `CodeNiveau` FROM `Niveau`"));
            comboBox_level.DisplayMember = "CodeNiveau";
            comboBox_level.ValueMember = "CodeNiveau";

            comboBox_field.DataSource = management.getList(new MySqlCommand("SELECT `CodeParcours` FROM `Parcours`"));
            comboBox_field.DisplayMember = "CodeParcours";
            comboBox_field.ValueMember = "CodeParcours";
        }

        private void AdmissionForm_Load(object sender, EventArgs e)
        {
            showRegister();
        }
    }
}
