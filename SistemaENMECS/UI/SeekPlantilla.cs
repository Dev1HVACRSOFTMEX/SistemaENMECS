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
    public partial class SeekPlantilla : Form
    {
        public _Plantilla plantilla = new _Plantilla();
        private DataTable dt = new DataTable();

        public SeekPlantilla()
        {
            InitializeComponent();

            plantilla.PaIdent = "";
            plantilla.PaDescripcion = "";
            plantilla.listado();
        }

        private void SeekPlantilla_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));

            foreach (PLANTILLA item in plantilla.listPla)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.PaIdent;
                dr["Descripcion"] = item.PaDescripcion;
                dt.Rows.Add(dr);
            }

            dgPla.DataSource = dt;
        }

        private void dgPla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            plantilla.PaIdent = plantilla.listPla[idx].PaIdent;
            plantilla.PaDescripcion = plantilla.listPla[idx].PaDescripcion;
            plantilla.consultaUno();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dt.Clear();
            plantilla.PaIdent = "";
            plantilla.PaDescripcion = txtDesc.Text.Trim();
            plantilla.listado();

            foreach (PLANTILLA item in plantilla.listPla)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.PaIdent;
                dr["Descripcion"] = item.PaDescripcion;
                dt.Rows.Add(dr);
            }

            dgPla.DataSource = dt;
        }
    }
}
