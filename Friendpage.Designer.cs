namespace project_emtehani
{
    partial class Friendpage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listoffriendsshow = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.usernameaddfriend = new System.Windows.Forms.TextBox();
            this.addtofriendbutton = new System.Windows.Forms.Button();
            this.showfriends = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listoffriendsshow)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureBox1.Location = new System.Drawing.Point(197, -134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 761);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 45);
            this.label5.TabIndex = 10;
            this.label5.Text = "Add friend";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "list of friends :";
            // 
            // listoffriendsshow
            // 
            this.listoffriendsshow.BackgroundColor = System.Drawing.Color.Snow;
            this.listoffriendsshow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listoffriendsshow.Location = new System.Drawing.Point(238, 68);
            this.listoffriendsshow.Name = "listoffriendsshow";
            this.listoffriendsshow.Size = new System.Drawing.Size(306, 326);
            this.listoffriendsshow.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "type Username then press add :";
            // 
            // usernameaddfriend
            // 
            this.usernameaddfriend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameaddfriend.ForeColor = System.Drawing.SystemColors.InfoText;
            this.usernameaddfriend.Location = new System.Drawing.Point(11, 100);
            this.usernameaddfriend.Name = "usernameaddfriend";
            this.usernameaddfriend.Size = new System.Drawing.Size(107, 20);
            this.usernameaddfriend.TabIndex = 14;
            // 
            // addtofriendbutton
            // 
            this.addtofriendbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.addtofriendbutton.Location = new System.Drawing.Point(11, 137);
            this.addtofriendbutton.Name = "addtofriendbutton";
            this.addtofriendbutton.Size = new System.Drawing.Size(167, 43);
            this.addtofriendbutton.TabIndex = 15;
            this.addtofriendbutton.Text = "Add to friend";
            this.addtofriendbutton.UseVisualStyleBackColor = false;
            this.addtofriendbutton.Click += new System.EventHandler(this.addtofriendbutton_Click);
            // 
            // showfriends
            // 
            this.showfriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.showfriends.Location = new System.Drawing.Point(11, 200);
            this.showfriends.Name = "showfriends";
            this.showfriends.Size = new System.Drawing.Size(167, 43);
            this.showfriends.TabIndex = 16;
            this.showfriends.Text = "Show friends";
            this.showfriends.UseVisualStyleBackColor = false;
            this.showfriends.Click += new System.EventHandler(this.showfriends_Click);
            // 
            // Friendpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.showfriends);
            this.Controls.Add(this.addtofriendbutton);
            this.Controls.Add(this.usernameaddfriend);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listoffriendsshow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Friendpage";
            this.Size = new System.Drawing.Size(556, 409);
            this.Load += new System.EventHandler(this.Friend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listoffriendsshow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listoffriendsshow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox usernameaddfriend;
        private System.Windows.Forms.Button addtofriendbutton;
        private System.Windows.Forms.Button showfriends;
    }
}
