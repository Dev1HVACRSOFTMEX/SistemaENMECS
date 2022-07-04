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
    public partial class ListaPlantilla : Form
    {
        private _Plantilla pla = new _Plantilla();
        private DataTable dt = new DataTable();

        public ListaPlantilla()
        {
            InitializeComponent();

            pla.PaIdent = "";
            pla.PaDescripcion = "";
            pla.listado();
        }

        private void ListaPlantilla_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Ident", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach (PLANTILLA item in pla.listPla)
            {
                DataRow dr = dt.NewRow();
                dr["Ident"] = item.PaIdent;
                dr["Descripcion"] = item.PaDescripcion;
                dr["Estatus"] = item.PaActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }

            dgPlantilla.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string PaIdent = "";
            Plantilla ventana = new Plantilla(PaIdent, modo.insert);
            ventana.ShowDialog();

            pla.PaIdent = "";
            pla.PaDescripcion = "";
            pla.listado();
            dt.Rows.Clear();
            foreach (PLANTILLA item in pla.listPla)
            {
                DataRow dr = dt.NewRow();
                dr["Ident"] = item.PaIdent;
                dr["Descripcion"] = item.PaDescripcion;
                dr["Estatus"] = item.PaActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }
            dgPlantilla.DataSource = dt;
        }

        private void dgPlantilla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            string PaIdent = pla.listPla[idx].PaIdent;
            Plantilla ventana = new Plantilla(PaIdent, modo.update);
            ventana.ShowDialog();

            pla.PaIdent = "";
            pla.PaDescripcion = "";
            pla.listado();
            dt.Rows.Clear();
            foreach (PLANTILLA item in pla.listPla)
            {
                DataRow dr = dt.NewRow();
                dr["Ident"] = item.PaIdent;
                dr["Descripcion"] = item.PaDescripcion;
                dr["Estatus"] = item.PaActivo == "A" ? "Activo" : "Inactivo";

                dt.Rows.Add(dr);
            }
            dgPlantilla.DataSource = dt;
        }
    }
}
