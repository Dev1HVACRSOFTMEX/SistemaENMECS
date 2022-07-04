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
    public partial class SeekDocumento : Form
    {
        public _Documento documento = new _Documento();
        private DataTable dt = new DataTable();
        private string tipo = "";

        public SeekDocumento(string DoTipo)
        {
            InitializeComponent();

            tipo = DoTipo;
            documento.DoIdent = "";
            documento.DoTipo = tipo;
            documento.DiNumero = "";
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = Convert.ToDateTime("2020-01-01");
            documento.FeFin = DateTime.Now;
            documento.DoUsuSeg = usuarioCache.nombreUsuario;
            documento.DoVendedor = "";
            documento.listado();
        }

        private void SeekDocumento_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Folio", typeof(string)));
            dt.Columns.Add(new DataColumn("Proyecto", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));

            foreach (DOCUMENTO item in documento.listDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Folio"] = item.DoFolio;
                dr["Proyecto"] = item.PyNombre;
                dr["Cliente"] = item.DiNomCorto;

                dt.Rows.Add(dr);
            }

            dgDoc.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            documento.DoIdent = "";
            documento.DoFolio = txtFolio.Text.Trim();
            documento.DoTipo = tipo;
            documento.DiNumero = "";
            documento.DiNomCorto = txtCliente.Text.Trim();
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = Convert.ToDateTime("2020-01-01");
            documento.FeFin = DateTime.Now;
            documento.PyNombre = txtProyecto.Text.Trim();
            documento.DoUsuSeg = usuarioCache.nombreUsuario;
            documento.DoVendedor = "";
            documento.listado();

            dt.Rows.Clear();
            foreach (DOCUMENTO item in documento.listDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Folio"] = item.DoFolio;
                dr["Proyecto"] = item.PyNombre;
                dr["Cliente"] = item.DiNomCorto;

                dt.Rows.Add(dr);
            }

            dgDoc.DataSource = dt;
        }

        private void dgDoc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            documento.DoIdent = documento.listDoc[idx].DoIdent;
            documento.DoTipo = tipo;
            documento.DiNumero = "";
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = Convert.ToDateTime("2020-01-01");
            documento.FeFin = DateTime.Now;
            documento.DoUsuSeg = usuarioCache.nombreUsuario;
            documento.DoVendedor = "";
            documento.consultaUno();

            this.Close();
        }
    }
}
