namespace SistemaENMECS.UI
{
    partial class DocCotConcepto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocCotConcepto));
            this.checkedConcepto = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedConcepto
            // 
            this.checkedConcepto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.checkedConcepto.FormattingEnabled = true;
            resources.ApplyResources(this.checkedConcepto, "checkedConcepto");
            this.checkedConcepto.Name = "checkedConcepto";
            this.checkedConcepto.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedConcepto_ItemCheck);
            // 
            // DocCotConcepto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.checkedConcepto);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocCotConcepto";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.DocCotConcepto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedConcepto;
    }
}