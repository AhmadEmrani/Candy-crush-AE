using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;

namespace project_emtehani
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            loginPage1.Hide();
            friend1.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game_Form game_Form = new Game_Form();
            game_Form.Show();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            competitionPage1.Hide();
            friend1.Hide();
            loginPage1.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBase>());
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            connection.Close();
            friend1.Hide();
            competitionPage1.Hide();
            loginPage1.Show();

        }

        private void button_addfriend_Click(object sender, EventArgs e)
        {
            competitionPage1.Hide();
            loginPage1.Hide();
            if (LoginPage.idplayeringame != -1)
            {
                friend1.Show();
            }
            else
            {
                MessageBox.Show($"you must login first \n " +
                    $"for login press login button" );

            }
        }

        private void button_makecontest_Click(object sender, EventArgs e)
        {
            loginPage1.Hide();
            friend1.Hide();
            if (LoginPage.idplayeringame != -1)
            {
                competitionPage1.Show();
            }
            else
            {
                MessageBox.Show($"you must login first \n " +
                    $"for login press login button");

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Have a good day ");
            Form1.instance.Close();
        }
    }
}
