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
    public partial class Pago : Form
    {
        private _Pago pago = new _Pago();
        private _Directorio directorio = new _Directorio();
        private modo m;
        private string idDo;
        private string idNu;
        private string tipo;
        private int idPa;

        public Pago(string DoIdent, string DiNumero, string PgTipo, int PgNumero, modo mod)
        {
            InitializeComponent();

            idDo = DoIdent;
            idNu = DiNumero;
            tipo = PgTipo;
            idPa = PgNumero;
            m = mod;

            if (PgTipo == "Ingreso")
                directorio.DiTipo = "CLI";
            else
                directorio.DiTipo = "PRV";
            directorio.listado();

            if (modo.update == m)
            {
                pago.PgNumero = idPa;
                pago.consultaUno();
            }
        }

        private void Pago_Load(object sender, EventArgs e)
        {
            cbMoneda.Items.Clear();
            cbMoneda.Items.Insert(0, "<Selección>");
            cbMoneda.Items.Insert(1, "MXP");
            cbMoneda.Items.Insert(2, "USD");
            if (modo.insert == m)
                cbMoneda.SelectedIndex = 0;
            else
                cbMoneda.SelectedIndex = pago.PgMoneda == "MXP" ? 1 : (pago.PgMoneda == "USD" ? 2 : 0);

            cbTipo.Items.Clear();
            cbTipo.Items.Insert(0, "<Selección>");
            cbTipo.Items.Insert(1, "Ingreso");
            cbTipo.Items.Insert(2, "Egreso");
            cbTipo.SelectedIndex = tipo == "Ingreso" ? 1 : (tipo == "Egreso" ? 2 : 0);

            int idx = 0, i = 0;
            cbDir.Items.Clear();
            cbDir.Items.Insert(0, "<Selección>");
            foreach (DIRECTORIO item in directorio.listDir)
            {
                cbDir.Items.Insert(idx, item.DiNomCorto);
                if (idNu == item.DiNumero)
                    i = idx;
                idx++;
            }
            cbDir.SelectedIndex = i;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            pago.PgMontoPrg = Convert.ToDouble(txtMonto.Text.Trim());
            pago.PgMontoReal = Convert.ToDouble(txtMonto.Text.Trim());
            pago.PgMoneda = cbMoneda.SelectedText.Trim();
            pago.PgFechaPrg = DateTime.Now;
            pago.PgFechaReal = DateTime.Now;
            pago.PgObservacion = txtObservacion.Text.Trim();
            pago.DoIdent = idDo;
            if (tipo == "Ingreso")
            {
                pago.DiNumeroCl = idNu.Trim();
                pago.DiNumeroPv = "";
            }
            else if (tipo == "Egreso")
            {
                pago.DiNumeroCl = "";
                pago.DiNumeroPv = idNu.Trim();
            }
            else
            {
                pago.DiNumeroCl = "";
                pago.DiNumeroPv = "";
            }
            pago.PgTipo = tipo.Trim();
            pago.PgReferencia = txtRef.Text.Trim();
            pago.PgActivo = checkActivo.Checked ? "A" : "I";
            if (modo.insert == m)
                pago.guardar();
            else if (modo.update == m)
                pago.actualizar();
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    pago.PgActivo = checkActivo.Checked ? "A" : "I";
                    pago.actualizar();
                }
                else
                {
                    pago.eliminar();
                }
            }
        }
    }
}
