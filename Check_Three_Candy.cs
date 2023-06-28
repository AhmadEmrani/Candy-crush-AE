using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_emtehani
{
    public static class Check_Three_Candy
    {
        public static bool Check_Three_Candy_Bool_Two_Picture(List<PictureBox> pictures, PictureBox picture1 , PictureBox picture2)
        {
            PictureBox temp = picture1;
            temp.BackgroundImage = picture1.BackgroundImage;
            picture1.BackgroundImage = picture2.BackgroundImage;
            picture2.BackgroundImage = temp.BackgroundImage;
            bool match_three_for_both=false;
            bool match_three_picture1=Check_Three_Candy.Check_Three_Candy_One_Picture(pictures , picture1);
            bool match_three_picture2= Check_Three_Candy.Check_Three_Candy_One_Picture(pictures, picture2);
            if(match_three_picture1 || match_three_picture2)
            {
                match_three_for_both= true;
            }
            if(match_three_for_both)
            {
                return true;
            }
            return false;

        }
        public static bool Check_Three_Candy_One_Picture(List<PictureBox> pictures, PictureBox picture)
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
                            return true;
                        }
                    }
                }
                if (num_left_exist)
                {
                    if ((pictures[num_left - 1].BackgroundImage == picture.BackgroundImage) && (num_left % 8 != 0) && num_left_exist)
                    {
                        if ((pictures[num_left - 1 - 1].BackgroundImage == picture.BackgroundImage) && ((num_left + 1) % 8 != 0))
                        {

                            return true;

                        }
                    }
                }
                if (num_up_exist)
                {
                    if ((pictures[num_up - 1].BackgroundImage == picture.BackgroundImage) && (num_up >= 1) && num_up_exist)
                    {
                        if ((pictures[num_up - 8 - 1].BackgroundImage == picture.BackgroundImage) && ((num_up - 8) >= 1))
                        {

                            return true;

                        }
                    }
                }
                if (num_down_exist)
                {
                    if ((pictures[num_down - 1].BackgroundImage == picture.BackgroundImage) && (num_down <= 64) && num_down_exist)
                    {
                        if ((pictures[num_down + 8 - 1].BackgroundImage == picture.BackgroundImage) && ((num_down + 8) <= 0))
                        {

                            return true;

                        }
                    }
                }
            }





            return false;
        }
    }
}
