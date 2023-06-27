using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project_emtehani
{
    public class DataSql
    {

        public static List<Player> playersinsql()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CandyUser", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Player> listplayer = new List<Player>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string familyname = reader.GetString(2);
                string username = reader.GetString(3);
                string password = reader.GetString(4);
                int score = reader.GetInt32(5);
                int topscore = reader.GetInt32(6);
                int countgame = reader.GetInt32(7);
                string friendid = reader.GetString(8);
                string incompetition = reader.GetString(9);
                int countwin = reader.GetInt32(10);
                int countlose = reader.GetInt32(11);
                Player player = new Player()
                {
                    Id = id,
                    name = name,
                    familyname = familyname,
                    username = username,
                    password = password,
                    score = score,
                    topscore = topscore,
                    countgame = countgame,
                    friends_id = friendid,
                    incompetition = incompetition,
                    countwin = countwin,
                    countlose = countlose,
                };
                listplayer.Add(player);
            }
            reader.Close();
            connection.Close();
            return listplayer;
        }

        public static void Add_Player(int id, string name, string familyname, string username, string password)
        {
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playerrepeatID = players.FirstOrDefault(p => p.Id == id);
            if (playerrepeatID == null)
            {
                var PLayerrepeatUsername = players.FirstOrDefault(p => p.username == username);
                if (PLayerrepeatUsername == null)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into CandyUser(Id,name,familyname,username,password) values (@id,@name,@familyname,@username,@password)", connection);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@familyname", SqlDbType.NVarChar).Value = familyname;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("player created welcome :)");
                }
                else
                {
                    MessageBox.Show("Enter another username ");
                }
            }
            else
            {
                MessageBox.Show("Enter another ID ");
            }
        }

        public static int Login_to_Account(string username, string password)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            int idfound = -1;
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playerfindusername = players.FirstOrDefault(p => p.username == username);
            if (playerfindusername != null)
            {
                var playerfindpassword = players.FirstOrDefault(p => p.password == password);
                if (playerfindpassword != null)
                {
                    idfound = playerfindusername.Id;
                    MessageBox.Show($"welcome {playerfindusername.name} {playerfindusername.familyname}  :) ");
                }
                else
                {
                    MessageBox.Show("Wrong Password! ");
                }
            }
            else
            {
                MessageBox.Show("no player with this username ! ");
            }

            connection.Close();
            return idfound;
        }


        public static void Add_Friend(string username)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
            var friendtoadd = players.FirstOrDefault(p => p.username == username);
            if (friendtoadd != null)
            {
                string stringidfriendlist = playeringameplaying.friends_id;
                stringidfriendlist = stringidfriendlist + " " + friendtoadd.Id.ToString();
                SqlCommand cmd = new SqlCommand("update CandyUser set friend=@friendtoadd where Id=@id", connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                cmd.Parameters.Add("@friendtoadd", SqlDbType.NVarChar).Value = stringidfriendlist;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("player added to your friends");
            }
            else
            {
                MessageBox.Show("no user found !");
            }
        }


        public static List<Friend_Demonstrate> Show_Friend()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
            string[] friendslist = playeringameplaying.friends_id.Split(' ');
            List<Friend_Demonstrate> friend_Demonstrates = new List<Friend_Demonstrate>();
            foreach (string friendIDinlist in friendslist)
            {
                if (int.Parse(friendIDinlist) == 0)
                {
                    continue;
                }
                else
                {
                    int idtofind = int.Parse(friendIDinlist);
                    var friendtoshow = players.FirstOrDefault(p => p.Id == idtofind);
                    if (friendtoshow != null)
                    {
                        Friend_Demonstrate instancetoshow = new Friend_Demonstrate();
                        instancetoshow.Id = idtofind;
                        instancetoshow.name = friendtoshow.name;
                        instancetoshow.familyname = friendtoshow.familyname;
                        instancetoshow.username = friendtoshow.username;
                        friend_Demonstrates.Add(instancetoshow);
                    }
                }
            }
            connection.Close();
            return friend_Demonstrates;

        }



        public static void Make_Contest(string usernameoffriend)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
            string[] friendslist = playeringameplaying.friends_id.Split(' ');
            foreach (string friendIDinlist in friendslist)
            {
                if (int.Parse(friendIDinlist) == 0)
                {
                    continue;
                }
                else
                {
                    int idtofind = int.Parse(friendIDinlist);
                    var friendtoplaywith = players.FirstOrDefault(p => p.Id == idtofind);
                    if (friendtoplaywith != null)
                    {
                        if (friendtoplaywith.username == usernameoffriend)
                        {
                            SqlCommand cmd = new SqlCommand("update CandyUser set incompetition=@boolincompetition where Id=@id", connection);
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = friendtoplaywith.Id;
                            cmd.Parameters.Add("@boolincompetition", SqlDbType.NVarChar).Value ="True" ;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Done succesfully");
                        }
                    }
                }
            }
            connection.Close();
        }






    }
}
