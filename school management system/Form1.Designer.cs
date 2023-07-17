namespace management_system
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_titleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.DesktopPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTestResult = new System.Windows.Forms.Button();
            this.btnScore = new System.Windows.Forms.Button();
            this.btnClass = new System.Windows.Forms.Button();
            this.btnSemester = new System.Windows.Forms.Button();
            this.btnEC = new System.Windows.Forms.Button();
            this.btnUE = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panel_titleBar.SuspendLayout();
            this.DesktopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.Gray;
            this.panelMenu.Controls.Add(this.button2);
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btnTestResult);
            this.panelMenu.Controls.Add(this.btnScore);
            this.panelMenu.Controls.Add(this.btnClass);
            this.panelMenu.Controls.Add(this.btnSemester);
            this.panelMenu.Controls.Add(this.btnEC);
            this.panelMenu.Controls.Add(this.btnUE);
            this.panelMenu.Controls.Add(this.btnRegister);
            this.panelMenu.Controls.Add(this.btnStudent);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.Color.ForestGreen;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(271, 953);
            this.panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.ForeColor = System.Drawing.Color.White;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(271, 103);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Garamond", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(49, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scolarité";
            // 
            // panel_titleBar
            // 
            this.panel_titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel_titleBar.Controls.Add(this.btnCloseChildForm);
            this.panel_titleBar.Controls.Add(this.lblTitle);
            this.panel_titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_titleBar.Location = new System.Drawing.Point(271, 0);
            this.panel_titleBar.Name = "panel_titleBar";
            this.panel_titleBar.Size = new System.Drawing.Size(911, 103);
            this.panel_titleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitle.Location = new System.Drawing.Point(383, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(142, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Accueil";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DesktopPanel
            // 
            this.DesktopPanel.Controls.Add(this.pictureBox1);
            this.DesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DesktopPanel.ForeColor = System.Drawing.Color.MediumBlue;
            this.DesktopPanel.Location = new System.Drawing.Point(271, 103);
            this.DesktopPanel.Name = "DesktopPanel";
            this.DesktopPanel.Size = new System.Drawing.Size(911, 850);
            this.DesktopPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::management_system.Properties.Resources.home_1000px;
            this.pictureBox1.Location = new System.Drawing.Point(224, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(465, 283);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCloseChildForm.Image = global::management_system.Properties.Resources.delete_50px;
            this.btnCloseChildForm.Location = new System.Drawing.Point(19, 12);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(75, 80);
            this.btnCloseChildForm.TabIndex = 1;
            this.btnCloseChildForm.UseVisualStyleBackColor = false;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click_1);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Image = global::management_system.Properties.Resources.exit_50px;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 681);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(271, 60);
            this.button2.TabIndex = 10;
            this.button2.Text = " Sortie";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Image = global::management_system.Properties.Resources.leaderboard_50px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 582);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(271, 99);
            this.button1.TabIndex = 9;
            this.button1.Text = "Résultat par classe";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTestResult
            // 
            this.btnTestResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTestResult.FlatAppearance.BorderSize = 0;
            this.btnTestResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestResult.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestResult.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestResult.Image = global::management_system.Properties.Resources.pass_fail_40px;
            this.btnTestResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestResult.Location = new System.Drawing.Point(0, 522);
            this.btnTestResult.Name = "btnTestResult";
            this.btnTestResult.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnTestResult.Size = new System.Drawing.Size(271, 60);
            this.btnTestResult.TabIndex = 8;
            this.btnTestResult.Text = "  Bulletin";
            this.btnTestResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestResult.UseVisualStyleBackColor = false;
            this.btnTestResult.Click += new System.EventHandler(this.btnTestResult_Click);
            // 
            // btnScore
            // 
            this.btnScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScore.FlatAppearance.BorderSize = 0;
            this.btnScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScore.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScore.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnScore.Image = global::management_system.Properties.Resources.grades_40px;
            this.btnScore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScore.Location = new System.Drawing.Point(0, 462);
            this.btnScore.Name = "btnScore";
            this.btnScore.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnScore.Size = new System.Drawing.Size(271, 60);
            this.btnScore.TabIndex = 7;
            this.btnScore.Text = "  Notes";
            this.btnScore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScore.UseVisualStyleBackColor = false;
            this.btnScore.Click += new System.EventHandler(this.btnScore_Click);
            // 
            // btnClass
            // 
            this.btnClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClass.FlatAppearance.BorderSize = 0;
            this.btnClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClass.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClass.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClass.Image = global::management_system.Properties.Resources.classroom_50px;
            this.btnClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClass.Location = new System.Drawing.Point(0, 402);
            this.btnClass.Name = "btnClass";
            this.btnClass.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClass.Size = new System.Drawing.Size(271, 60);
            this.btnClass.TabIndex = 6;
            this.btnClass.Text = " Classes";
            this.btnClass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClass.UseVisualStyleBackColor = false;
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // btnSemester
            // 
            this.btnSemester.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSemester.FlatAppearance.BorderSize = 0;
            this.btnSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemester.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemester.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSemester.Image = global::management_system.Properties.Resources.calendar_35px;
            this.btnSemester.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSemester.Location = new System.Drawing.Point(0, 342);
            this.btnSemester.Name = "btnSemester";
            this.btnSemester.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnSemester.Size = new System.Drawing.Size(271, 60);
            this.btnSemester.TabIndex = 5;
            this.btnSemester.Text = "   Semestres";
            this.btnSemester.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSemester.UseVisualStyleBackColor = false;
            this.btnSemester.Click += new System.EventHandler(this.btnSemester_Click);
            // 
            // btnEC
            // 
            this.btnEC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEC.FlatAppearance.BorderSize = 0;
            this.btnEC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEC.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEC.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEC.Image = global::management_system.Properties.Resources.course_40px1;
            this.btnEC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEC.Location = new System.Drawing.Point(0, 282);
            this.btnEC.Name = "btnEC";
            this.btnEC.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnEC.Size = new System.Drawing.Size(271, 60);
            this.btnEC.TabIndex = 4;
            this.btnEC.Text = "  EC";
            this.btnEC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEC.UseVisualStyleBackColor = false;
            this.btnEC.Click += new System.EventHandler(this.btnEC_Click);
            // 
            // btnUE
            // 
            this.btnUE.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUE.FlatAppearance.BorderSize = 0;
            this.btnUE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUE.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUE.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnUE.Image = global::management_system.Properties.Resources.course_40px;
            this.btnUE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUE.Location = new System.Drawing.Point(0, 222);
            this.btnUE.Name = "btnUE";
            this.btnUE.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnUE.Size = new System.Drawing.Size(271, 60);
            this.btnUE.TabIndex = 3;
            this.btnUE.Text = "  UE";
            this.btnUE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUE.UseVisualStyleBackColor = false;
            this.btnUE.Click += new System.EventHandler(this.btnUE_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegister.Image = global::management_system.Properties.Resources.admission_40px;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.Location = new System.Drawing.Point(0, 163);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnRegister.Size = new System.Drawing.Size(271, 59);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "  Inscription";
            this.btnRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudent.FlatAppearance.BorderSize = 0;
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudent.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStudent.Image = global::management_system.Properties.Resources.woman_student_48px;
            this.btnStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudent.Location = new System.Drawing.Point(0, 103);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnStudent.Size = new System.Drawing.Size(271, 60);
            this.btnStudent.TabIndex = 1;
            this.btnStudent.Text = " Etudiants";
            this.btnStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudent.UseVisualStyleBackColor = false;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.Controls.Add(this.DesktopPanel);
            this.Controls.Add(this.panel_titleBar);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panel_titleBar.ResumeLayout(false);
            this.panel_titleBar.PerformLayout();
            this.DesktopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_titleBar;
        private System.Windows.Forms.Panel DesktopPanel;
        private System.Windows.Forms.Button btnSemester;
        private System.Windows.Forms.Button btnEC;
        private System.Windows.Forms.Button btnUE;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.Button btnClass;
        private System.Windows.Forms.Button btnTestResult;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

