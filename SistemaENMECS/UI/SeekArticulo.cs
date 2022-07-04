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
    public partial class SeekArticulo : Form
    {
        public _Articulo articulo = new _Articulo();
        private DataTable dt = new DataTable();
        private string[] clas00 = new string[] { "PRO", "SER", "ACC", "REF", "CON" };
        private string[] clas01 = new string[] { "Producto", "Servicio", "Accesorio", "Refacción", "Consumible" };

        public SeekArticulo()
        {
            InitializeComponent();

            articulo.ArIdent = "";
            articulo.ArDescripcion = "";
            articulo.ArClasificacion = "";
            articulo.ArCodigo = "";
            articulo.ArModeloCom = "";
            articulo.ArMarca = "";
            articulo.listado();
        }

        private void SeekArticulo_Load(object sender, EventArgs e)
        {
            int idx = 1;
            cbClasif.Items.Clear();
            cbClasif.Items.Insert(0, "<Todos>");
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

            foreach (ARTICULO item in articulo.listArt)
            {
                DataRow dr = dt.NewRow();
                dr["Codigo"] = item.ArCodigo;
                dr["Comercial"] = item.ArCodCom;
                dr["Descripcion"] = item.ArDescripcion;

                dt.Rows.Add(dr);
            }

            dgArt.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            articulo.ArIdent = "";
            articulo.ArDescripcion = txtNombre.Text.Trim();
            articulo.ArClasificacion = cbClasif.SelectedIndex < 1 ? "" : clas00[cbClasif.SelectedIndex - 1];
            articulo.ArCodigo = "";
            articulo.ArModeloCom = "";
            articulo.ArMarca = "";
            articulo.listado();

            dt.Rows.Clear();
            foreach (ARTICULO item in articulo.listArt)
            {
                DataRow dr = dt.NewRow();
                dr["Codigo"] = item.ArCodigo;
                dr["Comercial"] = item.ArCodCom;
                dr["Descripcion"] = item.ArDescripcion;

                dt.Rows.Add(dr);
            }

            dgArt.DataSource = dt;
        }

        private void dgArt_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            articulo.ArIdent = articulo.listArt[idx].ArIdent;
            articulo.ArDescripcion = "";
            articulo.ArClasificacion = "";
            articulo.ArCodigo = "";
            articulo.ArModeloCom = "";
            articulo.ArMarca = "";
            articulo.consultaUno();
            this.Close();
        }

        private void dgArt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            txtDesc.Text = articulo.listArt[idx].ArDescripcion;
        }
    }
}
