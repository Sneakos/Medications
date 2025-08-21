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
using System.Configuration;

namespace Medications
{
    public partial class Game : Form
    {
        #region Instance Variables

        private List<string> _meds, _medUses, _sideEffects;
        private SortedList<string, Image> _catList;
        private Random _rnd;
        private Button _btnAnswer;
        private int _totalScore, _score, _gameMode, _currCat, _firstCat;
        private int _maxScore = 20;
        private double _winPercent;
        private Size _catMedalSize = new Size(40, 40);
        private Image _dog;
        private Mode _parent;
        private bool _hardClose, _debugMode;
        private ResourceManager _resources;
        private string _catFileName, _errorFileName;

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
                _errorFileName = GetErrorFileName();
                _meds = new List<string>();
                _medUses = new List<string>();
                _sideEffects = new List<string>();
                _catList = new SortedList<string, Image>();
                _hardClose = true;
                _rnd = new Random();
                _totalScore = 0;
                _score = 0;
                _maxScore = GetMaxScore();
                _winPercent = GetWinPercent();
                _parent = parentForm;
                _gameMode = gameMode;
                lblScore.Text = "Score: " + _score + "/" + _totalScore;
                _resources = new ResourceManager(typeof(Resources));
                _catFileName = GetCatFileName(_gameMode);
                string text = File.ReadAllText(_catFileName);
                _currCat = Convert.ToInt32(text.Substring(65, 2));
                _firstCat = _currCat;
                _debugMode = GetDebugMode();

                if (!_debugMode)
                {                    
                    btnResetCats.Visible = false;
                }

                PopulateMedications();
                
                SetupImages();

                NewQuestion();
                
