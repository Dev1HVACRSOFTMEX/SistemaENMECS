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
    public partial class SeekDirectorio : Form
    {
        public _Directorio directorio = new _Directorio();
        private DataTable dt = new DataTable();
        private string tipo;

        public SeekDirectorio(string DiTipo)
        {
            InitializeComponent();

            tipo = DiTipo;
            directorio.DiNumero = "";
            directorio.DiTipo = tipo;
            directorio.DiRFC = "";
            directorio.DiNombreCom = "";
            directorio.listado();
        }

        private void SeekDirectorio_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("RFC", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));

            foreach (DIRECTORIO item in directorio.listDir)
            {
                DataRow dr = dt.NewRow();
                dr["RFC"] = item.DiRFC;
                dr["Nombre"] = item.DiNombreCom;
                dt.Rows.Add(dr);
            }

            dgDir.DataSource = dt;
        }

        private void dgDir_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            directorio.DiNumero = directorio.listDir[idx].DiNumero;
            directorio.DiTipo = "";
            directorio.DiRFC = "";
            directorio.DiNombreCom = "";
            directorio.consultaUno();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dt.Clear();
            directorio.DiNumero = "";
            directorio.DiTipo = tipo;
            directorio.DiRFC = txtRFC.Text.Trim();
            directorio.DiNombreCom = txtNombre.Text.Trim();
            directorio.listado();

            foreach (DIRECTORIO item in directorio.listDir)
            {
                DataRow dr = dt.NewRow();
                dr["RFC"] = item.DiRFC;
                dr["Nombre"] = item.DiNombreCom;
                dt.Rows.Add(dr);
            }

            dgDir.DataSource = dt;
        }
    }
}
