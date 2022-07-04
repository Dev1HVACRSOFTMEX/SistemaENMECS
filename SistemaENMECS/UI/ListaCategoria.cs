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
    public partial class ListaCategoria : Form
    {
        private _Categoria cat = new _Categoria();
        private _Categoria catego = new _Categoria();
        private DataTable dt = new DataTable();
        private modo m;

        public ListaCategoria()
        {
            InitializeComponent();

            cat.CaIdent = "";
            cat.listado();
            gbCat.Visible = false;
        }

        private void ListaCategoria_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Ident", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach (CATEGORIA item in cat.listCat)
            {
                DataRow dr = dt.NewRow();
                dr["Ident"] = item.CaIdent;
                dr["Descripcion"] = item.CaDescripcion;
                dr["Estatus"] = item.CaActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }

            dgCat.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            catego = new _Categoria();
            txtIdent.Text = "";
            txtDesc.Text = "";
            checkActivo.Checked = false;
            gbCat.Visible = true;
            m = modo.insert;
        }

        private void dgCat_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            string CaIdent = cat.listCat[idx].CaIdent;
            Categoria ventana = new Categoria(CaIdent);
            ventana.ShowDialog();
            /*int idx = e.RowIndex;
            catego.CaIdent = cat.listCat[idx].CaIdent;
            catego.consultaUno();
            txtIdent.Text = catego.CaIdent.Trim();
            txtDesc.Text = catego.CaDescripcion.Trim();
            checkActivo.Checked = catego.CaActivo == "A" ? true : false;
            gbCat.Visible = true;
            m = modo.update;*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            catego.CaDescripcion = txtDesc.Text.Trim();
            catego.CaActivo = checkActivo.Checked ? "A" : "I";

            if (modo.insert == m)
            {
                catego.CaIdent = txtIdent.Text.Trim();
                catego.guardar();
            }
            if (modo.update == m)
                catego.actualizar();
            gbCat.Visible = false;

            cat.CaIdent = "";
            dt.Clear();
            cat.listado();
            foreach (CATEGORIA item in cat.listCat)
            {
                DataRow dr = dt.NewRow();
                dr["Ident"] = item.CaIdent;
                dr["Descripcion"] = item.CaDescripcion;
                dr["Estatus"] = item.CaActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }

            dgCat.DataSource = dt;
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    catego.CaActivo = "A";
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
