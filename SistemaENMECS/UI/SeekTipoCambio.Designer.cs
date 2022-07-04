namespace SistemaENMECS.UI
{
    partial class SeekTipoCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeekTipoCambio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblFeIni = new System.Windows.Forms.Label();
            this.lblFeFin = new System.Windows.Forms.Label();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.txtFeIni = new System.Windows.Forms.TextBox();
            this.txtFeFin = new System.Windows.Forms.TextBox();
            this.dgTipoCambio = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoCambio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            resources.ApplyResources(this.lblTitulo, "lblTitulo");
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblMoneda
            // 
            resources.ApplyResources(this.lblMoneda, "lblMoneda");
            this.lblMoneda.Name = "lblMoneda";
            // 
            // lblFeIni
            // 
            resources.ApplyResources(this.lblFeIni, "lblFeIni");
            this.lblFeIni.Name = "lblFeIni";
            // 
            // lblFeFin
            // 
            resources.ApplyResources(this.lblFeFin, "lblFeFin");
            this.lblFeFin.Name = "lblFeFin";
            // 
            // cbMoneda
            // 
            this.cbMoneda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbMoneda.FormattingEnabled = true;
            resources.ApplyResources(this.cbMoneda, "cbMoneda");
            this.cbMoneda.Name = "cbMoneda";
            // 
            // txtFeIni
            // 
            this.txtFeIni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtFeIni, "txtFeIni");
            this.txtFeIni.Name = "txtFeIni";
            this.txtFeIni.Leave += new System.EventHandler(this.txtFeIni_Leave);
            // 
            // txtFeFin
            // 
            this.txtFeFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtFeFin, "txtFeFin");
            this.txtFeFin.Name = "txtFeFin";
            this.txtFeFin.Leave += new System.EventHandler(this.txtFeFin_Leave);
            // 
            // dgTipoCambio
            // 
            this.dgTipoCambio.AllowUserToAddRows = false;
            this.dgTipoCambio.AllowUserToDeleteRows = false;
            this.dgTipoCambio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgTipoCambio, "dgTipoCambio");
            this.dgTipoCambio.Name = "dgTipoCambio";
            this.dgTipoCambio.ReadOnly = true;
            this.dgTipoCambio.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTipoCambio_CellContentDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnBuscar.BackgroundImage = global::SistemaENMECS.Properties.Resources.find_16;
            resources.ApplyResources(this.btnBuscar, "btnBuscar");
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // SeekTipoCambio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.dgTipoCambio);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtFeFin);
            this.Controls.Add(this.txtFeIni);
            this.Controls.Add(this.cbMoneda);
            this.Controls.Add(this.lblFeFin);
            this.Controls.Add(this.lblFeIni);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeekTipoCambio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SeekTipoCambio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoCambio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblFeIni;
        private System.Windows.Forms.Label lblFeFin;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.TextBox txtFeIni;
        private System.Windows.Forms.TextBox txtFeFin;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgTipoCambio;
    }
}