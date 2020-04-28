using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Medications.Properties;
using System.Resources;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

namespace Medications
{
    public partial class Game : Form
    {
        #region Instance Variables

        private List<string> meds, medUses, sideEffects;
        private SortedList<string, Image> catList;
        private Random rnd;
        private Button btnAnswer;
        private int totalScore, score, mode, currCat, firstCat;
        private int MAX_SCORE = 20;
        private Size catMedalSize = new Size(40, 40);
        private Image dog;
        private Mode parent;
        private bool hardClose;
        private ResourceManager resources;
        private string catFileName;

        #endregion

        #region Static Methods

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        #endregion

        #region Initializers

        public Game(Mode parentForm, int gameMode)
        {
            InitializeComponent();

            Init(parentForm, gameMode);
        }

        public void Init(Mode parentForm, int gameMode)
        {
            try
            {
                meds = new List<string>();
                medUses = new List<string>();
                sideEffects = new List<string>();
                catList = new SortedList<string, Image>();
                hardClose = true;
                rnd = new Random();
                totalScore = 0;
                score = 0;
                parent = parentForm;
                mode = gameMode;
                lblScore.Text = "Score: " + score + "/" + totalScore;
                resources = new ResourceManager(typeof(Resources));
                catFileName = @".\Files\CatsEarned" + mode + ".txt";
                string text = File.ReadAllText(catFileName);
                currCat = Convert.ToInt32(text.Substring(65, 2));
                firstCat = currCat;
                
                #if DEBUG
                MAX_SCORE = 5;
                #endif

                PopulateMedications();
                
                SetupImages();

                NewQuestion();
                
                CenterToParent();
            }
            catch (Exception e)
            {
                MessageBox.Show("Whoops");
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }

        private void SetupImages()
        {
            dog = (Image)resources.GetObject("LoserDog");
            dog = ResizeImage(dog, pbResultPicture.Width, pbResultPicture.Height);

            if (currCat > 0)
                btnViewMedals.Visible = true;

            ResourceSet set = resources.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            string currMode = "Mode" + mode;

            foreach (DictionaryEntry entry in set)
            {
                if (entry.Value.GetType().Equals(typeof(Bitmap)) 
                    && entry.Key.ToString().Contains("Cat")
                    && entry.Key.ToString().Contains(currMode))
                {
                    catList.Add(entry.Key.ToString(), (Image)entry.Value);
                }
            }

            for (int i = 0; i < currCat; i++)
            {
                AddCatMedal(catList.Values[i], i);
            }
        }

        private void PopulateMedications()
        {
            string[] drugs = resources.GetString("Drugs").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            meds.AddRange(drugs);


            string[] drugUses = resources.GetString("DrugUses").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            medUses.AddRange(drugUses);


            string[] effects = resources.GetString("SideEffects").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            sideEffects.AddRange(effects);
        }

        #endregion

        #region Methods

        private void AddCatMedal(Image cat, int index)
        {
            cat = ResizeImage(cat, catMedalSize.Width, catMedalSize.Height);
            PictureBox pbCat = new PictureBox
            {
                Size = catMedalSize,
                Image = cat
            };
            pnlCatMedals.Controls.Add(pbCat);
            int x = (catMedalSize.Width + 10) * index % ((catMedalSize.Width + 10) * 4);
            int y = (catMedalSize.Height + 10) * (index / 4);
            pbCat.Location = new Point(x, y);
        }

        public void NewQuestion()
        {
            int randomNumber = rnd.Next(0, meds.Count);
            int correctButton = rnd.Next(1, 5);

            string correctUse = medUses[randomNumber];
            string correctDrug = meds[randomNumber];
            string correctSideEffect = sideEffects[randomNumber];
            string correctAnswer = mode == 1 ? correctDrug : mode == 2 ? correctUse : correctSideEffect;

            rtbPrompt.Text = mode == 1 ? correctUse : correctDrug;

            List<int> randoms = GetRandoms(correctUse, correctAnswer);

            List<string> wrongOption = GetWrongOptions();

            SetButtonText(correctButton, correctUse, correctAnswer, randoms, wrongOption);

            CenterText(rtbPrompt);
            CenterText(rtbAnswer1);
            CenterText(rtbAnswer2);
            CenterText(rtbAnswer3);
            CenterText(rtbAnswer4);
        }

        private void SetButtonText(int correctButton, string correctUse, string correctAnswer, List<int> randoms, List<string> wrongOption)
        {
            if (correctButton != 1)
            {
                btnAnswer1.Text = wrongOption[randoms[0]];
                rtbAnswer1.Text = medUses[randoms[0]];
            }
            else
            {
                btnAnswer1.Text = correctAnswer;
                btnAnswer = btnAnswer1;
                rtbAnswer1.Text = correctUse;
            }

            if (correctButton != 2)
            {
                btnAnswer2.Text = wrongOption[randoms[1]];
                rtbAnswer2.Text = medUses[randoms[1]];
            }
            else
            {
                btnAnswer2.Text = correctAnswer;
                btnAnswer = btnAnswer2;
                rtbAnswer2.Text = correctUse;
            }

            if (correctButton != 3)
            {
                btnAnswer3.Text = wrongOption[randoms[2]];
                rtbAnswer3.Text = medUses[randoms[2]];
            }
            else
            {
                btnAnswer3.Text = correctAnswer;
                btnAnswer = btnAnswer3;
                rtbAnswer3.Text = correctUse;
            }

            if (correctButton != 4)
            {
                btnAnswer4.Text = wrongOption[randoms[3]];
                rtbAnswer4.Text = medUses[randoms[3]];
            }
            else
            {
                btnAnswer4.Text = correctAnswer;
                btnAnswer = btnAnswer4;
                rtbAnswer4.Text = correctUse;
            }

            #if DEBUG
              btnAnswer.BackColor = Color.Blue;
            #endif
        }

        private List<string> GetWrongOptions()
        {
            List<string> wrongOption;
            if (mode == 1) //Drugs
            {
                wrongOption = meds;
            }
            else if (mode == 2) //Drug Uses
            {
                wrongOption = medUses;
            }
            else //Side Effects
            {
                wrongOption = sideEffects;
            }

            return wrongOption;
        }

        private List<int> GetRandoms(string correctUse, string correctAnswer)
        {
            List<int> randoms = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int random;
                do
                {
                    random = rnd.Next(0, meds.Count);
                } while (CheckDuplicates(randoms, random, correctUse, correctAnswer));
                randoms.Add(random);
            }

            return randoms;
        }

