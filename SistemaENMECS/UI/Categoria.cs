using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaENMECS.BLL;

namespace SistemaENMECS.UI
{
    public partial class Categoria : Form
    {
        private _Categoria categoria = new _Categoria();
        private _CatNota catnotaC = new _CatNota();
        private _CatNota catnotaN = new _CatNota();
        private _CatNota catnotaI = new _CatNota();
        private _CatNota catnotaG = new _CatNota();
        private DataTable dtC = new DataTable();
        private DataTable dtI = new DataTable();
        private DataTable dtN = new DataTable();
        private CATNOTA itemC = new CATNOTA();
        private CATNOTA itemN = new CATNOTA();
        private CATNOTA itemI = new CATNOTA();
        private string catId = "";
        private modo m;
        int idx;

        public Categoria(string CaIdent)
        {
            InitializeComponent();

            catId = CaIdent;
            txtCaIdent.Enabled = false;

            categoria.CaIdent = catId;
            categoria.consultaUno();

            ///////////////CARACTERISTICAS///////////////
            lblCDesc.Visible = false;
            txtCDesc.Visible = false;
            checkCAct.Visible = false;
            lblCOrden.Visible = false;
            txtCOrden.Visible = false;
            btnCSave.Visible = false;

            catnotaC.CaIdent = catId;
            catnotaC.CtNumero = 0;
            catnotaC.CtTipo = "PCARA";
            catnotaC.NoIdent = "";
            catnotaC.listado();

            ///////////////NO INCLUYE///////////////
            lblNIDesc.Visible = false;
            txtNIDesc.Visible = false;
            checkNIActivo.Visible = false;
            lblNOrden.Visible = false;
            txtNOrden.Visible = false;
            btnNISave.Visible = false;

            catnotaN.CaIdent = catId;
            catnotaN.CtNumero = 0;
            catnotaN.CtTipo = "PNINC";
            catnotaN.NoIdent = "";
            catnotaN.listado();

            ///////////////INCLUYE///////////////
            lblIDesc.Visible = false;
            txtIDesc.Visible = false;
            checkIActivo.Visible = false;
            lblIOrden.Visible = false;
            txtIOrden.Visible = false;
            btnISave.Visible = false;

            catnotaI.CaIdent = catId;
            catnotaI.CtNumero = 0;
            catnotaI.CtTipo = "PINCL";
            catnotaI.NoIdent = "";
            catnotaI.listado();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            txtCaIdent.Text = categoria.CaIdent;
            checkActivo.CheckState = categoria.CaActivo == "A" ? CheckState.Checked : CheckState.Unchecked;
            txtCaDescripcion.Text = categoria.CaDescripcion;

            dtC.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dtC.Columns.Add(new DataColumn("Orden", typeof(string)));
            int i = -1;
            foreach (CATNOTA item in catnotaC.listCaN)
            {
                DataRow dr = dtC.NewRow();
                dr["Descripcion"] = item.CtDescripcion;
                dr["Orden"] = item.CtOrden.ToString();
                dtC.Rows.Add(dr);
            }
            dgC.DataSource = dtC;

            dtI.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dtI.Columns.Add(new DataColumn("Orden", typeof(string)));
            i = -1;
            foreach (CATNOTA item in catnotaI.listCaN)
            {
                DataRow dr = dtI.NewRow();
                dr["Descripcion"] = item.CtDescripcion;
                dr["Orden"] = item.CtOrden.ToString();
                dtI.Rows.Add(dr);
            }
            dgI.DataSource = dtI;

            dtN.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dtN.Columns.Add(new DataColumn("Orden", typeof(string)));
            i = -1;
            foreach (CATNOTA item in catnotaN.listCaN)
            {
                DataRow dr = dtN.NewRow();
                dr["Descripcion"] = item.CtDescripcion;
                dr["Orden"] = item.CtOrden.ToString();
                dtN.Rows.Add(dr);
            }
            dgN.DataSource = dtN;
        }

