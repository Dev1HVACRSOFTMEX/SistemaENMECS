namespace SistemaENMECS.UI
{
    partial class ListaDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaDocumento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgDocumento = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblFeIni = new System.Windows.Forms.Label();
            this.txtFeIni = new System.Windows.Forms.TextBox();
            this.lblFeFin = new System.Windows.Forms.Label();
            this.txtFeFin = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbEstatus = new System.Windows.Forms.ComboBox();
            this.btnCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDocumento)).BeginInit();
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
            // dgDocumento
            // 
            this.dgDocumento.AllowUserToAddRows = false;
            this.dgDocumento.AllowUserToDeleteRows = false;
            this.dgDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgDocumento, "dgDocumento");
            this.dgDocumento.Name = "dgDocumento";
            this.dgDocumento.ReadOnly = true;
            this.dgDocumento.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDocumento_CellContentDoubleClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnAgregar.BackgroundImage = global::SistemaENMECS.Properties.Resources.plus;
            resources.ApplyResources(this.btnAgregar, "btnAgregar");
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblCliente
            // 
            resources.ApplyResources(this.lblCliente, "lblCliente");
            this.lblCliente.Name = "lblCliente";
            // 
            // txtCliente
            // 
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtCliente, "txtCliente");
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
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
            // 
            // lblEmpresa
            // 
            resources.ApplyResources(this.lblEmpresa, "lblEmpresa");
            this.lblEmpresa.Name = "lblEmpresa";
            // 
            // lblEstatus
            // 
            resources.ApplyResources(this.lblEstatus, "lblEstatus");
            this.lblEstatus.Name = "lblEstatus";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbEmpresa.FormattingEnabled = true;
            resources.ApplyResources(this.cbEmpresa, "cbEmpresa");
            this.cbEmpresa.Name = "cbEmpresa";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnBuscar, "btnBuscar");
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbEstatus
            // 
            this.cbEstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbEstatus.FormattingEnabled = true;
            resources.ApplyResources(this.cbEstatus, "cbEstatus");
            this.cbEstatus.Name = "cbEstatus";
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnCliente.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCliente, "btnCliente");
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // ListaDocumento
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.cbEstatus);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.lblEstatus);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.txtFeFin);
            this.Controls.Add(this.lblFeFin);
            this.Controls.Add(this.txtFeIni);
            this.Controls.Add(this.lblFeIni);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgDocumento);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaDocumento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ListaDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgDocumento;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblFeIni;
        private System.Windows.Forms.TextBox txtFeIni;
        private System.Windows.Forms.Label lblFeFin;
        private System.Windows.Forms.TextBox txtFeFin;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbEstatus;
        private System.Windows.Forms.Button btnCliente;
    }
}