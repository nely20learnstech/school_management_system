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
    public partial class BulletinForm : Form
    {
        DBconnect connect = new DBconnect();
        GradeClass grade = new GradeClass();
        public BulletinForm()
        {
            InitializeComponent();
        }

        private void BulletinForm_Load(object sender, EventArgs e)
        {

        }


        //public class ClassName
        //{
        //    public string Matricule { get; set; }
        //    public string LastName { get; set; }
        //    public string FirstName { get; set; }            
        //    public string level { get; set; }
        //    public string field { get; set; }
        //    public string year { get; set; }

        //}

        public void showScore(string mat)
        {
            
            DataGridView_score.DataSource = grade.getScorelist(new MySqlCommand("SELECT Note.CodeUE, Note.CodeEC, `note`, coefficient ,note*coefficient AS `NotePonderee` FROM Note JOIN Element_Constitutif ON Element_Constitutif.CodeEC = Note.CodeEC  WHERE `Matricule` = '" + mat +"'"));
             
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            showScore(textBox_mat.Text);
           
            //ClassName[] allrecords = null;
            MySqlCommand command = new MySqlCommand("SELECT Etudiant.Matricule,`Nom`, `Prenoms`, `CodeNiveau`,`CodeParcours`, `Annee` FROM Etudiant JOIN Inscription ON Etudiant.Matricule = Inscription.Matricule WHERE Etudiant.Matricule = '" + textBox_mat.Text + "'", connect.getconnection);

            connect.openConnect();

            string level = "", field = "";
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                //var list = new List<ClassName>();
                while (reader.Read())
                {
                    label_mat.Text = "Matricule : " + reader.GetString(0);
                    label_Lname.Text = "Nom : " + reader.GetString(1);
                    label_fname.Text = "Prenoms : " +  reader.GetString(2);
                    label_level.Text = "Niveau : " + reader.GetString(3);
                    label_field.Text = "Parcours : " + reader.GetString(4);
                    label_year.Text = "Année : " + reader.GetString(5);

                     field = reader.GetString(4);
                     level = reader.GetString(3);

                }          
            
            }


            try
            {
                label_average.Text = "Moyenne : " + average(textBox_mat.Text);
                label_credit.Text = "Moyenne par rapport au total des crédits : " + average_credit(textBox_mat.Text, credit_sum(field, level));
                label_sum_credit.Text = "Total des crédits : " + credit_sum(field, level);
                label_student_credit.Text = "Crédits obtenus par l'étudiant : " + student_credit_sum(textBox_mat.Text) + "/" + credit_sum(field, level);
                label_obs.Text = "Observation : " + admit(textBox_mat.Text, credit_sum(field, level));
            }
            catch//(Exception ex)
            {
                MessageBox.Show("Les crédits et les EC pour cette classe n'est pas encore définis.", "Erreur de création de bulletin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string execute(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }

        public string average(string mat)
        {
            return execute("SELECT SUM(note*coefficient) / SUM(coefficient) FROM Note JOIN Element_Constitutif ON Element_Constitutif.CodeEC = Note.CodeEC WHERE `Matricule` = '" + mat + "'");
        }

        public string average_credit(string mat, string credit)
        {
            return execute("SELECT SUM(note * coefficient) / "+credit+" FROM Note JOIN Element_Constitutif ON Element_Constitutif.CodeEC = Note.CodeEC JOIN Unite_Enseignement ON Unite_Enseignement.CodeUE = Element_Constitutif.CodeUE WHERE Unite_Enseignement.CodeParcours ='IG' AND Unite_Enseignement.CodeNiveau ='L2' AND`Matricule` = '" + mat + "'");
        }

        public string credit_sum(string field, string level)
        {
            return execute("SELECT SUM(Credit) FROM Unite_Enseignement WHERE CodeParcours ='"+ field +"' AND CodeNiveau ='"+ level +"'");
        }

        public string student_credit_sum(string mat)
        {
            return execute("SELECT SUM(Coefficient) FROM Note JOIN Element_Constitutif ON Element_Constitutif.CodeEC = Note.CodeEC WHERE `Matricule` = '" + mat + "'");
        }

        public string admit(string mat, string credit)
        {
            return execute("SELECT IF(SUM(note * coefficient) / " + credit + ">= 10, 'Admis', 'Non Admis') FROM Note JOIN Element_Constitutif ON Element_Constitutif.CodeEC = Note.CodeEC JOIN Unite_Enseignement ON Unite_Enseignement.CodeUE = Element_Constitutif.CodeUE WHERE Unite_Enseignement.CodeParcours ='IG' AND Unite_Enseignement.CodeNiveau ='L2' AND`Matricule` = '" + mat + "'");
        }

       /* public string [] info()
        {
            return execute("SELECT Matricule`,`Nom`, `Prenoms` FROM ");
        }*/

    }
}
