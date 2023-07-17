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
    public partial class ManageForm : Form
    {
        ManageClass manage = new ManageClass();
        public ManageForm()
        {
            InitializeComponent();
            showfield();
            showlevel();
            showclass();
        }

        private void button_add_level_Click(object sender, EventArgs e)
        {
            string level = textBox_level.Text;
            string desc = textBox_descLevel.Text;

            if(textBox_level.Text=="" || textBox_descLevel.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if(manage.insertLevel(level, desc))
                    {
                        showlevel();
                        button_clear_level.PerformClick();
                        MessageBox.Show("Niveau ajouté", "Ajout de niveau", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n Ce niveau existe déjà!", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void showlevel()
        {
            DataGridView_level.DataSource = manage.getList(new MySqlCommand("SELECT * FROM `Niveau`"));
            comboBox_level.DataSource= manage.getList(new MySqlCommand("SELECT `CodeNiveau` FROM `Niveau`"));
            comboBox_level.DisplayMember = "CodeNiveau";
            comboBox_level.ValueMember = "CodeNiveau";
        }

        private void button_add_field_Click(object sender, EventArgs e)
        {
            string field = textBox_field.Text;
            string desc = textBox_descField.Text;

            if (textBox_field.Text == "" || textBox_descField.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
              
                    try
                    {
                        if (manage.insertField(field, desc))
                        {
                            showfield();
                            button_clear_field.PerformClick();
                            MessageBox.Show("Parcours ajouté", "Ajout de parcours", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\nCe parcours existe déjà!", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
              
            }
        }

        public void showfield()
        {
            DataGridView_field.DataSource = manage.getList(new MySqlCommand("SELECT * FROM `Parcours`"));
            comboBox_field.DataSource = manage.getList(new MySqlCommand("SELECT `CodeParcours` FROM `Parcours`"));
            comboBox_field.DisplayMember = "CodeParcours";
            comboBox_field.ValueMember = "CodeParcours";
        }



        private void button_update_level_Click(object sender, EventArgs e)
        {
            string level = textBox_level.Text;
            string desc = textBox_descLevel.Text;

            if (textBox_level.Text == "" || textBox_descLevel.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Modification impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (manage.updateLevel(level, desc))
                        {
                            showlevel();
                            button_clear_level.PerformClick();
                            MessageBox.Show("Niveau modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DataGridView_level_Click(object sender, EventArgs e)
        {
            textBox_level.Text = DataGridView_level.CurrentRow.Cells[0].Value.ToString();
            textBox_descLevel.Text = DataGridView_level.CurrentRow.Cells[1].Value.ToString();
        }

        private void DataGridView_field_Click(object sender, EventArgs e)
        {
            textBox_field.Text = DataGridView_field.CurrentRow.Cells[0].Value.ToString();
            textBox_descField.Text = DataGridView_field.CurrentRow.Cells[1].Value.ToString() ;
        }

        private void button_update_field_Click(object sender, EventArgs e)
        {
            string field = textBox_field.Text;
            string desc = textBox_descField.Text;

            if (textBox_field.Text == "")
            {
                MessageBox.Show("Champ(s) vide(s)", "Modification impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (MessageBox.Show("Voulez vraiment vous modifier?", "Modification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (manage.updateField(field, desc))
                        {
                            showfield();
                            button_clear_field.PerformClick();
                            MessageBox.Show("Parcours modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button_clear_level_Click(object sender, EventArgs e)
        {
            textBox_level.Clear();
            textBox_descLevel.Clear();
        }

        private void button_clear_field_Click(object sender, EventArgs e)
        {
            textBox_field.Clear();
            textBox_descField.Clear();
        }

        private void button_delete_level_Click(object sender, EventArgs e)
        {
            string level = textBox_level.Text;
            if (textBox_level.Text == "")
            {
                MessageBox.Show("Champ Niveau vide", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (manage.deleteLevel(level))
                        {
                            showlevel();
                            button_clear_level.PerformClick();
                            MessageBox.Show("Niveau supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button_delete_field_Click(object sender, EventArgs e)
        {
            string field = textBox_field.Text;

            if(textBox_field.Text.Equals(""))
            {
                MessageBox.Show("Champ Parcours vide", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (manage.deleteField(field))
                        {
                            showfield();
                            button_clear_field.PerformClick();
                            MessageBox.Show("Parcours supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button_add_class_Click(object sender, EventArgs e)
        {
            string Class = comboBox_level.Text + " " + comboBox_field.Text;
            string level = comboBox_level.Text;
            string field = comboBox_field.Text;

            if(level == "")
            {
                MessageBox.Show("Niveau non sélectionné", "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if(manage.insertClass(Class, level, field))
                    {
                        showclass();
                        MessageBox.Show("Classe ajoutée", "Ajout d'une classe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n Cette classe existe déjà!", "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void button_update_class_Click(object sender, EventArgs e)
        {

        }

        private void button_clear_class_Click(object sender, EventArgs e)
        {
            
        }

        private void button_delete_class_Click(object sender, EventArgs e)
        {
            string Class = DataGridView_class.CurrentRow.Cells[0].Value.ToString();
            /*if (textBox_level.Text == "")
            {
                MessageBox.Show("Champ Niveau vide", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
            //else
            //{

            if (MessageBox.Show("Voulez vraiment vous supprimer?", "Suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    if (manage.deleteClass(Class))
                    {
                        showclass();
                        //button_clear_level.PerformClick();
                        MessageBox.Show("Grade supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur de suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Suppression annulée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
            //}
        }

        public void showclass()
        {
            DataGridView_class.DataSource = manage.getList(new MySqlCommand("SELECT * FROM `Grade`"));
        }
    }
}
