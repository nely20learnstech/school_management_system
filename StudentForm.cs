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
    public partial class StudentForm : Form
    {
        StudentClass student = new StudentClass();
        public StudentForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {

            string matricule = textBox_matricule.Text;
            string string_num = textBox_number.Text;
            string nom = textBox_Fname.Text;
            string prenoms = textBox_Lname.Text;
            string sexe = radioButton_male.Checked ? "M" : "F";
            DateTime date_naissance = dateTimePicker1.Value;
            string lieu_naissance = textBox_Bcountry.Text;
            string adresse = textBox_address.Text;
            string phone = textBox_phone.Text;



            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("L'étudiant(e) devrait être âgé(e) de 10 à 100.", "Date de naissance invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                try
                {
                    // get photo from picture box
                    /* MemoryStream ms = new MemoryStream();
                     pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                     byte[] img = ms.ToArray();*/
                    int numero = Convert.ToInt32(string_num);
                    if (student.insertStudent(matricule, numero, nom, prenoms, sexe, date_naissance, lieu_naissance, adresse, phone))
                    {
                        showTable();
                        button_clear.PerformClick();
                        MessageBox.Show("Ajout éffectué", "Ajout d'étudiant(e)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n Ce matricule existe déjà!", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            else
            {
                MessageBox.Show("Champ(s) vide(s) ", "Ajout d'étudiant(e)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //function which verify
        bool verify()
        {
            if ((textBox_matricule.Text == "") || (textBox_number.Text == "") || (textBox_Fname.Text == "") || (textBox_Lname.Text == "") || (textBox_phone.Text == "") || (textBox_address.Text == "") || (textBox_Bcountry.Text == ""))
            {
                return false;
            }
            else
                return true;
        }

        // show student list in datagridview
        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentlist(new MySqlCommand("SELECT * FROM `Etudiant`"));
            //DataGridView_student.RowTemplate.Height = 80; // doesn't work
            /* DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
             imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
             imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;*/
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_matricule.Clear();
            textBox_number.Clear();
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_Bcountry.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            radioButton_male.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            //pictureBox_student.Image = null;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = student.searchStudent(textBox_search.Text);
            //textBox_search.Clear();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string matricule = textBox_matricule.Text;
            string string_num = textBox_number.Text;
            string nom = textBox_Fname.Text;
            string prenoms = textBox_Lname.Text;
            string sexe = radioButton_male.Checked ? "M" : "F";
            DateTime date_naissance = dateTimePicker1.Value;
            string lieu_naissance = textBox_Bcountry.Text;
            string adresse = textBox_address.Text;
            string phone = textBox_phone.Text;



            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("L'étudiant(e) devrait être âgé(e) de 10 à 100.", "Date de naissance invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        // get photo from picture box
                        /* MemoryStream ms = new MemoryStream();
                         pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                         byte[] img = ms.ToArray();*/
                        int numero = Convert.ToInt32(string_num);
                        if (student.updateStudent(matricule, numero, nom, prenoms, sexe, date_naissance, lieu_naissance, adresse, phone))
                        {
                            showTable();
                            button_clear.PerformClick();
                            MessageBox.Show("Modification éffectuée", "Mise à jour d'information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erreur de mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                }
                else
                    MessageBox.Show("Modification annulée", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            else
            {
                MessageBox.Show("Champ(s) vide(s) ", "Mise à jour d'information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            textBox_matricule.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            textBox_number.Text= DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            textBox_Fname.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();
            textBox_Lname.Text = DataGridView_student.CurrentRow.Cells[3].Value.ToString();
            if (DataGridView_student.CurrentRow.Cells[4].Value.ToString() == "M")
                radioButton_male.Checked = true;
            else 
                radioButton_female.Checked = true;

            dateTimePicker1.Value = (DateTime)DataGridView_student.CurrentRow.Cells[5].Value;
            textBox_Bcountry.Text = DataGridView_student.CurrentRow.Cells[6].Value.ToString();
            textBox_address.Text = DataGridView_student.CurrentRow.Cells[7].Value.ToString();
            textBox_phone.Text = DataGridView_student.CurrentRow.Cells[8].Value.ToString();

            /* textBox_Id.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
             textBox_Fname.Text = DataGridView_student.CurrentRow.Cells[1].Value.ToString();
             textBox_Lname.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();

             dateTimePicker1.Value = (DateTime)DataGridView_student.CurrentRow.Cells[3].Value;

             if (DataGridView_student.CurrentRow.Cells[4].Value.ToString() == "Male")
                 radioButton_male.Checked = true;

             textBox_Phone.Text = DataGridView_student.CurrentRow.Cells[5].Value.ToString();
             textBox_address.Text = DataGridView_student.CurrentRow.Cells[6].Value.ToString();*/
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_matricule.Text.Equals(""))
            {
                MessageBox.Show("N° Matricule manquant", "Champ matricule vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {

                        string mat = textBox_matricule.Text;

                        if (student.deleteStudent(mat))
                        {
                            showTable();
                            button_clear.PerformClick();
                            MessageBox.Show("Etudiant(e) supprimé(e)", "Suppression effectuée", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