                CenterToParent();
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured (see log)");
                if (_errorFileName != null)
                {
                    File.AppendAllText(_errorFileName, DateTime.Now + Environment.NewLine + e.ToString() + Environment.NewLine);
                }
                Environment.Exit(1);
            }
        }

        private void SetupImages()
        {
            _dog = (Image)_resources.GetObject("LoserDog");
            _dog = ResizeImage(_dog, pbResultPicture.Width, pbResultPicture.Height);

            if (_currCat > 0)
                btnViewMedals.Visible = true;

            ResourceSet set = _resources.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            string currMode = "Mode" + _gameMode;

            foreach (DictionaryEntry entry in set)
            {
                if (entry.Value.GetType().Equals(typeof(Bitmap)) 
                    && entry.Key.ToString().Contains("Cat")
                    && entry.Key.ToString().Contains(currMode))
                {
                    _catList.Add(entry.Key.ToString(), (Image)entry.Value);
                }
            }

            for (int i = 0; i < _currCat; i++)
            {
                AddCatMedal(_catList.Values[i], i);
            }
        }

        private void PopulateMedications()
        {
            string[] drugs = _resources.GetString("Drugs").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            _meds.AddRange(drugs);


            string[] drugUses = _resources.GetString("DrugUses").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            _medUses.AddRange(drugUses);


            string[] effects = _resources.GetString("SideEffects").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            _sideEffects.AddRange(effects);
        }

        #endregion

        #region Methods

        private void AddCatMedal(Image cat, int index)
        {
            cat = ResizeImage(cat, _catMedalSize.Width, _catMedalSize.Height);
            PictureBox pbCat = new PictureBox
            {
                Size = _catMedalSize,
                Image = cat
            };
            pnlCatMedals.Controls.Add(pbCat);
            int x = (_catMedalSize.Width + 10) * index % ((_catMedalSize.Width + 10) * 4);
            int y = (_catMedalSize.Height + 10) * (index / 4);
            pbCat.Location = new Point(x, y);
        }

        public void NewQuestion()
        {
            int randomNumber = _rnd.Next(0, _meds.Count);
            int correctButton = _rnd.Next(1, 5);

            string correctUse = _medUses[randomNumber];
            string correctDrug = _meds[randomNumber];
            string correctSideEffect = _sideEffects[randomNumber];
            string correctAnswer = _gameMode == 1 ? correctDrug : _gameMode == 2 ? correctUse : correctSideEffect;

            rtbPrompt.Text = _gameMode == 1 ? correctUse : correctDrug;

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
                rtbAnswer1.Text = _medUses[randoms[0]];
            }
            else
            {
                btnAnswer1.Text = correctAnswer;
                _btnAnswer = btnAnswer1;
                rtbAnswer1.Text = correctUse;
            }

            if (correctButton != 2)
            {
                btnAnswer2.Text = wrongOption[randoms[1]];
                rtbAnswer2.Text = _medUses[randoms[1]];
            }
            else
            {
                btnAnswer2.Text = correctAnswer;
                _btnAnswer = btnAnswer2;
                rtbAnswer2.Text = correctUse;
            }

            if (correctButton != 3)
            {
                btnAnswer3.Text = wrongOption[randoms[2]];
                rtbAnswer3.Text = _medUses[randoms[2]];
            }
            else
            {
                btnAnswer3.Text = correctAnswer;
                _btnAnswer = btnAnswer3;
                rtbAnswer3.Text = correctUse;
            }

            if (correctButton != 4)
            {
                btnAnswer4.Text = wrongOption[randoms[3]];
                rtbAnswer4.Text = _medUses[randoms[3]];
            }
            else
            {
                btnAnswer4.Text = correctAnswer;
                _btnAnswer = btnAnswer4;
                rtbAnswer4.Text = correctUse;
            }

            if (_debugMode)
                _btnAnswer.BackColor = Color.Blue;
        }

        private List<string> GetWrongOptions()
        {
            List<string> wrongOption;
            if (_gameMode == 1) //Drugs
            {
                wrongOption = _meds;
            }
            else if (_gameMode == 2) //Drug Uses
            {
                wrongOption = _medUses;
            }
            else //Side Effects
            {
                wrongOption = _sideEffects;
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
                    random = _rnd.Next(0, _meds.Count);
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

            if (_gameMode == 3)
            {
                if (_sideEffects[random].Equals(correctAnswer))
                    return true;
                for (int i = 0; i < randoms.Count; i++)
                {
                    if (_sideEffects[random].Equals(_sideEffects[i]))
                        return true;
                }
                return false;
            }

            if (_medUses[random].Equals(correctUse))
                return true;

            for (int i = 0; i < randoms.Count; i++)
            {
                if (_medUses[random].Equals(_medUses[i]))
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

            if (_score >= _totalScore * _winPercent)
            {
                int index = _currCat < _catList.Count ? _currCat : _currCat - 1;
                
                pbResultPicture.Image = ResizeImage(_catList.Values[index], pbResultPicture.Width, pbResultPicture.Height);
                if (_currCat < _catList.Count)
                {
                    AddCatMedal(pbResultPicture.Image, _currCat);
                    AddCatMedal(pbResultPicture.Image, _currCat);
                    AddCatMedal(pbResultPicture.Image, _currCat);
                    AddCatMedal(pbResultPicture.Image, _currCat);
                    _currCat++;
                    File.WriteAllText(_catFileName, GenerateRandomString(_currCat));
                }
                btnViewMedals.Visible = true;
            }
            else
                pbResultPicture.Image = _dog;
        }

        private String GenerateRandomString(int number)
        {
            string str = "";
            int[] nums = new int[265];
            for (int i = 0; i < 265; i++)
                nums[i] = _rnd.Next(10);
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

            if (_gameMode != 2)
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

        private string GetCatFileName(int gameMode)
        {
            string filesFolder = ConfigurationManager.AppSettings["FilesFolder"];

            return $@"{filesFolder}\CatsEarned{gameMode}.txt";
        }

        private string GetErrorFileName()
        {
            return ConfigurationManager.AppSettings["ErrorFile"];
        }

        private bool GetDebugMode()
        {
            string debugMode = ConfigurationManager.AppSettings["Debug"];
            return bool.Parse(debugMode);
        }

        private int GetMaxScore()
        {
            string maxScore = ConfigurationManager.AppSettings["QuestionsPerRound"];
            return int.Parse(maxScore);
        }

        private double GetWinPercent()
        {
            string winPercent = ConfigurationManager.AppSettings["WinPercent"];
            return double.Parse(winPercent);
        }

        private void PlayAgain()
        {
            _score = 0;
            _totalScore = 0;

            lblScore.Text = "Score: " + _score + "/" + _totalScore;

            btnPlayAgain.Visible = false;
            btnNext.Visible = true;
            pbResultPicture.Visible = false;

            NextQuestion();
        }

        #endregion Methods

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
            Gallery gallery = new Gallery(_catList, _currCat);
            gallery.ShowDialog();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            PlayAgain();
        }

        private void RtbPrompt_Enter(object sender, EventArgs e)
        {
            rtbPrompt.Enabled = false;
            rtbPrompt.Enabled = true;
        }

        private void BtnResetCats_Click(object sender, EventArgs e)
        {
            pnlCatMedals.Controls.Clear();
            _currCat = 0;
            File.WriteAllText(_catFileName, GenerateRandomString(_currCat));

        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button btnHit = (Button)sender;
            if (!btnHit.Equals(_btnAnswer))
            {
                btnHit.BackColor = Color.Red;
            }
            else
            {
                _score++;
            }
            _totalScore++;

            _btnAnswer.BackColor = Color.LightGreen;

            btnAnswer1.Enabled = false;
            btnAnswer2.Enabled = false;
            btnAnswer3.Enabled = false;
            btnAnswer4.Enabled = false;
            btnNext.Enabled = true;

            if (_gameMode != 2)
            {
                rtbAnswer1.Visible = true;
                rtbAnswer2.Visible = true;
                rtbAnswer3.Visible = true;
                rtbAnswer4.Visible = true;
            }

            lblScore.Text = "Score: " + _score + "/" + _totalScore;

            if (_totalScore == _maxScore)
            {
                EndGame();
            }
        }

        private void BtnReturnToMenu_Click(object sender, EventArgs e)
        {
            _parent.Show();
            _parent.SetFocus();
            _hardClose = false;
            Close();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        private void BtnPlayAgain_Click(object sender, EventArgs e)
        {
            PlayAgain();
        }
    
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_hardClose)
                Environment.Exit(1);
        }

        #endregion Events
    }
}
