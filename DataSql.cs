using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM CandyUser2", connection);
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
                string friendacceptcontest = reader.GetString(10);
                string friendthathavecontestwith = reader.GetString(11);
                string requesttohavecontest = reader.GetString(12);
                string finalcontestfinish = reader.GetString(13);
                int scoreincontest = reader.GetInt32(14);
                int countwin = reader.GetInt32(15);
                int countlose = reader.GetInt32(16);
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
                    friendacceptcontest = friendacceptcontest,
                    requesttohavecontest = requesttohavecontest,
                    friendthathavecontestwith=friendthathavecontestwith,
                    finalcontestfinish =finalcontestfinish,
                    scoreincontest= scoreincontest,
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
                    SqlCommand cmd = new SqlCommand("insert into CandyUser2(Id,name,familyname,username,password) values (@id,@name,@familyname,@username,@password)", connection);
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
                SqlCommand cmd = new SqlCommand("update CandyUser2 set friend=@friendtoadd where Id=@id", connection);
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
            if (playeringameplaying.incompetition != "True")
            {
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
                                SqlCommand cmd = new SqlCommand("update CandyUser2 set requesttohavecontest=@boolrequesttohavecontest , friendthathavecontestwith=@friendthathavecontestwith , scoreincontest=@scoreincontest where Id=@id", connection);
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = friendtoplaywith.Id;
                                cmd.Parameters.Add("@boolrequesttohavecontest", SqlDbType.NVarChar).Value = "True";
                                cmd.Parameters.Add("@friendthathavecontestwith", SqlDbType.NVarChar).Value = playeringameplaying.username;
                                cmd.Parameters.Add("@scoreincontest", SqlDbType.Int).Value = 0;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Done succesfully");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("plz first complete your last one");
            }
            connection.Close();
        }
        public static void Save_Exit_Game(int score , int topscore)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
            if(score >= topscore)
            {
                SqlCommand cmd = new SqlCommand("update CandyUser2 set topscore=@topscoreint  where Id=@id", connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                cmd.Parameters.Add("@topscoreint", SqlDbType.Int).Value = score;
                cmd.ExecuteNonQuery();
                MessageBox.Show("New top score :)");
            }
            if(playeringameplaying.incompetition == "True")
            {
                SqlCommand cmd = new SqlCommand("update CandyUser2 set scoreincontest=@scoreincontest , finalcontestfinish=@boolfinalcontestfinish  where Id=@id", connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                cmd.Parameters.Add("@scoreincontest", SqlDbType.Int).Value = score;
                cmd.Parameters.Add("@boolfinalcontestfinish", SqlDbType.NVarChar).Value = "True";
                cmd.ExecuteNonQuery();
                MessageBox.Show("your competition done too");
            }

            connection.Close();
        }
        public static void Accept_Contest(string usernamethatinviteyou)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);

            if (playeringameplaying.requesttohavecontest == "True")
            {
                var friendthatinviteyou = players.FirstOrDefault(p => p.username == playeringameplaying.friendthathavecontestwith);
                SqlCommand cmd = new SqlCommand("update CandyUser2 set requesttohavecontest=@boolrequesttohavecontest , incompetition=@boolincompetition , friendacceptcontest=@boolfriendacceptcontest , friendthathavecontestwith=@friendthathavecontestwith where Id=@id", connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = friendthatinviteyou.Id;
                cmd.Parameters.Add("@boolrequesttohavecontest", SqlDbType.NVarChar).Value = "False";
                cmd.Parameters.Add("@boolincompetition", SqlDbType.NVarChar).Value = "True";
                cmd.Parameters.Add("@boolfriendacceptcontest", SqlDbType.NVarChar).Value = "True";
                cmd.Parameters.Add("@friendthathavecontestwith", SqlDbType.NVarChar).Value = playeringameplaying.username;
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("update CandyUser2 set requesttohavecontest=@boolrequesttohavecontest , incompetition=@boolincompetition , friendacceptcontest=@boolfriendacceptcontest  where Id=@id", connection);
                cmd2.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                cmd2.Parameters.Add("@boolrequesttohavecontest", SqlDbType.NVarChar).Value = "False";
                cmd2.Parameters.Add("@boolincompetition", SqlDbType.NVarChar).Value = "True";
                cmd2.Parameters.Add("@boolfriendacceptcontest", SqlDbType.NVarChar).Value = "True";
                cmd2.ExecuteNonQuery();
                MessageBox.Show("contest acepted");
            }
            else
            {
                MessageBox.Show("No request");
            }



            connection.Close();
        }
       
        public static void Reject_Contest()
        {
             SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);

            if (playeringameplaying.requesttohavecontest == "True")
            {
                var friendthatinviteyou = players.FirstOrDefault(p => p.username == playeringameplaying.friendthathavecontestwith);
                SqlCommand cmd = new SqlCommand("update CandyUser2 set requesttohavecontest=@boolrequesttohavecontest , incompetition=@boolincompetition , friendacceptcontest=@boolfriendacceptcontest , friendthathavecontestwith=@friendthathavecontestwith  , finalcontestfinish=@boolfinalcontestfinish where Id=@id", connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = friendthatinviteyou.Id;
                cmd.Parameters.Add("@boolrequesttohavecontest", SqlDbType.NVarChar).Value = "False";
                cmd.Parameters.Add("@boolincompetition", SqlDbType.NVarChar).Value = "False";
                cmd.Parameters.Add("@boolfriendacceptcontest", SqlDbType.NVarChar).Value = "False";
                cmd.Parameters.Add("@friendthathavecontestwith", SqlDbType.NVarChar).Value = "No one ";
                cmd.Parameters.Add("@boolfinalcontestfinish", SqlDbType.NVarChar).Value = "False";
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("update CandyUser2 set requesttohavecontest=@boolrequesttohavecontest , incompetition=@boolincompetition , friendacceptcontest=@boolfriendacceptcontest , friendthathavecontestwith=@friendthathavecontestwith , finalcontestfinish=@boolfinalcontestfinish    where Id=@id", connection);
                cmd2.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                cmd2.Parameters.Add("@boolrequesttohavecontest", SqlDbType.NVarChar).Value = "False";
                cmd2.Parameters.Add("@boolincompetition", SqlDbType.NVarChar).Value = "False";
                cmd2.Parameters.Add("@boolfriendacceptcontest", SqlDbType.NVarChar).Value = "False";
                cmd2.Parameters.Add("@friendthathavecontestwith", SqlDbType.NVarChar).Value = "No one ";
                cmd2.Parameters.Add("@boolfinalcontestfinish", SqlDbType.NVarChar).Value = "False";
                cmd2.ExecuteNonQuery();
                MessageBox.Show("contest rejected");
            }
            else
            {
                MessageBox.Show("No request");
            }


            connection.Close();
        }

        public static void See_Resault()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ahmad;Initial Catalog=candycrushahmad2;Integrated Security=True");
            connection.Open();
            List<Player> players = new List<Player>();
            players = DataSql.playersinsql();
            var playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
            var friendthatplayingwith = players.FirstOrDefault(p => p.username == playeringameplaying.friendthathavecontestwith);
            MessageBox.Show($"your score : {playeringameplaying.scoreincontest} \n friend score : {friendthatplayingwith.scoreincontest}");
            if((playeringameplaying.finalcontestfinish=="True") || (friendthatplayingwith.finalcontestfinish == "True"))////////////////////////////////////////////////
            {
                if(playeringameplaying.scoreincontest > friendthatplayingwith.scoreincontest)
                {
                    playeringameplaying.countwin++;
                    MessageBox.Show("you WIN the contest");
                    SqlCommand cmd3 = new SqlCommand("update CandyUser2 set countwin=@countwin  where Id=@id", connection);
                    cmd3.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                    cmd3.Parameters.Add("@countwin", SqlDbType.Int).Value = playeringameplaying.countwin;
                    cmd3.ExecuteNonQuery();
                }
                else
                {
                    playeringameplaying.countlose++;
                    SqlCommand cmd4 = new SqlCommand("update CandyUser2 set countlose=@countlose  where Id=@id", connection);
                    cmd4.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                    cmd4.Parameters.Add("@countlose", SqlDbType.Int).Value = playeringameplaying.countlose;
                    cmd4.ExecuteNonQuery();
                    MessageBox.Show("you LOSE the contest");
                }
                SqlCommand cmd2 = new SqlCommand("update CandyUser2 set requesttohavecontest=@boolrequesttohavecontest , incompetition=@boolincompetition , friendacceptcontest=@boolfriendacceptcontest , friendthathavecontestwith=@friendthathavecontestwith , finalcontestfinish=@boolfinalcontestfinish    where Id=@id", connection);
                cmd2.Parameters.Add("@id", SqlDbType.Int).Value = playeringameplaying.Id;
                cmd2.Parameters.Add("@boolrequesttohavecontest", SqlDbType.NVarChar).Value = "False";
                cmd2.Parameters.Add("@boolincompetition", SqlDbType.NVarChar).Value = "False";
                cmd2.Parameters.Add("@boolfriendacceptcontest", SqlDbType.NVarChar).Value = "False";
                cmd2.Parameters.Add("@friendthathavecontestwith", SqlDbType.NVarChar).Value = "No one ";
                cmd2.Parameters.Add("@boolfinalcontestfinish", SqlDbType.NVarChar).Value = "False";
                cmd2.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("one of you must play game (or both) there is no score yet for you both");
            }
            connection.Close();
        }
    }
}
