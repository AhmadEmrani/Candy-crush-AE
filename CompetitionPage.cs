using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
