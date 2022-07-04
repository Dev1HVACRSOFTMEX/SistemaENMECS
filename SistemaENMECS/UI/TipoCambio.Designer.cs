namespace SistemaENMECS.UI
{
    partial class TipoCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoCambio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgTipoCambio = new System.Windows.Forms.DataGridView();
            this.lblFeIni = new System.Windows.Forms.Label();
            this.txtFeIni = new System.Windows.Forms.TextBox();
            this.lblFeFin = new System.Windows.Forms.Label();
            this.txtFeFin = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.CalDia = new System.Windows.Forms.MonthCalendar();
            this.CalIni = new System.Windows.Forms.MonthCalendar();
            this.CalFin = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoCambio)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            // lblFeIni
            // 
            resources.ApplyResources(this.lblFeIni, "lblFeIni");
            this.lblFeIni.Name = "lblFeIni";
            // 
            // txtFeIni
            // 
            this.txtFeIni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtFeIni, "txtFeIni");
            this.txtFeIni.Name = "txtFeIni";
            this.txtFeIni.ReadOnly = true;
            this.txtFeIni.Click += new System.EventHandler(this.txtFeIni_Click);
            this.txtFeIni.Leave += new System.EventHandler(this.txtFeIni_Leave);
            // 
            // lblFeFin
            // 
            resources.ApplyResources(this.lblFeFin, "lblFeFin");
            this.lblFeFin.Name = "lblFeFin";
            // 
            // txtFeFin
            // 
            this.txtFeFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtFeFin, "txtFeFin");
            this.txtFeFin.Name = "txtFeFin";
            this.txtFeFin.ReadOnly = true;
            this.txtFeFin.Click += new System.EventHandler(this.txtFeFin_Click);
            this.txtFeFin.Leave += new System.EventHandler(this.txtFeFin_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.cbMoneda);
            this.groupBox2.Controls.Add(this.lblMoneda);
            this.groupBox2.Controls.Add(this.txtImporte);
            this.groupBox2.Controls.Add(this.lblImporte);
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Controls.Add(this.lblFecha);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnGuardar, "btnGuardar");
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbMoneda
            // 
            this.cbMoneda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbMoneda.FormattingEnabled = true;
            resources.ApplyResources(this.cbMoneda, "cbMoneda");
            this.cbMoneda.Name = "cbMoneda";
            // 
            // lblMoneda
            // 
            resources.ApplyResources(this.lblMoneda, "lblMoneda");
            this.lblMoneda.Name = "lblMoneda";
            // 
            // txtImporte
            // 
            this.txtImporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtImporte, "txtImporte");
            this.txtImporte.Name = "txtImporte";
            // 
            // lblImporte
            // 
            resources.ApplyResources(this.lblImporte, "lblImporte");
            this.lblImporte.Name = "lblImporte";
            // 
            // txtFecha
            // 
            this.txtFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtFecha, "txtFecha");
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Click += new System.EventHandler(this.txtFecha_Click);
            this.txtFecha.Leave += new System.EventHandler(this.txtFecha_Leave);
            // 
            // lblFecha
            // 
            resources.ApplyResources(this.lblFecha, "lblFecha");
            this.lblFecha.Name = "lblFecha";
            // 
            // CalDia
            // 
            this.CalDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.CalDia, "CalDia");
            this.CalDia.Name = "CalDia";
            this.CalDia.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalDia_DateSelected);
            // 
            // CalIni
            // 
            this.CalIni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.CalIni, "CalIni");
            this.CalIni.Name = "CalIni";
            this.CalIni.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalIni_DateSelected);
            // 
            // CalFin
            // 
            this.CalFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.CalFin, "CalFin");
            this.CalFin.Name = "CalFin";
            this.CalFin.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalFin_DateSelected);
            // 
            // TipoCambio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.CalDia);
            this.Controls.Add(this.CalFin);
            this.Controls.Add(this.CalIni);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtFeFin);
            this.Controls.Add(this.lblFeFin);
            this.Controls.Add(this.txtFeIni);
            this.Controls.Add(this.lblFeIni);
            this.Controls.Add(this.dgTipoCambio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TipoCambio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TipoCambio_Load);
            this.Click += new System.EventHandler(this.TipoCambio_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgTipoCambio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgTipoCambio;
        private System.Windows.Forms.Label lblFeIni;
        private System.Windows.Forms.TextBox txtFeIni;
        private System.Windows.Forms.Label lblFeFin;
        private System.Windows.Forms.TextBox txtFeFin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.MonthCalendar CalIni;
        private System.Windows.Forms.MonthCalendar CalFin;
        private System.Windows.Forms.MonthCalendar CalDia;
    }
}