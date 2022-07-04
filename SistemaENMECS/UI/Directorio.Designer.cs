namespace SistemaENMECS.UI
{
    partial class Directorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Directorio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabCInfo = new System.Windows.Forms.TabControl();
            this.tabUbicacion = new System.Windows.Forms.TabPage();
            this.btnActUb = new System.Windows.Forms.Button();
            this.txtNacional = new System.Windows.Forms.TextBox();
            this.lblNacional = new System.Windows.Forms.Label();
            this.txtNumInt = new System.Windows.Forms.TextBox();
            this.lblNumInt = new System.Windows.Forms.Label();
            this.txtNumExt = new System.Windows.Forms.TextBox();
            this.lblNumExt = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.tabBanco = new System.Windows.Forms.TabPage();
            this.btnActBanco = new System.Windows.Forms.Button();
            this.txtCLABE = new System.Windows.Forms.TextBox();
            this.lblCLABE = new System.Windows.Forms.Label();
            this.txtNumCta = new System.Windows.Forms.TextBox();
            this.lblNumCta = new System.Windows.Forms.Label();
            this.txtSuc = new System.Windows.Forms.TextBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtBenef = new System.Windows.Forms.TextBox();
            this.lblBenef = new System.Windows.Forms.Label();
            this.txtLCred = new System.Windows.Forms.TextBox();
            this.lblLCredito = new System.Windows.Forms.Label();
            this.txtDCred = new System.Windows.Forms.TextBox();
            this.lblDCredito = new System.Windows.Forms.Label();
            this.checkCredito = new System.Windows.Forms.CheckBox();
            this.tabContacto = new System.Windows.Forms.TabPage();
            this.btnAgregarCon = new System.Windows.Forms.Button();
            this.dgContactos = new System.Windows.Forms.DataGridView();
            this.tabCategoria = new System.Windows.Forms.TabPage();
            this.btnAddCat = new System.Windows.Forms.Button();
            this.listBCategoria = new System.Windows.Forms.ListBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblRFC = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.lblRazon = new System.Windows.Forms.Label();
            this.txtNomCom = new System.Windows.Forms.TextBox();
            this.lblNomCom = new System.Windows.Forms.Label();
            this.TxtNomCorto = new System.Windows.Forms.TextBox();
            this.lblNomCorto = new System.Windows.Forms.Label();
            this.lblTPersona = new System.Windows.Forms.Label();
            this.cbTPersona = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblWeb = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.cbClasif = new System.Windows.Forms.ComboBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.checkActivo = new System.Windows.Forms.CheckBox();
            this.groupPrv = new System.Windows.Forms.GroupBox();
            this.lblPj = new System.Windows.Forms.Label();
            this.txtPjDesc = new System.Windows.Forms.TextBox();
            this.radBtnDis = new System.Windows.Forms.RadioButton();
            this.radBtnFab = new System.Windows.Forms.RadioButton();
            this.lblPjDesc = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.tabCInfo.SuspendLayout();
            this.tabUbicacion.SuspendLayout();
            this.tabBanco.SuspendLayout();
            this.tabContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).BeginInit();
            this.tabCategoria.SuspendLayout();
            this.groupPrv.SuspendLayout();
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
            // tabCInfo
            // 
            this.tabCInfo.Controls.Add(this.tabUbicacion);
            this.tabCInfo.Controls.Add(this.tabBanco);
            this.tabCInfo.Controls.Add(this.tabContacto);
            this.tabCInfo.Controls.Add(this.tabCategoria);
            resources.ApplyResources(this.tabCInfo, "tabCInfo");
            this.tabCInfo.Name = "tabCInfo";
            this.tabCInfo.SelectedIndex = 0;
            // 
            // tabUbicacion
            // 
            this.tabUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabUbicacion.Controls.Add(this.btnActUb);
            this.tabUbicacion.Controls.Add(this.txtNacional);
            this.tabUbicacion.Controls.Add(this.lblNacional);
            this.tabUbicacion.Controls.Add(this.txtNumInt);
            this.tabUbicacion.Controls.Add(this.lblNumInt);
            this.tabUbicacion.Controls.Add(this.txtNumExt);
            this.tabUbicacion.Controls.Add(this.lblNumExt);
            this.tabUbicacion.Controls.Add(this.txtCP);
            this.tabUbicacion.Controls.Add(this.lblCP);
            this.tabUbicacion.Controls.Add(this.txtPais);
            this.tabUbicacion.Controls.Add(this.lblPais);
            this.tabUbicacion.Controls.Add(this.txtEstado);
            this.tabUbicacion.Controls.Add(this.txtMunicipio);
            this.tabUbicacion.Controls.Add(this.txtCiudad);
            this.tabUbicacion.Controls.Add(this.txtColonia);
            this.tabUbicacion.Controls.Add(this.txtCalle);
            this.tabUbicacion.Controls.Add(this.lblEstado);
            this.tabUbicacion.Controls.Add(this.lblMunicipio);
            this.tabUbicacion.Controls.Add(this.lblCiudad);
            this.tabUbicacion.Controls.Add(this.lblColonia);
            this.tabUbicacion.Controls.Add(this.lblCalle);
            resources.ApplyResources(this.tabUbicacion, "tabUbicacion");
            this.tabUbicacion.Name = "tabUbicacion";
            // 
            // btnActUb
            // 
            this.btnActUb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnActUb.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnActUb, "btnActUb");
            this.btnActUb.Name = "btnActUb";
            this.btnActUb.UseVisualStyleBackColor = false;
            this.btnActUb.Click += new System.EventHandler(this.btnActUb_Click);
            // 
            // txtNacional
            // 
            this.txtNacional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNacional, "txtNacional");
            this.txtNacional.Name = "txtNacional";
            // 
            // lblNacional
            // 
            resources.ApplyResources(this.lblNacional, "lblNacional");
            this.lblNacional.Name = "lblNacional";
            // 
            // txtNumInt
            // 
            this.txtNumInt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNumInt, "txtNumInt");
            this.txtNumInt.Name = "txtNumInt";
            // 
            // lblNumInt
            // 
            resources.ApplyResources(this.lblNumInt, "lblNumInt");
            this.lblNumInt.Name = "lblNumInt";
            // 
            // txtNumExt
            // 
            this.txtNumExt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNumExt, "txtNumExt");
            this.txtNumExt.Name = "txtNumExt";
            // 
            // lblNumExt
            // 
            resources.ApplyResources(this.lblNumExt, "lblNumExt");
            this.lblNumExt.Name = "lblNumExt";
            // 
            // txtCP
            // 
            resources.ApplyResources(this.txtCP, "txtCP");
            this.txtCP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtCP.Name = "txtCP";
            // 
            // lblCP
            // 
            resources.ApplyResources(this.lblCP, "lblCP");
            this.lblCP.Name = "lblCP";
            // 
            // txtPais
            // 
            resources.ApplyResources(this.txtPais, "txtPais");
            this.txtPais.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtPais.Name = "txtPais";
            // 
            // lblPais
            // 
            resources.ApplyResources(this.lblPais, "lblPais");
            this.lblPais.Name = "lblPais";
            // 
            // txtEstado
            // 
            resources.ApplyResources(this.txtEstado, "txtEstado");
            this.txtEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtEstado.Name = "txtEstado";
            // 
            // txtMunicipio
            // 
            resources.ApplyResources(this.txtMunicipio, "txtMunicipio");
            this.txtMunicipio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtMunicipio.Name = "txtMunicipio";
            // 
            // txtCiudad
            // 
            resources.ApplyResources(this.txtCiudad, "txtCiudad");
            this.txtCiudad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtCiudad.Name = "txtCiudad";
            // 
            // txtColonia
            // 
            resources.ApplyResources(this.txtColonia, "txtColonia");
            this.txtColonia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtColonia.Name = "txtColonia";
            // 
            // txtCalle
            // 
            resources.ApplyResources(this.txtCalle, "txtCalle");
            this.txtCalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtCalle.Name = "txtCalle";
            // 
            // lblEstado
            // 
            resources.ApplyResources(this.lblEstado, "lblEstado");
            this.lblEstado.Name = "lblEstado";
            // 
            // lblMunicipio
            // 
            resources.ApplyResources(this.lblMunicipio, "lblMunicipio");
            this.lblMunicipio.Name = "lblMunicipio";
            // 
            // lblCiudad
            // 
            resources.ApplyResources(this.lblCiudad, "lblCiudad");
            this.lblCiudad.Name = "lblCiudad";
            // 
            // lblColonia
            // 
            resources.ApplyResources(this.lblColonia, "lblColonia");
            this.lblColonia.Name = "lblColonia";
            // 
            // lblCalle
            // 
            resources.ApplyResources(this.lblCalle, "lblCalle");
            this.lblCalle.Name = "lblCalle";
            // 
            // tabBanco
            // 
            this.tabBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabBanco.Controls.Add(this.btnActBanco);
            this.tabBanco.Controls.Add(this.txtCLABE);
            this.tabBanco.Controls.Add(this.lblCLABE);
            this.tabBanco.Controls.Add(this.txtNumCta);
            this.tabBanco.Controls.Add(this.lblNumCta);
            this.tabBanco.Controls.Add(this.txtSuc);
            this.tabBanco.Controls.Add(this.lblSucursal);
            this.tabBanco.Controls.Add(this.txtBanco);
            this.tabBanco.Controls.Add(this.lblBanco);
            this.tabBanco.Controls.Add(this.txtBenef);
            this.tabBanco.Controls.Add(this.lblBenef);
            this.tabBanco.Controls.Add(this.txtLCred);
            this.tabBanco.Controls.Add(this.lblLCredito);
            this.tabBanco.Controls.Add(this.txtDCred);
            this.tabBanco.Controls.Add(this.lblDCredito);
            this.tabBanco.Controls.Add(this.checkCredito);
            resources.ApplyResources(this.tabBanco, "tabBanco");
            this.tabBanco.Name = "tabBanco";
            // 
            // btnActBanco
            // 
            this.btnActBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnActBanco.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnActBanco, "btnActBanco");
            this.btnActBanco.Name = "btnActBanco";
            this.btnActBanco.UseVisualStyleBackColor = false;
            this.btnActBanco.Click += new System.EventHandler(this.btnActBanco_Click);
            // 
            // txtCLABE
            // 
            this.txtCLABE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtCLABE, "txtCLABE");
            this.txtCLABE.Name = "txtCLABE";
            // 
            // lblCLABE
            // 
            resources.ApplyResources(this.lblCLABE, "lblCLABE");
            this.lblCLABE.Name = "lblCLABE";
            // 
            // txtNumCta
            // 
            this.txtNumCta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNumCta, "txtNumCta");
            this.txtNumCta.Name = "txtNumCta";
            // 
            // lblNumCta
            // 
            resources.ApplyResources(this.lblNumCta, "lblNumCta");
            this.lblNumCta.Name = "lblNumCta";
            // 
            // txtSuc
            // 
            this.txtSuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtSuc, "txtSuc");
            this.txtSuc.Name = "txtSuc";
            // 
            // lblSucursal
            // 
            resources.ApplyResources(this.lblSucursal, "lblSucursal");
            this.lblSucursal.Name = "lblSucursal";
            // 
            // txtBanco
            // 
            this.txtBanco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtBanco, "txtBanco");
            this.txtBanco.Name = "txtBanco";
            // 
            // lblBanco
            // 
            resources.ApplyResources(this.lblBanco, "lblBanco");
            this.lblBanco.Name = "lblBanco";
            // 
            // txtBenef
            // 
            this.txtBenef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtBenef, "txtBenef");
            this.txtBenef.Name = "txtBenef";
            // 
            // lblBenef
            // 
            resources.ApplyResources(this.lblBenef, "lblBenef");
            this.lblBenef.Name = "lblBenef";
            // 
            // txtLCred
            // 
            this.txtLCred.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtLCred, "txtLCred");
            this.txtLCred.Name = "txtLCred";
            // 
            // lblLCredito
            // 
            resources.ApplyResources(this.lblLCredito, "lblLCredito");
            this.lblLCredito.Name = "lblLCredito";
            // 
            // txtDCred
            // 
            this.txtDCred.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtDCred, "txtDCred");
            this.txtDCred.Name = "txtDCred";
            // 
            // lblDCredito
            // 
            resources.ApplyResources(this.lblDCredito, "lblDCredito");
            this.lblDCredito.Name = "lblDCredito";
            // 
            // checkCredito
            // 
            resources.ApplyResources(this.checkCredito, "checkCredito");
            this.checkCredito.Name = "checkCredito";
            this.checkCredito.UseVisualStyleBackColor = true;
            this.checkCredito.CheckedChanged += new System.EventHandler(this.checkCredito_CheckedChanged);
            // 
            // tabContacto
            // 
            this.tabContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabContacto.Controls.Add(this.btnAgregarCon);
            this.tabContacto.Controls.Add(this.dgContactos);
            resources.ApplyResources(this.tabContacto, "tabContacto");
            this.tabContacto.Name = "tabContacto";
            // 
            // btnAgregarCon
            // 
            this.btnAgregarCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnAgregarCon.BackgroundImage = global::SistemaENMECS.Properties.Resources.plus;
            resources.ApplyResources(this.btnAgregarCon, "btnAgregarCon");
            this.btnAgregarCon.FlatAppearance.BorderSize = 0;
            this.btnAgregarCon.Name = "btnAgregarCon";
            this.btnAgregarCon.UseVisualStyleBackColor = false;
            this.btnAgregarCon.Click += new System.EventHandler(this.btnAgregarCon_Click);
            // 
            // dgContactos
            // 
            this.dgContactos.AllowUserToAddRows = false;
            this.dgContactos.AllowUserToDeleteRows = false;
            this.dgContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgContactos, "dgContactos");
            this.dgContactos.Name = "dgContactos";
            this.dgContactos.ReadOnly = true;
            this.dgContactos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgContactos_CellContentDoubleClick);
            // 
            // tabCategoria
            // 
            this.tabCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabCategoria.Controls.Add(this.btnDel);
            this.tabCategoria.Controls.Add(this.btnAddCat);
            this.tabCategoria.Controls.Add(this.listBCategoria);
            this.tabCategoria.Controls.Add(this.cbCategoria);
            this.tabCategoria.Controls.Add(this.lblCategoria);
            resources.ApplyResources(this.tabCategoria, "tabCategoria");
            this.tabCategoria.Name = "tabCategoria";
            // 
            // btnAddCat
            // 
            this.btnAddCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnAddCat.BackgroundImage = global::SistemaENMECS.Properties.Resources.plus;
            resources.ApplyResources(this.btnAddCat, "btnAddCat");
            this.btnAddCat.FlatAppearance.BorderSize = 0;
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.UseVisualStyleBackColor = false;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // listBCategoria
            // 
            this.listBCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.listBCategoria.FormattingEnabled = true;
            resources.ApplyResources(this.listBCategoria, "listBCategoria");
            this.listBCategoria.Name = "listBCategoria";
            // 
            // cbCategoria
            // 
            this.cbCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbCategoria.FormattingEnabled = true;
            resources.ApplyResources(this.cbCategoria, "cbCategoria");
            this.cbCategoria.Name = "cbCategoria";
            // 
            // lblCategoria
            // 
            resources.ApplyResources(this.lblCategoria, "lblCategoria");
            this.lblCategoria.Name = "lblCategoria";
            // 
            // lblRFC
            // 
            resources.ApplyResources(this.lblRFC, "lblRFC");
            this.lblRFC.Name = "lblRFC";
            // 
            // txtRFC
            // 
            resources.ApplyResources(this.txtRFC, "txtRFC");
            this.txtRFC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtRFC.Name = "txtRFC";
            // 
            // txtRazon
            // 
            resources.ApplyResources(this.txtRazon, "txtRazon");
            this.txtRazon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtRazon.Name = "txtRazon";
            // 
            // lblRazon
            // 
            resources.ApplyResources(this.lblRazon, "lblRazon");
            this.lblRazon.Name = "lblRazon";
            // 
            // txtNomCom
            // 
            resources.ApplyResources(this.txtNomCom, "txtNomCom");
            this.txtNomCom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtNomCom.Name = "txtNomCom";
            // 
            // lblNomCom
            // 
            resources.ApplyResources(this.lblNomCom, "lblNomCom");
            this.lblNomCom.Name = "lblNomCom";
            // 
            // TxtNomCorto
            // 
            resources.ApplyResources(this.TxtNomCorto, "TxtNomCorto");
            this.TxtNomCorto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.TxtNomCorto.Name = "TxtNomCorto";
            // 
            // lblNomCorto
            // 
            resources.ApplyResources(this.lblNomCorto, "lblNomCorto");
            this.lblNomCorto.Name = "lblNomCorto";
            // 
            // lblTPersona
            // 
            resources.ApplyResources(this.lblTPersona, "lblTPersona");
            this.lblTPersona.Name = "lblTPersona";
            // 
            // cbTPersona
            // 
            resources.ApplyResources(this.cbTPersona, "cbTPersona");
            this.cbTPersona.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbTPersona.FormattingEnabled = true;
            this.cbTPersona.Name = "cbTPersona";
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
            // lblWeb
            // 
            resources.ApplyResources(this.lblWeb, "lblWeb");
            this.lblWeb.Name = "lblWeb";
            // 
            // txtWeb
            // 
            resources.ApplyResources(this.txtWeb, "txtWeb");
            this.txtWeb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtWeb.Name = "txtWeb";
            // 
            // lblClasificacion
            // 
            resources.ApplyResources(this.lblClasificacion, "lblClasificacion");
            this.lblClasificacion.Name = "lblClasificacion";
            // 
            // cbClasif
            // 
            resources.ApplyResources(this.cbClasif, "cbClasif");
            this.cbClasif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbClasif.FormattingEnabled = true;
            this.cbClasif.Name = "cbClasif";
            // 
            // lblCorreo
            // 
            resources.ApplyResources(this.lblCorreo, "lblCorreo");
            this.lblCorreo.Name = "lblCorreo";
            // 
            // txtCorreo
            // 
            resources.ApplyResources(this.txtCorreo, "txtCorreo");
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtCorreo.Name = "txtCorreo";
            // 
            // lblTel
            // 
            resources.ApplyResources(this.lblTel, "lblTel");
            this.lblTel.Name = "lblTel";
            // 
            // txtTel
            // 
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtTel.Name = "txtTel";
            // 
            // checkActivo
            // 
            resources.ApplyResources(this.checkActivo, "checkActivo");
            this.checkActivo.Name = "checkActivo";
            this.checkActivo.UseVisualStyleBackColor = true;
            this.checkActivo.CheckedChanged += new System.EventHandler(this.checkActivo_CheckedChanged);
            // 
            // groupPrv
            // 
            this.groupPrv.Controls.Add(this.lblPj);
            this.groupPrv.Controls.Add(this.txtPjDesc);
            this.groupPrv.Controls.Add(this.radBtnDis);
            this.groupPrv.Controls.Add(this.radBtnFab);
            this.groupPrv.Controls.Add(this.lblPjDesc);
            resources.ApplyResources(this.groupPrv, "groupPrv");
            this.groupPrv.Name = "groupPrv";
            this.groupPrv.TabStop = false;
            // 
            // lblPj
            // 
            resources.ApplyResources(this.lblPj, "lblPj");
            this.lblPj.Name = "lblPj";
            // 
            // txtPjDesc
            // 
            this.txtPjDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtPjDesc, "txtPjDesc");
            this.txtPjDesc.Name = "txtPjDesc";
            // 
            // radBtnDis
            // 
            resources.ApplyResources(this.radBtnDis, "radBtnDis");
            this.radBtnDis.Name = "radBtnDis";
            this.radBtnDis.TabStop = true;
            this.radBtnDis.UseVisualStyleBackColor = true;
            // 
            // radBtnFab
            // 
            resources.ApplyResources(this.radBtnFab, "radBtnFab");
            this.radBtnFab.Name = "radBtnFab";
            this.radBtnFab.TabStop = true;
            this.radBtnFab.UseVisualStyleBackColor = true;
            // 
            // lblPjDesc
            // 
            resources.ApplyResources(this.lblPjDesc, "lblPjDesc");
            this.lblPjDesc.Name = "lblPjDesc";
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnDel.BackgroundImage = global::SistemaENMECS.Properties.Resources.cancel_16;
            resources.ApplyResources(this.btnDel, "btnDel");
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.Name = "btnDel";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // Directorio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.groupPrv);
            this.Controls.Add(this.checkActivo);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.cbClasif);
            this.Controls.Add(this.lblClasificacion);
            this.Controls.Add(this.txtWeb);
            this.Controls.Add(this.lblWeb);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbTPersona);
            this.Controls.Add(this.lblTPersona);
            this.Controls.Add(this.TxtNomCorto);
            this.Controls.Add(this.lblNomCorto);
            this.Controls.Add(this.txtNomCom);
            this.Controls.Add(this.lblNomCom);
            this.Controls.Add(this.txtRazon);
            this.Controls.Add(this.lblRazon);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.lblRFC);
            this.Controls.Add(this.tabCInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Directorio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Directorio_Load);
            this.tabCInfo.ResumeLayout(false);
            this.tabUbicacion.ResumeLayout(false);
            this.tabUbicacion.PerformLayout();
            this.tabBanco.ResumeLayout(false);
            this.tabBanco.PerformLayout();
            this.tabContacto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).EndInit();
            this.tabCategoria.ResumeLayout(false);
            this.tabCategoria.PerformLayout();
            this.groupPrv.ResumeLayout(false);
            this.groupPrv.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabCInfo;
        private System.Windows.Forms.TabPage tabUbicacion;
        private System.Windows.Forms.TabPage tabBanco;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.TextBox txtNomCom;
        private System.Windows.Forms.Label lblNomCom;
        private System.Windows.Forms.TextBox TxtNomCorto;
        private System.Windows.Forms.Label lblNomCorto;
        private System.Windows.Forms.Label lblTPersona;
        private System.Windows.Forms.ComboBox cbTPersona;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.TabPage tabContacto;
        private System.Windows.Forms.DataGridView dgContactos;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.ComboBox cbClasif;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Button btnAgregarCon;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.CheckBox checkActivo;
        private System.Windows.Forms.TextBox txtCLABE;
        private System.Windows.Forms.Label lblCLABE;
        private System.Windows.Forms.TextBox txtNumCta;
        private System.Windows.Forms.Label lblNumCta;
        private System.Windows.Forms.TextBox txtSuc;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtBenef;
        private System.Windows.Forms.Label lblBenef;
        private System.Windows.Forms.TextBox txtLCred;
        private System.Windows.Forms.Label lblLCredito;
        private System.Windows.Forms.TextBox txtDCred;
        private System.Windows.Forms.Label lblDCredito;
        private System.Windows.Forms.CheckBox checkCredito;
        private System.Windows.Forms.Button btnActUb;
        private System.Windows.Forms.TextBox txtNacional;
        private System.Windows.Forms.Label lblNacional;
        private System.Windows.Forms.TextBox txtNumInt;
        private System.Windows.Forms.Label lblNumInt;
        private System.Windows.Forms.TextBox txtNumExt;
        private System.Windows.Forms.Label lblNumExt;
        private System.Windows.Forms.Button btnActBanco;
        private System.Windows.Forms.GroupBox groupPrv;
        private System.Windows.Forms.TextBox txtPjDesc;
        private System.Windows.Forms.RadioButton radBtnDis;
        private System.Windows.Forms.RadioButton radBtnFab;
        private System.Windows.Forms.Label lblPjDesc;
        private System.Windows.Forms.Label lblPj;
        private System.Windows.Forms.TabPage tabCategoria;
        private System.Windows.Forms.Button btnAddCat;
        private System.Windows.Forms.ListBox listBCategoria;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnDel;
    }
}