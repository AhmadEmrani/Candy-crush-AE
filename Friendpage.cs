using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_emtehani
{
    public partial class Friendpage : UserControl
    {
        public static Friendpage instance;
        public Friendpage()
        {
            InitializeComponent();
            instance= this;
        }

        private void Friend_Load(object sender, EventArgs e)
        {
           
        }

        private void addtofriendbutton_Click(object sender, EventArgs e)
        {
            DataSql.Add_Friend(usernameaddfriend.Text);
        }

        private void showfriends_Click(object sender, EventArgs e)
        {
            List<Friend_Demonstrate> friendshow = new List<Friend_Demonstrate>();
            friendshow = DataSql.Show_Friend();
            listoffriendsshow.DataSource= friendshow;
        }
    }
    public class Friend_Demonstrate
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string familyname { get; set; }
        public string username { get; set; }
    }
}
