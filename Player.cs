using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_emtehani
{
    public class Player
    {

        public Player() { } 
        public Player(string name, string familyname, string username, string password) 
        {
            this.name = name;
            this.familyname = familyname;
            this.username = username;
            this.password = password;
        }

        public int Id { get; set; }
        public string name { get; set; }
        public string familyname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int score { get; set; }
        public int topscore { get; set; }
        public int countgame { get; set; }
        public List<Player> friends_of_player = new List<Player>();
        public string incompetition { get; set; }
        public int countwin { get; set; }
        public int countlose { get; set; }
        public string friends_id { get; set; }

    }
    public class Friend_Of_Player : Player
    { 
    
    }

}
