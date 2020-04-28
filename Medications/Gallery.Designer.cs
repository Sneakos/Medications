namespace Medications
{
    partial class Gallery
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
            this.pbCatMedal = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCatMedal)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCatMedal
            // 
            this.pbCatMedal.Location = new System.Drawing.Point(66, 0);
            this.pbCatMedal.Name = "pbCatMedal";
            this.pbCatMedal.Size = new System.Drawing.Size(542, 519);
            this.pbCatMedal.TabIndex = 0;
            this.pbCatMedal.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(614, 223);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 48);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(4, 223);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(56, 48);
            this.btnBack.TabIndex = 2;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // Gallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 520);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pbCatMedal);
            this.Name = "Gallery";
            this.Text = "Gallery";
            ((System.ComponentModel.ISupportInitialize)(this.pbCatMedal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCatMedal;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
    }
}