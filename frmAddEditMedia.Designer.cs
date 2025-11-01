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
            this.components = new System.ComponentModel.Container();
            this.lblMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMovieID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.checkBoxCompleted = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblWatchAgain = new System.Windows.Forms.Label();
            this.chkbxWatchAgain = new System.Windows.Forms.CheckBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblNumberOfSeasons = new System.Windows.Forms.Label();
            this.txtNumberOfSeasons = new System.Windows.Forms.TextBox();
            this.lblWhereToWatch = new System.Windows.Forms.Label();
            this.txtWhereToWatch = new System.Windows.Forms.TextBox();
            this.lblNumberOfEpisodes = new System.Windows.Forms.Label();
            this.txtNumberOfEpisodes = new System.Windows.Forms.TextBox();
            this.lblNumberOfPages = new System.Windows.Forms.Label();
            this.txtNumberOfPages = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CkBxStartWatching = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PbPercentageOfCompletion = new System.Windows.Forms.ProgressBar();
            this.btnAddEpisodes = new System.Windows.Forms.Button();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.txtCurrentPage = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.ep1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(368, 19);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(81, 13);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Add New Media";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Media ID";
            // 
            // lblMovieID
            // 
            this.lblMovieID.AutoSize = true;
            this.lblMovieID.Location = new System.Drawing.Point(165, 63);
            this.lblMovieID.Name = "lblMovieID";
            this.lblMovieID.Size = new System.Drawing.Size(22, 13);
            this.lblMovieID.TabIndex = 2;
            this.lblMovieID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rating";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(72, 171);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(48, 13);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "Duration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Completed";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(168, 99);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 20);
            this.txtName.TabIndex = 7;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(168, 132);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(100, 20);
            this.txtRating.TabIndex = 8;
            this.txtRating.Validating += new System.ComponentModel.CancelEventHandler(this.txtRating_Validating);
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(170, 171);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 9;
            this.txtDuration.Validating += new System.ComponentModel.CancelEventHandler(this.txtDuration_Validating);
            // 
            // checkBoxCompleted
            // 
            this.checkBoxCompleted.AutoSize = true;
            this.checkBoxCompleted.Location = new System.Drawing.Point(170, 242);
            this.checkBoxCompleted.Name = "checkBoxCompleted";
            this.checkBoxCompleted.Size = new System.Drawing.Size(43, 17);
            this.checkBoxCompleted.TabIndex = 10;
            this.checkBoxCompleted.Text = "Yes";
            this.checkBoxCompleted.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(617, 76);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(507, 76);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lblWatchAgain
            // 
            this.lblWatchAgain.AutoSize = true;
            this.lblWatchAgain.Location = new System.Drawing.Point(62, 269);
            this.lblWatchAgain.Name = "lblWatchAgain";
            this.lblWatchAgain.Size = new System.Drawing.Size(73, 13);
            this.lblWatchAgain.TabIndex = 13;
            this.lblWatchAgain.Text = "Watch Again?";
            // 
            // chkbxWatchAgain
            // 
            this.chkbxWatchAgain.AutoSize = true;
            this.chkbxWatchAgain.Location = new System.Drawing.Point(170, 269);
            this.chkbxWatchAgain.Name = "chkbxWatchAgain";
            this.chkbxWatchAgain.Size = new System.Drawing.Size(43, 17);
            this.chkbxWatchAgain.TabIndex = 14;
            this.chkbxWatchAgain.Text = "Yes";
            this.chkbxWatchAgain.UseVisualStyleBackColor = true;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(68, 303);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 15;
            this.lblCategory.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Movie",
            "Series",
            "Game",
            "Book"});
            this.cbCategory.Location = new System.Drawing.Point(168, 303);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 21);
            this.cbCategory.TabIndex = 16;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            this.cbCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cbCategory_Validating);
            // 
            // lblNumberOfSeasons
            // 
            this.lblNumberOfSeasons.AutoSize = true;
            this.lblNumberOfSeasons.Location = new System.Drawing.Point(62, 341);
            this.lblNumberOfSeasons.Name = "lblNumberOfSeasons";
            this.lblNumberOfSeasons.Size = new System.Drawing.Size(100, 13);
            this.lblNumberOfSeasons.TabIndex = 17;
            this.lblNumberOfSeasons.Text = "Number of Seasons";
            this.lblNumberOfSeasons.Visible = false;
            // 
            // txtNumberOfSeasons
            // 
            this.txtNumberOfSeasons.Location = new System.Drawing.Point(168, 341);
            this.txtNumberOfSeasons.Name = "txtNumberOfSeasons";
            this.txtNumberOfSeasons.Size = new System.Drawing.Size(100, 20);
            this.txtNumberOfSeasons.TabIndex = 18;
            this.txtNumberOfSeasons.Visible = false;
            this.txtNumberOfSeasons.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberOfSeasons_Validating);
            // 
            // lblWhereToWatch
            // 
            this.lblWhereToWatch.AutoSize = true;
            this.lblWhereToWatch.Location = new System.Drawing.Point(71, 207);
            this.lblWhereToWatch.Name = "lblWhereToWatch";
            this.lblWhereToWatch.Size = new System.Drawing.Size(86, 13);
            this.lblWhereToWatch.TabIndex = 19;
            this.lblWhereToWatch.Text = "Where to Watch";
            // 
            // txtWhereToWatch
            // 
            this.txtWhereToWatch.Location = new System.Drawing.Point(170, 207);
            this.txtWhereToWatch.Name = "txtWhereToWatch";
            this.txtWhereToWatch.Size = new System.Drawing.Size(100, 20);
            this.txtWhereToWatch.TabIndex = 20;
            this.txtWhereToWatch.Validating += new System.ComponentModel.CancelEventHandler(this.txtWhereToWatch_Validating);
            // 
            // lblNumberOfEpisodes
            // 
            this.lblNumberOfEpisodes.AutoSize = true;
            this.lblNumberOfEpisodes.Location = new System.Drawing.Point(62, 383);
            this.lblNumberOfEpisodes.Name = "lblNumberOfEpisodes";
            this.lblNumberOfEpisodes.Size = new System.Drawing.Size(102, 13);
            this.lblNumberOfEpisodes.TabIndex = 21;
            this.lblNumberOfEpisodes.Text = "Number of Episodes";
            this.lblNumberOfEpisodes.Visible = false;
            // 
            // txtNumberOfEpisodes
            // 
            this.txtNumberOfEpisodes.Location = new System.Drawing.Point(170, 380);
            this.txtNumberOfEpisodes.Name = "txtNumberOfEpisodes";
            this.txtNumberOfEpisodes.Size = new System.Drawing.Size(100, 20);
            this.txtNumberOfEpisodes.TabIndex = 22;
            this.txtNumberOfEpisodes.Visible = false;
            this.txtNumberOfEpisodes.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberOfEpisodes_Validating);
            // 
            // lblNumberOfPages
            // 
            this.lblNumberOfPages.AutoSize = true;
            this.lblNumberOfPages.Location = new System.Drawing.Point(62, 421);
            this.lblNumberOfPages.Name = "lblNumberOfPages";
            this.lblNumberOfPages.Size = new System.Drawing.Size(89, 13);
            this.lblNumberOfPages.TabIndex = 23;
            this.lblNumberOfPages.Text = "Number of Pages";
            this.lblNumberOfPages.Visible = false;
            // 
            // txtNumberOfPages
            // 
            this.txtNumberOfPages.Location = new System.Drawing.Point(170, 418);
            this.txtNumberOfPages.Name = "txtNumberOfPages";
            this.txtNumberOfPages.Size = new System.Drawing.Size(100, 20);
            this.txtNumberOfPages.TabIndex = 24;
            this.txtNumberOfPages.Visible = false;
            this.txtNumberOfPages.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberOfPages_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Started Watching?";
            // 
            // CkBxStartWatching
            // 
            this.CkBxStartWatching.AutoSize = true;
            this.CkBxStartWatching.Location = new System.Drawing.Point(170, 464);
            this.CkBxStartWatching.Name = "CkBxStartWatching";
            this.CkBxStartWatching.Size = new System.Drawing.Size(43, 17);
            this.CkBxStartWatching.TabIndex = 26;
            this.CkBxStartWatching.Text = "Yes";
            this.CkBxStartWatching.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 506);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Percentage of Completion";
            // 
            // PbPercentageOfCompletion
            // 
            this.PbPercentageOfCompletion.Location = new System.Drawing.Point(209, 506);
            this.PbPercentageOfCompletion.Name = "PbPercentageOfCompletion";
            this.PbPercentageOfCompletion.Size = new System.Drawing.Size(240, 23);
            this.PbPercentageOfCompletion.TabIndex = 28;
            this.PbPercentageOfCompletion.Click += new System.EventHandler(this.PbPercentageOfCompletion_Click);
            // 
            // btnAddEpisodes
            // 
            this.btnAddEpisodes.Location = new System.Drawing.Point(507, 116);
            this.btnAddEpisodes.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddEpisodes.Name = "btnAddEpisodes";
            this.btnAddEpisodes.Size = new System.Drawing.Size(210, 29);
            this.btnAddEpisodes.TabIndex = 29;
            this.btnAddEpisodes.Text = "Add Episodes";
            this.btnAddEpisodes.UseVisualStyleBackColor = true;
            this.btnAddEpisodes.Visible = false;
            this.btnAddEpisodes.Click += new System.EventHandler(this.btnAddEpisodes_Click);
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(430, 336);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(71, 13);
            this.lblCurrentPage.TabIndex = 30;
            this.lblCurrentPage.Text = "Current Page";
            this.lblCurrentPage.Visible = false;
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.Location = new System.Drawing.Point(507, 333);
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPage.TabIndex = 31;
            this.txtCurrentPage.Visible = false;
            this.txtCurrentPage.TextChanged += new System.EventHandler(this.txtCurrentPage_TextChanged);
            this.txtCurrentPage.MouseLeave += new System.EventHandler(this.txtCurrentPage_MouseLeave);
            this.txtCurrentPage.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentPage_Validating);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(433, 380);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(40, 13);
            this.lblAuthor.TabIndex = 32;
            this.lblAuthor.Text = "Author";
            this.lblAuthor.Visible = false;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(507, 380);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(171, 20);
            this.txtAuthor.TabIndex = 33;
            this.txtAuthor.Visible = false;
            this.txtAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.txtAuthor_Validating);
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(436, 420);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(30, 13);
            this.lblISBN.TabIndex = 34;
            this.lblISBN.Text = "ISBN";
            this.lblISBN.Visible = false;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(507, 418);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(210, 20);
            this.txtISBN.TabIndex = 35;
            this.txtISBN.Visible = false;
            this.txtISBN.Validating += new System.ComponentModel.CancelEventHandler(this.txtISBN_Validating);
            // 
            // ep1
            // 
            this.ep1.ContainerControl = this;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(507, 190);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(210, 37);
            this.saveButton.TabIndex = 36;
            this.saveButton.Text = "Search in IMDB";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // frmAddEditMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 573);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtCurrentPage);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.btnAddEpisodes);
            this.Controls.Add(this.PbPercentageOfCompletion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CkBxStartWatching);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumberOfPages);
            this.Controls.Add(this.lblNumberOfPages);
            this.Controls.Add(this.txtNumberOfEpisodes);
            this.Controls.Add(this.lblNumberOfEpisodes);
            this.Controls.Add(this.txtWhereToWatch);
            this.Controls.Add(this.lblWhereToWatch);
            this.Controls.Add(this.txtNumberOfSeasons);
            this.Controls.Add(this.lblNumberOfSeasons);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.chkbxWatchAgain);
            this.Controls.Add(this.lblWatchAgain);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.checkBoxCompleted);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMovieID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMode);
            this.Name = "frmAddEditMedia";
            this.Text = "Add Edit Media";
            this.Load += new System.EventHandler(this.frmAddEditMovie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMovieID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.CheckBox checkBoxCompleted;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblWatchAgain;
        private System.Windows.Forms.CheckBox chkbxWatchAgain;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblNumberOfSeasons;
        private System.Windows.Forms.TextBox txtNumberOfSeasons;
        private System.Windows.Forms.Label lblWhereToWatch;
        private System.Windows.Forms.TextBox txtWhereToWatch;
        private System.Windows.Forms.Label lblNumberOfEpisodes;
        private System.Windows.Forms.TextBox txtNumberOfEpisodes;
        private System.Windows.Forms.Label lblNumberOfPages;
        private System.Windows.Forms.TextBox txtNumberOfPages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CkBxStartWatching;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar PbPercentageOfCompletion;
        private System.Windows.Forms.Button btnAddEpisodes;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.TextBox txtCurrentPage;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.ErrorProvider ep1;
        private System.Windows.Forms.Button saveButton;
    }
}