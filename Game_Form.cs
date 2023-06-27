using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project_emtehani
{
    public partial class Game_Form : Form
    {
        public static Game_Form instance;
        public static class Two_Picture
        {
            public static PictureBox P1 = new PictureBox();
            public static PictureBox P2 = new PictureBox();
            public static bool isP1selected = false;
            public static bool isP2selected = false;
        }

        public List<PictureBox> picturelist;
        public Player playeringameplaying;
        public Game_Form()
        {
            InitializeComponent();
            picturelist = new List<PictureBox>();
            instance = this;
        }
        public void Random_Candy(List<PictureBox> pictures)
        {
            Random rnd = new Random();
            foreach (var picture in pictures)
            {
                int rnd_num_option = rnd.Next(1, 6);
                switch (rnd_num_option)
                {
                    case 1:
                        {
                            picture.BackgroundImage = Candy_376.BackgroundImage;
                            break;
                        }
                    case 2:
                        {
                            picture.BackgroundImage = Candy_377.BackgroundImage;
                            break;
                        }

                    case 3:
                        {
                            picture.BackgroundImage = Candy_378.BackgroundImage;
                            break;
                        }
                    case 4:
                        {
                            picture.BackgroundImage = Candy_379.BackgroundImage;
                            break;
                        }
                    case 5:
                        {
                            picture.BackgroundImage = Candy_380.BackgroundImage;
                            break;
                        }
                }
            }

        }
        public void Check_three_Candy(List<PictureBox> pictures)
        {
            foreach (var picture in pictures)
            {
                int num_right = int.Parse(picture.Name.Substring(10)) + 1;
                bool num_right_exist = true;
                if (((num_right + 1) % 8 == 1) || num_right + 1 > 64)
                {
                    num_right_exist = false;
                }
                int num_left = int.Parse(picture.Name.Substring(10)) - 1;
                bool num_left_exist = true;
                if (((num_left - 1) % 8 == 0) || num_left - 1 < 1)
                {
                    num_left_exist = false;
                }
                int num_up = int.Parse(picture.Name.Substring(10)) - 8;
                bool num_up_exist = true;
                if ((num_up - 8) < 1)
                {
                    num_up_exist = false;
                }
                int num_down = int.Parse(picture.Name.Substring(10)) + 8;
                bool num_down_exist = true;
                if ((num_down + 8) > 64)
                {
                    num_down_exist = false;
                }

                if (picture.BackgroundImage != null)
                {
                    if (num_right_exist)
                    {
                        if ((pictures[num_right - 1].BackgroundImage == picture.BackgroundImage) && (num_right % 8 != 1) && num_right_exist)
                        {
                            if ((pictures[num_right + 1 - 1].BackgroundImage == picture.BackgroundImage) && ((num_right + 1) % 8 != 1))
                            {
                                Score(picture);
                                topscore();
                                picture.BackgroundImage = null;
                                pictures[num_right - 1].BackgroundImage = null;
                                pictures[num_right + 1 - 1].BackgroundImage = null;

                            }
                        }
                    }
                    if (num_left_exist)
                    {
                        if ((pictures[num_left - 1].BackgroundImage == picture.BackgroundImage) && (num_left % 8 != 0) && num_left_exist)
                        {
                            if ((pictures[num_left - 1 - 1].BackgroundImage == picture.BackgroundImage) && ((num_left + 1) % 8 != 0))
                            {
                                Score(picture);
                                topscore();
                                picture.BackgroundImage = null;
                                pictures[num_left - 1].BackgroundImage = null;
                                pictures[num_left + 1 - 1].BackgroundImage = null;

                            }
                        }
                    }
                    if (num_up_exist)
                    {
                        if ((pictures[num_up - 1].BackgroundImage == picture.BackgroundImage) && (num_up >= 1) && num_up_exist)
                        {
                            if ((pictures[num_up - 8 - 1].BackgroundImage == picture.BackgroundImage) && ((num_up - 8) >= 1))
                            {
                                Score(picture);
                                topscore();
                                picture.BackgroundImage = null;
                                pictures[num_up - 1].BackgroundImage = null;
                                pictures[num_up - 8 - 1].BackgroundImage = null;


                            }
                        }
                    }
                    if (num_down_exist)
                    {
                        if ((pictures[num_down - 1].BackgroundImage == picture.BackgroundImage) && (num_down <= 64) && num_down_exist)
                        {
                            if ((pictures[num_down + 8 - 1].BackgroundImage == picture.BackgroundImage) && ((num_down + 8) <= 0))
                            {
                                Score(picture);
                                topscore();
                                picture.BackgroundImage = null;
                                pictures[num_down - 1].BackgroundImage = null;
                                pictures[num_down + 8 - 1].BackgroundImage = null;


                            }
                        }
                    }
                }
            }
            scoreofplayer.Text = playeringameplaying.score.ToString();

        }
        public void Gravity_For_Candy(List<PictureBox> pictures)
        {

            bool up_null_is_candy = true;
            while (up_null_is_candy)
            {
                foreach (PictureBox picture in pictures)
                {
                    int num_up = int.Parse(picture.Name.Substring(10)) - 8;
                    bool num_up_exist = true;
                    if (num_up < 1)
                    {
                        num_up_exist = false;
                    }
                    if (num_up_exist)
                    {
                        if (picture.BackgroundImage == null)
                        {
                            picture.BackgroundImage = pictures[num_up - 1].BackgroundImage;
                            pictures[num_up - 1].BackgroundImage = null;
                        }
                    }
                }
                bool checked_null = true;
                foreach (PictureBox picture2 in pictures)
                {
                    int num_up_2 = int.Parse(picture2.Name.Substring(10)) - 8;
                    bool num_up_2_exist = true;

                    if (num_up_2 < 1)
                    {
                        num_up_2_exist = false;
                    }
                    if (num_up_2_exist)
                    {
                        if (picture2.BackgroundImage == null)
                        {
                            if (pictures[num_up_2 - 1].BackgroundImage != null)
                            {
                                //Check_three_Candy(pictures);
                                up_null_is_candy = true;
                                checked_null = false;
                                break;
                            }
                        }
                    }
                }
                if (checked_null)
                {
                    up_null_is_candy = false;
                }
            }


        }
        public void Refill_After_Gravity(List<PictureBox> pictures)
        {
            Random rnd = new Random();
            bool refill_again = true;
            while (refill_again)
            {


                foreach (var picture in pictures)
                {
                    if (picture.BackgroundImage == null)
                    {
                        int rnd_num_option = rnd.Next(1, 6);
                        switch (rnd_num_option)
                        {
                            case 1:
                                {
                                    picture.BackgroundImage = Candy_376.BackgroundImage;
                                    break;
                                }
                            case 2:
                                {
                                    picture.BackgroundImage = Candy_377.BackgroundImage;
                                    break;
                                }

                            case 3:
                                {
                                    picture.BackgroundImage = Candy_378.BackgroundImage;
                                    break;
                                }
                            case 4:
                                {
                                    picture.BackgroundImage = Candy_379.BackgroundImage;
                                    break;
                                }
                            case 5:
                                {
                                    picture.BackgroundImage = Candy_380.BackgroundImage;
                                    break;
                                }
                        }
                        //Check_three_Candy(pictures);
                    }
                }
                Check_three_Candy(pictures);
                bool null_picture = false;
                foreach (var picture2 in pictures)
                {
                    if (picture2.BackgroundImage == null)
                    {
                        null_picture = true;
                        refill_again = true;
                        break;
                    }
                }
                if (!null_picture)
                {
                    refill_again = false;
                }
            }
            ///////////////
            ///


        }
        public void topscore()
        {
            if (int.Parse(scoreofplayer.Text) > int.Parse(topscoreofplayer.Text))
            {

                playeringameplaying.topscore = playeringameplaying.score;
                scoreofplayer.Text = playeringameplaying.score.ToString();
                topscoreofplayer.Text = scoreofplayer.Text;
            }
        }
        public void Score(PictureBox picture)
        {
            if (picture.BackgroundImage == Candy_376.BackgroundImage)
            {
                playeringameplaying.score = playeringameplaying.score + 10;
            }
            else if (picture.BackgroundImage == Candy_377.BackgroundImage)
            {
                playeringameplaying.score = playeringameplaying.score + 20;
            }
            else if (picture.BackgroundImage == Candy_378.BackgroundImage)
            {
                playeringameplaying.score = playeringameplaying.score + 40;
            }
            else if (picture.BackgroundImage == Candy_379.BackgroundImage)
            {
                playeringameplaying.score = playeringameplaying.score + 80;
            }
            else if (picture.BackgroundImage == Candy_380.BackgroundImage)
            {
                playeringameplaying.score = playeringameplaying.score + 100;
            }
            scoreofplayer.Text = playeringameplaying.score.ToString();
        }
        public void Game_Form_Load(object sender, EventArgs e)
        {


            if (LoginPage.idplayeringame != -1)
            {
                List<Player> players = new List<Player>();
                players = DataSql.playersinsql();
                playeringameplaying = players.FirstOrDefault(p => p.Id == LoginPage.idplayeringame);
                picturelist = this.Controls.OfType<PictureBox>().ToList();
                picturelist = picturelist.OrderBy(p => int.Parse(p.Name.Substring(10))).ToList();
                int trmptopscorebeforegame = playeringameplaying.topscore;
                Random_Candy(picturelist);
                Check_three_Candy(picturelist);
                Gravity_For_Candy(picturelist);
                Refill_After_Gravity(picturelist);
                playeringameplaying.score = 0;
                scoreofplayer.Text = playeringameplaying.score.ToString();
                playeringameplaying.topscore= trmptopscorebeforegame;
                topscoreofplayer.Text = playeringameplaying.topscore.ToString();
            }
            else
            {
                MessageBox.Show("plz first login to your account");
                Game_Form.instance.Close();

            }

        }


        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (!Two_Picture.isP1selected)
            {
                Two_Picture.isP1selected = true;
                Two_Picture.P1 = (PictureBox)sender;
            }
            else if (!Two_Picture.isP2selected)
            {
                Two_Picture.isP2selected = true;
                Two_Picture.P2 = (PictureBox)sender;
                int num_right = int.Parse(Two_Picture.P1.Name.Substring(10)) + 1;
                if (num_right % 8 == 1)
                {
                    num_right = 100;
                }
                int num_left = int.Parse(Two_Picture.P1.Name.Substring(10)) - 1;
                if (num_left % 8 == 0)
                {
                    num_left = 100;
                }
                int num_up = int.Parse(Two_Picture.P1.Name.Substring(10)) - 8;
                if (num_up < 1)
                {
                    num_up = 100;
                }
                int num_down = int.Parse(Two_Picture.P1.Name.Substring(10)) + 8;
                if (num_down > 64)
                {
                    num_down = 100;
                }
                if (Two_Picture.isP1selected && Two_Picture.isP2selected)
                {
                    if (int.Parse(Two_Picture.P2.Name.Substring(10)) == num_right || int.Parse(Two_Picture.P2.Name.Substring(10)) == num_left
                        || int.Parse(Two_Picture.P2.Name.Substring(10)) == num_up || int.Parse(Two_Picture.P2.Name.Substring(10)) == num_down)
                    {
                        var temppicture = Two_Picture.P2.BackgroundImage;
                        Two_Picture.P2.BackgroundImage = Two_Picture.P1.BackgroundImage;
                        Two_Picture.P1.BackgroundImage = temppicture;
                        Check_three_Candy(picturelist);
                        Gravity_For_Candy(picturelist);
                        Thread.Sleep(50);
                        Refill_After_Gravity(picturelist);

                        Two_Picture.isP1selected = false;
                        Two_Picture.isP2selected = false;
                    }
                    else
                    {
                        MessageBox.Show("you must choose up , down , left or right if its possible !");
                        Two_Picture.isP1selected = false;
                        Two_Picture.isP2selected = false;
                    }

                }
            }


        }


        private void Game_Form_Shown(object sender, EventArgs e)
        {

        }
        private void Game_Form_Activated(object sender, EventArgs e)
        {

        }

        private void Refill_again_Click(object sender, EventArgs e)
        {
            int tempscore = playeringameplaying.score;
            int temptopscore = playeringameplaying.topscore;
            Random_Candy(picturelist);
            Check_three_Candy(picturelist);
            Gravity_For_Candy(picturelist);
            Refill_After_Gravity(picturelist);
            playeringameplaying.score = 0;
            playeringameplaying.topscore= temptopscore;
            scoreofplayer.Text = playeringameplaying.score.ToString();
            topscoreofplayer.Text = playeringameplaying.topscore.ToString();
        }

        private void accountinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"name : {playeringameplaying.name}\n " +
                $"family = {playeringameplaying.familyname}\n" +
                $"username = {playeringameplaying.username}\n" +
                $"password = {playeringameplaying.password} \n");
        }

        private void saveandexit_Click(object sender, EventArgs e)
        {
            DataSql.Save_Exit_Game(int.Parse(scoreofplayer.Text), int.Parse(topscoreofplayer.Text));
            Game_Form.instance.Close();
        }
    }
}
