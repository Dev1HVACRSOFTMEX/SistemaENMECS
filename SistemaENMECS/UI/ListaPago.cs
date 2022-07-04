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
    public partial class ListaPago : Form
    {
        private _Pago pag = new _Pago();
        private DataTable dt = new DataTable();

        public ListaPago()
        {
            InitializeComponent();
            pag.listado();
        }

        private void ListaPago_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("Monto", typeof(string)));
            dt.Columns.Add(new DataColumn("Moneda", typeof(string)));
            dt.Columns.Add(new DataColumn("Observacion", typeof(string)));

            foreach (PAGO item in pag.listPag)
            {
                DataRow dr = dt.NewRow();
                dr["Cliente"] = item.DiNombreCl;
                dr["Monto"] = item.PgMontoReal.ToString();
                dr["Moneda"] = item.PgMoneda;
                dr["Observacion"] = item.PgObservacion;
                dt.Rows.Add(dr);
            }
            dgPago.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string DoIdent = "", DiNumero = "", PgTipo = "Ingreso";
            int PgNumero = 0;
            Pago ventana = new Pago(DoIdent, DiNumero, PgTipo, PgNumero, modo.insert);
            ventana.ShowDialog();
        }

        private void dgPago_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            int PgNumero = pag.listPag[idx].PgNumero;
            string DoIdent = "", DiNumero = "", PgTipo = "Ingreso";
            Pago ventana = new Pago(DoIdent, DiNumero, PgTipo, PgNumero, modo.update);
            ventana.ShowDialog();
        }
    }
}
