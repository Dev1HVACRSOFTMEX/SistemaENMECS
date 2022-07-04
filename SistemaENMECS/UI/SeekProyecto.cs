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
    public partial class SeekProyecto : Form
    {
        public _Proyecto proyecto = new _Proyecto();
        private DataTable dt = new DataTable();

        public SeekProyecto()
        {
            InitializeComponent();

            proyecto.PyNumero = "";
            proyecto.PyNombre = "";
            proyecto.DiNombre = "";
            proyecto.listado();
        }

        private void SeekProyecto_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Numero", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));

            foreach (PROYECTO item in proyecto.listPry)
            {
                DataRow dr = dt.NewRow();
                dr["Numero"] = item.PyNumero;
                dr["Nombre"] = item.PyNombre;
                dr["Cliente"] = item.DiNombre;
                dt.Rows.Add(dr);
            }

            dgPry.DataSource = dt;
        }

        private void dgPry_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            proyecto.PyNumero = proyecto.listPry[idx].PyNumero;
            proyecto.PyNombre = "";
            proyecto.DiNombre = "";
            proyecto.consultaUno();
            this.Close();
        }
    }
}
