using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_emtehani
{
    public partial class CompetitionPage : UserControl
    {
        public CompetitionPage()
        {
            InitializeComponent();
        }

        private void CompetitionPage_Load(object sender, EventArgs e)
        {
            //dataGridView100.DataSource = DataSql.Show_Friend();
           
        }

        private void createcontestmain_Click(object sender, EventArgs e)
        {
            DataSql.Make_Contest(usernametoinvitein.Text);
        }

        private void acceptcontestmain_Click(object sender, EventArgs e)
        {
            DataSql.Accept_Contest(usernameinvitertextbox.Text);
        }

        private void usernameinvitertextbox_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void CompetitionPage_VisibleChanged(object sender, EventArgs e)
        {
            if (LoginPage.idplayeringame != -1)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
                connection.Open();
                List<Player> players = new List<Player>();
                players = DataSql.playersinsql();
                var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
                usernameinvitertextbox.Text = playeringameplaying.friendthathavecontestwith.ToString();
                countwintextbox.Text = playeringameplaying.countwin.ToString();
                countlosetextbox.Text = playeringameplaying.countlose.ToString();   
                dataGridView100.DataSource = DataSql.Show_Friend();
            }
        }

        private void button_rejectcontestmain_Click(object sender, EventArgs e)
        {
            DataSql.Reject_Contest();
        }

        private void button_seeresault_Click(object sender, EventArgs e)
        {
            DataSql.See_Resault();
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
            usernameinvitertextbox.Text = playeringameplaying.friendthathavecontestwith.ToString();
            countwintextbox.Text = playeringameplaying.countwin.ToString();
            countlosetextbox.Text = playeringameplaying.countlose.ToString();
        }

        private void updatefriendlist_Click(object sender, EventArgs e)
        {

        }
    }
}
