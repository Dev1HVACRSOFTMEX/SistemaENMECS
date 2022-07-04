namespace SistemaENMECS.UI
{
    partial class Categoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categoria));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabCategoria = new System.Windows.Forms.TabControl();
            this.tabInf = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkActivo = new System.Windows.Forms.CheckBox();
            this.txtCaDescripcion = new System.Windows.Forms.TextBox();
            this.lblCaDesc = new System.Windows.Forms.Label();
            this.txtCaIdent = new System.Windows.Forms.TextBox();
            this.lblCaIdent = new System.Windows.Forms.Label();
            this.tabCaracteristicas = new System.Windows.Forms.TabPage();
            this.txtCOrden = new System.Windows.Forms.TextBox();
            this.lblCOrden = new System.Windows.Forms.Label();
            this.dgC = new System.Windows.Forms.DataGridView();
            this.btnCSave = new System.Windows.Forms.Button();
            this.btnCAdd = new System.Windows.Forms.Button();
            this.checkCAct = new System.Windows.Forms.CheckBox();
            this.txtCDesc = new System.Windows.Forms.TextBox();
            this.lblCDesc = new System.Windows.Forms.Label();
            this.tabIncluye = new System.Windows.Forms.TabPage();
            this.txtIOrden = new System.Windows.Forms.TextBox();
            this.lblIOrden = new System.Windows.Forms.Label();
            this.dgI = new System.Windows.Forms.DataGridView();
            this.btnISave = new System.Windows.Forms.Button();
            this.btnIAdd = new System.Windows.Forms.Button();
            this.checkIActivo = new System.Windows.Forms.CheckBox();
            this.txtIDesc = new System.Windows.Forms.TextBox();
            this.lblIDesc = new System.Windows.Forms.Label();
            this.tabNoInc = new System.Windows.Forms.TabPage();
            this.txtNOrden = new System.Windows.Forms.TextBox();
            this.lblNOrden = new System.Windows.Forms.Label();
            this.dgN = new System.Windows.Forms.DataGridView();
            this.btnNISave = new System.Windows.Forms.Button();
            this.btnNIAdd = new System.Windows.Forms.Button();
            this.checkNIActivo = new System.Windows.Forms.CheckBox();
            this.txtNIDesc = new System.Windows.Forms.TextBox();
            this.lblNIDesc = new System.Windows.Forms.Label();
            this.tabCategoria.SuspendLayout();
            this.tabInf.SuspendLayout();
            this.tabCaracteristicas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgC)).BeginInit();
            this.tabIncluye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgI)).BeginInit();
            this.tabNoInc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgN)).BeginInit();
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
            // tabCategoria
            // 
            this.tabCategoria.Controls.Add(this.tabInf);
            this.tabCategoria.Controls.Add(this.tabCaracteristicas);
            this.tabCategoria.Controls.Add(this.tabIncluye);
            this.tabCategoria.Controls.Add(this.tabNoInc);
            resources.ApplyResources(this.tabCategoria, "tabCategoria");
            this.tabCategoria.Name = "tabCategoria";
            this.tabCategoria.SelectedIndex = 0;
            this.tabCategoria.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCategoria_Selected);
            // 
            // tabInf
            // 
            this.tabInf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabInf.Controls.Add(this.btnSave);
            this.tabInf.Controls.Add(this.checkActivo);
            this.tabInf.Controls.Add(this.txtCaDescripcion);
            this.tabInf.Controls.Add(this.lblCaDesc);
            this.tabInf.Controls.Add(this.txtCaIdent);
            this.tabInf.Controls.Add(this.lblCaIdent);
            resources.ApplyResources(this.tabInf, "tabInf");
            this.tabInf.Name = "tabInf";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkActivo
            // 
            resources.ApplyResources(this.checkActivo, "checkActivo");
            this.checkActivo.Name = "checkActivo";
            this.checkActivo.UseVisualStyleBackColor = true;
            // 
            // txtCaDescripcion
            // 
            this.txtCaDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtCaDescripcion, "txtCaDescripcion");
            this.txtCaDescripcion.Name = "txtCaDescripcion";
            // 
            // lblCaDesc
            // 
            resources.ApplyResources(this.lblCaDesc, "lblCaDesc");
            this.lblCaDesc.Name = "lblCaDesc";
            // 
            // txtCaIdent
            // 
            this.txtCaIdent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtCaIdent, "txtCaIdent");
            this.txtCaIdent.Name = "txtCaIdent";
            // 
            // lblCaIdent
            // 
            resources.ApplyResources(this.lblCaIdent, "lblCaIdent");
            this.lblCaIdent.Name = "lblCaIdent";
            // 
            // tabCaracteristicas
            // 
            this.tabCaracteristicas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabCaracteristicas.Controls.Add(this.txtCOrden);
            this.tabCaracteristicas.Controls.Add(this.lblCOrden);
            this.tabCaracteristicas.Controls.Add(this.dgC);
            this.tabCaracteristicas.Controls.Add(this.btnCSave);
            this.tabCaracteristicas.Controls.Add(this.btnCAdd);
            this.tabCaracteristicas.Controls.Add(this.checkCAct);
            this.tabCaracteristicas.Controls.Add(this.txtCDesc);
            this.tabCaracteristicas.Controls.Add(this.lblCDesc);
            resources.ApplyResources(this.tabCaracteristicas, "tabCaracteristicas");
            this.tabCaracteristicas.Name = "tabCaracteristicas";
            // 
            // txtCOrden
            // 
            this.txtCOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtCOrden, "txtCOrden");
            this.txtCOrden.Name = "txtCOrden";
            // 
            // lblCOrden
            // 
            resources.ApplyResources(this.lblCOrden, "lblCOrden");
            this.lblCOrden.Name = "lblCOrden";
            // 
            // dgC
            // 
            this.dgC.AllowUserToAddRows = false;
            this.dgC.AllowUserToDeleteRows = false;
            this.dgC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgC, "dgC");
            this.dgC.Name = "dgC";
            this.dgC.ReadOnly = true;
            this.dgC.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgC_CellContentDoubleClick);
            // 
            // btnCSave
            // 
            this.btnCSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnCSave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCSave, "btnCSave");
            this.btnCSave.Name = "btnCSave";
            this.btnCSave.UseVisualStyleBackColor = false;
            this.btnCSave.Click += new System.EventHandler(this.btnCSave_Click);
            // 
            // btnCAdd
            // 
            this.btnCAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnCAdd.BackgroundImage = global::SistemaENMECS.Properties.Resources.plus;
            resources.ApplyResources(this.btnCAdd, "btnCAdd");
            this.btnCAdd.FlatAppearance.BorderSize = 0;
            this.btnCAdd.Name = "btnCAdd";
            this.btnCAdd.UseVisualStyleBackColor = false;
            this.btnCAdd.Click += new System.EventHandler(this.btnCAdd_Click);
            // 
            // checkCAct
            // 
            resources.ApplyResources(this.checkCAct, "checkCAct");
            this.checkCAct.Name = "checkCAct";
            this.checkCAct.UseVisualStyleBackColor = true;
            // 
            // txtCDesc
            // 
            this.txtCDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtCDesc, "txtCDesc");
            this.txtCDesc.Name = "txtCDesc";
            // 
            // lblCDesc
            // 
            resources.ApplyResources(this.lblCDesc, "lblCDesc");
            this.lblCDesc.Name = "lblCDesc";
            // 
            // tabIncluye
            // 
            this.tabIncluye.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabIncluye.Controls.Add(this.txtIOrden);
            this.tabIncluye.Controls.Add(this.lblIOrden);
            this.tabIncluye.Controls.Add(this.dgI);
            this.tabIncluye.Controls.Add(this.btnISave);
            this.tabIncluye.Controls.Add(this.btnIAdd);
            this.tabIncluye.Controls.Add(this.checkIActivo);
            this.tabIncluye.Controls.Add(this.txtIDesc);
            this.tabIncluye.Controls.Add(this.lblIDesc);
            resources.ApplyResources(this.tabIncluye, "tabIncluye");
            this.tabIncluye.Name = "tabIncluye";
            // 
            // txtIOrden
            // 
            this.txtIOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtIOrden, "txtIOrden");
            this.txtIOrden.Name = "txtIOrden";
            // 
            // lblIOrden
            // 
            resources.ApplyResources(this.lblIOrden, "lblIOrden");
            this.lblIOrden.Name = "lblIOrden";
            // 
            // dgI
            // 
            this.dgI.AllowUserToAddRows = false;
            this.dgI.AllowUserToDeleteRows = false;
            this.dgI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgI, "dgI");
            this.dgI.Name = "dgI";
            this.dgI.ReadOnly = true;
            this.dgI.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgI_CellContentDoubleClick);
            // 
            // btnISave
            // 
            this.btnISave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnISave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnISave, "btnISave");
            this.btnISave.Name = "btnISave";
            this.btnISave.UseVisualStyleBackColor = false;
            this.btnISave.Click += new System.EventHandler(this.btnISave_Click);
            // 
            // btnIAdd
            // 
            this.btnIAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnIAdd.BackgroundImage = global::SistemaENMECS.Properties.Resources.plus;
            resources.ApplyResources(this.btnIAdd, "btnIAdd");
            this.btnIAdd.FlatAppearance.BorderSize = 0;
            this.btnIAdd.Name = "btnIAdd";
            this.btnIAdd.UseVisualStyleBackColor = false;
            this.btnIAdd.Click += new System.EventHandler(this.btnIAdd_Click);
            // 
            // checkIActivo
            // 
            resources.ApplyResources(this.checkIActivo, "checkIActivo");
            this.checkIActivo.Name = "checkIActivo";
            this.checkIActivo.UseVisualStyleBackColor = true;
            // 
            // txtIDesc
            // 
            this.txtIDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtIDesc, "txtIDesc");
            this.txtIDesc.Name = "txtIDesc";
            // 
            // lblIDesc
            // 
            resources.ApplyResources(this.lblIDesc, "lblIDesc");
            this.lblIDesc.Name = "lblIDesc";
            // 
            // tabNoInc
            // 
            this.tabNoInc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.tabNoInc.Controls.Add(this.txtNOrden);
            this.tabNoInc.Controls.Add(this.lblNOrden);
            this.tabNoInc.Controls.Add(this.dgN);
            this.tabNoInc.Controls.Add(this.btnNISave);
            this.tabNoInc.Controls.Add(this.btnNIAdd);
            this.tabNoInc.Controls.Add(this.checkNIActivo);
            this.tabNoInc.Controls.Add(this.txtNIDesc);
            this.tabNoInc.Controls.Add(this.lblNIDesc);
            resources.ApplyResources(this.tabNoInc, "tabNoInc");
            this.tabNoInc.Name = "tabNoInc";
            // 
            // txtNOrden
            // 
            this.txtNOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNOrden, "txtNOrden");
            this.txtNOrden.Name = "txtNOrden";
            // 
            // lblNOrden
            // 
            resources.ApplyResources(this.lblNOrden, "lblNOrden");
            this.lblNOrden.Name = "lblNOrden";
            // 
            // dgN
            // 
            this.dgN.AllowUserToAddRows = false;
            this.dgN.AllowUserToDeleteRows = false;
            this.dgN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgN, "dgN");
            this.dgN.Name = "dgN";
            this.dgN.ReadOnly = true;
            this.dgN.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgN_CellContentDoubleClick);
            // 
            // btnNISave
            // 
            this.btnNISave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnNISave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnNISave, "btnNISave");
            this.btnNISave.Name = "btnNISave";
            this.btnNISave.UseVisualStyleBackColor = false;
            this.btnNISave.Click += new System.EventHandler(this.btnNISave_Click);
            // 
            // btnNIAdd
            // 
            this.btnNIAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(226)))), ((int)(((byte)(101)))));
            this.btnNIAdd.BackgroundImage = global::SistemaENMECS.Properties.Resources.plus;
            resources.ApplyResources(this.btnNIAdd, "btnNIAdd");
            this.btnNIAdd.FlatAppearance.BorderSize = 0;
            this.btnNIAdd.Name = "btnNIAdd";
            this.btnNIAdd.UseVisualStyleBackColor = false;
            this.btnNIAdd.Click += new System.EventHandler(this.btnNIAdd_Click);
            // 
            // checkNIActivo
            // 
            resources.ApplyResources(this.checkNIActivo, "checkNIActivo");
            this.checkNIActivo.Name = "checkNIActivo";
            this.checkNIActivo.UseVisualStyleBackColor = true;
            // 
            // txtNIDesc
            // 
            this.txtNIDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(126)))), ((int)(((byte)(147)))));
            resources.ApplyResources(this.txtNIDesc, "txtNIDesc");
            this.txtNIDesc.Name = "txtNIDesc";
            // 
            // lblNIDesc
            // 
            resources.ApplyResources(this.lblNIDesc, "lblNIDesc");
            this.lblNIDesc.Name = "lblNIDesc";
            // 
            // Categoria
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(216)))));
            this.Controls.Add(this.tabCategoria);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(73)))), ((int)(((byte)(116)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Categoria";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Categoria_Load);
            this.tabCategoria.ResumeLayout(false);
            this.tabInf.ResumeLayout(false);
            this.tabInf.PerformLayout();
            this.tabCaracteristicas.ResumeLayout(false);
            this.tabCaracteristicas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgC)).EndInit();
            this.tabIncluye.ResumeLayout(false);
            this.tabIncluye.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgI)).EndInit();
            this.tabNoInc.ResumeLayout(false);
            this.tabNoInc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabCategoria;
        private System.Windows.Forms.TabPage tabInf;
        private System.Windows.Forms.TabPage tabCaracteristicas;
        private System.Windows.Forms.TabPage tabIncluye;
        private System.Windows.Forms.TabPage tabNoInc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkActivo;
        private System.Windows.Forms.TextBox txtCaDescripcion;
        private System.Windows.Forms.Label lblCaDesc;
        private System.Windows.Forms.TextBox txtCaIdent;
        private System.Windows.Forms.Label lblCaIdent;
        private System.Windows.Forms.Button btnCSave;
        private System.Windows.Forms.Button btnCAdd;
        private System.Windows.Forms.CheckBox checkCAct;
        private System.Windows.Forms.TextBox txtCDesc;
        private System.Windows.Forms.Label lblCDesc;
        private System.Windows.Forms.Button btnISave;
        private System.Windows.Forms.Button btnIAdd;
        private System.Windows.Forms.CheckBox checkIActivo;
        private System.Windows.Forms.TextBox txtIDesc;
        private System.Windows.Forms.Label lblIDesc;
        private System.Windows.Forms.Button btnNISave;
        private System.Windows.Forms.CheckBox checkNIActivo;
        private System.Windows.Forms.TextBox txtNIDesc;
        private System.Windows.Forms.Label lblNIDesc;
        private System.Windows.Forms.Button btnNIAdd;
        private System.Windows.Forms.DataGridView dgC;
        private System.Windows.Forms.DataGridView dgI;
        private System.Windows.Forms.DataGridView dgN;
        private System.Windows.Forms.TextBox txtCOrden;
        private System.Windows.Forms.Label lblCOrden;
        private System.Windows.Forms.TextBox txtIOrden;
        private System.Windows.Forms.Label lblIOrden;
        private System.Windows.Forms.TextBox txtNOrden;
        private System.Windows.Forms.Label lblNOrden;
    }
}