using Medications.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Medications
{
    public partial class Gallery : Form
    {
        SortedList<string, Image> catList;
        int currPicture, lastCat;

        public Gallery(SortedList<String, Image> cats, int currCat)
        {
            InitializeComponent();

            Init(cats, currCat);
        }

        private void Init(SortedList<String, Image> cats, int currCat)
        {
            lastCat = currCat;
            catList = cats;
            btnNext.BackgroundImage = Game.ResizeImage(Resources.Next, btnNext.Width - 5, btnNext.Height - 5);
            btnBack.BackgroundImage = Game.ResizeImage(Resources.BackArrow, btnBack.Width - 5, btnBack.Height - 5);
            pbCatMedal.Image = Game.ResizeImage(catList.Values[0], pbCatMedal.Width, pbCatMedal.Height);
            currPicture = 0;

            CenterToParent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            currPicture--;
            if (currPicture < 0)
            {
                currPicture = lastCat - 1;
            }
            pbCatMedal.Image = Game.ResizeImage(catList.Values[currPicture], pbCatMedal.Width, pbCatMedal.Height);           
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currPicture++;
            currPicture %= lastCat;
            pbCatMedal.Image = Game.ResizeImage(catList.Values[currPicture], pbCatMedal.Width, pbCatMedal.Height);
        }
    }
}
