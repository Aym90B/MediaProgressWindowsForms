namespace MediaProgressWindowsForms
{
    partial class frmAddEditSeries
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
            this.label7 = new System.Windows.Forms.Label();
            this.lblSeriesID = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtSeasons = new System.Windows.Forms.TextBox();
            this.checkBoxCompleted = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(930, 54);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(200, 33);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Add New Series";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "SeriesID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 488);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rating";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 586);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seasons";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 691);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 33);
            this.label7.TabIndex = 6;
            this.label7.Text = "Completed";
            // 
            // lblSeriesID
            // 
            this.lblSeriesID.AutoSize = true;
            this.lblSeriesID.Location = new System.Drawing.Point(545, 201);
            this.lblSeriesID.Name = "lblSeriesID";
            this.lblSeriesID.Size = new System.Drawing.Size(54, 33);
            this.lblSeriesID.TabIndex = 7;
            this.lblSeriesID.Text = "???";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(542, 319);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(816, 40);
            this.txtName.TabIndex = 8;
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(542, 488);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(816, 40);
            this.txtRating.TabIndex = 9;
            // 
            // txtSeasons
            // 
            this.txtSeasons.Location = new System.Drawing.Point(542, 586);
            this.txtSeasons.Name = "txtSeasons";
            this.txtSeasons.Size = new System.Drawing.Size(100, 40);
            this.txtSeasons.TabIndex = 10;
            // 
            // checkBoxCompleted
            // 
            this.checkBoxCompleted.AutoSize = true;
            this.checkBoxCompleted.Location = new System.Drawing.Point(542, 691);
            this.checkBoxCompleted.Name = "checkBoxCompleted";
            this.checkBoxCompleted.Size = new System.Drawing.Size(169, 37);
            this.checkBoxCompleted.TabIndex = 11;
            this.checkBoxCompleted.Text = "Watched?";
            this.checkBoxCompleted.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(729, 774);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(244, 87);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1023, 774);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(244, 87);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(355, 405);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(117, 33);
            this.lblDuration.TabIndex = 14;
            this.lblDuration.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(542, 405);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(816, 40);
            this.txtDuration.TabIndex = 15;
            // 
            // frmAddEditSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2057, 1107);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkBoxCompleted);
            this.Controls.Add(this.txtSeasons);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSeriesID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Name = "frmAddEditSeries";
            this.Text = "Add Edit Series";
            this.Load += new System.EventHandler(this.frmAddEditSeries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSeriesID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtSeasons;
        private System.Windows.Forms.CheckBox checkBoxCompleted;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtDuration;
    }
}