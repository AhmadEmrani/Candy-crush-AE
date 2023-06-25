using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_emtehani
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance= this;
            loginPage1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game_Form game_Form = new Game_Form();
            game_Form.Show();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
           loginPage1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}
