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
    public partial class ListaArticulo : Form
    {
        private _Articulo art = new _Articulo();
        private DataTable dt = new DataTable();
        private string[] clas00 = new string[] { "PRO", "SER", "ACC", "REF", "CON" };
        private string[] clas01 = new string[] { "Producto", "Servicio", "Accesorio", "Refacción", "Consumible" };

        public ListaArticulo()
        {
            InitializeComponent();

            art.ArIdent = "";
            art.ArDescripcion = "";
            art.ArClasificacion = "";
            art.ArCodigo = "";
            art.ArModeloCom = "";
            art.ArMarca = "";
            art.listado();
        }

        private void ListaArticulo_Load(object sender, EventArgs e)
        {
            int idx = 1;
            cbClasif.Items.Clear();
            cbClasif.Items.Insert(0, "<Selección>");
            foreach (string item in clas01)
            {
                cbClasif.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
                cbClasif.SelectedIndex = 0;

            dt.Columns.Add(new DataColumn("Codigo", typeof(string)));
            dt.Columns.Add(new DataColumn("Comercial", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Precio", typeof(string)));
            dt.Columns.Add(new DataColumn("Moneda", typeof(string)));
            dt.Columns.Add(new DataColumn("Estado", typeof(string)));

            foreach (ARTICULO item in art.listArt)
            {
                DataRow dr = dt.NewRow();
                dr["Codigo"] = item.ArCodigo;
                dr["Comercial"] = item.ArCodCom;
                dr["Descripcion"] = item.ArDescripcion;
                dr["Precio"] = item.ArPrecioPub;
                dr["Moneda"] = item.ArMoneda;
                dr["Estado"] = item.ArActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }

            dgArt.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string ArIdent = "";
            Articulo ventana = new Articulo(ArIdent, modo.insert);
            ventana.ShowDialog();
            art.ArIdent = "";
            art.ArDescripcion = txtNombre.Text.Trim();
            art.ArClasificacion = cbClasif.SelectedIndex < 1 ? "" : clas00[cbClasif.SelectedIndex - 1];
            art.ArCodigo = txtCodigo.Text.Trim();
            art.ArModeloCom = txtModelo.Text.Trim();
            art.ArMarca = txtMarca.Text.Trim();
            art.listado();
            dt.Rows.Clear();
            foreach (ARTICULO item in art.listArt)
            {
                DataRow dr = dt.NewRow();
                dr["Codigo"] = item.ArCodigo;
                dr["Comercial"] = item.ArCodCom;
                dr["Descripcion"] = item.ArDescripcion;
                dr["Precio"] = item.ArPrecioPub;
                dr["Moneda"] = item.ArMoneda;
                dr["Estado"] = item.ArActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }

            dgArt.DataSource = dt;
        }

        private void dgArt_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ArIdent = art.listArt[e.RowIndex].ArIdent;
            Articulo ventana = new Articulo(ArIdent, modo.update);
            ventana.ShowDialog();
            art.ArIdent = "";
            art.ArDescripcion = txtNombre.Text.Trim();
            art.ArClasificacion = cbClasif.SelectedIndex < 1 ? "" : clas00[cbClasif.SelectedIndex - 1];
            art.ArCodigo = txtCodigo.Text.Trim();
            art.ArModeloCom = txtModelo.Text.Trim();
            art.ArMarca = txtMarca.Text.Trim();
            art.listado();
            dt.Rows.Clear();
            foreach (ARTICULO item in art.listArt)
            {
                DataRow dr = dt.NewRow();
                dr["Codigo"] = item.ArCodigo;
                dr["Comercial"] = item.ArCodCom;
                dr["Descripcion"] = item.ArDescripcion;
                dr["Precio"] = item.ArPrecioPub;
                dr["Moneda"] = item.ArMoneda;
                dr["Estado"] = item.ArActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }

            dgArt.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            art.ArIdent = "";
            art.ArDescripcion = txtNombre.Text.Trim();
            art.ArClasificacion = cbClasif.SelectedIndex < 1 ? "" : clas00[cbClasif.SelectedIndex - 1];
            art.ArCodigo = txtCodigo.Text.Trim();
            art.ArModeloCom = txtModelo.Text.Trim();
            art.ArMarca = txtMarca.Text.Trim();
            art.listado();
        }
    }
}
