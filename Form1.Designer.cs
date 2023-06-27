namespace project_emtehani
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
            this.Button_start_game = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_makecontest = new System.Windows.Forms.Button();
            this.button_addfriend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.competitionPage1 = new project_emtehani.CompetitionPage();
            this.friend1 = new project_emtehani.Friendpage();
            this.loginPage1 = new project_emtehani.LoginPage();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_start_game
            // 
            this.Button_start_game.Location = new System.Drawing.Point(12, 20);
            this.Button_start_game.Name = "Button_start_game";
            this.Button_start_game.Size = new System.Drawing.Size(200, 62);
            this.Button_start_game.TabIndex = 0;
            this.Button_start_game.Text = "start game";
            this.Button_start_game.UseVisualStyleBackColor = true;
            this.Button_start_game.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_login
            // 
            this.button_login.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_login.Location = new System.Drawing.Point(12, 126);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(200, 62);
            this.button_login.TabIndex = 1;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button_makecontest);
            this.groupBox1.Controls.Add(this.button_addfriend);
            this.groupBox1.Controls.Add(this.button_login);
            this.groupBox1.Controls.Add(this.Button_start_game);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 586);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button_makecontest
            // 
            this.button_makecontest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_makecontest.Location = new System.Drawing.Point(12, 335);
            this.button_makecontest.Name = "button_makecontest";
            this.button_makecontest.Size = new System.Drawing.Size(200, 62);
            this.button_makecontest.TabIndex = 3;
            this.button_makecontest.Text = "competition";
            this.button_makecontest.UseVisualStyleBackColor = true;
            this.button_makecontest.Click += new System.EventHandler(this.button_makecontest_Click);
            // 
            // button_addfriend
            // 
            this.button_addfriend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_addfriend.Location = new System.Drawing.Point(12, 230);
            this.button_addfriend.Name = "button_addfriend";
            this.button_addfriend.Size = new System.Drawing.Size(200, 62);
            this.button_addfriend.TabIndex = 2;
            this.button_addfriend.Text = "friends";
            this.button_addfriend.UseVisualStyleBackColor = true;
            this.button_addfriend.Click += new System.EventHandler(this.button_addfriend_Click);
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(12, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "Exit Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // competitionPage1
            // 
            this.competitionPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.competitionPage1.Location = new System.Drawing.Point(234, 12);
            this.competitionPage1.Name = "competitionPage1";
            this.competitionPage1.Size = new System.Drawing.Size(556, 544);
            this.competitionPage1.TabIndex = 3;
            // 
            // friend1
            // 
            this.friend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.friend1.Location = new System.Drawing.Point(234, 12);
            this.friend1.Name = "friend1";
            this.friend1.Size = new System.Drawing.Size(556, 544);
            this.friend1.TabIndex = 2;
            // 
            // loginPage1
            // 
            this.loginPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loginPage1.Location = new System.Drawing.Point(234, 12);
            this.loginPage1.Name = "loginPage1";
            this.loginPage1.Size = new System.Drawing.Size(554, 544);
            this.loginPage1.TabIndex = 1;
            this.loginPage1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.competitionPage1);
            this.Controls.Add(this.friend1);
            this.Controls.Add(this.loginPage1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_start_game;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.GroupBox groupBox1;
        private LoginPage loginPage1;
        private Friendpage friend1;
        private System.Windows.Forms.Button button_addfriend;
        private CompetitionPage competitionPage1;
        private System.Windows.Forms.Button button_makecontest;
        private System.Windows.Forms.Button button1;
    }
}

