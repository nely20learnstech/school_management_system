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
    public partial class GradeListForm : Form
    {
        DBconnect connect = new DBconnect();
        GradeClass grade = new GradeClass();
        ManageClass manage = new ManageClass();
        public GradeListForm()
        {
            InitializeComponent();
            show_manage_info();
            
        }

        private void button_List_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {
                    showlist(credit_sum(comboBox_field.Text, comboBox_level.Text), comboBox_level.Text, comboBox_field.Text, textBox_year.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Les notes pour cette année et/ou pour cette classe ne sont pas encore définies", "Erreur de listage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_year.Clear();
                    comboBox_field.SelectedIndex = 0;
                    comboBox_level.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Le champ Année est vide", "Impossible de lister", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            
            

        }

        public string credit_sum(string field, string level)
        {
            return execute("SELECT SUM(Credit) FROM Unite_Enseignement WHERE CodeParcours ='" + field + "' AND CodeNiveau ='" + level + "'");
        }

        public string execute(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }

        public void showlist(string credit, string level, string field, string year)
        {
            DataGridView_gradeList.DataSource = grade.getScorelist(new MySqlCommand("SELECT Etudiant.Matricule AS Matricule, Nom, Prenoms, SUM(note*coefficient) / "+ credit +" AS moyenne, IF(SUM(note*coefficient) / " + credit + " >=10, 'Admis', 'Non Admis')" +
            "FROM Note JOIN Element_Constitutif ON Element_Constitutif.CodeEC = Note.CodeEC " +
            "JOIN Etudiant ON Etudiant.Matricule = Note.Matricule WHERE CodeParcours = '"+ field +"' AND CodeNiveau = '"+ level +"' AND Annee = '"+ year +"' GROUP BY Etudiant.Matricule ORDER BY moyenne DESC"));
        }

        public void show_manage_info()
        {
            comboBox_level.DataSource = manage.getList(new MySqlCommand("SELECT `CodeNiveau` FROM `Niveau`"));
            comboBox_level.DisplayMember = "CodeNiveau";
            comboBox_level.ValueMember = "CodeNiveau";

            comboBox_field.DataSource = manage.getList(new MySqlCommand("SELECT `CodeParcours` FROM `Parcours`"));
            comboBox_field.DisplayMember = "CodeParcours";
            comboBox_field.ValueMember = "CodeParcours";
        }

        bool verify()
        {
            if(textBox_year.Text == "")
                return false;
            else
                return true;
                
        }
    }
}
