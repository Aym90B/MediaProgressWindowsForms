namespace MediaProgressWindowsForms
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.hoursComboBox = new System.Windows.Forms.ComboBox();
            this.minutesComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.dgvAll = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnAddMovies = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnShowMovies = new System.Windows.Forms.Button();
            this.btnShowSeries = new System.Windows.Forms.Button();
            this.btnShowGames = new System.Windows.Forms.Button();
            this.btnShowBooks = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.chkPS = new System.Windows.Forms.CheckBox();
            this.chkOSN = new System.Windows.Forms.CheckBox();
            this.chkTOD = new System.Windows.Forms.CheckBox();
            this.chkShahid = new System.Windows.Forms.CheckBox();
            this.chkDisney = new System.Windows.Forms.CheckBox();
            this.chkStarzOn = new System.Windows.Forms.CheckBox();
            this.chkThamanya = new System.Windows.Forms.CheckBox();
            this.chkAJ = new System.Windows.Forms.CheckBox();
            this.chkAlAraby = new System.Windows.Forms.CheckBox();
            this.chkCrunchyRoll = new System.Windows.Forms.CheckBox();
            this.chkNetflix = new System.Windows.Forms.CheckBox();
            this.btnStarted = new System.Windows.Forms.Button();
            this.btnEpisodes25 = new System.Windows.Forms.Button();
            this.btnMovies25 = new System.Windows.Forms.Button();
            this.chkPC = new System.Windows.Forms.CheckBox();
            this.chkHD = new System.Windows.Forms.CheckBox();
            this.chk4K = new System.Windows.Forms.CheckBox();
            this.btnCompleted = new System.Windows.Forms.Button();
            this.btnDailyUpdates = new System.Windows.Forms.Button();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.DifficultyComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F);
            this.label1.Location = new System.Drawing.Point(45, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "Media Progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "How much time do you have?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 292);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hours";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 292);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Minutes";
            // 
            // hoursComboBox
            // 
            this.hoursComboBox.FormattingEnabled = true;
            this.hoursComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.hoursComboBox.Location = new System.Drawing.Point(42, 343);
            this.hoursComboBox.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.hoursComboBox.Name = "hoursComboBox";
            this.hoursComboBox.Size = new System.Drawing.Size(154, 41);
            this.hoursComboBox.TabIndex = 4;
            this.hoursComboBox.SelectedIndexChanged += new System.EventHandler(this.hoursComboBox_SelectedIndexChanged);
            this.hoursComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.hoursComboBox_Validating);
            // 
            // minutesComboBox
            // 
            this.minutesComboBox.FormattingEnabled = true;
            this.minutesComboBox.Items.AddRange(new object[] {
            "0",
            "15",
            "30",
            "45"});
            this.minutesComboBox.Location = new System.Drawing.Point(238, 343);
            this.minutesComboBox.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.minutesComboBox.Name = "minutesComboBox";
            this.minutesComboBox.Size = new System.Drawing.Size(204, 41);
            this.minutesComboBox.TabIndex = 5;
            this.minutesComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.minutesComboBox_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 33);
            this.label5.TabIndex = 6;
            this.label5.Text = "Category";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "All",
            "Movies",
            "Series",
            "Episodes",
            "Games",
            "Books"});
            this.categoryComboBox.Location = new System.Drawing.Point(478, 343);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(199, 41);
            this.categoryComboBox.TabIndex = 7;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            this.categoryComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.categoryComboBox_Validating);
            // 
            // dgvAll
            // 
            this.dgvAll.AllowUserToAddRows = false;
            this.dgvAll.AllowUserToDeleteRows = false;
            this.dgvAll.AllowUserToOrderColumns = true;
            this.dgvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAll.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAll.Location = new System.Drawing.Point(-5, 586);
            this.dgvAll.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.RowHeadersWidth = 102;
            this.dgvAll.Size = new System.Drawing.Size(3810, 1462);
            this.dgvAll.TabIndex = 8;
            this.dgvAll.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAll_CellContentClick);
            this.dgvAll.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAll_CellValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 100);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(182, 48);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(182, 48);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(422, 444);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(370, 86);
            this.btnShow.TabIndex = 9;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnAddMovies
            // 
            this.btnAddMovies.Location = new System.Drawing.Point(42, 444);
            this.btnAddMovies.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddMovies.Name = "btnAddMovies";
            this.btnAddMovies.Size = new System.Drawing.Size(342, 86);
            this.btnAddMovies.TabIndex = 10;
            this.btnAddMovies.Text = "Add Media";
            this.btnAddMovies.UseVisualStyleBackColor = true;
            this.btnAddMovies.Click += new System.EventHandler(this.btnAddMovies_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(2158, 86);
            this.txtFind.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(546, 40);
            this.txtFind.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2052, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 33);
            this.label6.TabIndex = 16;
            this.label6.Text = "Search";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(2740, 84);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(258, 53);
            this.btnFind.TabIndex = 17;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnShowMovies
            // 
            this.btnShowMovies.Location = new System.Drawing.Point(2060, 180);
            this.btnShowMovies.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnShowMovies.Name = "btnShowMovies";
            this.btnShowMovies.Size = new System.Drawing.Size(318, 173);
            this.btnShowMovies.TabIndex = 18;
            this.btnShowMovies.Text = "Show All Movies";
            this.btnShowMovies.UseVisualStyleBackColor = true;
            this.btnShowMovies.Click += new System.EventHandler(this.btnShowMovies_Click);
            // 
            // btnShowSeries
            // 
            this.btnShowSeries.Location = new System.Drawing.Point(2412, 178);
            this.btnShowSeries.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnShowSeries.Name = "btnShowSeries";
            this.btnShowSeries.Size = new System.Drawing.Size(298, 173);
            this.btnShowSeries.TabIndex = 19;
            this.btnShowSeries.Text = "Show All Series";
            this.btnShowSeries.UseVisualStyleBackColor = true;
            this.btnShowSeries.Click += new System.EventHandler(this.btnShowSeries_Click);
            // 
            // btnShowGames
            // 
            this.btnShowGames.Location = new System.Drawing.Point(2060, 371);
            this.btnShowGames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnShowGames.Name = "btnShowGames";
            this.btnShowGames.Size = new System.Drawing.Size(318, 160);
            this.btnShowGames.TabIndex = 20;
            this.btnShowGames.Text = "Show All Games";
            this.btnShowGames.UseVisualStyleBackColor = true;
            this.btnShowGames.Click += new System.EventHandler(this.btnShowGames_Click);
            // 
            // btnShowBooks
            // 
            this.btnShowBooks.Location = new System.Drawing.Point(2412, 371);
            this.btnShowBooks.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnShowBooks.Name = "btnShowBooks";
            this.btnShowBooks.Size = new System.Drawing.Size(298, 160);
            this.btnShowBooks.TabIndex = 21;
            this.btnShowBooks.Text = "Show All Books";
            this.btnShowBooks.UseVisualStyleBackColor = true;
            this.btnShowBooks.Click += new System.EventHandler(this.btnShowBooks_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1105, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 33);
            this.label7.TabIndex = 22;
            this.label7.Text = "Where To Watch";
            // 
            // chkPS
            // 
            this.chkPS.AutoSize = true;
            this.chkPS.Location = new System.Drawing.Point(1322, 305);
            this.chkPS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkPS.Name = "chkPS";
            this.chkPS.Size = new System.Drawing.Size(103, 37);
            this.chkPS.TabIndex = 43;
            this.chkPS.Text = "PS+";
            this.chkPS.UseVisualStyleBackColor = true;
            // 
            // chkOSN
            // 
            this.chkOSN.AutoSize = true;
            this.chkOSN.Location = new System.Drawing.Point(1265, 117);
            this.chkOSN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkOSN.Name = "chkOSN";
            this.chkOSN.Size = new System.Drawing.Size(125, 37);
            this.chkOSN.TabIndex = 42;
            this.chkOSN.Text = "OSN+";
            this.chkOSN.UseVisualStyleBackColor = true;
            // 
            // chkTOD
            // 
            this.chkTOD.AutoSize = true;
            this.chkTOD.Location = new System.Drawing.Point(1420, 117);
            this.chkTOD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkTOD.Name = "chkTOD";
            this.chkTOD.Size = new System.Drawing.Size(106, 37);
            this.chkTOD.TabIndex = 41;
            this.chkTOD.Text = "TOD";
            this.chkTOD.UseVisualStyleBackColor = true;
            // 
            // chkShahid
            // 
            this.chkShahid.AutoSize = true;
            this.chkShahid.Location = new System.Drawing.Point(1562, 117);
            this.chkShahid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkShahid.Name = "chkShahid";
            this.chkShahid.Size = new System.Drawing.Size(133, 37);
            this.chkShahid.TabIndex = 40;
            this.chkShahid.Text = "Shahid";
            this.chkShahid.UseVisualStyleBackColor = true;
            // 
            // chkDisney
            // 
            this.chkDisney.AutoSize = true;
            this.chkDisney.Location = new System.Drawing.Point(1720, 117);
            this.chkDisney.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkDisney.Name = "chkDisney";
            this.chkDisney.Size = new System.Drawing.Size(151, 37);
            this.chkDisney.TabIndex = 39;
            this.chkDisney.Text = "Disney+";
            this.chkDisney.UseVisualStyleBackColor = true;
            // 
            // chkStarzOn
            // 
            this.chkStarzOn.AutoSize = true;
            this.chkStarzOn.Location = new System.Drawing.Point(1110, 213);
            this.chkStarzOn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkStarzOn.Name = "chkStarzOn";
            this.chkStarzOn.Size = new System.Drawing.Size(147, 37);
            this.chkStarzOn.TabIndex = 38;
            this.chkStarzOn.Text = "StarzOn";
            this.chkStarzOn.UseVisualStyleBackColor = true;
            // 
            // chkThamanya
            // 
            this.chkThamanya.AutoSize = true;
            this.chkThamanya.Location = new System.Drawing.Point(1278, 213);
            this.chkThamanya.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkThamanya.Name = "chkThamanya";
            this.chkThamanya.Size = new System.Drawing.Size(177, 37);
            this.chkThamanya.TabIndex = 37;
            this.chkThamanya.Text = "Thamanya";
            this.chkThamanya.UseVisualStyleBackColor = true;
            // 
            // chkAJ
            // 
            this.chkAJ.AutoSize = true;
            this.chkAJ.Location = new System.Drawing.Point(1502, 213);
            this.chkAJ.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkAJ.Name = "chkAJ";
            this.chkAJ.Size = new System.Drawing.Size(181, 37);
            this.chkAJ.TabIndex = 36;
            this.chkAJ.Text = "Aljazeera+";
            this.chkAJ.UseVisualStyleBackColor = true;
            // 
            // chkAlAraby
            // 
            this.chkAlAraby.AutoSize = true;
            this.chkAlAraby.Location = new System.Drawing.Point(1705, 213);
            this.chkAlAraby.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkAlAraby.Name = "chkAlAraby";
            this.chkAlAraby.Size = new System.Drawing.Size(163, 37);
            this.chkAlAraby.TabIndex = 35;
            this.chkAlAraby.Text = "AlAraby+";
            this.chkAlAraby.UseVisualStyleBackColor = true;
            // 
            // chkCrunchyRoll
            // 
            this.chkCrunchyRoll.AutoSize = true;
            this.chkCrunchyRoll.Location = new System.Drawing.Point(1110, 305);
            this.chkCrunchyRoll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkCrunchyRoll.Name = "chkCrunchyRoll";
            this.chkCrunchyRoll.Size = new System.Drawing.Size(193, 37);
            this.chkCrunchyRoll.TabIndex = 34;
            this.chkCrunchyRoll.Text = "CrunchyRoll";
            this.chkCrunchyRoll.UseVisualStyleBackColor = true;
            // 
            // chkNetflix
            // 
            this.chkNetflix.AutoSize = true;
            this.chkNetflix.Location = new System.Drawing.Point(1110, 117);
            this.chkNetflix.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkNetflix.Name = "chkNetflix";
            this.chkNetflix.Size = new System.Drawing.Size(128, 37);
            this.chkNetflix.TabIndex = 33;
            this.chkNetflix.Text = "Netflix";
            this.chkNetflix.UseVisualStyleBackColor = true;
            // 
            // btnStarted
            // 
            this.btnStarted.Location = new System.Drawing.Point(830, 444);
            this.btnStarted.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStarted.Name = "btnStarted";
            this.btnStarted.Size = new System.Drawing.Size(378, 86);
            this.btnStarted.TabIndex = 44;
            this.btnStarted.Text = "Already Started";
            this.btnStarted.UseVisualStyleBackColor = true;
            this.btnStarted.Click += new System.EventHandler(this.btnStarted_Click);
            // 
            // btnEpisodes25
            // 
            this.btnEpisodes25.Location = new System.Drawing.Point(2740, 178);
            this.btnEpisodes25.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEpisodes25.Name = "btnEpisodes25";
            this.btnEpisodes25.Size = new System.Drawing.Size(258, 175);
            this.btnEpisodes25.TabIndex = 45;
            this.btnEpisodes25.Text = "Episodes 2025";
            this.btnEpisodes25.UseVisualStyleBackColor = true;
            this.btnEpisodes25.Click += new System.EventHandler(this.btnEpisodes25_Click);
            // 
            // btnMovies25
            // 
            this.btnMovies25.Location = new System.Drawing.Point(2740, 368);
            this.btnMovies25.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnMovies25.Name = "btnMovies25";
            this.btnMovies25.Size = new System.Drawing.Size(258, 162);
            this.btnMovies25.TabIndex = 46;
            this.btnMovies25.Text = "Movies 2025";
            this.btnMovies25.UseVisualStyleBackColor = true;
            // 
            // chkPC
            // 
            this.chkPC.AutoSize = true;
            this.chkPC.Location = new System.Drawing.Point(1442, 305);
            this.chkPC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkPC.Name = "chkPC";
            this.chkPC.Size = new System.Drawing.Size(84, 37);
            this.chkPC.TabIndex = 47;
            this.chkPC.Text = "PC";
            this.chkPC.UseVisualStyleBackColor = true;
            // 
            // chkHD
            // 
            this.chkHD.AutoSize = true;
            this.chkHD.Location = new System.Drawing.Point(712, 61);
            this.chkHD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkHD.Name = "chkHD";
            this.chkHD.Size = new System.Drawing.Size(89, 37);
            this.chkHD.TabIndex = 48;
            this.chkHD.Text = "HD";
            this.chkHD.UseVisualStyleBackColor = true;
            // 
            // chk4K
            // 
            this.chk4K.AutoSize = true;
            this.chk4K.Location = new System.Drawing.Point(830, 61);
            this.chk4K.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chk4K.Name = "chk4K";
            this.chk4K.Size = new System.Drawing.Size(84, 37);
            this.chk4K.TabIndex = 49;
            this.chk4K.Text = "4K";
            this.chk4K.UseVisualStyleBackColor = true;
            // 
            // btnCompleted
            // 
            this.btnCompleted.Location = new System.Drawing.Point(1238, 444);
            this.btnCompleted.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(378, 86);
            this.btnCompleted.TabIndex = 50;
            this.btnCompleted.Text = "Mark as Completed";
            this.btnCompleted.UseVisualStyleBackColor = true;
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // btnDailyUpdates
            // 
            this.btnDailyUpdates.Location = new System.Drawing.Point(42, 540);
            this.btnDailyUpdates.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDailyUpdates.Name = "btnDailyUpdates";
            this.btnDailyUpdates.Size = new System.Drawing.Size(342, 86);
            this.btnDailyUpdates.TabIndex = 53;
            this.btnDailyUpdates.Text = "Daily IMDb Updates";
            this.btnDailyUpdates.UseVisualStyleBackColor = true;
            this.btnDailyUpdates.Click += new System.EventHandler(this.btnDailyUpdates_Click);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(705, 292);
            this.lblDifficulty.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(118, 33);
            this.lblDifficulty.TabIndex = 51;
            this.lblDifficulty.Text = "Difficulty";
            // 
            // DifficultyComboBox
            // 
            this.DifficultyComboBox.FormattingEnabled = true;
            this.DifficultyComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.DifficultyComboBox.Location = new System.Drawing.Point(712, 343);
            this.DifficultyComboBox.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.DifficultyComboBox.Name = "DifficultyComboBox";
            this.DifficultyComboBox.Size = new System.Drawing.Size(206, 41);
            this.DifficultyComboBox.TabIndex = 52;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3125, 1604);
            this.Controls.Add(this.DifficultyComboBox);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.btnCompleted);
            this.Controls.Add(this.btnDailyUpdates);
            this.Controls.Add(this.chk4K);
            this.Controls.Add(this.chkHD);
            this.Controls.Add(this.chkPC);
            this.Controls.Add(this.btnMovies25);
            this.Controls.Add(this.btnEpisodes25);
            this.Controls.Add(this.btnStarted);
            this.Controls.Add(this.chkPS);
            this.Controls.Add(this.chkOSN);
            this.Controls.Add(this.chkTOD);
            this.Controls.Add(this.chkShahid);
            this.Controls.Add(this.chkDisney);
            this.Controls.Add(this.chkStarzOn);
            this.Controls.Add(this.chkThamanya);
            this.Controls.Add(this.chkAJ);
            this.Controls.Add(this.chkAlAraby);
            this.Controls.Add(this.chkCrunchyRoll);
            this.Controls.Add(this.chkNetflix);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnShowBooks);
            this.Controls.Add(this.btnShowGames);
            this.Controls.Add(this.btnShowSeries);
            this.Controls.Add(this.btnShowMovies);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnAddMovies);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dgvAll);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.minutesComboBox);
            this.Controls.Add(this.hoursComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox hoursComboBox;
        private System.Windows.Forms.ComboBox minutesComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.DataGridView dgvAll;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnAddMovies;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnShowMovies;
        private System.Windows.Forms.Button btnShowBooks;
        private System.Windows.Forms.Button btnShowGames;
        private System.Windows.Forms.Button btnShowSeries;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPS;
        private System.Windows.Forms.CheckBox chkOSN;
        private System.Windows.Forms.CheckBox chkTOD;
        private System.Windows.Forms.CheckBox chkShahid;
        private System.Windows.Forms.CheckBox chkDisney;
        private System.Windows.Forms.CheckBox chkStarzOn;
        private System.Windows.Forms.CheckBox chkThamanya;
        private System.Windows.Forms.CheckBox chkAJ;
        private System.Windows.Forms.CheckBox chkAlAraby;
        private System.Windows.Forms.CheckBox chkCrunchyRoll;
        private System.Windows.Forms.CheckBox chkNetflix;
        private System.Windows.Forms.Button btnStarted;
        private System.Windows.Forms.Button btnMovies25;
        private System.Windows.Forms.Button btnEpisodes25;
        private System.Windows.Forms.CheckBox chkPC;
        private System.Windows.Forms.CheckBox chkHD;
        private System.Windows.Forms.CheckBox chk4K;
        private System.Windows.Forms.Button btnCompleted;
        private System.Windows.Forms.Button btnDailyUpdates;
        private System.Windows.Forms.ComboBox DifficultyComboBox;
        private System.Windows.Forms.Label lblDifficulty;
    }
}