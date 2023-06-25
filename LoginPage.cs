using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project_emtehani
{
    public partial class LoginPage : UserControl
    {
        public static LoginPage instance ;
        public  DataBase db = new DataBase();
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
            string name = Nametextbox.Text;
            string familyname = FamilynametextBox.Text;
            string username = Usernamecreate.Text;
            string password = Passwordcreate.Text;
            List<Player> playersforlogincheck = db.Players.ToList();
            var repatative = playersforlogincheck.First(q => q.username == username);
            if (repatative == null)
            {
                Player p = new Player(name, familyname, username, password);
                db.Players.Add(p);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show($"this username : ({username}) used before you plz try another one");
            }

        }
        private void loginto_Click(object sender, EventArgs e)
        {
            string usernamelogin1 = usernamelogin.Text;
            string passwordlogin1 = passwordlogin.Text;
            List<Player> playersforlogin = db.Players.ToList();
            var playerfind = playersforlogin.FirstOrDefault(p => p.username==usernamelogin1);
            if (playerfind.password == passwordlogin1)
            {
                playeringame = playerfind;
                playeringame.score= 0;
                MessageBox.Show($"hello {playerfind.name}  {playerfind.familyname} now you can play...");
            }
            else
            {
                MessageBox.Show($"there is no player with this username or password try again !");
            }
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

       
    }
}