        private void tabCategoria_Selected(object sender, TabControlEventArgs e)
        {
            int tab = e.TabPageIndex;
            switch (tab)
            {
                case 0:
                    break;
                case 1:
                    lblCDesc.Visible = false;
                    txtCDesc.Visible = false;
                    checkCAct.Visible = false;
                    lblCOrden.Visible = false;
                    txtCOrden.Visible = false;
                    btnCSave.Visible = false;
                    break;
                case 2:
                    lblIDesc.Visible = false;
                    txtIDesc.Visible = false;
                    checkIActivo.Visible = false;
                    lblIOrden.Visible = false;
                    txtIOrden.Visible = false;
                    btnISave.Visible = false;
                    break;
                case 3:
                    lblNIDesc.Visible = false;
                    txtNIDesc.Visible = false;
                    checkNIActivo.Visible = false;
                    lblNOrden.Visible = false;
                    txtNOrden.Visible = false;
                    btnNISave.Visible = false;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            categoria.CaDescripcion = txtCaDescripcion.Text.Trim();
            categoria.CaActivo = checkActivo.CheckState == CheckState.Checked ? "A" : "I";
            categoria.guardar();
        }

        private void btnCAdd_Click(object sender, EventArgs e)
        {
            lblCDesc.Visible = true;
            txtCDesc.Visible = true;
            checkCAct.Visible = true;
            lblCOrden.Visible = true;
            txtCOrden.Visible = true;
            btnCSave.Visible = true;

            txtCDesc.Text = "";
            checkCAct.CheckState = CheckState.Checked;
            txtCOrden.Text = "0";

            m = modo.insert;
        }
        
        private void dgC_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            lblCDesc.Visible = true;
            txtCDesc.Visible = true;
            checkCAct.Visible = true;
            lblCOrden.Visible = true;
            txtCOrden.Visible = true;
            btnCSave.Visible = true;

            txtCDesc.Text = catnotaC.listCaN[idx].CtDescripcion;
            checkCAct.CheckState = catnotaC.listCaN[idx].CtActivo == "A" ? CheckState.Checked : CheckState.Unchecked;
            txtCOrden.Text = "0";

            m = modo.update;
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            if (m == modo.update)
            {
                catnotaG.CaIdent = catnotaC.listCaN[idx].CaIdent;
                catnotaG.CtNumero = catnotaC.listCaN[idx].CtNumero;
                catnotaG.CtDescripcion = txtCDesc.Text;
                catnotaG.CtTipo = catnotaC.listCaN[idx].CtTipo;
                catnotaG.CtOrden = Convert.ToInt16(txtCOrden.Text);
                catnotaG.NoIdent = catnotaC.listCaN[idx].NoIdent;
                catnotaG.CtActivo = checkCAct.CheckState == CheckState.Checked ? "A" : "I";
                catnotaG.actualizar();

                lblCDesc.Visible = false;
                txtCDesc.Visible = false;
                checkCAct.Visible = false;
                lblCOrden.Visible = false;
                txtCOrden.Visible = false;
                btnCSave.Visible = false;

                catnotaC.CaIdent = catId;
                catnotaC.CtNumero = 0;
                catnotaC.CtTipo = "PCARA";
                catnotaC.NoIdent = "";
                catnotaC.listado();
            }
            else if (m == modo.insert)
            {
                catnotaG.CaIdent = catId;
                catnotaG.CtNumero = catnotaC.listCaN.Count + catnotaI.listCaN.Count + catnotaN.listCaN.Count + 1;
                catnotaG.CtDescripcion = txtCDesc.Text;
                catnotaG.CtTipo = "PCARA";
                catnotaG.CtOrden = Convert.ToInt16(txtCOrden.Text == "" ? "0" : txtCOrden.Text);
                catnotaG.NoIdent = "";
                catnotaG.CtActivo = checkCAct.CheckState == CheckState.Checked ? "A" : "I";
                catnotaG.guardar();

                lblCDesc.Visible = false;
                txtCDesc.Visible = false;
                checkCAct.Visible = false;
                lblCOrden.Visible = false;
                txtCOrden.Visible = false;
                btnCSave.Visible = false;

                catnotaC.CaIdent = catId;
                catnotaC.CtNumero = 0;
                catnotaC.CtTipo = "PCARA";
                catnotaC.NoIdent = "";
                catnotaC.listado();
            }

            dtC.Rows.Clear();
            foreach (CATNOTA item in catnotaC.listCaN)
            {
                DataRow dr = dtC.NewRow();
                dr["Descripcion"] = item.CtDescripcion;
                dr["Orden"] = item.CtOrden.ToString();
                dtC.Rows.Add(dr);
            }
            dgC.DataSource = dtC;
        }

