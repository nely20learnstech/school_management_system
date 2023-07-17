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
    public partial class UEForm : Form
    {
        DBconnect connect = new DBconnect();
        UEClass unity = new UEClass();
        ManageClass manage = new ManageClass();
        SemesterClass semester = new SemesterClass();

        public UEForm()
        {
            InitializeComponent();
            
        }

        private void UEForm_Load(object sender, EventArgs e)
        {
            showList();
        }

        public void showList()
        {
            DataGridView.DataSource = unity.getUElist(new MySqlCommand("SELECT * FROM `Unite_Enseignement`"));

            comboBox_level.DataSource = manage.getList(new MySqlCommand("SELECT `CodeNiveau` FROM `Niveau`"));
            comboBox_level.DisplayMember = "CodeNiveau";
            comboBox_level.ValueMember= "CodeNiveau";

            comboBox_field.DataSource = manage.getList(new MySqlCommand("SELECT `CodeParcours` FROM `Parcours`"));
            comboBox_field.DisplayMember = "CodeParcours";
            comboBox_field.ValueMember = "CodeParcours";

            comboBox_semester.DataSource = semester.getSemesterlist(new MySqlCommand("SELECT `CodeSemestre` FROM `Semestre`"));
            comboBox_semester.DisplayMember = "CodeSemestre";
            comboBox_semester.ValueMember = "CodeSemestre";
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string code = textBox_code.Text;
            string desc = textBox_desc.Text;
            string field = comboBox_field.Text;
            string level = comboBox_level.Text;
            string semester = comboBox_semester.Text;
            string string_credit = textBox_credit.Text;
            //int numero = Convert.ToInt32(textBox_number.Text);

            if (textBox_code.Text == "" || textBox_credit.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int credit = Convert.ToInt32(string_credit);
                    if (unity.insertUE(code, desc, level, field, semester, credit))
                    {
                        showList();
                        button_clear.PerformClick();
                        MessageBox.Show("UE ajoutée", "Nouvelle UE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n Cette UE existe déjà! ", "Erreur d'ajout d'UE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string code = textBox_code.Text;
            string desc = textBox_desc.Text;
            string field = comboBox_field.Text;
            string level = comboBox_level.Text;
            string semester = comboBox_semester.Text;
            string string_credit = textBox_credit.Text;

            if (verify())
            {
                MessageBox.Show("Champ(s) vide(s)", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        int credit = Convert.ToInt32(string_credit);
                        if (unity.updateUE(code, desc, level, field, semester, credit))
                        {
                            showList();
                            button_clear.PerformClick();
                            MessageBox.Show("UE mise à jour", "Mise à jour d'UE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            comboBox_level.SelectedIndex = 0;
            comboBox_field.SelectedIndex = 0;
            comboBox_semester.SelectedIndex = 0;
            textBox_credit.Clear();
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
                        if (unity.deleteUE(code))
                        {
                            showList();
                            button_clear.PerformClick();
                            MessageBox.Show("UE supprimée", "Suppression d'UE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DataGridView_Click(object sender, EventArgs e)
        {
            textBox_code.Text = DataGridView.CurrentRow.Cells[0].Value.ToString();
            textBox_desc.Text = DataGridView.CurrentRow.Cells[1].Value.ToString();
            comboBox_level.Text = DataGridView.CurrentRow.Cells[2].Value.ToString();
            comboBox_field.Text = DataGridView.CurrentRow.Cells[3].Value.ToString();
            comboBox_semester.Text = DataGridView.CurrentRow.Cells[4].Value.ToString();
            textBox_credit.Text = DataGridView.CurrentRow.Cells[5].Value.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView.DataSource = unity.searchUE(textBox_search.Text);
        }

        public bool verify()
        {
            if (textBox_code.Text == "" || textBox_credit.Text == "")
            {
                return true;
            }
            else
                return false;
        }
    }
}
