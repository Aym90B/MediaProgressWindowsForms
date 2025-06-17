namespace MediaProgressWindowsForms
{
    partial class FrmAddEditEpisodes
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEpisodeID = new System.Windows.Forms.Label();
            this.seasonsComboBox = new System.Windows.Forms.ComboBox();
            this.txtEpisodeNumber = new System.Windows.Forms.TextBox();
            this.txtEpisodeName = new System.Windows.Forms.TextBox();
            this.txtEpisodeRating = new System.Windows.Forms.TextBox();
            this.txtEpisodeDuration = new System.Windows.Forms.TextBox();
            this.checkBoxCompleted = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbSeries = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(322, 30);
            this.lblMode.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(95, 13);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Add New Episodes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Episode ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Series";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Season";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Episode Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 195);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Rating";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 258);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Duration";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 290);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Completed";
            // 
            // lblEpisodeID
            // 
            this.lblEpisodeID.AutoSize = true;
            this.lblEpisodeID.Location = new System.Drawing.Point(252, 80);
            this.lblEpisodeID.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblEpisodeID.Name = "lblEpisodeID";
            this.lblEpisodeID.Size = new System.Drawing.Size(22, 13);
            this.lblEpisodeID.TabIndex = 9;
            this.lblEpisodeID.Text = "???";
            // 
            // seasonsComboBox
            // 
            this.seasonsComboBox.FormattingEnabled = true;
            this.seasonsComboBox.Location = new System.Drawing.Point(254, 137);
            this.seasonsComboBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.seasonsComboBox.Name = "seasonsComboBox";
            this.seasonsComboBox.Size = new System.Drawing.Size(51, 21);
            this.seasonsComboBox.TabIndex = 11;
           
            // 
            // txtEpisodeNumber
            // 
            this.txtEpisodeNumber.Location = new System.Drawing.Point(254, 165);
            this.txtEpisodeNumber.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtEpisodeNumber.Name = "txtEpisodeNumber";
            this.txtEpisodeNumber.Size = new System.Drawing.Size(51, 20);
            this.txtEpisodeNumber.TabIndex = 12;
            // 
            // txtEpisodeName
            // 
            this.txtEpisodeName.Location = new System.Drawing.Point(254, 194);
            this.txtEpisodeName.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtEpisodeName.Name = "txtEpisodeName";
            this.txtEpisodeName.Size = new System.Drawing.Size(153, 20);
            this.txtEpisodeName.TabIndex = 13;
            // 
            // txtEpisodeRating
            // 
            this.txtEpisodeRating.Location = new System.Drawing.Point(254, 228);
            this.txtEpisodeRating.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtEpisodeRating.Name = "txtEpisodeRating";
            this.txtEpisodeRating.Size = new System.Drawing.Size(42, 20);
            this.txtEpisodeRating.TabIndex = 14;
            // 
            // txtEpisodeDuration
            // 
            this.txtEpisodeDuration.Location = new System.Drawing.Point(254, 258);
            this.txtEpisodeDuration.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtEpisodeDuration.Name = "txtEpisodeDuration";
            this.txtEpisodeDuration.Size = new System.Drawing.Size(42, 20);
            this.txtEpisodeDuration.TabIndex = 15;
            // 
            // checkBoxCompleted
            // 
            this.checkBoxCompleted.AutoSize = true;
            this.checkBoxCompleted.Location = new System.Drawing.Point(254, 290);
            this.checkBoxCompleted.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.checkBoxCompleted.Name = "checkBoxCompleted";
            this.checkBoxCompleted.Size = new System.Drawing.Size(74, 17);
            this.checkBoxCompleted.TabIndex = 16;
            this.checkBoxCompleted.Text = "Watched?";
            this.checkBoxCompleted.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(473, 258);
            this.btnSave.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 45);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(597, 258);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 45);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbSeries
            // 
            this.cbSeries.FormattingEnabled = true;
            this.cbSeries.Location = new System.Drawing.Point(254, 109);
            this.cbSeries.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cbSeries.Name = "cbSeries";
            this.cbSeries.Size = new System.Drawing.Size(348, 21);
            this.cbSeries.TabIndex = 19;
            // 
            // FrmAddEditEpisodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 375);
            this.Controls.Add(this.cbSeries);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkBoxCompleted);
            this.Controls.Add(this.txtEpisodeDuration);
            this.Controls.Add(this.txtEpisodeRating);
            this.Controls.Add(this.txtEpisodeName);
            this.Controls.Add(this.txtEpisodeNumber);
            this.Controls.Add(this.seasonsComboBox);
            this.Controls.Add(this.lblEpisodeID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "FrmAddEditEpisodes";
            this.Text = "FrmAddEditEpisodes";
            this.Load += new System.EventHandler(this.FrmAddEditEpisodes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEpisodeID;
        private System.Windows.Forms.ComboBox seasonsComboBox;
        private System.Windows.Forms.TextBox txtEpisodeNumber;
        private System.Windows.Forms.TextBox txtEpisodeName;
        private System.Windows.Forms.TextBox txtEpisodeRating;
        private System.Windows.Forms.TextBox txtEpisodeDuration;
        private System.Windows.Forms.CheckBox checkBoxCompleted;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbSeries;
    }
}