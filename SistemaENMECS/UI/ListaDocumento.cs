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
    public partial class ListaDocumento : Form
    {
        private _Directorio directorio = new _Directorio();
        private _Empresa empresa = new _Empresa();
        private _Documento documento = new _Documento();
        private DataTable dt = new DataTable("documento");
        private string[] est00 = new string[] { "CRE", "ENV", "SEG", "ACP", "CAN" };
        private string[] est01 = new string[] { "Creación", "Enviado", "Seguimiento", "Aceptada", "Cancelada" };
        private string tipo;

        public ListaDocumento(string DoTipo)
        {
            InitializeComponent();

            tipo = DoTipo;
            documento.DoIdent = "";
            documento.DoTipo = tipo;
            documento.DiNumero = "";
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = DateTime.Now.AddYears(-2);
            documento.FeFin = DateTime.Now;
            documento.DoUsuSeg = usuarioCache.nombreUsuario;
            documento.DoVendedor = "";
            documento.listado();

            empresa.EmIdent = "";
            empresa.listado();

            txtFeIni.Text = documento.FeIni.ToString().Substring(0, 10);
            txtFeFin.Text = documento.FeFin.ToString().Substring(0, 10);
        }

        private void ListaDocumento_Load(object sender, EventArgs e)
        {
            cbEmpresa.Items.Clear();
            cbEmpresa.Items.Insert(0, "<Selección>");
            int idx = 1;
            foreach(EMPRESA item in empresa.listEmp)
            {
                cbEmpresa.Items.Insert(idx, item.DiNomCorto.Trim());
                idx++;
            }
            cbEmpresa.SelectedIndex = 0;

            cbEstatus.Items.Clear();
            cbEstatus.Items.Insert(0, "<Selección>");
            idx = 1;
            foreach(string item in est01)
            {
                cbEstatus.Items.Insert(idx, item.Trim());
                idx++;
            }
            cbEstatus.SelectedIndex = 0;

            dt.Columns.Add(new DataColumn("Folio", typeof(string)));
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            dt.Columns.Add(new DataColumn("Empresa", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach (DOCUMENTO item in documento.listDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Folio"] = item.DoFolio;
                dr["Fecha"] = item.DoFecha;
                dr["Empresa"] = item.EmIdent;
                dr["Cliente"] = item.DiNumero;
                dr["Estatus"] = item.DoEstatus;
                dt.Rows.Add(dr);
            }

            dgDocumento.DataSource = dt;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            documento.DoIdent = "";
            documento.DoTipo = tipo;
            documento.DiNumero = txtCliente.Text.Trim() == "" ? "" : directorio.DiNumero;
            documento.EmIdent = cbEmpresa.SelectedIndex == 0 ? "" : empresa.listEmp[cbEmpresa.SelectedIndex - 1].EmIdent;
            documento.DoEstatus = cbEstatus.SelectedIndex == 0 ? "" : est00[cbEstatus.SelectedIndex - 1];
            documento.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            documento.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            documento.FeFin = documento.FeFin.AddDays(1);
            documento.DoUsuSeg = usuarioCache.nombreUsuario;
            documento.DoVendedor = "";
            documento.listado();

            dt.Rows.Clear();
            foreach (DOCUMENTO item in documento.listDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Folio"] = item.DoFolio;
                dr["Fecha"] = item.DoFecha;
                dr["Empresa"] = item.EmIdent;
                dr["Cliente"] = item.DiNumero;
                dr["Estatus"] = item.DoEstatus;
                dt.Rows.Add(dr);
            }

            dgDocumento.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string DoIdent = "";
            DocCotizacion ventana = new DocCotizacion(DoIdent, tipo, modo.insert);
            ventana.ShowDialog();

            documento.DoIdent = "";
            documento.DoTipo = tipo;
            documento.DiNumero = "";
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            documento.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            documento.FeFin = documento.FeFin.AddDays(1);
            documento.DoUsuSeg = usuarioCache.nombreUsuario;
            documento.DoVendedor = "";
            documento.listado();

            dt.Rows.Clear();
            foreach (DOCUMENTO item in documento.listDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Folio"] = item.DoFolio;
                dr["Fecha"] = item.DoFecha;
                dr["Empresa"] = item.EmIdent;
                dr["Cliente"] = item.DiNumero;
                dr["Estatus"] = item.DoEstatus;
                dt.Rows.Add(dr);
            }

            dgDocumento.DataSource = dt;
        }

        private void dgDocumento_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string DoIdent = documento.listDoc[e.RowIndex].DoIdent;
            DocCotCuerpo ventana = new DocCotCuerpo(DoIdent, modo.update);
            ventana.ShowDialog();

            documento.DoIdent = "";
            documento.DoTipo = tipo;
            documento.DiNumero = "";
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = Convert.ToDateTime(txtFeIni.Text.Trim());
            documento.FeFin = Convert.ToDateTime(txtFeFin.Text.Trim());
            documento.FeFin = documento.FeFin.AddDays(1);
            documento.DoUsuSeg = usuarioCache.nombreUsuario;
            documento.DoVendedor = "";
            documento.listado();

            dt.Rows.Clear();
            foreach (DOCUMENTO item in documento.listDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Folio"] = item.DoFolio;
                dr["Fecha"] = item.DoFecha;
                dr["Empresa"] = item.EmIdent;
                dr["Cliente"] = item.DiNumero;
                dr["Estatus"] = item.DoEstatus;
                dt.Rows.Add(dr);
            }

            dgDocumento.DataSource = dt;
        }
    }
}
