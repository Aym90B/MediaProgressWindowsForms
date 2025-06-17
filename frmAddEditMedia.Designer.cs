namespace MediaProgressWindowsForms
{
    partial class frmAddEditMedia
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
            this.lblMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMovieID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.checkBoxCompleted = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSeason = new System.Windows.Forms.Label();
            this.txtSeason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSeries = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEpisodeNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(855, 33);
            this.lblMode.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(198, 33);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Add New Movie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 83);
            this.label1.TabIndex = 1;
            this.label1.Text = "Media ID";
            // 
            // lblMovieID
            // 
            this.lblMovieID.AutoSize = true;
            this.lblMovieID.Location = new System.Drawing.Point(365, 160);
            this.lblMovieID.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMovieID.Name = "lblMovieID";
            this.lblMovieID.Size = new System.Drawing.Size(54, 33);
            this.lblMovieID.TabIndex = 2;
            this.lblMovieID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 251);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 343);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 579);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 33);
            this.label4.TabIndex = 5;
            this.label4.Text = "Duration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 685);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 33);
            this.label5.TabIndex = 6;
            this.label5.Text = "Completed";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(372, 251);
            this.txtName.Margin = new System.Windows.Forms.Padding(8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(532, 40);
            this.txtName.TabIndex = 7;
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(372, 336);
            this.txtRating.Margin = new System.Windows.Forms.Padding(8);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(244, 40);
            this.txtRating.TabIndex = 8;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(372, 579);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(8);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(244, 40);
            this.txtDuration.TabIndex = 9;
            // 
            // checkBoxCompleted
            // 
            this.checkBoxCompleted.AutoSize = true;
            this.checkBoxCompleted.Location = new System.Drawing.Point(372, 685);
            this.checkBoxCompleted.Margin = new System.Windows.Forms.Padding(8);
            this.checkBoxCompleted.Name = "checkBoxCompleted";
            this.checkBoxCompleted.Size = new System.Drawing.Size(169, 37);
            this.checkBoxCompleted.TabIndex = 10;
            this.checkBoxCompleted.Text = "Watched?";
            this.checkBoxCompleted.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1391, 345);
            this.btnClose.Margin = new System.Windows.Forms.Padding(8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(188, 58);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1158, 345);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(188, 58);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Location = new System.Drawing.Point(155, 415);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(100, 33);
            this.lblSeason.TabIndex = 13;
            this.lblSeason.Text = "Season";
            // 
            // txtSeason
            // 
            this.txtSeason.Location = new System.Drawing.Point(365, 408);
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.Size = new System.Drawing.Size(557, 40);
            this.txtSeason.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 774);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 33);
            this.label6.TabIndex = 15;
            this.label6.Text = "Series / Genre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 891);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 33);
            this.label7.TabIndex = 16;
            this.label7.Text = "Category";
            // 
            // cbSeries
            // 
            this.cbSeries.FormattingEnabled = true;
            this.cbSeries.Location = new System.Drawing.Point(365, 774);
            this.cbSeries.Name = "cbSeries";
            this.cbSeries.Size = new System.Drawing.Size(538, 41);
            this.cbSeries.TabIndex = 17;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(370, 896);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(533, 41);
            this.cbCategory.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(94, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 33);
            this.label8.TabIndex = 19;
            this.label8.Text = "Episode Number";
            // 
            // txtEpisodeNumber
            // 
            this.txtEpisodeNumber.Location = new System.Drawing.Point(372, 488);
            this.txtEpisodeNumber.Name = "txtEpisodeNumber";
            this.txtEpisodeNumber.Size = new System.Drawing.Size(511, 40);
            this.txtEpisodeNumber.TabIndex = 20;
            // 
            // frmAddEditMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2000, 1142);
            this.Controls.Add(this.txtEpisodeNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbSeries);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSeason);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.checkBoxCompleted);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMovieID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMode);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "frmAddEditMedia";
            this.Text = "Add Edit Movie";
            this.Load += new System.EventHandler(this.frmAddEditMovie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMovieID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.CheckBox checkBoxCompleted;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.TextBox txtSeason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSeries;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEpisodeNumber;
    }
}