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
    public partial class TipoCambio : Form
    {
        _TipoCambio tipocambio = new _TipoCambio();
        private DataTable dt = new DataTable("tipoCambio");
        string TcIdent = "";
        modo m;

        public TipoCambio()
        {
            InitializeComponent();

            m = modo.insert;
            txtFecha.Text = DateTime.Today.Date.ToString().Substring(0, 10);

            DateTime mes = DateTime.Today.AddMonths(-1);
            txtFeIni.Text = mes.Day.ToString().PadLeft(2, '0') + "/" + mes.Month.ToString().PadLeft(2, '0') + "/" + mes.Year.ToString();
            txtFeFin.Text = DateTime.Today.AddDays(1).Day.ToString().PadLeft(2, '0') + "/" + DateTime.Today.AddDays(1).Month.ToString().PadLeft(2, '0') + "/" + DateTime.Today.AddDays(1).Year.ToString();

            //txtFeIni.Text = Convert.ToDateTime("01/"+DateTime.Today);
            //txtFeFin.Text = DateTime.Today.Date.ToString().Substring(0, 10);

            tipocambio.TcIdent = "";
            tipocambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipocambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipocambio.listado();
        }

        private void TipoCambio_Load(object sender, EventArgs e)
        {
            cbMoneda.Items.Clear();
            cbMoneda.Items.Insert(0, "<Selección>");
            cbMoneda.Items.Insert(1, "MXN");
            cbMoneda.Items.Insert(2, "USD");
            cbMoneda.SelectedIndex = 2;

            ////////////////////////////////////////////////////////////
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            dt.Columns.Add(new DataColumn("Importe", typeof(string)));
            dt.Columns.Add(new DataColumn("Moneda", typeof(string)));

            foreach (TIPOCAMBIO item in tipocambio.listTiC)
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
            int i = e.RowIndex;
            TcIdent = tipocambio.listTiC[i].TcIdent.Trim();
            txtFecha.Text = tipocambio.listTiC[i].TcFecha.ToString().Substring(0, 10);
            txtImporte.Text = tipocambio.listTiC[i].TcImporte.ToString().Trim();
            string mon = tipocambio.listTiC[i].TcMonedaOri.Trim();
            cbMoneda.SelectedIndex = mon == "MXN" ? 1 : (mon == "USD" ? 2 : 0);
            m = modo.update;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (m == modo.insert)
            {
                string fecha = txtFecha.Text.Trim();
                DateTime fe = Convert.ToDateTime(fecha);
                if (fe.Day == DateTime.Today.Day && fe.Month == DateTime.Today.Month && fe.Year == DateTime.Today.Year)
                    fe = fe;
                else
                    fe = Convert.ToDateTime(txtFecha.Text.Trim() + " 00:00:00");
                tipocambio = new _TipoCambio();
                tipocambio.TcMonedaOri = cbMoneda.SelectedIndex == 1 ? "MXN" : (cbMoneda.SelectedIndex == 2 ? "USD" : "");
                tipocambio.TcIdent = fe.Year.ToString().Trim() + fe.Month.ToString().PadLeft(2, '0') + fe.Day.ToString().PadLeft(2, '0');// + tipocambio.TcMonedaOri.Trim();
                tipocambio.TcFecha = fe;
                tipocambio.TcImporte = txtImporte.Text == "" ? 0 : Convert.ToDouble(txtImporte.Text.Trim());
                

                string res = tipocambio.guardar();

                if (res != "")
                    MessageBox.Show(res.Trim());

                tipocambio.consultaUno();
            }
            else if (m == modo.update)
            {
                tipocambio.TcIdent = TcIdent;
                tipocambio.TcFecha = Convert.ToDateTime(txtFecha.Text.Trim());
                tipocambio.TcImporte = Convert.ToDouble(txtImporte.Text.Trim());
                tipocambio.TcMonedaOri = cbMoneda.SelectedIndex == 1 ? "MXN" : (cbMoneda.SelectedIndex == 2 ? "USD" : "");

                tipocambio.actualizar();

                tipocambio.consultaUno();
            }
            m = modo.insert;
            txtFecha.Text = DateTime.Today.Date.ToString().Substring(0, 10);
            txtImporte.Text = "";
            cbMoneda.SelectedIndex = 2;

            tipocambio.TcIdent = "";
            tipocambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipocambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipocambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipocambio.listTiC)
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
            //CalIni.Visible = false;

            /*tipocambio.TcIdent = "";
            tipocambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipocambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipocambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipocambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N4").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;*/
        }

        private void txtFeFin_Leave(object sender, EventArgs e)
        {
            //CalFin.Visible = false;

            /*tipocambio.TcIdent = "";
            tipocambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipocambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipocambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipocambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N4").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;*/
        }

        private void txtFeIni_Click(object sender, EventArgs e)
        {
            CalIni.SetDate(Convert.ToDateTime(txtFeIni.Text));

            CalFin.Visible = false;
            CalDia.Visible = false;
            CalIni.Visible = CalIni.Visible ? false : true;
        }

        private void txtFeFin_Click(object sender, EventArgs e)
        {
            CalFin.SetDate(Convert.ToDateTime(txtFeFin.Text));

            CalIni.Visible = false;
            CalDia.Visible = false;
            CalFin.Visible = CalFin.Visible ? false : true;
        }

        private void txtFecha_Click(object sender, EventArgs e)
        {
            CalDia.SetDate(Convert.ToDateTime(txtFecha.Text));

            CalIni.Visible = false;
            CalFin.Visible = false;
            CalDia.Visible = CalDia.Visible ? false : true;
        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {
            //CalDia.Visible = false;
        }

        private void CalIni_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFeIni.Text = CalIni.SelectionRange.Start.ToShortDateString();

            CalIni.Visible = false;

            tipocambio.TcIdent = "";
            tipocambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipocambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipocambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipocambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N4").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;
        }

        private void CalFin_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFeFin.Text = CalFin.SelectionRange.Start.ToShortDateString();

            CalFin.Visible = false;

            tipocambio.TcIdent = "";
            tipocambio.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            tipocambio.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            tipocambio.listado();
            dt.Rows.Clear();
            foreach (TIPOCAMBIO item in tipocambio.listTiC)
            {
                DataRow dr = dt.NewRow();
                dr["Fecha"] = item.TcFecha.ToString().Substring(0, 10);
                dr["Importe"] = item.TcImporte.ToString("N4").Trim();
                dr["Moneda"] = item.TcMonedaOri.Trim();
                dt.Rows.Add(dr);
            }
            dgTipoCambio.DataSource = dt;
        }

        private void CalDia_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFecha.Text = CalDia.SelectionRange.Start.ToShortDateString();

            CalDia.Visible = false;
        }

        private void TipoCambio_Click(object sender, EventArgs e)
        {
            CalIni.Visible = false;
            CalFin.Visible = false;
            CalDia.Visible = false;
        }
    }
}
