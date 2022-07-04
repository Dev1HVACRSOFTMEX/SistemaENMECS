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
    public partial class ListaCodigo : Form
    {
        private _Codigo catego = new _Codigo();
        private _Codigo grupo = new _Codigo();
        private _Codigo codigo = new _Codigo();
        private DataTable dt = new DataTable();
        private modo m;

        public ListaCodigo()
        {
            InitializeComponent();

            lblSubTit.Visible = false;
            lblCategoria.Visible = false;
            lblTipo.Visible = false;
            lblDesc.Visible = false;
            lblOrden.Visible = false;
            txtTipo.Visible = false;
            txtDesc.Visible = false;
            txtOrden.Visible = false;
            checkActivo.Visible = false;
            btnGuardar.Visible = false;

            txtTipo.Text = "";
            txtDesc.Text = "";
            txtOrden.Text = "0";
            checkActivo.CheckState = CheckState.Unchecked;

            catego.CdCategoria = "GRAL";
            catego.CdGrupo = "";
            catego.CdTipo = "";
            catego.listado();

            m = modo.none;
        }

        private void ListaCodigo_Load(object sender, EventArgs e)
        {
            try
            {
                dt.Columns.Add(new DataColumn("Tipo", typeof(string)));
                dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                dt.Columns.Add(new DataColumn("Estatus", typeof(string)));
                dgCodigo.DataSource = dt;

                int idx = 1;
                cbCategoria.Items.Clear();
                cbCategoria.Items.Insert(0, "<Seleccionar>");
                if (catego.listCod != null && catego.listCod.Count > 0)
                {
                    foreach (CODIGO item in catego.listCod)
                    {
                        cbCategoria.Items.Insert(idx, item.CdDescripcion.Trim());
                        idx++;
                    }
                }
                cbCategoria.SelectedIndex = 0;

                cbGrupo.Items.Clear();
                cbGrupo.Items.Insert(0, "<Seleccionar");
                cbGrupo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategoria.SelectedIndex > 0)
            {
                grupo.CdCategoria = catego.listCod[cbCategoria.SelectedIndex - 1].CdGrupo;
                grupo.CdGrupo = catego.listCod[cbCategoria.SelectedIndex - 1].CdTipo;
                grupo.CdTipo = "";
                grupo.listado();

                int idx = 1;
                cbGrupo.Items.Clear();
                cbGrupo.Items.Insert(0, "<Seleccionar");
                foreach (CODIGO item in grupo.listCod)
                {
                    cbGrupo.Items.Insert(idx, item.CdDescripcion.Trim());
                    idx++;
                }
                cbGrupo.SelectedIndex = 0;
            }
            else
            {
                txtTipo.Text = "";
                txtDesc.Text = "";
                txtOrden.Text = "0";
                checkActivo.CheckState = CheckState.Unchecked;

                txtTipo.ReadOnly = true;
                lblSubTit.Visible = false;
                lblCategoria.Visible = false;
                lblTipo.Visible = false;
                lblDesc.Visible = false;
                lblOrden.Visible = false;
                txtTipo.Visible = false;
                txtDesc.Visible = false;
                txtOrden.Visible = false;
                checkActivo.Visible = false;
                btnGuardar.Visible = false;
            }
        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGrupo.SelectedIndex > 0)
            {
                codigo.CdCategoria = grupo.listCod[cbGrupo.SelectedIndex - 1].CdGrupo;
                codigo.CdGrupo = grupo.listCod[cbGrupo.SelectedIndex - 1].CdTipo;
                codigo.CdTipo = "";
                codigo.listado();

                dt.Rows.Clear();
                foreach (CODIGO item in codigo.listCod)
                {
                    DataRow dr = dt.NewRow();
                    dr["Tipo"] = item.CdTipo;
                    dr["Descripcion"] = item.CdDescripcion;
                    dr["Estatus"] = item.CdActivo == "A" ? "Activo" : "Inactivo";

                    dt.Rows.Add(dr);
                }

                dgCodigo.DataSource = dt;
            }
            else
            {
                txtTipo.Text = "";
                txtDesc.Text = "";
                txtOrden.Text = "0";
                checkActivo.CheckState = CheckState.Unchecked;

                txtTipo.ReadOnly = true;
                lblSubTit.Visible = false;
                lblCategoria.Visible = false;
                lblTipo.Visible = false;
                lblDesc.Visible = false;
                lblOrden.Visible = false;
                txtTipo.Visible = false;
                txtDesc.Visible = false;
                txtOrden.Visible = false;
                checkActivo.Visible = false;
                btnGuardar.Visible = false;
            }
        }

        private void dgCodigo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            codigo.CdCategoria = codigo.listCod[idx].CdCategoria;
            codigo.CdGrupo = codigo.listCod[idx].CdGrupo;
            codigo.CdTipo = codigo.listCod[idx].CdTipo;
            codigo.consultaUno();

            txtTipo.Text = codigo.CdTipo.Trim();
            txtDesc.Text = codigo.CdDescripcion.Trim();
            txtOrden.Text = codigo.CdOrden.ToString().Trim();
            checkActivo.CheckState = codigo.CdActivo == "A" ? CheckState.Checked : CheckState.Unchecked;

            txtTipo.ReadOnly = true;
            lblSubTit.Visible = true;
            lblCategoria.Visible = true;
            lblTipo.Visible = true;
            lblDesc.Visible = true;
            lblOrden.Visible = false;
            txtTipo.Visible = true;
            txtDesc.Visible = true;
            txtOrden.Visible = false;
            checkActivo.Visible = true;
            btnGuardar.Visible = true;

            m = modo.update;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbCategoria.SelectedIndex == 0 || cbGrupo.SelectedIndex == 0)
            {
                txtTipo.Text = "";
                txtDesc.Text = "";
                txtOrden.Text = "0";
                checkActivo.CheckState = CheckState.Unchecked;

                txtTipo.ReadOnly = true;
                lblSubTit.Visible = false;
                lblCategoria.Visible = false;
                lblTipo.Visible = false;
                lblDesc.Visible = false;
                lblOrden.Visible = false;
                txtTipo.Visible = false;
                txtDesc.Visible = false;
                txtOrden.Visible = false;
                checkActivo.Visible = false;
                btnGuardar.Visible = false;
            }
            else
            {
                txtTipo.Text = "";
                txtDesc.Text = "";
                txtOrden.Text = "0";
                checkActivo.CheckState = CheckState.Unchecked;

                txtTipo.ReadOnly = false;
                lblSubTit.Visible = true;
                lblCategoria.Visible = true;
                lblTipo.Visible = true;
                lblDesc.Visible = true;
                lblOrden.Visible = false;
                txtTipo.Visible = true;
                txtDesc.Visible = true;
                txtOrden.Visible = true;
                checkActivo.Visible = true;
                btnGuardar.Visible = true;

                m = modo.insert;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            codigo.CdTipo = txtTipo.Text;
            codigo.CdDescripcion = txtDesc.Text;
            codigo.CdOrden = Convert.ToInt16(txtOrden.Text);
            codigo.CdActivo = checkActivo.Checked == true ? "A" : "I";

            if (modo.insert == m)
            {
                codigo.CdCategoria = catego.CdTipo;
                codigo.CdGrupo = grupo.CdTipo;
                codigo.guardar();
            } else if (modo.update == m)
                codigo.actualizar();

            lblSubTit.Visible = false;
            lblCategoria.Visible = false;
            lblTipo.Visible = false;
            lblDesc.Visible = false;
            lblOrden.Visible = false;
            txtTipo.Visible = false;
            txtDesc.Visible = false;
            txtOrden.Visible = false;
            checkActivo.Visible = false;
            btnGuardar.Visible = false;
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    catego.CdActivo = "A";
                    catego.actualizar();
                }
                else
                {
                    catego.eliminar();
                }
            }
        }
    }
}
