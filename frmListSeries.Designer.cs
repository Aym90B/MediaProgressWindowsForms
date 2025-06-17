namespace MediaProgressWindowsForms
{
    partial class frmListSeries
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
            this.btnAddNewSeries = new System.Windows.Forms.Button();
            this.dgvAllSeries = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSeries)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNewSeries
            // 
            this.btnAddNewSeries.Location = new System.Drawing.Point(1612, 74);
            this.btnAddNewSeries.Name = "btnAddNewSeries";
            this.btnAddNewSeries.Size = new System.Drawing.Size(486, 190);
            this.btnAddNewSeries.TabIndex = 0;
            this.btnAddNewSeries.Text = "Add New Series";
            this.btnAddNewSeries.UseVisualStyleBackColor = true;
            // 
            // dgvAllSeries
            // 
            this.dgvAllSeries.AllowUserToAddRows = false;
            this.dgvAllSeries.AllowUserToDeleteRows = false;
            this.dgvAllSeries.AllowUserToOrderColumns = true;
            this.dgvAllSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSeries.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllSeries.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAllSeries.Location = new System.Drawing.Point(0, 940);
            this.dgvAllSeries.Name = "dgvAllSeries";
            this.dgvAllSeries.ReadOnly = true;
            this.dgvAllSeries.RowHeadersWidth = 102;
            this.dgvAllSeries.RowTemplate.Height = 42;
            this.dgvAllSeries.Size = new System.Drawing.Size(2197, 150);
            this.dgvAllSeries.TabIndex = 1;
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
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(182, 48);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // frmListSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2197, 1090);
            this.Controls.Add(this.dgvAllSeries);
            this.Controls.Add(this.btnAddNewSeries);
            this.Name = "frmListSeries";
            this.Text = "List Series";
            this.Load += new System.EventHandler(this.frmListSeries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSeries)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewSeries;
        private System.Windows.Forms.DataGridView dgvAllSeries;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}