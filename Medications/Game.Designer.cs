namespace Medications
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.btnAnswer1 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAnswer2 = new System.Windows.Forms.Button();
            this.btnAnswer4 = new System.Windows.Forms.Button();
            this.btnAnswer3 = new System.Windows.Forms.Button();
            this.rtbPrompt = new System.Windows.Forms.RichTextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.rtbAnswer1 = new System.Windows.Forms.RichTextBox();
            this.rtbAnswer2 = new System.Windows.Forms.RichTextBox();
            this.rtbAnswer3 = new System.Windows.Forms.RichTextBox();
            this.rtbAnswer4 = new System.Windows.Forms.RichTextBox();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.pbResultPicture = new System.Windows.Forms.PictureBox();
            this.BtnReturnToMenu = new System.Windows.Forms.Button();
            this.pnlCatMedals = new System.Windows.Forms.Panel();
            this.btnViewMedals = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.btnResetCats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbResultPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnswer1
            // 
            this.btnAnswer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAnswer1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswer1.Location = new System.Drawing.Point(216, 96);
            this.btnAnswer1.Name = "btnAnswer1";
            this.btnAnswer1.Size = new System.Drawing.Size(535, 92);
            this.btnAnswer1.TabIndex = 2;
            this.btnAnswer1.Text = "Answer 1";
            this.btnAnswer1.UseVisualStyleBackColor = false;
            this.btnAnswer1.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(399, 680);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(171, 51);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnAnswer2
            // 
            this.btnAnswer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAnswer2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswer2.Location = new System.Drawing.Point(216, 235);
            this.btnAnswer2.Name = "btnAnswer2";
            this.btnAnswer2.Size = new System.Drawing.Size(535, 92);
            this.btnAnswer2.TabIndex = 7;
            this.btnAnswer2.Text = "Answer 2";
            this.btnAnswer2.UseVisualStyleBackColor = false;
            this.btnAnswer2.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnAnswer4
            // 
            this.btnAnswer4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAnswer4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnswer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswer4.Location = new System.Drawing.Point(216, 522);
            this.btnAnswer4.Name = "btnAnswer4";
            this.btnAnswer4.Size = new System.Drawing.Size(535, 92);
            this.btnAnswer4.TabIndex = 8;
            this.btnAnswer4.Text = "Answer 4";
            this.btnAnswer4.UseVisualStyleBackColor = false;
            this.btnAnswer4.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnAnswer3
            // 
            this.btnAnswer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAnswer3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnswer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswer3.Location = new System.Drawing.Point(216, 378);
            this.btnAnswer3.Name = "btnAnswer3";
            this.btnAnswer3.Size = new System.Drawing.Size(535, 92);
            this.btnAnswer3.TabIndex = 9;
            this.btnAnswer3.Text = "Answer 3";
            this.btnAnswer3.UseVisualStyleBackColor = false;
            this.btnAnswer3.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // rtbPrompt
            // 
            this.rtbPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rtbPrompt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPrompt.Location = new System.Drawing.Point(216, 9);
            this.rtbPrompt.Name = "rtbPrompt";
            this.rtbPrompt.ReadOnly = true;
            this.rtbPrompt.Size = new System.Drawing.Size(535, 64);
            this.rtbPrompt.TabIndex = 10;
            this.rtbPrompt.Text = "";
            this.rtbPrompt.Enter += new System.EventHandler(this.RtbPrompt_Enter);
            this.rtbPrompt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWasPresesd);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(766, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(93, 29);
            this.lblScore.TabIndex = 11;
            this.lblScore.Text = "Score: ";
            // 
            // rtbAnswer1
            // 
            this.rtbAnswer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rtbAnswer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAnswer1.Location = new System.Drawing.Point(216, 194);
            this.rtbAnswer1.Name = "rtbAnswer1";
            this.rtbAnswer1.ReadOnly = true;
            this.rtbAnswer1.Size = new System.Drawing.Size(535, 31);
            this.rtbAnswer1.TabIndex = 16;
            this.rtbAnswer1.Text = "";
            this.rtbAnswer1.Visible = false;
            this.rtbAnswer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWasPresesd);
            // 
            // rtbAnswer2
            // 
            this.rtbAnswer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rtbAnswer2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAnswer2.Location = new System.Drawing.Point(216, 333);
            this.rtbAnswer2.Name = "rtbAnswer2";
            this.rtbAnswer2.ReadOnly = true;
            this.rtbAnswer2.Size = new System.Drawing.Size(535, 31);
            this.rtbAnswer2.TabIndex = 17;
            this.rtbAnswer2.Text = "";
            this.rtbAnswer2.Visible = false;
            this.rtbAnswer2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWasPresesd);
            // 
            // rtbAnswer3
            // 
            this.rtbAnswer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rtbAnswer3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAnswer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAnswer3.Location = new System.Drawing.Point(216, 476);
            this.rtbAnswer3.Name = "rtbAnswer3";
            this.rtbAnswer3.ReadOnly = true;
            this.rtbAnswer3.Size = new System.Drawing.Size(535, 31);
            this.rtbAnswer3.TabIndex = 18;
            this.rtbAnswer3.Text = "";
            this.rtbAnswer3.Visible = false;
            this.rtbAnswer3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWasPresesd);
            // 
            // rtbAnswer4
            // 
            this.rtbAnswer4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.rtbAnswer4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAnswer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAnswer4.Location = new System.Drawing.Point(216, 620);
            this.rtbAnswer4.Name = "rtbAnswer4";
            this.rtbAnswer4.ReadOnly = true;
            this.rtbAnswer4.Size = new System.Drawing.Size(535, 31);
            this.rtbAnswer4.TabIndex = 19;
            this.rtbAnswer4.Text = "";
            this.rtbAnswer4.Visible = false;
            this.rtbAnswer4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyWasPresesd);
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Location = new System.Drawing.Point(399, 680);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(171, 51);
            this.btnPlayAgain.TabIndex = 20;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Visible = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.BtnPlayAgain_Click);
            // 
            // pbResultPicture
            // 
            this.pbResultPicture.BackColor = System.Drawing.Color.White;
            this.pbResultPicture.InitialImage = null;
            this.pbResultPicture.Location = new System.Drawing.Point(12, 9);
            this.pbResultPicture.Name = "pbResultPicture";
            this.pbResultPicture.Size = new System.Drawing.Size(180, 155);
            this.pbResultPicture.TabIndex = 21;
            this.pbResultPicture.TabStop = false;
            this.pbResultPicture.Visible = false;
            // 
            // BtnReturnToMenu
            // 
            this.BtnReturnToMenu.Location = new System.Drawing.Point(12, 694);
            this.BtnReturnToMenu.Name = "BtnReturnToMenu";
            this.BtnReturnToMenu.Size = new System.Drawing.Size(146, 45);
            this.BtnReturnToMenu.TabIndex = 22;
            this.BtnReturnToMenu.Text = "Return To Menu";
            this.BtnReturnToMenu.UseVisualStyleBackColor = true;
            this.BtnReturnToMenu.Click += new System.EventHandler(this.BtnReturnToMenu_Click);
            // 
            // pnlCatMedals
            // 
            this.pnlCatMedals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlCatMedals.Location = new System.Drawing.Point(758, 96);
            this.pnlCatMedals.Name = "pnlCatMedals";
            this.pnlCatMedals.Size = new System.Drawing.Size(255, 300);
            this.pnlCatMedals.TabIndex = 23;
            // 
            // btnViewMedals
            // 
            this.btnViewMedals.Location = new System.Drawing.Point(873, 694);
            this.btnViewMedals.Name = "btnViewMedals";
            this.btnViewMedals.Size = new System.Drawing.Size(131, 45);
            this.btnViewMedals.TabIndex = 24;
            this.btnViewMedals.Text = "View Medals";
            this.btnViewMedals.UseVisualStyleBackColor = true;
            this.btnViewMedals.Visible = false;
            this.btnViewMedals.Click += new System.EventHandler(this.BtnViewMedals_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(164, 694);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(122, 45);
            this.BtnReset.TabIndex = 25;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnResetCats
            // 
            this.btnResetCats.Location = new System.Drawing.Point(736, 694);
            this.btnResetCats.Name = "btnResetCats";
            this.btnResetCats.Size = new System.Drawing.Size(131, 45);
            this.btnResetCats.TabIndex = 26;
            this.btnResetCats.Text = "Reset Kattz";
            this.btnResetCats.UseVisualStyleBackColor = true;
            this.btnResetCats.Click += new System.EventHandler(this.BtnResetCats_Click);
            // 
            // Game
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1028, 751);
            this.Controls.Add(this.btnResetCats);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.btnViewMedals);
            this.Controls.Add(this.pnlCatMedals);
            this.Controls.Add(this.BtnReturnToMenu);
            this.Controls.Add(this.pbResultPicture);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.rtbAnswer4);
            this.Controls.Add(this.rtbAnswer3);
            this.Controls.Add(this.rtbAnswer2);
            this.Controls.Add(this.rtbAnswer1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.rtbPrompt);
            this.Controls.Add(this.btnAnswer3);
            this.Controls.Add(this.btnAnswer4);
            this.Controls.Add(this.btnAnswer2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnAnswer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.Text = "Drugs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbResultPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnswer1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAnswer2;
        private System.Windows.Forms.Button btnAnswer4;
        private System.Windows.Forms.Button btnAnswer3;
        private System.Windows.Forms.RichTextBox rtbPrompt;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.RichTextBox rtbAnswer1;
        private System.Windows.Forms.RichTextBox rtbAnswer2;
        private System.Windows.Forms.RichTextBox rtbAnswer3;
        private System.Windows.Forms.RichTextBox rtbAnswer4;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.PictureBox pbResultPicture;
        private System.Windows.Forms.Button BtnReturnToMenu;
        private System.Windows.Forms.Panel pnlCatMedals;
        private System.Windows.Forms.Button btnViewMedals;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button btnResetCats;
    }
}

