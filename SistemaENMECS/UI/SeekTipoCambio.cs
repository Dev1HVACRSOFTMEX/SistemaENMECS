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
    public partial class SeekTipoCambio : Form
    {
        public _TipoCambio tipoCambio = new _TipoCambio();
        private DataTable dt = new DataTable();

        public SeekTipoCambio()
        {
            InitializeComponent();

            DateTime mes = DateTime.Today.AddMonths(-1);

            txtFeIni.Text = mes.Day.ToString().PadLeft(2, '0') + "/" + mes.Month.ToString().PadLeft(2, '0') + "/" + mes.Year.ToString();
            txtFeFin.Text = DateTime.Today.AddDays(1).Day.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Year.ToString();

            tipoCambio.TcIdent = "";
            tipoCambio.FeIni = Convert.ToDateTime(txtFeIni.Text);
            tipoCambio.FeFin = Convert.ToDateTime(txtFeFin.Text);
            tipoCambio.listado();
        }

        private void SeekTipoCambio_Load(object sender, EventArgs e)
        {
            cbMoneda.Items.Clear();
            cbMoneda.Items.Insert(0, "<Selección>");
            cbMoneda.Items.Insert(1, "MXN");
            cbMoneda.Items.Insert(2, "USD");
            cbMoneda.SelectedIndex = 2;

            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            dt.Columns.Add(new DataColumn("Importe", typeof(string)));
            dt.Columns.Add(new DataColumn("Moneda", typeof(string)));

            foreach (TIPOCAMBIO item in tipoCambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N4").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;
        }

        private void txtFeIni_Leave(object sender, EventArgs e)
        {
            /*tipoCambio.TcIdent = "";
            tipoCambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipoCambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipoCambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipoCambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N2").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;*/
        }

        private void txtFeFin_Leave(object sender, EventArgs e)
        {
            /*tipoCambio.TcIdent = "";
            tipoCambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipoCambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipoCambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipoCambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N2").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;*/
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tipoCambio.TcIdent = "";
            tipoCambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipoCambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipoCambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipoCambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N4").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;
        }

        private void dgTipoCambio_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tipoCambio.TcIdent = tipoCambio.listTiC[idx].TcIdent;
            tipoCambio.FeIni = DateTime.Today;
            tipoCambio.FeFin = DateTime.Today;
            tipoCambio.consultaUno();
            this.Close();
        }
    }
}
