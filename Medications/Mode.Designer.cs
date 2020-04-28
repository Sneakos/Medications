namespace Medications
{
    partial class Mode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mode));
            this.lblChooseMode = new System.Windows.Forms.Label();
            this.btnMode1 = new System.Windows.Forms.Button();
            this.btnMode2 = new System.Windows.Forms.Button();
            this.btnMode3 = new System.Windows.Forms.Button();
            this.rtbReset = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblChooseMode
            // 
            this.lblChooseMode.AutoSize = true;
            this.lblChooseMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseMode.Location = new System.Drawing.Point(81, 22);
            this.lblChooseMode.Name = "lblChooseMode";
            this.lblChooseMode.Size = new System.Drawing.Size(297, 39);
            this.lblChooseMode.TabIndex = 0;
            this.lblChooseMode.Text = "Choose The Mode";
            // 
            // btnMode1
            // 
            this.btnMode1.BackColor = System.Drawing.SystemColors.Control;
            this.btnMode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMode1.Location = new System.Drawing.Point(64, 91);
            this.btnMode1.Name = "btnMode1";
            this.btnMode1.Size = new System.Drawing.Size(330, 69);
            this.btnMode1.TabIndex = 1;
            this.btnMode1.Text = "Drug Name From Use";
            this.btnMode1.UseVisualStyleBackColor = false;
            this.btnMode1.Click += new System.EventHandler(this.BtnMode1_Click);
            // 
            // btnMode2
            // 
            this.btnMode2.BackColor = System.Drawing.SystemColors.Control;
            this.btnMode2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMode2.Location = new System.Drawing.Point(64, 198);
            this.btnMode2.Name = "btnMode2";
            this.btnMode2.Size = new System.Drawing.Size(330, 69);
            this.btnMode2.TabIndex = 2;
            this.btnMode2.Text = "Use From Drug Name";
            this.btnMode2.UseVisualStyleBackColor = false;
            this.btnMode2.Click += new System.EventHandler(this.BtnMode2_Click);
            // 
            // btnMode3
            // 
            this.btnMode3.BackColor = System.Drawing.SystemColors.Control;
            this.btnMode3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMode3.Location = new System.Drawing.Point(64, 309);
            this.btnMode3.Name = "btnMode3";
            this.btnMode3.Size = new System.Drawing.Size(330, 69);
            this.btnMode3.TabIndex = 3;
            this.btnMode3.Text = "Side Effects";
            this.btnMode3.UseVisualStyleBackColor = false;
            this.btnMode3.Click += new System.EventHandler(this.BtnMode3_Click);
            // 
            // rtbReset
            // 
            this.rtbReset.Location = new System.Drawing.Point(-2, 393);
            this.rtbReset.Name = "rtbReset";
            this.rtbReset.Size = new System.Drawing.Size(0, 0);
            this.rtbReset.TabIndex = 5;
            this.rtbReset.Text = "";
            this.rtbReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RtbReset_KeyDown);
            // 
            // Mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(467, 414);
            this.Controls.Add(this.rtbReset);
            this.Controls.Add(this.btnMode3);
            this.Controls.Add(this.btnMode2);
            this.Controls.Add(this.btnMode1);
            this.Controls.Add(this.lblChooseMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mode";
            this.Text = "Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChooseMode;
        private System.Windows.Forms.Button btnMode1;
        private System.Windows.Forms.Button btnMode2;
        private System.Windows.Forms.Button btnMode3;
        private System.Windows.Forms.RichTextBox rtbReset;
    }
}