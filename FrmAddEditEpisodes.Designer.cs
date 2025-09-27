namespace MediaProgressWindowsForms
{
    partial class frmAddEditEpisodes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbxSeriesNames = new System.Windows.Forms.ComboBox();
            this.cbxSeasons = new System.Windows.Forms.ComboBox();
            this.txtEpisodeName = new System.Windows.Forms.TextBox();
            this.txtEpisodeRating = new System.Windows.Forms.TextBox();
            this.txtEpisodeDuration = new System.Windows.Forms.TextBox();
            this.txtEpisodeNumber = new System.Windows.Forms.TextBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.chkWatchAgain = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Series";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Season";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Episode Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Episode Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Episode Rating";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 272);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Episode Duration";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(251, 329);
            this.btnSave.Margin = new System.Windows.Forms.Padding(1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(376, 329);
            this.btnClear.Margin = new System.Windows.Forms.Padding(1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 36);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(501, 329);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbxSeriesNames
            // 
            this.cbxSeriesNames.FormattingEnabled = true;
            this.cbxSeriesNames.Location = new System.Drawing.Point(291, 86);
            this.cbxSeriesNames.Margin = new System.Windows.Forms.Padding(1);
            this.cbxSeriesNames.Name = "cbxSeriesNames";
            this.cbxSeriesNames.Size = new System.Drawing.Size(256, 21);
            this.cbxSeriesNames.TabIndex = 9;
            this.cbxSeriesNames.Text = "Choose Series";
            this.cbxSeriesNames.SelectedIndexChanged += new System.EventHandler(this.cbxSeriesNames_SelectedIndexChanged);
            // 
            // cbxSeasons
            // 
            this.cbxSeasons.FormattingEnabled = true;
            this.cbxSeasons.Location = new System.Drawing.Point(291, 120);
            this.cbxSeasons.Margin = new System.Windows.Forms.Padding(1);
            this.cbxSeasons.Name = "cbxSeasons";
            this.cbxSeasons.Size = new System.Drawing.Size(103, 21);
            this.cbxSeasons.TabIndex = 10;
            this.cbxSeasons.Text = "Choose Season";
            // 
            // txtEpisodeName
            // 
            this.txtEpisodeName.Location = new System.Drawing.Point(291, 188);
            this.txtEpisodeName.Margin = new System.Windows.Forms.Padding(1);
            this.txtEpisodeName.Name = "txtEpisodeName";
            this.txtEpisodeName.Size = new System.Drawing.Size(256, 20);
            this.txtEpisodeName.TabIndex = 12;
            // 
            // txtEpisodeRating
            // 
            this.txtEpisodeRating.Location = new System.Drawing.Point(291, 226);
            this.txtEpisodeRating.Margin = new System.Windows.Forms.Padding(1);
            this.txtEpisodeRating.Name = "txtEpisodeRating";
            this.txtEpisodeRating.Size = new System.Drawing.Size(58, 20);
            this.txtEpisodeRating.TabIndex = 13;
            // 
            // txtEpisodeDuration
            // 
            this.txtEpisodeDuration.Location = new System.Drawing.Point(291, 265);
            this.txtEpisodeDuration.Margin = new System.Windows.Forms.Padding(1);
            this.txtEpisodeDuration.Name = "txtEpisodeDuration";
            this.txtEpisodeDuration.Size = new System.Drawing.Size(58, 20);
            this.txtEpisodeDuration.TabIndex = 14;
            // 
            // txtEpisodeNumber
            // 
            this.txtEpisodeNumber.Location = new System.Drawing.Point(291, 155);
            this.txtEpisodeNumber.Margin = new System.Windows.Forms.Padding(1);
            this.txtEpisodeNumber.Name = "txtEpisodeNumber";
            this.txtEpisodeNumber.Size = new System.Drawing.Size(58, 20);
            this.txtEpisodeNumber.TabIndex = 15;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(347, 26);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(90, 13);
            this.lblMode.TabIndex = 16;
            this.lblMode.Text = "Add New Episode";
            // 
            // chkCompleted
            // 
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Location = new System.Drawing.Point(401, 268);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(77, 17);
            this.chkCompleted.TabIndex = 19;
            this.chkCompleted.Text = "Completed";
            this.chkCompleted.UseVisualStyleBackColor = true;
            // 
            // chkWatchAgain
            // 
            this.chkWatchAgain.AutoSize = true;
            this.chkWatchAgain.Location = new System.Drawing.Point(501, 268);
            this.chkWatchAgain.Name = "chkWatchAgain";
            this.chkWatchAgain.Size = new System.Drawing.Size(87, 17);
            this.chkWatchAgain.TabIndex = 20;
            this.chkWatchAgain.Text = "Watch Again";
            this.chkWatchAgain.UseVisualStyleBackColor = true;
            // 
            // frmAddEditEpisodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 422);
            this.Controls.Add(this.chkWatchAgain);
            this.Controls.Add(this.chkCompleted);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.txtEpisodeNumber);
            this.Controls.Add(this.txtEpisodeDuration);
            this.Controls.Add(this.txtEpisodeRating);
            this.Controls.Add(this.txtEpisodeName);
            this.Controls.Add(this.cbxSeasons);
            this.Controls.Add(this.cbxSeriesNames);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "frmAddEditEpisodes";
            this.Text = "frmAddEditEpisodes";
            this.Load += new System.EventHandler(this.frmAddEditEpisodes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbxSeriesNames;
        private System.Windows.Forms.ComboBox cbxSeasons;
        private System.Windows.Forms.TextBox txtEpisodeName;
        private System.Windows.Forms.TextBox txtEpisodeRating;
        private System.Windows.Forms.TextBox txtEpisodeDuration;
        private System.Windows.Forms.TextBox txtEpisodeNumber;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.CheckBox chkCompleted;
        private System.Windows.Forms.CheckBox chkWatchAgain;
    }
}