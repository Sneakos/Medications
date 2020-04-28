using System;
using System.IO;
using System.Windows.Forms;

namespace Medications
{
    public partial class Mode : Form
    {
        public Mode()
        {
            InitializeComponent();

            CenterToParent();
        }

        public void SetFocus()
        {
            rtbReset.Focus();
        }

        private void BtnMode1_Click(object sender, EventArgs e)
        {
            Hide();
            Game game = new Game(this, 1);
            game.Show();
            game.SetFocus();
        }

        private void BtnMode2_Click(object sender, EventArgs e)
        {
            Hide();
            Game game = new Game(this, 2);
            game.Show();
            game.SetFocus();
        }

        private void BtnMode3_Click(object sender, EventArgs e)
        {
            Hide();
            Game game = new Game(this, 3);
            game.Show();
            game.SetFocus();
        }

        private void RtbReset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rtbReset.Text.Equals("reset"))
                {
                    SetFile(@".\Files\CatsEarned1.txt", 0);
                    SetFile(@".\Files\CatsEarned2.txt", 0);
                    SetFile(@".\Files\CatsEarned3.txt", 0);
                }
                if (rtbReset.Text.Contains("set one "))
                {
                    SetFile(@".\Files\CatsEarned1.txt", (int) Char.GetNumericValue(rtbReset.Text[rtbReset.Text.Length - 1]));
                }
                if (rtbReset.Text.Equals("set two "))
                {
                    SetFile(@".\Files\CatsEarned2.txt", (int)Char.GetNumericValue(rtbReset.Text[rtbReset.Text.Length - 1]));
                }
                if (rtbReset.Text.Equals("set three "))
                {
                    SetFile(@".\Files\CatsEarned3.txt", (int)Char.GetNumericValue(rtbReset.Text[rtbReset.Text.Length - 1]));
                }
            }
        }

        private void SetFile(string fileName, int value)
        {
            Random random = new Random();
            string str = "";
            int[] nums = new int[265];
            for (int i = 0; i < 265; i++)
                nums[i] = random.Next(10);

            if (value > 9)
                nums[65] = value;
            else
            {
                nums[65] = 0;
                nums[66] = value;
            }
            foreach (int i in nums)
            {
                str += i;
            }
            File.WriteAllText(fileName, str);
        }
    }
}
