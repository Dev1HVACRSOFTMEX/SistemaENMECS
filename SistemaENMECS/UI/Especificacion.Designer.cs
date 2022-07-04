namespace SistemaENMECS.UI
{
    partial class Especificacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.cbLinea = new System.Windows.Forms.ComboBox();
            this.gbVersion = new System.Windows.Forms.GroupBox();
            this.rbEspecial = new System.Windows.Forms.RadioButton();
            this.rbEstandar = new System.Windows.Forms.RadioButton();
            this.rbCompacta = new System.Windows.Forms.RadioButton();
            this.gbMaterial = new System.Windows.Forms.GroupBox();
            this.rbLaminaN = new System.Windows.Forms.RadioButton();
            this.rbInoxidable = new System.Windows.Forms.RadioButton();
            this.rbGalvanizado = new System.Windows.Forms.RadioButton();
            this.lblTamanio = new System.Windows.Forms.Label();
            this.cbTamanio = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.gbAcabado = new System.Windows.Forms.GroupBox();
            this.rbEpoxica = new System.Windows.Forms.RadioButton();
            this.rbPintura = new System.Windows.Forms.RadioButton();
            this.rbNatural = new System.Windows.Forms.RadioButton();
            this.gbAislamiento = new System.Windows.Forms.GroupBox();
            this.rbAisla5 = new System.Windows.Forms.RadioButton();
            this.rbAisla4 = new System.Windows.Forms.RadioButton();
            this.rbAisla3 = new System.Windows.Forms.RadioButton();
            this.rbAisla2 = new System.Windows.Forms.RadioButton();
            this.rbAisla1 = new System.Windows.Forms.RadioButton();
            this.rbSinAisla = new System.Windows.Forms.RadioButton();
            this.gbEtapas = new System.Windows.Forms.GroupBox();
            this.rb5Et = new System.Windows.Forms.RadioButton();
            this.rb4Et = new System.Windows.Forms.RadioButton();
            this.rb3Et = new System.Windows.Forms.RadioButton();
            this.rb2Et = new System.Windows.Forms.RadioButton();
            this.rb1Et = new System.Windows.Forms.RadioButton();
            this.gbUso = new System.Windows.Forms.GroupBox();
            this.rbExtraccion = new System.Windows.Forms.RadioButton();
            this.rbInyeccion = new System.Windows.Forms.RadioButton();
            this.rbNoIndicado = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbVersion.SuspendLayout();
            this.gbMaterial.SuspendLayout();
            this.gbAcabado.SuspendLayout();
            this.gbAislamiento.SuspendLayout();
            this.gbEtapas.SuspendLayout();
            this.gbUso.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 10);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F);
            this.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitulo.Location = new System.Drawing.Point(8, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(645, 22);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "GENERADOR DE CÓDIGOS PARA BANCOS Y UNIDADES DE FILTROS";
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Location = new System.Drawing.Point(37, 153);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(107, 15);
            this.lblLinea.TabIndex = 6;
            this.lblLinea.Text = "Línea de Producto";
            // 
            // cbLinea
            // 
            this.cbLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbLinea.FormattingEnabled = true;
            this.cbLinea.Location = new System.Drawing.Point(162, 150);
            this.cbLinea.Name = "cbLinea";
            this.cbLinea.Size = new System.Drawing.Size(121, 23);
            this.cbLinea.TabIndex = 7;
            this.cbLinea.SelectedIndexChanged += new System.EventHandler(this.cbLinea_SelectedIndexChanged);
            // 
            // gbVersion
            // 
            this.gbVersion.Controls.Add(this.rbEspecial);
            this.gbVersion.Controls.Add(this.rbEstandar);
            this.gbVersion.Controls.Add(this.rbCompacta);
            this.gbVersion.Location = new System.Drawing.Point(47, 199);
            this.gbVersion.Name = "gbVersion";
            this.gbVersion.Size = new System.Drawing.Size(106, 100);
            this.gbVersion.TabIndex = 10;
            this.gbVersion.TabStop = false;
            this.gbVersion.Text = "Versión";
            // 
            // rbEspecial
            // 
            this.rbEspecial.AutoSize = true;
            this.rbEspecial.Location = new System.Drawing.Point(6, 70);
            this.rbEspecial.Name = "rbEspecial";
            this.rbEspecial.Size = new System.Drawing.Size(73, 19);
            this.rbEspecial.TabIndex = 2;
            this.rbEspecial.TabStop = true;
            this.rbEspecial.Text = "Especial";
            this.rbEspecial.UseVisualStyleBackColor = true;
            this.rbEspecial.CheckedChanged += new System.EventHandler(this.rbEspecial_CheckedChanged);
            // 
            // rbEstandar
            // 
            this.rbEstandar.AutoSize = true;
            this.rbEstandar.Location = new System.Drawing.Point(6, 45);
            this.rbEstandar.Name = "rbEstandar";
            this.rbEstandar.Size = new System.Drawing.Size(75, 19);
            this.rbEstandar.TabIndex = 1;
            this.rbEstandar.TabStop = true;
            this.rbEstandar.Text = "Estándar";
            this.rbEstandar.UseVisualStyleBackColor = true;
            this.rbEstandar.CheckedChanged += new System.EventHandler(this.rbEstandar_CheckedChanged);
            // 
            // rbCompacta
            // 
            this.rbCompacta.AutoSize = true;
            this.rbCompacta.Location = new System.Drawing.Point(6, 20);
            this.rbCompacta.Name = "rbCompacta";
            this.rbCompacta.Size = new System.Drawing.Size(82, 19);
            this.rbCompacta.TabIndex = 0;
            this.rbCompacta.TabStop = true;
            this.rbCompacta.Text = "Compacta";
            this.rbCompacta.UseVisualStyleBackColor = true;
            this.rbCompacta.CheckedChanged += new System.EventHandler(this.rbCompacta_CheckedChanged);
            // 
            // gbMaterial
            // 
            this.gbMaterial.Controls.Add(this.rbLaminaN);
            this.gbMaterial.Controls.Add(this.rbInoxidable);
            this.gbMaterial.Controls.Add(this.rbGalvanizado);
            this.gbMaterial.Location = new System.Drawing.Point(276, 199);
            this.gbMaterial.Name = "gbMaterial";
            this.gbMaterial.Size = new System.Drawing.Size(123, 100);
            this.gbMaterial.TabIndex = 11;
            this.gbMaterial.TabStop = false;
            this.gbMaterial.Text = "Material";
            // 
            // rbLaminaN
            // 
            this.rbLaminaN.AutoSize = true;
            this.rbLaminaN.Location = new System.Drawing.Point(6, 70);
            this.rbLaminaN.Name = "rbLaminaN";
            this.rbLaminaN.Size = new System.Drawing.Size(104, 19);
            this.rbLaminaN.TabIndex = 2;
            this.rbLaminaN.TabStop = true;
            this.rbLaminaN.Text = "Lámina Negra";
            this.rbLaminaN.UseVisualStyleBackColor = true;
            this.rbLaminaN.CheckedChanged += new System.EventHandler(this.rbLaminaN_CheckedChanged);
            // 
            // rbInoxidable
            // 
            this.rbInoxidable.AutoSize = true;
            this.rbInoxidable.Location = new System.Drawing.Point(6, 45);
            this.rbInoxidable.Name = "rbInoxidable";
            this.rbInoxidable.Size = new System.Drawing.Size(81, 19);
            this.rbInoxidable.TabIndex = 1;
            this.rbInoxidable.TabStop = true;
            this.rbInoxidable.Text = "Inoxidable";
            this.rbInoxidable.UseVisualStyleBackColor = true;
            this.rbInoxidable.CheckedChanged += new System.EventHandler(this.rbInoxidable_CheckedChanged);
            // 
            // rbGalvanizado
            // 
            this.rbGalvanizado.AutoSize = true;
            this.rbGalvanizado.Location = new System.Drawing.Point(6, 20);
            this.rbGalvanizado.Name = "rbGalvanizado";
            this.rbGalvanizado.Size = new System.Drawing.Size(92, 19);
            this.rbGalvanizado.TabIndex = 0;
            this.rbGalvanizado.TabStop = true;
            this.rbGalvanizado.Text = "Galvanizado";
            this.rbGalvanizado.UseVisualStyleBackColor = true;
            this.rbGalvanizado.CheckedChanged += new System.EventHandler(this.rbGalvanizado_CheckedChanged);
            // 
            // lblTamanio
            // 
            this.lblTamanio.AutoSize = true;
            this.lblTamanio.Location = new System.Drawing.Point(406, 153);
            this.lblTamanio.Name = "lblTamanio";
            this.lblTamanio.Size = new System.Drawing.Size(52, 15);
            this.lblTamanio.TabIndex = 8;
            this.lblTamanio.Text = "Tamaño";
            // 
            // cbTamanio
            // 
            this.cbTamanio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbTamanio.FormattingEnabled = true;
            this.cbTamanio.Location = new System.Drawing.Point(479, 150);
            this.cbTamanio.Name = "cbTamanio";
            this.cbTamanio.Size = new System.Drawing.Size(121, 23);
            this.cbTamanio.TabIndex = 9;
            this.cbTamanio.SelectedIndexChanged += new System.EventHandler(this.cbTamanio_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtCodigo.Location = new System.Drawing.Point(65, 100);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(218, 21);
            this.txtCodigo.TabIndex = 4;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 103);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(47, 15);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código";
            // 
            // gbAcabado
            // 
            this.gbAcabado.Controls.Add(this.rbEpoxica);
            this.gbAcabado.Controls.Add(this.rbPintura);
            this.gbAcabado.Controls.Add(this.rbNatural);
            this.gbAcabado.Location = new System.Drawing.Point(497, 199);
            this.gbAcabado.Name = "gbAcabado";
            this.gbAcabado.Size = new System.Drawing.Size(200, 100);
            this.gbAcabado.TabIndex = 12;
            this.gbAcabado.TabStop = false;
            this.gbAcabado.Text = "Acabado";
            // 
            // rbEpoxica
            // 
            this.rbEpoxica.AutoSize = true;
            this.rbEpoxica.Location = new System.Drawing.Point(6, 70);
            this.rbEpoxica.Name = "rbEpoxica";
            this.rbEpoxica.Size = new System.Drawing.Size(109, 19);
            this.rbEpoxica.TabIndex = 2;
            this.rbEpoxica.TabStop = true;
            this.rbEpoxica.Text = "Pintura epóxica";
            this.rbEpoxica.UseVisualStyleBackColor = true;
            this.rbEpoxica.CheckedChanged += new System.EventHandler(this.rbEpoxica_CheckedChanged);
            // 
            // rbPintura
            // 
            this.rbPintura.AutoSize = true;
            this.rbPintura.Location = new System.Drawing.Point(6, 45);
            this.rbPintura.Name = "rbPintura";
            this.rbPintura.Size = new System.Drawing.Size(169, 19);
            this.rbPintura.TabIndex = 1;
            this.rbPintura.TabStop = true;
            this.rbPintura.Text = "Pintura en polvo horneada";
            this.rbPintura.UseVisualStyleBackColor = true;
            this.rbPintura.CheckedChanged += new System.EventHandler(this.rbPintura_CheckedChanged);
            // 
            // rbNatural
            // 
            this.rbNatural.AutoSize = true;
            this.rbNatural.Location = new System.Drawing.Point(6, 20);
            this.rbNatural.Name = "rbNatural";
            this.rbNatural.Size = new System.Drawing.Size(126, 19);
            this.rbNatural.TabIndex = 0;
            this.rbNatural.TabStop = true;
            this.rbNatural.Text = "Natural - sin pintar";
            this.rbNatural.UseVisualStyleBackColor = true;
            this.rbNatural.CheckedChanged += new System.EventHandler(this.rbNatural_CheckedChanged);
            // 
            // gbAislamiento
            // 
            this.gbAislamiento.Controls.Add(this.rbAisla5);
            this.gbAislamiento.Controls.Add(this.rbAisla4);
            this.gbAislamiento.Controls.Add(this.rbAisla3);
            this.gbAislamiento.Controls.Add(this.rbAisla2);
            this.gbAislamiento.Controls.Add(this.rbAisla1);
            this.gbAislamiento.Controls.Add(this.rbSinAisla);
            this.gbAislamiento.Location = new System.Drawing.Point(497, 321);
            this.gbAislamiento.Name = "gbAislamiento";
            this.gbAislamiento.Size = new System.Drawing.Size(272, 172);
            this.gbAislamiento.TabIndex = 15;
            this.gbAislamiento.TabStop = false;
            this.gbAislamiento.Text = "Aislamiento";
            // 
            // rbAisla5
            // 
            this.rbAisla5.AutoSize = true;
            this.rbAisla5.Location = new System.Drawing.Point(6, 145);
            this.rbAisla5.Name = "rbAisla5";
            this.rbAisla5.Size = new System.Drawing.Size(202, 19);
            this.rbAisla5.TabIndex = 5;
            this.rbAisla5.TabStop = true;
            this.rbAisla5.Text = "Poliestireno rígido extruído de 2\"";
            this.rbAisla5.UseVisualStyleBackColor = true;
            this.rbAisla5.CheckedChanged += new System.EventHandler(this.rbAisla5_CheckedChanged);
            // 
            // rbAisla4
            // 
            this.rbAisla4.AutoSize = true;
            this.rbAisla4.Location = new System.Drawing.Point(6, 120);
            this.rbAisla4.Name = "rbAisla4";
            this.rbAisla4.Size = new System.Drawing.Size(168, 19);
            this.rbAisla4.TabIndex = 4;
            this.rbAisla4.TabStop = true;
            this.rbAisla4.Text = "Lana mineral 4.0 pcf de 2\"";
            this.rbAisla4.UseVisualStyleBackColor = true;
            this.rbAisla4.CheckedChanged += new System.EventHandler(this.rbAisla4_CheckedChanged);
            // 
            // rbAisla3
            // 
            this.rbAisla3.AutoSize = true;
            this.rbAisla3.Location = new System.Drawing.Point(6, 95);
            this.rbAisla3.Name = "rbAisla3";
            this.rbAisla3.Size = new System.Drawing.Size(168, 19);
            this.rbAisla3.TabIndex = 3;
            this.rbAisla3.TabStop = true;
            this.rbAisla3.Text = "Lana mineral 4.0 pcf de 1\"";
            this.rbAisla3.UseVisualStyleBackColor = true;
            this.rbAisla3.CheckedChanged += new System.EventHandler(this.rbAisla3_CheckedChanged);
            // 
            // rbAisla2
            // 
            this.rbAisla2.AutoSize = true;
            this.rbAisla2.Location = new System.Drawing.Point(6, 70);
            this.rbAisla2.Name = "rbAisla2";
            this.rbAisla2.Size = new System.Drawing.Size(257, 19);
            this.rbAisla2.TabIndex = 2;
            this.rbAisla2.TabStop = true;
            this.rbAisla2.Text = "Fibra de vidrio c/foil de alum. Ref. de 1 1/2\"";
            this.rbAisla2.UseVisualStyleBackColor = true;
            this.rbAisla2.CheckedChanged += new System.EventHandler(this.rbAisla2_CheckedChanged);
            // 
            // rbAisla1
            // 
            this.rbAisla1.AutoSize = true;
            this.rbAisla1.Location = new System.Drawing.Point(6, 45);
            this.rbAisla1.Name = "rbAisla1";
            this.rbAisla1.Size = new System.Drawing.Size(202, 19);
            this.rbAisla1.TabIndex = 1;
            this.rbAisla1.TabStop = true;
            this.rbAisla1.Text = "Poliestireno rígido extruído de 1\"";
            this.rbAisla1.UseVisualStyleBackColor = true;
            this.rbAisla1.CheckedChanged += new System.EventHandler(this.rbAisla1_CheckedChanged);
            // 
            // rbSinAisla
            // 
            this.rbSinAisla.AutoSize = true;
            this.rbSinAisla.Location = new System.Drawing.Point(6, 20);
            this.rbSinAisla.Name = "rbSinAisla";
            this.rbSinAisla.Size = new System.Drawing.Size(111, 19);
            this.rbSinAisla.TabIndex = 0;
            this.rbSinAisla.TabStop = true;
            this.rbSinAisla.Text = "Sin aislamiento";
            this.rbSinAisla.UseVisualStyleBackColor = true;
            this.rbSinAisla.CheckedChanged += new System.EventHandler(this.rbSinAisla_CheckedChanged);
            // 
            // gbEtapas
            // 
            this.gbEtapas.Controls.Add(this.rb5Et);
            this.gbEtapas.Controls.Add(this.rb4Et);
            this.gbEtapas.Controls.Add(this.rb3Et);
            this.gbEtapas.Controls.Add(this.rb2Et);
            this.gbEtapas.Controls.Add(this.rb1Et);
            this.gbEtapas.Location = new System.Drawing.Point(276, 321);
            this.gbEtapas.Name = "gbEtapas";
            this.gbEtapas.Size = new System.Drawing.Size(123, 144);
            this.gbEtapas.TabIndex = 14;
            this.gbEtapas.TabStop = false;
            this.gbEtapas.Text = "Etapas de Filtros";
            // 
            // rb5Et
            // 
            this.rb5Et.AutoSize = true;
            this.rb5Et.Location = new System.Drawing.Point(6, 120);
            this.rb5Et.Name = "rb5Et";
            this.rb5Et.Size = new System.Drawing.Size(98, 19);
            this.rb5Et.TabIndex = 4;
            this.rb5Et.TabStop = true;
            this.rb5Et.Text = "Cinco etapas";
            this.rb5Et.UseVisualStyleBackColor = true;
            // 
            // rb4Et
            // 
            this.rb4Et.AutoSize = true;
            this.rb4Et.Location = new System.Drawing.Point(6, 95);
            this.rb4Et.Name = "rb4Et";
            this.rb4Et.Size = new System.Drawing.Size(103, 19);
            this.rb4Et.TabIndex = 3;
            this.rb4Et.TabStop = true;
            this.rb4Et.Text = "Cuatro etapas";
            this.rb4Et.UseVisualStyleBackColor = true;
            // 
            // rb3Et
            // 
            this.rb3Et.AutoSize = true;
            this.rb3Et.Location = new System.Drawing.Point(6, 70);
            this.rb3Et.Name = "rb3Et";
            this.rb3Et.Size = new System.Drawing.Size(91, 19);
            this.rb3Et.TabIndex = 2;
            this.rb3Et.TabStop = true;
            this.rb3Et.Text = "Tres etapas";
            this.rb3Et.UseVisualStyleBackColor = true;
            this.rb3Et.CheckedChanged += new System.EventHandler(this.rb3Et_CheckedChanged);
            // 
            // rb2Et
            // 
            this.rb2Et.AutoSize = true;
            this.rb2Et.Location = new System.Drawing.Point(6, 45);
            this.rb2Et.Name = "rb2Et";
            this.rb2Et.Size = new System.Drawing.Size(89, 19);
            this.rb2Et.TabIndex = 1;
            this.rb2Et.TabStop = true;
            this.rb2Et.Text = "Dos etapas";
            this.rb2Et.UseVisualStyleBackColor = true;
            this.rb2Et.CheckedChanged += new System.EventHandler(this.rb2Et_CheckedChanged);
            // 
            // rb1Et
            // 
            this.rb1Et.AutoSize = true;
            this.rb1Et.Location = new System.Drawing.Point(6, 20);
            this.rb1Et.Name = "rb1Et";
            this.rb1Et.Size = new System.Drawing.Size(82, 19);
            this.rb1Et.TabIndex = 0;
            this.rb1Et.TabStop = true;
            this.rb1Et.Text = "Una etapa";
            this.rb1Et.UseVisualStyleBackColor = true;
            this.rb1Et.CheckedChanged += new System.EventHandler(this.rb1Et_CheckedChanged);
            // 
            // gbUso
            // 
            this.gbUso.Controls.Add(this.rbExtraccion);
            this.gbUso.Controls.Add(this.rbInyeccion);
            this.gbUso.Controls.Add(this.rbNoIndicado);
            this.gbUso.Location = new System.Drawing.Point(47, 321);
            this.gbUso.Name = "gbUso";
            this.gbUso.Size = new System.Drawing.Size(106, 100);
            this.gbUso.TabIndex = 13;
            this.gbUso.TabStop = false;
            this.gbUso.Text = "Uso";
            // 
            // rbExtraccion
            // 
            this.rbExtraccion.AutoSize = true;
            this.rbExtraccion.Location = new System.Drawing.Point(6, 70);
            this.rbExtraccion.Name = "rbExtraccion";
            this.rbExtraccion.Size = new System.Drawing.Size(81, 19);
            this.rbExtraccion.TabIndex = 2;
            this.rbExtraccion.TabStop = true;
            this.rbExtraccion.Text = "Extracción";
            this.rbExtraccion.UseVisualStyleBackColor = true;
            this.rbExtraccion.CheckedChanged += new System.EventHandler(this.rbExtraccion_CheckedChanged);
            // 
            // rbInyeccion
            // 
            this.rbInyeccion.AutoSize = true;
            this.rbInyeccion.Location = new System.Drawing.Point(6, 45);
            this.rbInyeccion.Name = "rbInyeccion";
            this.rbInyeccion.Size = new System.Drawing.Size(76, 19);
            this.rbInyeccion.TabIndex = 1;
            this.rbInyeccion.TabStop = true;
            this.rbInyeccion.Text = "Inyección";
            this.rbInyeccion.UseVisualStyleBackColor = true;
            this.rbInyeccion.CheckedChanged += new System.EventHandler(this.rbInyeccion_CheckedChanged);
            // 
            // rbNoIndicado
            // 
            this.rbNoIndicado.AutoSize = true;
            this.rbNoIndicado.Location = new System.Drawing.Point(6, 20);
            this.rbNoIndicado.Name = "rbNoIndicado";
            this.rbNoIndicado.Size = new System.Drawing.Size(91, 19);
            this.rbNoIndicado.TabIndex = 0;
            this.rbNoIndicado.TabStop = true;
            this.rbNoIndicado.Text = "No indicado";
            this.rbNoIndicado.UseVisualStyleBackColor = true;
            this.rbNoIndicado.CheckedChanged += new System.EventHandler(this.rbNoIndicado_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Location = new System.Drawing.Point(306, 99);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Especificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.gbUso);
            this.Controls.Add(this.gbEtapas);
            this.Controls.Add(this.gbAislamiento);
            this.Controls.Add(this.gbAcabado);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cbTamanio);
            this.Controls.Add(this.lblTamanio);
            this.Controls.Add(this.gbMaterial);
            this.Controls.Add(this.gbVersion);
            this.Controls.Add(this.cbLinea);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Especificacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de códigos para bancos y unidades de Filtros";
            this.Load += new System.EventHandler(this.Especificacion_Load);
            this.gbVersion.ResumeLayout(false);
            this.gbVersion.PerformLayout();
            this.gbMaterial.ResumeLayout(false);
            this.gbMaterial.PerformLayout();
            this.gbAcabado.ResumeLayout(false);
            this.gbAcabado.PerformLayout();
            this.gbAislamiento.ResumeLayout(false);
            this.gbAislamiento.PerformLayout();
            this.gbEtapas.ResumeLayout(false);
            this.gbEtapas.PerformLayout();
            this.gbUso.ResumeLayout(false);
            this.gbUso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.ComboBox cbLinea;
        private System.Windows.Forms.GroupBox gbVersion;
        private System.Windows.Forms.RadioButton rbEspecial;
        private System.Windows.Forms.RadioButton rbEstandar;
        private System.Windows.Forms.RadioButton rbCompacta;
        private System.Windows.Forms.GroupBox gbMaterial;
        private System.Windows.Forms.RadioButton rbLaminaN;
        private System.Windows.Forms.RadioButton rbInoxidable;
        private System.Windows.Forms.Label lblTamanio;
        private System.Windows.Forms.ComboBox cbTamanio;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gbAcabado;
        private System.Windows.Forms.RadioButton rbEpoxica;
        private System.Windows.Forms.RadioButton rbPintura;
        private System.Windows.Forms.RadioButton rbNatural;
        private System.Windows.Forms.RadioButton rbGalvanizado;
        private System.Windows.Forms.GroupBox gbAislamiento;
        private System.Windows.Forms.RadioButton rbAisla2;
        private System.Windows.Forms.RadioButton rbAisla1;
        private System.Windows.Forms.RadioButton rbSinAisla;
        private System.Windows.Forms.GroupBox gbEtapas;
        private System.Windows.Forms.RadioButton rb3Et;
        private System.Windows.Forms.RadioButton rb2Et;
        private System.Windows.Forms.RadioButton rb1Et;
        private System.Windows.Forms.GroupBox gbUso;
        private System.Windows.Forms.RadioButton rbExtraccion;
        private System.Windows.Forms.RadioButton rbInyeccion;
        private System.Windows.Forms.RadioButton rbNoIndicado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.RadioButton rb5Et;
        private System.Windows.Forms.RadioButton rb4Et;
        private System.Windows.Forms.RadioButton rbAisla5;
        private System.Windows.Forms.RadioButton rbAisla4;
        private System.Windows.Forms.RadioButton rbAisla3;
    }
}