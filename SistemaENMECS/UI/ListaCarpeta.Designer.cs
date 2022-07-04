namespace SistemaENMECS.UI
{
    partial class ListaCarpeta
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
            this.gbGrupo = new System.Windows.Forms.GroupBox();
            this.btnEditGrupo = new System.Windows.Forms.Button();
            this.btnAddGrupo = new System.Windows.Forms.Button();
            this.cbGcIdent = new System.Windows.Forms.ComboBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.btnGuardaGrupo = new System.Windows.Forms.Button();
            this.txtGcPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtGcDescripcion = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtGcIdent = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.dgCarpetas = new System.Windows.Forms.DataGridView();
            this.gbCarpeta = new System.Windows.Forms.GroupBox();
            this.ckeckActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardaCar = new System.Windows.Forms.Button();
            this.txtCrNombre = new System.Windows.Forms.TextBox();
            this.lblCar = new System.Windows.Forms.Label();
            this.txtCrIdent = new System.Windows.Forms.TextBox();
            this.lblIdCar = new System.Windows.Forms.Label();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.gbGrupo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCarpetas)).BeginInit();
            this.gbCarpeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 10);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 14F);
            this.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitulo.Location = new System.Drawing.Point(8, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(172, 22);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "LISTA CARPETAS";
            // 
            // gbGrupo
            // 
            this.gbGrupo.Controls.Add(this.btnEditGrupo);
            this.gbGrupo.Controls.Add(this.btnAddGrupo);
            this.gbGrupo.Controls.Add(this.cbGcIdent);
            this.gbGrupo.Controls.Add(this.lblGrupo);
            this.gbGrupo.Controls.Add(this.gbDatos);
            this.gbGrupo.Location = new System.Drawing.Point(12, 74);
            this.gbGrupo.Name = "gbGrupo";
            this.gbGrupo.Size = new System.Drawing.Size(757, 85);
            this.gbGrupo.TabIndex = 7;
            this.gbGrupo.TabStop = false;
            this.gbGrupo.Text = "Grupo Carpeta";
            // 
            // btnEditGrupo
            // 
            this.btnEditGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnEditGrupo.BackgroundImage = global::SistemaENMECS.Properties.Resources.edit_16;
            this.btnEditGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditGrupo.FlatAppearance.BorderSize = 0;
            this.btnEditGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditGrupo.Location = new System.Drawing.Point(299, 32);
            this.btnEditGrupo.Name = "btnEditGrupo";
            this.btnEditGrupo.Size = new System.Drawing.Size(25, 25);
            this.btnEditGrupo.TabIndex = 4;
            this.btnEditGrupo.UseVisualStyleBackColor = false;
            this.btnEditGrupo.Click += new System.EventHandler(this.btnEditGrupo_Click);
            // 
            // btnAddGrupo
            // 
            this.btnAddGrupo.Location = new System.Drawing.Point(298, 32);
            this.btnAddGrupo.Name = "btnAddGrupo";
            this.btnAddGrupo.Size = new System.Drawing.Size(25, 25);
            this.btnAddGrupo.TabIndex = 3;
            this.btnAddGrupo.Text = "+";
            this.btnAddGrupo.UseVisualStyleBackColor = true;
            this.btnAddGrupo.Click += new System.EventHandler(this.btnAddGrupo_Click);
            // 
            // cbGcIdent
            // 
            this.cbGcIdent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.cbGcIdent.FormattingEnabled = true;
            this.cbGcIdent.Location = new System.Drawing.Point(50, 33);
            this.cbGcIdent.Name = "cbGcIdent";
            this.cbGcIdent.Size = new System.Drawing.Size(242, 23);
            this.cbGcIdent.TabIndex = 2;
            this.cbGcIdent.SelectedIndexChanged += new System.EventHandler(this.cbGcIdent_SelectedIndexChanged);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(6, 36);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(44, 15);
            this.lblGrupo.TabIndex = 1;
            this.lblGrupo.Text = "Grupo:";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.btnGuardaGrupo);
            this.gbDatos.Controls.Add(this.txtGcPath);
            this.gbDatos.Controls.Add(this.lblPath);
            this.gbDatos.Controls.Add(this.txtGcDescripcion);
            this.gbDatos.Controls.Add(this.lblNom);
            this.gbDatos.Controls.Add(this.txtGcIdent);
            this.gbDatos.Controls.Add(this.lblId);
            this.gbDatos.Location = new System.Drawing.Point(330, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(421, 63);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            // 
            // btnGuardaGrupo
            // 
            this.btnGuardaGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnGuardaGrupo.BackgroundImage = global::SistemaENMECS.Properties.Resources.save_16;
            this.btnGuardaGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGuardaGrupo.FlatAppearance.BorderSize = 0;
            this.btnGuardaGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardaGrupo.Location = new System.Drawing.Point(389, 18);
            this.btnGuardaGrupo.Name = "btnGuardaGrupo";
            this.btnGuardaGrupo.Size = new System.Drawing.Size(25, 25);
            this.btnGuardaGrupo.TabIndex = 6;
            this.btnGuardaGrupo.UseVisualStyleBackColor = false;
            this.btnGuardaGrupo.Click += new System.EventHandler(this.btnGuardaGrupo_Click);
            // 
            // txtGcPath
            // 
            this.txtGcPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtGcPath.Location = new System.Drawing.Point(307, 21);
            this.txtGcPath.MaxLength = 100;
            this.txtGcPath.Name = "txtGcPath";
            this.txtGcPath.Size = new System.Drawing.Size(74, 21);
            this.txtGcPath.TabIndex = 5;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(266, 24);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(35, 15);
            this.lblPath.TabIndex = 4;
            this.lblPath.Text = "Path:";
            // 
            // txtGcDescripcion
            // 
            this.txtGcDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtGcDescripcion.Location = new System.Drawing.Point(159, 20);
            this.txtGcDescripcion.MaxLength = 100;
            this.txtGcDescripcion.Name = "txtGcDescripcion";
            this.txtGcDescripcion.Size = new System.Drawing.Size(100, 21);
            this.txtGcDescripcion.TabIndex = 3;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(98, 23);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(55, 15);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nombre:";
            // 
            // txtGcIdent
            // 
            this.txtGcIdent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtGcIdent.Location = new System.Drawing.Point(34, 21);
            this.txtGcIdent.MaxLength = 10;
            this.txtGcIdent.Name = "txtGcIdent";
            this.txtGcIdent.Size = new System.Drawing.Size(53, 21);
            this.txtGcIdent.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(8, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(20, 15);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id:";
            // 
            // dgCarpetas
            // 
            this.dgCarpetas.AllowUserToAddRows = false;
            this.dgCarpetas.AllowUserToDeleteRows = false;
            this.dgCarpetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCarpetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCarpetas.Location = new System.Drawing.Point(12, 191);
            this.dgCarpetas.Name = "dgCarpetas";
            this.dgCarpetas.ReadOnly = true;
            this.dgCarpetas.Size = new System.Drawing.Size(390, 408);
            this.dgCarpetas.TabIndex = 8;
            this.dgCarpetas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCarpetas_CellContentDoubleClick);
            // 
            // gbCarpeta
            // 
            this.gbCarpeta.Controls.Add(this.ckeckActivo);
            this.gbCarpeta.Controls.Add(this.btnGuardaCar);
            this.gbCarpeta.Controls.Add(this.txtCrNombre);
            this.gbCarpeta.Controls.Add(this.lblCar);
            this.gbCarpeta.Controls.Add(this.txtCrIdent);
            this.gbCarpeta.Controls.Add(this.lblIdCar);
            this.gbCarpeta.Location = new System.Drawing.Point(408, 191);
            this.gbCarpeta.Name = "gbCarpeta";
            this.gbCarpeta.Size = new System.Drawing.Size(361, 159);
            this.gbCarpeta.TabIndex = 9;
            this.gbCarpeta.TabStop = false;
            this.gbCarpeta.Text = "Carpeta";
            // 
            // ckeckActivo
            // 
            this.ckeckActivo.AutoSize = true;
            this.ckeckActivo.Location = new System.Drawing.Point(195, 25);
            this.ckeckActivo.Name = "ckeckActivo";
            this.ckeckActivo.Size = new System.Drawing.Size(57, 19);
            this.ckeckActivo.TabIndex = 5;
            this.ckeckActivo.Text = "Activo";
            this.ckeckActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardaCar
            // 
            this.btnGuardaCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnGuardaCar.FlatAppearance.BorderSize = 0;
            this.btnGuardaCar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardaCar.Location = new System.Drawing.Point(264, 130);
            this.btnGuardaCar.Name = "btnGuardaCar";
            this.btnGuardaCar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardaCar.TabIndex = 4;
            this.btnGuardaCar.Text = "Guardar";
            this.btnGuardaCar.UseVisualStyleBackColor = false;
            this.btnGuardaCar.Click += new System.EventHandler(this.btnGuardaCar_Click);
            // 
            // txtCrNombre
            // 
            this.txtCrNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtCrNombre.Location = new System.Drawing.Point(75, 62);
            this.txtCrNombre.MaxLength = 40;
            this.txtCrNombre.Multiline = true;
            this.txtCrNombre.Name = "txtCrNombre";
            this.txtCrNombre.Size = new System.Drawing.Size(264, 60);
            this.txtCrNombre.TabIndex = 3;
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Location = new System.Drawing.Point(14, 65);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(51, 15);
            this.lblCar.TabIndex = 2;
            this.lblCar.Text = "Carpeta";
            // 
            // txtCrIdent
            // 
            this.txtCrIdent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            this.txtCrIdent.Location = new System.Drawing.Point(75, 23);
            this.txtCrIdent.MaxLength = 10;
            this.txtCrIdent.Name = "txtCrIdent";
            this.txtCrIdent.Size = new System.Drawing.Size(100, 21);
            this.txtCrIdent.TabIndex = 1;
            // 
            // lblIdCar
            // 
            this.lblIdCar.AutoSize = true;
            this.lblIdCar.Location = new System.Drawing.Point(49, 26);
            this.lblIdCar.Name = "lblIdCar";
            this.lblIdCar.Size = new System.Drawing.Size(20, 15);
            this.lblIdCar.TabIndex = 0;
            this.lblIdCar.Text = "Id:";
            // 
            // btnAddCar
            // 
            this.btnAddCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnAddCar.BackgroundImage = global::SistemaENMECS.Properties.Resources.plus;
            this.btnAddCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddCar.FlatAppearance.BorderSize = 0;
            this.btnAddCar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCar.Location = new System.Drawing.Point(377, 160);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(25, 25);
            this.btnAddCar.TabIndex = 10;
            this.btnAddCar.UseVisualStyleBackColor = false;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // ListaCarpeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.btnAddCar);
            this.Controls.Add(this.gbCarpeta);
            this.Controls.Add(this.dgCarpetas);
            this.Controls.Add(this.gbGrupo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaCarpeta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Carpetas";
            this.Load += new System.EventHandler(this.ListaCarpeta_Load);
            this.gbGrupo.ResumeLayout(false);
            this.gbGrupo.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCarpetas)).EndInit();
            this.gbCarpeta.ResumeLayout(false);
            this.gbCarpeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbGrupo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Button btnEditGrupo;
        private System.Windows.Forms.Button btnAddGrupo;
        private System.Windows.Forms.ComboBox cbGcIdent;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.DataGridView dgCarpetas;
        private System.Windows.Forms.GroupBox gbCarpeta;
        private System.Windows.Forms.Button btnGuardaGrupo;
        private System.Windows.Forms.TextBox txtGcPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtGcDescripcion;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtGcIdent;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblIdCar;
        private System.Windows.Forms.Button btnAddCar;
        private System.Windows.Forms.Button btnGuardaCar;
        private System.Windows.Forms.TextBox txtCrNombre;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.TextBox txtCrIdent;
        private System.Windows.Forms.CheckBox ckeckActivo;
    }
}