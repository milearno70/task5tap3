namespace task5tap3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            this.lblFile.Text = "Mətn faylı:";
            this.lblFile.Location = new System.Drawing.Point(15, 20);
            this.lblFile.AutoSize = true;

            this.txtFilePath.Location = new System.Drawing.Point(95, 17);
            this.txtFilePath.Size = new System.Drawing.Size(455, 22);
            this.txtFilePath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.btnBrowseFile.Text = "Seç...";
            this.btnBrowseFile.Location = new System.Drawing.Point(565, 15);
            this.btnBrowseFile.Size = new System.Drawing.Size(120, 28);
            this.btnBrowseFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);

            this.btnAnalyze.Text = "Analiz et";
            this.btnAnalyze.Location = new System.Drawing.Point(95, 55);
            this.btnAnalyze.Size = new System.Drawing.Size(150, 32);
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);

            this.txtReport.Location = new System.Drawing.Point(15, 100);
            this.txtReport.Size = new System.Drawing.Size(670, 340);
            this.txtReport.Multiline = true;
            this.txtReport.ReadOnly = true;
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 455);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtReport);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mətn Analizatoru";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.TextBox txtReport;
    }
}