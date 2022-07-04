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
    public partial class ListaConcepto : Form
    {
        private _Concepto con = new _Concepto();
        private DataTable dt = new DataTable("concepto");

        public ListaConcepto()
        {
            InitializeComponent();

            con.CoNumero = 0;
            con.listado();
        }

        private void ListaConcepto_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Identificador", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach(CONCEPTO item in con.listCon)
            {
                DataRow dr = dt.NewRow();
                dr["Identificador"] = item.CoNumero;
                dr["Descripcion"] = item.CoDescripcion;
                dr["Estatus"] = item.CoActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgConcepto.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Concepto ventana = new Concepto(0, modo.insert);
            ventana.ShowDialog();

            con.CoNumero = 0;
            con.listado();
            dt.Rows.Clear();
            foreach (CONCEPTO item in con.listCon)
            {
                DataRow dr = dt.NewRow();
                dr["Identificador"] = item.CoNumero;
                dr["Descripcion"] = item.CoDescripcion;
                dr["Estatus"] = item.CoActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgConcepto.DataSource = dt;
        }

        private void dgConcepto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int CoNumero = con.listCon[e.RowIndex].CoNumero;
            Concepto ventana = new Concepto(CoNumero, modo.update);
            ventana.ShowDialog();

            con.CoNumero = 0;
            con.listado();
            dt.Rows.Clear();
            foreach (CONCEPTO item in con.listCon)
            {
                DataRow dr = dt.NewRow();
                dr["Identificador"] = item.CoNumero;
                dr["Descripcion"] = item.CoDescripcion;
                dr["Estatus"] = item.CoActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgConcepto.DataSource = dt;
        }
    }
}
