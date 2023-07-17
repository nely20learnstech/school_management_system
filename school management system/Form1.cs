using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace management_system
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            random = new Random();
            btnCloseChildForm.Visible = false;
        }

        //We add the function of drag the form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);

            // If the color has already been selected, we select again to choose a different one.
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;

            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    // By activating / highlight a button, we increase the size of the
                    // Font-zoom effect (here 12.5)
                    currentButton.Font = new System.Drawing.Font("Garamond", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel_titleBar.BackColor = color;

                    //Thz value must be in decimals (0.1, 0.05, -0.1, 0.3) -> Value Percentage
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                    //For the child forms
                    //We save the current theme color
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {

                    previousBtn.BackColor = Color.Gray;
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Garamond", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);//We highlight the button. (Activate)
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.DesktopPanel.Controls.Add(childForm);
            this.DesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            //We show the title (Text) of the child form in the title bar (lbltitle)
            lblTitle.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Accueil";
            panel_titleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCloseChildForm_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StudentForm(), sender);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AdmissionForm(), sender);
        }

        private void btnUE_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UEForm(), sender);
        }

        private void btnEC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ECForm(), sender);
        }

        private void btnSemester_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SemesterForm(), sender);
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageForm(), sender);
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GradeForm(), sender);
        }

        private void btnTestResult_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BulletinForm(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GradeListForm(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
