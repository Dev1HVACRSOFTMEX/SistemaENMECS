namespace SistemaENMECS.UI
{
    partial class Proyecto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proyecto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNomCarp = new System.Windows.Forms.Label();
            this.txtNomCarp = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.checkActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblObjetivo = new System.Windows.Forms.Label();
            this.cbObjetivo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoSis = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.cbEstatus = new System.Windows.Forms.ComboBox();
            this.cbLugar = new System.Windows.Forms.ComboBox();
            this.tabCarpeta = new System.Windows.Forms.TabControl();
            this.tabNom = new System.Windows.Forms.TabPage();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.lblLugar = new System.Windows.Forms.Label();
            this.tabCar = new System.Windows.Forms.TabPage();
            this.lblCCot = new System.Windows.Forms.Label();
            this.checkListCCot = new System.Windows.Forms.CheckedListBox();
            this.lblCPry = new System.Windows.Forms.Label();
            this.checkListCPry = new System.Windows.Forms.CheckedListBox();
            this.tabCot = new System.Windows.Forms.TabPage();
            this.dgDoc = new System.Windows.Forms.DataGridView();
            this.btnNCli = new System.Windows.Forms.Button();
            this.tabCarpeta.SuspendLayout();
            this.tabNom.SuspendLayout();
            this.tabCar.SuspendLayout();
            this.tabCot.SuspendLayout();
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
            // lblNumero
            // 
            resources.ApplyResources(this.lblNumero, "lblNumero");
            this.lblNumero.Name = "lblNumero";
            // 
            // txtNumero
            // 
            this.txtNumero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNumero, "txtNumero");
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            // 
            // lblNombre
            // 
            resources.ApplyResources(this.lblNombre, "lblNombre");
            this.lblNombre.Name = "lblNombre";
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            // 
            // lblNomCarp
            // 
            resources.ApplyResources(this.lblNomCarp, "lblNomCarp");
            this.lblNomCarp.Name = "lblNomCarp";
            // 
            // txtNomCarp
            // 
            this.txtNomCarp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNomCarp, "txtNomCarp");
            this.txtNomCarp.Name = "txtNomCarp";
            // 
            // lblCliente
            // 
            resources.ApplyResources(this.lblCliente, "lblCliente");
            this.lblCliente.Name = "lblCliente";
            // 
            // cbCliente
            // 
            this.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbCliente.FormattingEnabled = true;
            resources.ApplyResources(this.cbCliente, "cbCliente");
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // checkActivo
            // 
            resources.ApplyResources(this.checkActivo, "checkActivo");
            this.checkActivo.Name = "checkActivo";
            this.checkActivo.UseVisualStyleBackColor = true;
            this.checkActivo.CheckedChanged += new System.EventHandler(this.checkActivo_CheckedChanged);
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
            // lblEmpresa
            // 
            resources.ApplyResources(this.lblEmpresa, "lblEmpresa");
            this.lblEmpresa.Name = "lblEmpresa";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbEmpresa.FormattingEnabled = true;
            resources.ApplyResources(this.cbEmpresa, "cbEmpresa");
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            // 
            // lblObjetivo
            // 
            resources.ApplyResources(this.lblObjetivo, "lblObjetivo");
            this.lblObjetivo.Name = "lblObjetivo";
            // 
            // cbObjetivo
            // 
            this.cbObjetivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbObjetivo.FormattingEnabled = true;
            resources.ApplyResources(this.cbObjetivo, "cbObjetivo");
            this.cbObjetivo.Name = "cbObjetivo";
            this.cbObjetivo.SelectedIndexChanged += new System.EventHandler(this.cbObjetivo_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbTipoSis
            // 
            this.cbTipoSis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbTipoSis.FormattingEnabled = true;
            resources.ApplyResources(this.cbTipoSis, "cbTipoSis");
            this.cbTipoSis.Name = "cbTipoSis";
            this.cbTipoSis.SelectedIndexChanged += new System.EventHandler(this.cbTipoSis_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            resources.ApplyResources(this.lblEstado, "lblEstado");
            this.lblEstado.Name = "lblEstado";
            // 
            // lblEstatus
            // 
            resources.ApplyResources(this.lblEstatus, "lblEstatus");
            this.lblEstatus.Name = "lblEstatus";
            // 
            // cbEstatus
            // 
            this.cbEstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbEstatus.FormattingEnabled = true;
            resources.ApplyResources(this.cbEstatus, "cbEstatus");
            this.cbEstatus.Name = "cbEstatus";
            this.cbEstatus.SelectedIndexChanged += new System.EventHandler(this.cbEstatus_SelectedIndexChanged);
            // 
            // cbLugar
            // 
            this.cbLugar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbLugar.FormattingEnabled = true;
            resources.ApplyResources(this.cbLugar, "cbLugar");
            this.cbLugar.Name = "cbLugar";
            this.cbLugar.SelectedIndexChanged += new System.EventHandler(this.cbLugar_SelectedIndexChanged);
            // 
            // tabCarpeta
            // 
            this.tabCarpeta.Controls.Add(this.tabNom);
            this.tabCarpeta.Controls.Add(this.tabCar);
            this.tabCarpeta.Controls.Add(this.tabCot);
            resources.ApplyResources(this.tabCarpeta, "tabCarpeta");
            this.tabCarpeta.Name = "tabCarpeta";
            this.tabCarpeta.SelectedIndex = 0;
            // 
            // tabNom
            // 
            this.tabNom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabNom.Controls.Add(this.txtLugar);
            this.tabNom.Controls.Add(this.lblLugar);
            this.tabNom.Controls.Add(this.lblObjetivo);
            this.tabNom.Controls.Add(this.cbLugar);
            this.tabNom.Controls.Add(this.lblNombre);
            this.tabNom.Controls.Add(this.txtNombre);
            this.tabNom.Controls.Add(this.lblNomCarp);
            this.tabNom.Controls.Add(this.lblEstado);
            this.tabNom.Controls.Add(this.txtNomCarp);
            this.tabNom.Controls.Add(this.cbTipoSis);
            this.tabNom.Controls.Add(this.cbObjetivo);
            this.tabNom.Controls.Add(this.label3);
            resources.ApplyResources(this.tabNom, "tabNom");
            this.tabNom.Name = "tabNom";
            // 
            // txtLugar
            // 
            this.txtLugar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtLugar, "txtLugar");
            this.txtLugar.Name = "txtLugar";
            // 
            // lblLugar
            // 
            resources.ApplyResources(this.lblLugar, "lblLugar");
            this.lblLugar.Name = "lblLugar";
            // 
            // tabCar
            // 
            this.tabCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabCar.Controls.Add(this.lblCCot);
            this.tabCar.Controls.Add(this.checkListCCot);
            this.tabCar.Controls.Add(this.lblCPry);
            this.tabCar.Controls.Add(this.checkListCPry);
            resources.ApplyResources(this.tabCar, "tabCar");
            this.tabCar.Name = "tabCar";
            // 
            // lblCCot
            // 
            resources.ApplyResources(this.lblCCot, "lblCCot");
            this.lblCCot.Name = "lblCCot";
            // 
            // checkListCCot
            // 
            this.checkListCCot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.checkListCCot.FormattingEnabled = true;
            resources.ApplyResources(this.checkListCCot, "checkListCCot");
            this.checkListCCot.Name = "checkListCCot";
            this.checkListCCot.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListCCot_ItemCheck);
            // 
            // lblCPry
            // 
            resources.ApplyResources(this.lblCPry, "lblCPry");
            this.lblCPry.Name = "lblCPry";
            // 
            // checkListCPry
            // 
            this.checkListCPry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.checkListCPry.FormattingEnabled = true;
            resources.ApplyResources(this.checkListCPry, "checkListCPry");
            this.checkListCPry.Name = "checkListCPry";
            this.checkListCPry.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListCPry_ItemCheck);
            this.checkListCPry.SelectedIndexChanged += new System.EventHandler(this.cbEstatus_SelectedIndexChanged);
            // 
            // tabCot
            // 
            this.tabCot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabCot.Controls.Add(this.dgDoc);
            resources.ApplyResources(this.tabCot, "tabCot");
            this.tabCot.Name = "tabCot";
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
            // btnNCli
            // 
            this.btnNCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnNCli.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnNCli, "btnNCli");
            this.btnNCli.Name = "btnNCli";
            this.btnNCli.UseVisualStyleBackColor = false;
            this.btnNCli.Click += new System.EventHandler(this.btnNCli_Click);
            // 
            // Proyecto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.btnNCli);
            this.Controls.Add(this.tabCarpeta);
            this.Controls.Add(this.cbEstatus);
            this.Controls.Add(this.lblEstatus);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.checkActivo);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Proyecto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Proyecto_Load);
            this.tabCarpeta.ResumeLayout(false);
            this.tabNom.ResumeLayout(false);
            this.tabNom.PerformLayout();
            this.tabCar.ResumeLayout(false);
            this.tabCar.PerformLayout();
            this.tabCot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNomCarp;
        private System.Windows.Forms.TextBox txtNomCarp;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.CheckBox checkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label lblObjetivo;
        private System.Windows.Forms.ComboBox cbObjetivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTipoSis;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.ComboBox cbEstatus;
        private System.Windows.Forms.ComboBox cbLugar;
        private System.Windows.Forms.TabControl tabCarpeta;
        private System.Windows.Forms.TabPage tabNom;
        private System.Windows.Forms.TabPage tabCar;
        private System.Windows.Forms.Label lblLugar;
        private System.Windows.Forms.CheckedListBox checkListCPry;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.CheckedListBox checkListCCot;
        private System.Windows.Forms.Label lblCPry;
        private System.Windows.Forms.Label lblCCot;
        private System.Windows.Forms.Button btnNCli;
        private System.Windows.Forms.TabPage tabCot;
        private System.Windows.Forms.DataGridView dgDoc;
    }
}