        public bool CheckDuplicates(List<int> randoms, int random, string correctUse, string correctAnswer)
        {
            if (randoms.Contains(random))
            {
                return true;
            }

            if (mode == 3)
            {
                if (sideEffects[random].Equals(correctAnswer))
                    return true;
                for (int i = 0; i < randoms.Count; i++)
                {
                    if (sideEffects[random].Equals(sideEffects[i]))
                        return true;
                }
                return false;
            }

            if (medUses[random].Equals(correctUse))
                return true;

            for (int i = 0; i < randoms.Count; i++)
            {
                if (medUses[random].Equals(medUses[i]))
                    return true;
            }
            return false;
        }

        public void CenterText(RichTextBox rtb)
        {
            rtb.SelectAll();
            rtb.SelectionAlignment = HorizontalAlignment.Center;
            rtb.DeselectAll();
        }

        public void EndGame()
        {
            btnNext.Visible = false;
            btnPlayAgain.Visible = true;
            pbResultPicture.Visible = true;

            if (score == totalScore)
            {
                int index = currCat < catList.Count ? currCat : currCat - 1;
                
                pbResultPicture.Image = ResizeImage(catList.Values[index], pbResultPicture.Width, pbResultPicture.Height);
                if (currCat < catList.Count)
                {
                    AddCatMedal(pbResultPicture.Image, currCat);
                    AddCatMedal(pbResultPicture.Image, currCat);
                    AddCatMedal(pbResultPicture.Image, currCat);
                    AddCatMedal(pbResultPicture.Image, currCat);
                    currCat++;
                    File.WriteAllText(catFileName, GenerateRandomString(currCat));
                }
                btnViewMedals.Visible = true;
            }
            else
                pbResultPicture.Image = dog;
        }

