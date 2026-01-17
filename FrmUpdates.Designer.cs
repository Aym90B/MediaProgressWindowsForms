namespace MediaProgressWindowsForms
{
    partial class FrmUpdates
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
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpDeepScan = new System.Windows.Forms.GroupBox();
            this.chkDeepScan = new System.Windows.Forms.CheckBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.numRating = new System.Windows.Forms.NumericUpDown();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.chkAdult = new System.Windows.Forms.CheckBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDailyUpdates = new System.Windows.Forms.Button();
            this.grpDeepScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(20, 20);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(60, 17);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(60, 20);
            this.txtYear.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(140, 20);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "movie",
            "series",
            "episode",
            "game"});
            this.cmbType.Location = new System.Drawing.Point(180, 17);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(100, 21);
            this.cmbType.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(300, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(350, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Marvel";
            // 
            // grpDeepScan
            // 
            this.grpDeepScan.Controls.Add(this.chkAdult);
            this.grpDeepScan.Controls.Add(this.txtGenre);
            this.grpDeepScan.Controls.Add(this.lblGenre);
            this.grpDeepScan.Controls.Add(this.numRating);
            this.grpDeepScan.Controls.Add(this.lblRating);
            this.grpDeepScan.Controls.Add(this.chkDeepScan);
            this.grpDeepScan.Location = new System.Drawing.Point(20, 60);
            this.grpDeepScan.Name = "grpDeepScan";
            this.grpDeepScan.Size = new System.Drawing.Size(750, 60);
            this.grpDeepScan.TabIndex = 6;
            this.grpDeepScan.TabStop = false;
            this.grpDeepScan.Text = "Advanced Filters (Requires Deep Scan API calls)";
            // 
            // chkDeepScan
            // 
            this.chkDeepScan.AutoSize = true;
            this.chkDeepScan.Location = new System.Drawing.Point(20, 25);
            this.chkDeepScan.Name = "chkDeepScan";
            this.chkDeepScan.Size = new System.Drawing.Size(113, 17);
            this.chkDeepScan.TabIndex = 0;
            this.chkDeepScan.Text = "Enable Deep Scan";
            this.chkDeepScan.UseVisualStyleBackColor = true;
            this.chkDeepScan.CheckedChanged += new System.EventHandler(this.chkDeepScan_CheckedChanged);
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(150, 26);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(61, 13);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "Min Rating:";
            // 
            // numRating
            // 
            this.numRating.DecimalPlaces = 1;
            this.numRating.Enabled = false;
            this.numRating.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numRating.Location = new System.Drawing.Point(220, 24);
            this.numRating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRating.Name = "numRating";
            this.numRating.Size = new System.Drawing.Size(50, 20);
            this.numRating.TabIndex = 2;
            this.numRating.Value = new decimal(new int[] {
            70,
            0,
            0,
            65536});
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(300, 26);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.TabIndex = 3;
            this.lblGenre.Text = "Genre:";
            // 
            // txtGenre
            // 
            this.txtGenre.Enabled = false;
            this.txtGenre.Location = new System.Drawing.Point(350, 23);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(120, 20);
            this.txtGenre.TabIndex = 4;
            // 
            // chkAdult
            // 
            this.chkAdult.AutoSize = true;
            this.chkAdult.Enabled = false;
            this.chkAdult.Location = new System.Drawing.Point(500, 25);
            this.chkAdult.Name = "chkAdult";
            this.chkAdult.Size = new System.Drawing.Size(88, 17);
            this.chkAdult.TabIndex = 5;
            this.chkAdult.Text = "Include Adult";
            this.chkAdult.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(500, 15);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(100, 23);
            this.btnScan.TabIndex = 7;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(20, 140);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(750, 350);
            this.dgvResults.TabIndex = 8;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(20, 500);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 30);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import Selected";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDailyUpdates
            // 
            this.btnDailyUpdates.Location = new System.Drawing.Point(190, 500);
            this.btnDailyUpdates.Name = "btnDailyUpdates";
            this.btnDailyUpdates.Size = new System.Drawing.Size(150, 30);
            this.btnDailyUpdates.TabIndex = 10;
            this.btnDailyUpdates.Text = "Get Daily Updates";
            this.btnDailyUpdates.UseVisualStyleBackColor = true;
            this.btnDailyUpdates.Click += new System.EventHandler(this.btnDailyUpdates_Click);
            // 
            // FrmUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnDailyUpdates);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.grpDeepScan);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Name = "FrmUpdates";
            this.Text = "Daily IMDb Updates / New Releases";
            this.grpDeepScan.ResumeLayout(false);
            this.grpDeepScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpDeepScan;
        private System.Windows.Forms.CheckBox chkDeepScan;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.CheckBox chkAdult;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDailyUpdates;
    }
}
