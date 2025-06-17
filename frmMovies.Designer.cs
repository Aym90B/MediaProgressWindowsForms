namespace MediaProgressWindowsForms
{
    partial class frmMovies
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
            this.btnAddMovies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddMovies
            // 
            this.btnAddMovies.Location = new System.Drawing.Point(88, 47);
            this.btnAddMovies.Name = "btnAddMovies";
            this.btnAddMovies.Size = new System.Drawing.Size(124, 35);
            this.btnAddMovies.TabIndex = 0;
            this.btnAddMovies.Text = "Add Movie";
            this.btnAddMovies.UseVisualStyleBackColor = true;
            this.btnAddMovies.Click += new System.EventHandler(this.btnAddMovies_Click);
            // 
            // frmMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddMovies);
            this.Name = "frmMovies";
            this.Text = "Movies";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddMovies;
    }
}