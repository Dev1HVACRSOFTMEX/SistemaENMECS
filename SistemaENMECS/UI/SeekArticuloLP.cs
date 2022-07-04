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
    public partial class SeekArticuloLP : Form
    {
        public _PrecioLista precioLista = new _PrecioLista();
        public _Articulo articulo = new _Articulo();
        private DataTable dt = new DataTable();
        private string[] clas00 = new string[] { "PRO", "SER", "ACC", "REF", "CON" };
        private string[] clas01 = new string[] { "Producto", "Servicio", "Accesorio", "Refacción", "Consumible" };

        public SeekArticuloLP()
        {
            InitializeComponent();

            precioLista.ArIdent = "";
            precioLista.DiNumero = "";
            precioLista.listado();
        }

        private void SeekArticuloLP_Load(object sender, EventArgs e)
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

            dt.Columns.Add(new DataColumn("Proveedor", typeof(string)));
            dt.Columns.Add(new DataColumn("Producto", typeof(string)));
            dt.Columns.Add(new DataColumn("Precio", typeof(string)));
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));

            foreach (PRECIOLISTA item in precioLista.listPrl)
            {
                DateTime fec = item.PlAudFeMod.Year == 1 ? item.PlAudFeCre : item.PlAudFeMod;

                DataRow dr = dt.NewRow();
                dr["Proveedor"] = item.DiNomCorto;
                dr["Producto"] = item.ArDescripcion;
                dr["Precio"] = item.PlPrecioLista.ToString();
                dr["Fecha"] = fec.Day.ToString().PadLeft(2, '0') + "/" + fec.Month.ToString().PadLeft(2, '0') + "/" + fec.Year.ToString();

                dt.Rows.Add(dr);
            }

            dgArt.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            precioLista.ArIdent = "";
            precioLista.DiNumero = "";
            precioLista.listado();

            dt.Rows.Clear();
            foreach (PRECIOLISTA item in precioLista.listPrl)
            {
                DateTime fec = item.PlAudFeMod.Year == 1 ? item.PlAudFeCre : item.PlAudFeMod;

                DataRow dr = dt.NewRow();
                dr["Proveedor"] = item.DiNomCorto;
                dr["Producto"] = item.ArDescripcion;
                dr["Precio"] = item.PlPrecioLista.ToString();
                dr["Fecha"] = fec.Day.ToString().PadLeft(2, '0') + "/" + fec.Month.ToString().PadLeft(2, '0') + "/" + fec.Year.ToString();

                dt.Rows.Add(dr);
            }

            dgArt.DataSource = dt;
        }

        private void dgArt_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            articulo.ArIdent = precioLista.listPrl[idx].ArIdent;
            articulo.ArDescripcion = "";
            articulo.ArClasificacion = "";
            articulo.ArCodigo = "";
            articulo.ArModeloCom = "";
            articulo.ArMarca = "";
            articulo.consultaUno();

            precioLista.ArIdent = precioLista.listPrl[idx].ArIdent;
            precioLista.DiNumero = precioLista.listPrl[idx].DiNumero;
            this.Close();
        }

        private void dgArt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            txtDesc.Text = precioLista.listPrl[idx].ArDescripcion;
        }
    }
}
