using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project_emtehani
{
    public partial class LoginPage : UserControl
    {
        public static int idplayeringame=-1;
        public static LoginPage instance;
        public DataBase db = new DataBase();
        public DataBase database;
        public Player playeringame;
        public LoginPage()
        {
            InitializeComponent();
            instance = this;
            database = db;
        }
        private void createaccount_Click(object sender, EventArgs e)
        {
            //List<Player> list = DataSql.playersinsql();
            DataSql.Add_Player(int.Parse(IDtextBox.Text),Nametextbox.Text, FamilynametextBox.Text, Usernamecreate.Text, Passwordcreate.Text);
            LoginPage.instance.Hide();
            usernamelogin.Text = null; passwordlogin.Text = null;
            Usernamecreate.Text = null; Passwordcreate.Text = null;
            IDtextBox.Text = null; Nametextbox.Text = null; FamilynametextBox.Text = null;
        }
        private void loginto_Click(object sender, EventArgs e)
        {
            idplayeringame = DataSql.Login_to_Account(usernamelogin.Text, passwordlogin.Text);
            usernamelogin.Text = null; passwordlogin.Text = null;
            Usernamecreate.Text = null; Passwordcreate.Text = null;
            IDtextBox.Text = null; Nametextbox.Text = null; FamilynametextBox.Text = null;
            LoginPage.instance.Hide();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            connection.Close();
        }
    }
}