        private void btnIAdd_Click(object sender, EventArgs e)
        {
            lblIDesc.Visible = true;
            txtIDesc.Visible = true;
            checkIActivo.Visible = true;
            lblIOrden.Visible = true;
            txtIOrden.Visible = true;
            btnISave.Visible = true;

            txtIDesc.Text = "";
            checkIActivo.CheckState = CheckState.Checked;
            txtIOrden.Text = "0";

            m = modo.insert;
        }

        private void dgI_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            lblIDesc.Visible = true;
            txtIDesc.Visible = true;
            checkIActivo.Visible = true;
            lblIOrden.Visible = true;
            txtIOrden.Visible = true;
            btnISave.Visible = true;

            txtIDesc.Text = catnotaI.listCaN[idx].CtDescripcion;
            checkIActivo.CheckState = catnotaI.listCaN[idx].CtActivo == "A" ? CheckState.Checked : CheckState.Unchecked;
            txtIOrden.Text = catnotaI.listCaN[idx].CtOrden.ToString();

            m = modo.update;
        }

        private void btnISave_Click(object sender, EventArgs e)
        {
            if (m == modo.update)
            {
                catnotaG.CaIdent = catnotaI.listCaN[idx].CaIdent;
                catnotaG.CtNumero = catnotaI.listCaN[idx].CtNumero;
                catnotaG.CtDescripcion = txtIDesc.Text;
                catnotaG.CtTipo = catnotaI.listCaN[idx].CtTipo;
                catnotaG.CtOrden = Convert.ToInt16(txtIOrden.Text);
                catnotaG.NoIdent = catnotaI.listCaN[idx].NoIdent;
                catnotaG.CtActivo = checkIActivo.CheckState == CheckState.Checked ? "A" : "I";
                catnotaG.actualizar();

                lblIDesc.Visible = false;
                txtIDesc.Visible = false;
                checkIActivo.Visible = false;
                lblIOrden.Visible = false;
                txtIOrden.Visible = false;
                btnISave.Visible = false;

                catnotaI.CaIdent = catId;
                catnotaI.CtNumero = 0;
                catnotaI.CtTipo = "PINCL";
                catnotaI.NoIdent = "";
                catnotaI.listado();
            }
            else if (m == modo.insert)
            {
                catnotaG.CaIdent = catId;
                catnotaG.CtNumero = catnotaC.listCaN.Count + catnotaI.listCaN.Count + catnotaN.listCaN.Count + 1;
                catnotaG.CtDescripcion = txtIDesc.Text;
                catnotaG.CtTipo = "PINCL";
                catnotaG.CtOrden = Convert.ToInt16(txtIOrden.Text == "" ? "0" : txtIOrden.Text);
                catnotaG.NoIdent = "";
                catnotaG.CtActivo = checkIActivo.CheckState == CheckState.Checked ? "A" : "I";
                catnotaG.guardar();

                lblIDesc.Visible = false;
                txtIDesc.Visible = false;
                checkIActivo.Visible = false;
                lblIOrden.Visible = false;
                txtIOrden.Visible = false;
                btnISave.Visible = false;

                catnotaI.CaIdent = catId;
                catnotaI.CtNumero = 0;
                catnotaI.CtTipo = "PINCL";
                catnotaI.NoIdent = "";
                catnotaI.listado();
            }

            dtI.Rows.Clear();
            foreach (CATNOTA item in catnotaI.listCaN)
            {
                DataRow dr = dtI.NewRow();
                dr["Descripcion"] = item.CtDescripcion;
                dr["Orden"] = item.CtOrden.ToString();
                dtI.Rows.Add(dr);
            }
            dgI.DataSource = dtI;
        }

