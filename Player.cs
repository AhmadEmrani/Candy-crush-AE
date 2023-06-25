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
        public Player(string name, string familyname, string username, string passwor) 
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

    }
}
