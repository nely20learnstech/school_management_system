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

    public partial class GradeForm : Form
    {
        DBconnect connect = new DBconnect();
        GradeClass grade = new GradeClass();
        UEClass unity = new UEClass();
        ECClass element = new ECClass();
        public GradeForm()
        {
            InitializeComponent();
            showList();
        }

        private void DataGridView_grade_Click(object sender, EventArgs e)
        {
            textBox_mat.Text = DataGridView_grade.CurrentRow.Cells[0].Value.ToString();
            comboBox_UE.Text = DataGridView_grade.CurrentRow.Cells[1].Value.ToString();
            comboBox_EC.Text = DataGridView_grade.CurrentRow.Cells[2].Value.ToString();
            textBox_note.Text = DataGridView_grade.CurrentRow.Cells[3].Value.ToString();
            textBox_year.Text = DataGridView_grade.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void button_add_Click(object sender, EventArgs e)
        {            
            string mat = textBox_mat.Text;
            string UE = comboBox_UE.Text;
            string EC = comboBox_EC.Text;
            string string_score = textBox_note.Text;
            string year = textBox_year.Text;

            if (textBox_mat.Text == "" || textBox_note.Text == "" || textBox_year.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    double score = Convert.ToDouble(string_score);
                    
                    if (grade.insertGrade(mat, UE, EC, score, year))
                    {
                        showList();
                        button_clear.PerformClick();
                        MessageBox.Show("Ajout d'une note effectuée ", "Ajout d'une note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " \n Cette note existe déjà!", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string mat = textBox_mat.Text;
            string UE = comboBox_UE.Text;
            string EC = comboBox_EC.Text;
            string string_score = textBox_note.Text;
            string year = textBox_year.Text;

            if (textBox_mat.Text == "" || textBox_note.Text == "" || textBox_year.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        double score = Convert.ToDouble(string_score);

                        if (grade.updateGrade(mat, UE, EC, score, year))
                        {
                            showList();
                            button_clear.PerformClick();
                            MessageBox.Show("Mise à jour d'une note effectuée ", "Mise à jour d'une note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            textBox_mat.Clear();
            comboBox_UE.SelectedIndex = 0;
            comboBox_EC.SelectedIndex = 0;
            textBox_note.Clear();
            textBox_year.Clear();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string mat = textBox_mat.Text;
            string EC = comboBox_EC.Text;

            if (textBox_mat.Text == "" )
            {
                MessageBox.Show("Veuillez sélectionner la note", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {

                    try
                    {                    

                        if (grade.deleteGrade(mat, EC))
                        {
                            showList();
                            button_clear.PerformClick();
                            MessageBox.Show("Suppression effectuée ", "Suppression d'une note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataGridView_grade.DataSource = grade.searchScore(textBox_search.Text);
        }

        public void showList()
        {
            DataGridView_grade.DataSource = grade.getScorelist(new MySqlCommand("SELECT * FROM `Note`"));

            comboBox_EC.DataSource = element.getEClist(new MySqlCommand("SELECT `CodeEC` FROM `Element_Constitutif`"));
            comboBox_EC.DisplayMember = "CodeEC";
            comboBox_EC.ValueMember = "CodeEC";

            //comboBox_UE.DataSource = element.getEClist(new MySqlCommand("SELECT `CodeUE` FROM `Element_Constitutif` WHERE `CodeEC` ='" + comboBox_EC.Text + "'"));
            comboBox_UE.DataSource = unity.getUElist(new MySqlCommand("SELECT `CodeUE` FROM `Unite_Enseignement`"));
            comboBox_UE.DisplayMember = "CodeUE";
            comboBox_UE.ValueMember = "CodeUE";
        }

        public string take(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteNonQuery().ToString();
            connect.closeConnect();
            return count;
        }

        public string UEofEC(string EC)
        {
            return take("SELECT `CodeUE` FROM `Element_Constitutif` WHERE `CodeEC` ='"+ EC +"'");
        }

        private void GradeForm_Load(object sender, EventArgs e)
        {
            //textBox_UE.Text = UEofEC(comboBox_EC.Text);
        }


       
    }
}
