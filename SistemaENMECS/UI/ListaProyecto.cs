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
    public partial class ListaProyecto : Form
    {
        private _Proyecto proyecto = new _Proyecto();
        private DataTable dt = new DataTable("proyecto");

        public ListaProyecto()
        {
            InitializeComponent();

            proyecto.PyNumero = "";
            proyecto.PyNombre = "";
            proyecto.DiNombre = "";
            proyecto.listado();
        }

        private void ListaProyecto_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Numero", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("Estado", typeof(string)));

            foreach(PROYECTO item in proyecto.listPry)
            {
                DataRow dr = dt.NewRow();
                dr["Numero"] = item.DiNumero.ToString().Trim();
                dr["Nombre"] = item.PyNombre.Trim();
                dr["Cliente"] = item.DiNombre.Trim();
                dr["Estado"] = item.PyActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgProyectos.DataSource = dt;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string PyNumero = proyecto.listPry[e.RowIndex].PyNumero;
            Proyecto ventana = new Proyecto(PyNumero, modo.update);
            ventana.ShowDialog();

            proyecto.PyNumero = "";
            proyecto.PyNombre = txtNombre.Text.Trim();
            proyecto.DiNombre = txtCliente.Text.Trim();
            proyecto.listado();
            dt.Rows.Clear();
            foreach (PROYECTO item in proyecto.listPry)
            {
                DataRow dr = dt.NewRow();
                dr["Numero"] = item.DiNumero.ToString().Trim();
                dr["Nombre"] = item.PyNombre.Trim();
                dr["Cliente"] = item.DiNombre.Trim();
                dr["Estado"] = item.PyActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgProyectos.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proyecto ventana = new Proyecto("", modo.insert);
            ventana.ShowDialog();

            proyecto.PyNumero = "";
            proyecto.PyNombre = txtNombre.Text.Trim();
            proyecto.DiNombre = txtCliente.Text.Trim();
            proyecto.listado();
            dt.Rows.Clear();
            foreach (PROYECTO item in proyecto.listPry)
            {
                DataRow dr = dt.NewRow();
                dr["Numero"] = item.DiNumero.ToString().Trim();
                dr["Nombre"] = item.PyNombre.Trim();
                dr["Cliente"] = item.DiNombre.Trim();
                dr["Estado"] = item.PyActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgProyectos.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            proyecto.PyNumero = "";
            proyecto.PyNombre = txtNombre.Text.Trim();
            proyecto.DiNombre = txtCliente.Text.Trim();
            proyecto.listado();
            /*DataTable dt = new DataTable("proyecto");
            dt.Columns.Add(new DataColumn("Numero", typeof(string)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("Estado", typeof(string)));*/
            dt.Rows.Clear();
            foreach (PROYECTO item in proyecto.listPry)
            {
                DataRow dr = dt.NewRow();
                dr["Numero"] = item.DiNumero.ToString().Trim();
                dr["Nombre"] = item.PyNombre.Trim();
                dr["Cliente"] = item.DiNombre.Trim();
                dr["Estado"] = item.PyActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgProyectos.DataSource = dt;
        }
    }
}
