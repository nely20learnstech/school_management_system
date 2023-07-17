using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace management_system
{
    public partial class SemesterForm : Form
    {
        DBconnect connect = new DBconnect();
        ManageClass management = new ManageClass();
        SemesterClass semester = new SemesterClass();
        public SemesterForm()
        {
            InitializeComponent();
        }

        public bool verify()
        {
            if (textBox_semester.Text == "" || textBox_descSemester.Text == "")
            {
                return false;
            }
            else
                return true;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string level = comboBox_level.Text;
            string code = textBox_semester.Text;
            string desc = textBox_descSemester.Text;
            DateTime start = dateTimePicker_start.Value;
            DateTime end = dateTimePicker_end.Value;
                      
            // start == end doesn't work! Why???
            if (start >= end )
            {
                MessageBox.Show("Veuillez définir la date début et fin du semestre!", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*else if(start > end)
            {
                MessageBox.Show("La date du début est plus grande que celle du fin!", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            else if (verify())
            {
                try
                {
                    if (semester.insertSemester(code, desc, level, start, end))
                    {
                        showsemester();
                        button_clear.PerformClick();
                        MessageBox.Show("Ajout effectuée", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Champ semestre ou description vide", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string level = comboBox_level.Text;
            string code = textBox_semester.Text;
            string desc = textBox_descSemester.Text;
            DateTime start = dateTimePicker_start.Value;
            DateTime end = dateTimePicker_end.Value;

            if(start >= end)
            {
                MessageBox.Show("Veuillez définir la date début et fin du semestre!", "Modification impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox_semester.Text == "" || textBox_descSemester.Text == "")
            {
                MessageBox.Show("Aucun semestre n'a été sélectionné ou \n remplissez ce qui est vide!", "Modification impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (semester.updateSemester(code, desc, level, start, end))
                        {
                            showsemester();
                            button_clear.PerformClick();
                            MessageBox.Show("Modification effectuée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            textBox_semester.Clear();
            textBox_descSemester.Clear();
            dateTimePicker_start.Value = DateTime.Now;
            dateTimePicker_end.Value = DateTime.Now;
            comboBox_level.SelectedIndex = 0;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string code = textBox_semester.Text;

            if (textBox_semester.Text == "")
            {
                MessageBox.Show("Aucun semestre n'a été sélectionné!", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (semester.deleteSemester(code))
                        {
                            showsemester();
                            button_clear.PerformClick();
                            MessageBox.Show("Suppression effectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n Ce semestre existe déjà!", "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Suppression annulée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
        }

        private void DataGridView_semester_Click(object sender, EventArgs e)
        {
            textBox_semester.Text = DataGridView_semester.CurrentRow.Cells[0].Value.ToString();
            textBox_descSemester.Text = DataGridView_semester.CurrentRow.Cells[1].Value.ToString();
            comboBox_level.Text = DataGridView_semester.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker_start.Value = (DateTime)DataGridView_semester.CurrentRow.Cells[3].Value;
            dateTimePicker_end.Value = (DateTime)DataGridView_semester.CurrentRow.Cells[4].Value;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_semester.DataSource = semester.searchSemester(textBox_search.Text);
        }


        public void showsemester()
        {
            DataGridView_semester.DataSource = semester.getSemesterlist(new MySqlCommand("SELECT * FROM `Semestre`"));
            comboBox_level.DataSource = management.getList(new MySqlCommand("SELECT `CodeNiveau` FROM `Niveau`"));
            comboBox_level.DisplayMember = "CodeNiveau";
            comboBox_level.ValueMember = "CodeNiveau";

        }

        private void SemesterForm_Load(object sender, EventArgs e)
        {
            showsemester();
        }
    }
}