        private String GenerateRandomString(int number)
        {
            string str = "";
            int[] nums = new int[265];
            for (int i = 0; i < 265; i++)
                nums[i] = rnd.Next(10);
            if (number > 9)
                nums[65] = number;
            else
            {
                nums[65] = 0;
                nums[66] = number;
            }
            foreach (int i in nums)
            {
                str += i;
            }
            return str;
        }

        private void NextQuestion()
        {
            //Original background color of answer choices
            Color orange = Color.FromArgb(255, 255, 224, 192); 

            btnAnswer1.BackColor = orange;
            btnAnswer2.BackColor = orange;
            btnAnswer3.BackColor = orange;
            btnAnswer4.BackColor = orange;

            btnAnswer1.Enabled = true;
            btnAnswer2.Enabled = true;
            btnAnswer3.Enabled = true;
            btnAnswer4.Enabled = true;

            if (mode != 2)
            {
                rtbAnswer1.Visible = false;
                rtbAnswer2.Visible = false;
                rtbAnswer3.Visible = false;
                rtbAnswer4.Visible = false;
            }

            NewQuestion();

            btnNext.Enabled = false;
            SetFocus();
        }

        public void SetFocus()
        {
            rtbPrompt.Focus();
        }

#endregion

        #region Events

        private void KeyWasPresesd(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                NextQuestion();
            }
        }

        private void BtnViewMedals_Click(object sender, EventArgs e)
        {
            Gallery gallery = new Gallery(catList, currCat);
            gallery.ShowDialog();
        }


        private void BtnReset_Click(object sender, EventArgs e)
        {
            score = 0;
            totalScore = 0;
            lblScore.Text = "Score: " + score + "/" + totalScore;
        }


        private void RtbPrompt_Enter(object sender, EventArgs e)
        {
            rtbPrompt.Enabled = false;
            rtbPrompt.Enabled = true;
        }

        private void BtnResetCats_Click(object sender, EventArgs e)
        {
            pnlCatMedals.Controls.Clear();
            currCat = 0;
            File.WriteAllText(catFileName, GenerateRandomString(currCat));

        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button btnHit = (Button)sender;
            if (!btnHit.Equals(btnAnswer))
            {
                btnHit.BackColor = Color.Red;
            }
            else
            {
                score++;
            }
            totalScore++;

            btnAnswer.BackColor = Color.LightGreen;

            btnAnswer1.Enabled = false;
            btnAnswer2.Enabled = false;
            btnAnswer3.Enabled = false;
            btnAnswer4.Enabled = false;
            btnNext.Enabled = true;

            if (mode != 2)
            {
                rtbAnswer1.Visible = true;
                rtbAnswer2.Visible = true;
                rtbAnswer3.Visible = true;
                rtbAnswer4.Visible = true;
            }

            lblScore.Text = "Score: " + score + "/" + totalScore;

            if (totalScore == MAX_SCORE)
            {
                EndGame();
            }
        }

        private void BtnReturnToMenu_Click(object sender, EventArgs e)
        {
            parent.Show();
            parent.SetFocus();
            hardClose = false;
            Close();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        private void BtnPlayAgain_Click(object sender, EventArgs e)
        {

            score = 0;
            totalScore = 0;

            lblScore.Text = "Score: " + score + "/" + totalScore;

            btnPlayAgain.Visible = false;
            btnNext.Visible = true;
            pbResultPicture.Visible = false;

            NextQuestion();
        }
    
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (hardClose)
                Environment.Exit(1);
        }

        #endregion
    }
}
