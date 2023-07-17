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
    public partial class LoginForm : Form
    {
        LoginClass login = new LoginClass();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Nom d'utilisateur")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Gray;
            }
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nom d'utilisateur";
                textBox1.ForeColor = Color.ForestGreen;
            }
            
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Mot de passe")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Gray;
                textBox4.UseSystemPasswordChar = true;
            }
            //label2.Hide();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Mot de passe";
                textBox4.ForeColor = Color.ForestGreen;
                textBox4.UseSystemPasswordChar = false;
            }
        }

     

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
          
            if (textBox1.Text == "Nom d'utilisateur" && textBox4.Text == "Mot de passe")
            {
                // MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Text = "Veuillez entrer le nom d'utilisateur!";
                label2.Text = "Veuillez entrer le mot de passe!";
            }
            else if(textBox4.Text == "" || textBox4.Text == "Mot de passe")
            {
                label2.Text = "Veuillez entrer le mot de passe!";
                //label1.Hide();
            }
            else if(textBox1.Text == "" || textBox1.Text == "Nom d'utilisateur")
            {
                label1.Text = "Veuillez entrer le nom d'utilisateur!";
                
            }
            else
            {
                string uname = textBox1.Text;
                string pass = textBox4.Text;

               
                DataTable table = login.getList(new MySqlCommand("SELECT * FROM `user` WHERE `username`= '" + uname + "' AND `password`='" + pass + "'"));
                
                if (table.Rows.Count > 0)
                {
                    Form1 main = new Form1();
                    this.Hide();
                    main.Show();
                }
                else if (textBox4.Text != table.Columns[1].ToString() || textBox1.Text != table.Columns[0].ToString())
                {
                    //MessageBox.Show("Invalid username or password", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label2.Text = "Mot de passe incorrect";
                    label1.Text = "Veuillez vérifier le nom d'utilisateur";
                }
            
              
                    
                //else if ()
                //{
                //    label2.Text = "Mot de passe incorrect";
                //    label1.Text = "Nom d'utilisateur incorrect";
                //}



               
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Transparent;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
