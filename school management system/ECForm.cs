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
    public partial class ECForm : Form
    {
        ECClass element = new ECClass();
        UEClass unity = new UEClass();
        ManageClass manage = new ManageClass();
        SemesterClass semester = new SemesterClass();
        public ECForm()
        {
            InitializeComponent();
            showList();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string code = textBox_code.Text;
            string desc = textBox_desc.Text;
            string string_coef = textBox_coef.Text;
            string UE = comboBox_UE.Text;
            string field = comboBox_field.Text;
            string level = comboBox_level.Text;
            string semester = comboBox_semester.Text;
            string string_hour = textBox_during.Text;
            //int numero = Convert.ToInt32(textBox_number.Text);

            if (textBox_code.Text == "" || textBox_during.Text == "" || textBox_coef.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int coef = Convert.ToInt32(string_coef);
                    int hour = Convert.ToInt32(string_hour);
                    if (element.insertEC(code, desc, coef, UE, level, field, semester, hour))
                    {
                        showList();
                        button_clear.PerformClick();
                        MessageBox.Show("EC ajouté", "Nouvel EC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " \n Cet EC existe déjà!", "Erreur d'ajout d'EC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string code = textBox_code.Text;
            string desc = textBox_desc.Text;
            string string_coef = textBox_coef.Text;
            string UE = comboBox_UE.Text;
            string field = comboBox_field.Text;
            string level = comboBox_level.Text;
            string semester = comboBox_semester.Text;
            string string_hour = textBox_during.Text;

            if (textBox_code.Text == "" || textBox_during.Text == "" || textBox_coef.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        int coef = Convert.ToInt32(string_coef);
                        int hour = Convert.ToInt32(string_hour);
                        if (element.updateEC(code, desc, coef, UE, level, field, semester, hour))
                        {
                            showList();
                            button_clear.PerformClick();
                            MessageBox.Show("EC mise à jour", "Mise à jour d'EC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur de mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Modification annulée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_code.Clear();
            textBox_desc.Clear();
            comboBox_UE.SelectedIndex = 0;
            textBox_coef.Clear();
            comboBox_level.SelectedIndex = 0;
            comboBox_field.SelectedIndex = 0;
            comboBox_semester.SelectedIndex = 0;
            textBox_during.Clear();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string code = textBox_code.Text;

            if (textBox_code.Text == "")
            {
                MessageBox.Show("Champ code vide", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (element.deleteEC(code))
                        {
                            showList();
                            button_clear.PerformClick();
                            MessageBox.Show("EC supprimé", "Suppression d'UE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button_search_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = element.searchEC(textBox_search.Text);
        }

        private void guna2DataGridView1_Click(object sender, EventArgs e)
        {
            textBox_code.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_desc.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_coef.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox_UE.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox_level.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox_field.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox_semester.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_during.Text = guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        public void showList()
        {
            guna2DataGridView1.DataSource = element.getEClist(new MySqlCommand("SELECT * FROM `Element_Constitutif`"));

            comboBox_UE.DataSource = manage.getList(new MySqlCommand("SELECT `CodeUE` FROM `Unite_Enseignement`"));
            comboBox_UE.DisplayMember = "CodeUE";
            comboBox_UE.ValueMember = "CodeUE";

            comboBox_level.DataSource = manage.getList(new MySqlCommand("SELECT `CodeNiveau` FROM `Niveau`"));
            comboBox_level.DisplayMember = "CodeNiveau";
            comboBox_level.ValueMember = "CodeNiveau";

            comboBox_field.DataSource = manage.getList(new MySqlCommand("SELECT `CodeParcours` FROM `Parcours`"));
            comboBox_field.DisplayMember = "CodeParcours";
            comboBox_field.ValueMember = "CodeParcours";

            comboBox_semester.DataSource = semester.getSemesterlist(new MySqlCommand("SELECT `CodeSemestre` FROM `Semestre`"));
            comboBox_semester.DisplayMember = "CodeSemestre";
            comboBox_semester.ValueMember = "CodeSemestre";
        }

        private void ECForm_Load(object sender, EventArgs e)
        {

        }
    }
}
