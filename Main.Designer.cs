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
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.btnAddGames = new System.Windows.Forms.Button();
            this.btnAddBooks = new System.Windows.Forms.Button();
            this.btnAddEpisodes = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnShowMovies = new System.Windows.Forms.Button();
            this.btnShowSeries = new System.Windows.Forms.Button();
            this.btnShowGames = new System.Windows.Forms.Button();
            this.btnShowBooks = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAll)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F);
            this.label1.Location = new System.Drawing.Point(688, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "Media Progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(775, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "How much time do you have?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 345);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hours";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 345);
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
            this.hoursComboBox.Location = new System.Drawing.Point(202, 343);
            this.hoursComboBox.Margin = new System.Windows.Forms.Padding(8);
            this.hoursComboBox.Name = "hoursComboBox";
            this.hoursComboBox.Size = new System.Drawing.Size(296, 41);
            this.hoursComboBox.TabIndex = 4;
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
            this.minutesComboBox.Location = new System.Drawing.Point(682, 343);
            this.minutesComboBox.Margin = new System.Windows.Forms.Padding(8);
            this.minutesComboBox.Name = "minutesComboBox";
            this.minutesComboBox.Size = new System.Drawing.Size(296, 41);
            this.minutesComboBox.TabIndex = 5;
            this.minutesComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.minutesComboBox_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1070, 340);
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
            this.categoryComboBox.Location = new System.Drawing.Point(1208, 338);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(8);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(296, 41);
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
            this.dgvAll.Margin = new System.Windows.Forms.Padding(8);
            this.dgvAll.Name = "dgvAll";
            this.dgvAll.RowHeadersWidth = 102;
            this.dgvAll.Size = new System.Drawing.Size(3118, 845);
            this.dgvAll.TabIndex = 8;
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
            this.btnShow.Location = new System.Drawing.Point(1568, 327);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(245, 71);
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
            this.btnAddMovies.Size = new System.Drawing.Size(340, 86);
            this.btnAddMovies.TabIndex = 10;
            this.btnAddMovies.Text = "Add Movie";
            this.btnAddMovies.UseVisualStyleBackColor = true;
            this.btnAddMovies.Click += new System.EventHandler(this.btnAddMovies_Click);
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.Location = new System.Drawing.Point(415, 444);
            this.btnAddSeries.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(340, 86);
            this.btnAddSeries.TabIndex = 11;
            this.btnAddSeries.Text = "Add Series";
            this.btnAddSeries.UseVisualStyleBackColor = true;
            this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
            // 
            // btnAddGames
            // 
            this.btnAddGames.Location = new System.Drawing.Point(1110, 444);
            this.btnAddGames.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddGames.Name = "btnAddGames";
            this.btnAddGames.Size = new System.Drawing.Size(340, 86);
            this.btnAddGames.TabIndex = 12;
            this.btnAddGames.Text = "Add Games";
            this.btnAddGames.UseVisualStyleBackColor = true;
            // 
            // btnAddBooks
            // 
            this.btnAddBooks.Location = new System.Drawing.Point(1470, 444);
            this.btnAddBooks.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddBooks.Name = "btnAddBooks";
            this.btnAddBooks.Size = new System.Drawing.Size(340, 86);
            this.btnAddBooks.TabIndex = 13;
            this.btnAddBooks.Text = "Add Books";
            this.btnAddBooks.UseVisualStyleBackColor = true;
            // 
            // btnAddEpisodes
            // 
            this.btnAddEpisodes.Location = new System.Drawing.Point(782, 444);
            this.btnAddEpisodes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddEpisodes.Name = "btnAddEpisodes";
            this.btnAddEpisodes.Size = new System.Drawing.Size(305, 86);
            this.btnAddEpisodes.TabIndex = 14;
            this.btnAddEpisodes.Text = "Add Episodes";
            this.btnAddEpisodes.UseVisualStyleBackColor = true;
            this.btnAddEpisodes.Click += new System.EventHandler(this.btnAddEpisodes_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(2140, 142);
            this.txtFind.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(546, 40);
            this.txtFind.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2038, 145);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 33);
            this.label6.TabIndex = 16;
            this.label6.Text = "Search";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(2710, 135);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(220, 53);
            this.btnFind.TabIndex = 17;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnShowMovies
            // 
            this.btnShowMovies.Location = new System.Drawing.Point(2044, 236);
            this.btnShowMovies.Name = "btnShowMovies";
            this.btnShowMovies.Size = new System.Drawing.Size(210, 103);
            this.btnShowMovies.TabIndex = 18;
            this.btnShowMovies.Text = "Show Movies";
            this.btnShowMovies.UseVisualStyleBackColor = true;
            this.btnShowMovies.Click += new System.EventHandler(this.btnShowMovies_Click);
            // 
            // btnShowSeries
            // 
            this.btnShowSeries.Location = new System.Drawing.Point(2281, 236);
            this.btnShowSeries.Name = "btnShowSeries";
            this.btnShowSeries.Size = new System.Drawing.Size(210, 103);
            this.btnShowSeries.TabIndex = 19;
            this.btnShowSeries.Text = "Show Series";
            this.btnShowSeries.UseVisualStyleBackColor = true;
            this.btnShowSeries.Click += new System.EventHandler(this.btnShowSeries_Click);
            // 
            // btnShowGames
            // 
            this.btnShowGames.Location = new System.Drawing.Point(2044, 388);
            this.btnShowGames.Name = "btnShowGames";
            this.btnShowGames.Size = new System.Drawing.Size(210, 103);
            this.btnShowGames.TabIndex = 20;
            this.btnShowGames.Text = "Show Games";
            this.btnShowGames.UseVisualStyleBackColor = true;
            // 
            // btnShowBooks
            // 
            this.btnShowBooks.Location = new System.Drawing.Point(2281, 388);
            this.btnShowBooks.Name = "btnShowBooks";
            this.btnShowBooks.Size = new System.Drawing.Size(210, 103);
            this.btnShowBooks.TabIndex = 21;
            this.btnShowBooks.Text = "Show Books";
            this.btnShowBooks.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2972, 1394);
            this.Controls.Add(this.btnShowBooks);
            this.Controls.Add(this.btnShowGames);
            this.Controls.Add(this.btnShowSeries);
            this.Controls.Add(this.btnShowMovies);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnAddEpisodes);
            this.Controls.Add(this.btnAddBooks);
            this.Controls.Add(this.btnAddGames);
            this.Controls.Add(this.btnAddSeries);
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
            this.Margin = new System.Windows.Forms.Padding(8);
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
        private System.Windows.Forms.Button btnAddSeries;
        private System.Windows.Forms.Button btnAddGames;
        private System.Windows.Forms.Button btnAddBooks;
        private System.Windows.Forms.Button btnAddEpisodes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnShowMovies;
        private System.Windows.Forms.Button btnShowBooks;
        private System.Windows.Forms.Button btnShowGames;
        private System.Windows.Forms.Button btnShowSeries;
    }
}