        private void btnNIAdd_Click(object sender, EventArgs e)
        {
            lblNIDesc.Visible = true;
            txtNIDesc.Visible = true;
            checkNIActivo.Visible = true;
            lblNOrden.Visible = true;
            txtNOrden.Visible = true;
            btnNISave.Visible = true;

            txtNIDesc.Text = "";
            checkNIActivo.CheckState = CheckState.Checked;
            txtNOrden.Text = "0";

            m = modo.insert;
        }

        private void dgN_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            lblNIDesc.Visible = true;
            txtNIDesc.Visible = true;
            checkNIActivo.Visible = true;
            lblNOrden.Visible = true;
            txtNOrden.Visible = true;
            btnNISave.Visible = true;

            txtNIDesc.Text = catnotaI.listCaN[idx].CtDescripcion;
            checkNIActivo.CheckState = catnotaI.listCaN[idx].CtActivo == "A" ? CheckState.Checked : CheckState.Unchecked;
            txtNOrden.Text = "0";

            m = modo.update;
        }

        private void btnNISave_Click(object sender, EventArgs e)
        {
            if (m == modo.update)
            {
                catnotaG.CaIdent = catnotaN.listCaN[idx].CaIdent;
                catnotaG.CtNumero = catnotaN.listCaN[idx].CtNumero;
                catnotaG.CtDescripcion = txtNIDesc.Text;
                catnotaG.CtTipo = catnotaN.listCaN[idx].CtTipo;
                catnotaG.CtOrden = Convert.ToInt16(txtNOrden.Text);
                catnotaG.NoIdent = catnotaN.listCaN[idx].NoIdent;
                catnotaG.CtActivo = checkNIActivo.CheckState == CheckState.Checked ? "A" : "I";
                catnotaG.actualizar();

                lblNIDesc.Visible = false;
                txtNIDesc.Visible = false;
                checkNIActivo.Visible = false;
                lblNOrden.Visible = false;
                txtNOrden.Visible = false;
                btnNISave.Visible = false;

                catnotaN.CaIdent = catId;
                catnotaN.CtNumero = 0;
                catnotaN.CtTipo = "PNINC";
                catnotaN.NoIdent = "";
                catnotaN.listado();
            }
            else if (m == modo.insert)
            {
                catnotaG.CaIdent = catId;
                catnotaG.CtNumero = catnotaC.listCaN.Count + catnotaI.listCaN.Count + catnotaN.listCaN.Count + 1;
                catnotaG.CtDescripcion = txtNIDesc.Text;
                catnotaG.CtTipo = "PNINC";
                catnotaG.CtOrden = Convert.ToInt16(txtNOrden.Text == "" ? "0" : txtNOrden.Text);
                catnotaG.NoIdent = "";
                catnotaG.CtActivo = checkNIActivo.CheckState == CheckState.Checked ? "A" : "I";
                catnotaG.guardar();

                lblNIDesc.Visible = false;
                txtNIDesc.Visible = false;
                checkNIActivo.Visible = false;
                lblNOrden.Visible = false;
                txtNOrden.Visible = false;
                btnNISave.Visible = false;

                catnotaN.CaIdent = catId;
                catnotaN.CtNumero = 0;
                catnotaN.CtTipo = "PNINC";
                catnotaN.NoIdent = "";
                catnotaN.listado();
            }

            dtN.Rows.Clear();
            foreach (CATNOTA item in catnotaN.listCaN)
            {
                DataRow dr = dtN.NewRow();
                dr["Descripcion"] = item.CtDescripcion;
                dr["Orden"] = item.CtOrden.ToString();
                dtN.Rows.Add(dr);
            }
            dgN.DataSource = dtN;
        }
    }
}
