namespace SistemaENMECS.UI
{
    partial class SeekDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeekDocumento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.dgDoc = new System.Windows.Forms.DataGridView();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblPry = new System.Windows.Forms.Label();
            this.txtProyecto = new System.Windows.Forms.TextBox();
            this.lblCli = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDoc)).BeginInit();
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
            // lblFolio
            // 
            resources.ApplyResources(this.lblFolio, "lblFolio");
            this.lblFolio.Name = "lblFolio";
            // 
            // dgDoc
            // 
            this.dgDoc.AllowUserToAddRows = false;
            this.dgDoc.AllowUserToDeleteRows = false;
            this.dgDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgDoc, "dgDoc");
            this.dgDoc.Name = "dgDoc";
            this.dgDoc.ReadOnly = true;
            this.dgDoc.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDoc_CellContentDoubleClick);
            // 
            // txtFolio
            // 
            resources.ApplyResources(this.txtFolio, "txtFolio");
            this.txtFolio.Name = "txtFolio";
            // 
            // lblPry
            // 
            resources.ApplyResources(this.lblPry, "lblPry");
            this.lblPry.Name = "lblPry";
            // 
            // txtProyecto
            // 
            resources.ApplyResources(this.txtProyecto, "txtProyecto");
            this.txtProyecto.Name = "txtProyecto";
            // 
            // lblCli
            // 
            resources.ApplyResources(this.lblCli, "lblCli");
            this.lblCli.Name = "lblCli";
            // 
            // txtCliente
            // 
            resources.ApplyResources(this.txtCliente, "txtCliente");
            this.txtCliente.Name = "txtCliente";
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
            // SeekDocumento
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCli);
            this.Controls.Add(this.txtProyecto);
            this.Controls.Add(this.lblPry);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.dgDoc);
            this.Controls.Add(this.lblFolio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeekDocumento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SeekDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.DataGridView dgDoc;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label lblPry;
        private System.Windows.Forms.Label lblCli;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtProyecto;
        private System.Windows.Forms.Button btnBuscar;
    }
}