namespace MediaProgressWindowsForms
{
    partial class frmListMedia
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
            this.btnAddNewMovie = new System.Windows.Forms.Button();
            this.dgvAllMovies = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewSeries = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMovies)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNewMovie
            // 
            this.btnAddNewMovie.Location = new System.Drawing.Point(2212, 79);
            this.btnAddNewMovie.Margin = new System.Windows.Forms.Padding(8);
            this.btnAddNewMovie.Name = "btnAddNewMovie";
            this.btnAddNewMovie.Size = new System.Drawing.Size(492, 185);
            this.btnAddNewMovie.TabIndex = 0;
            this.btnAddNewMovie.Text = "Add New Movie";
            this.btnAddNewMovie.UseVisualStyleBackColor = true;
            this.btnAddNewMovie.Click += new System.EventHandler(this.btnAddNewMovie_Click);
            // 
            // dgvAllMovies
            // 
            this.dgvAllMovies.AllowUserToAddRows = false;
            this.dgvAllMovies.AllowUserToDeleteRows = false;
            this.dgvAllMovies.AllowUserToOrderColumns = true;
            this.dgvAllMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllMovies.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllMovies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAllMovies.Location = new System.Drawing.Point(0, 412);
            this.dgvAllMovies.Margin = new System.Windows.Forms.Padding(8);
            this.dgvAllMovies.Name = "dgvAllMovies";
            this.dgvAllMovies.ReadOnly = true;
            this.dgvAllMovies.RowHeadersWidth = 102;
            this.dgvAllMovies.Size = new System.Drawing.Size(2785, 982);
            this.dgvAllMovies.TabIndex = 1;
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
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(182, 48);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // btnAddNewSeries
            // 
            this.btnAddNewSeries.Location = new System.Drawing.Point(1616, 79);
            this.btnAddNewSeries.Margin = new System.Windows.Forms.Padding(8);
            this.btnAddNewSeries.Name = "btnAddNewSeries";
            this.btnAddNewSeries.Size = new System.Drawing.Size(492, 185);
            this.btnAddNewSeries.TabIndex = 2;
            this.btnAddNewSeries.Text = "Add New Series";
            this.btnAddNewSeries.UseVisualStyleBackColor = true;
            this.btnAddNewSeries.Click += new System.EventHandler(this.btnAddNewSeries_Click);
            // 
            // frmListMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2785, 1394);
            this.Controls.Add(this.btnAddNewSeries);
            this.Controls.Add(this.dgvAllMovies);
            this.Controls.Add(this.btnAddNewMovie);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "frmListMovies";
            this.Text = "List Movies";
            this.Load += new System.EventHandler(this.frmListMovies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllMovies)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewMovie;
        private System.Windows.Forms.DataGridView dgvAllMovies;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnAddNewSeries;
    }
}

