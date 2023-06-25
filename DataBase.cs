using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;

namespace project_emtehani
{
    public class DataBase : DbContext
    {
        public static string constring = @"Data Source=(localdb)\local;
Initial Catalog=CandyCrushMain;
Integrated Security=True;
Connect Timeout=30;
Encrypt=False;
Trust Server Certificated=False;
Application Intent=ReadWrite;
Multi Subnet Failover=false";
        public DbSet<Player> Players { get; set; }

    }

}
