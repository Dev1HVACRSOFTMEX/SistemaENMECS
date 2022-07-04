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
    public partial class ListaDirectorio : Form
    {
        private _Directorio dir = new _Directorio();
        private _Contacto cont = new _Contacto();
        private DataTable dt = new DataTable("directorio");
        private string Tipo;

        public ListaDirectorio()
        {
            InitializeComponent();

            dir.DiNumero = "";
            dir.DiTipo = Tipo = "";
            dir.DiRFC = "";
            dir.DiNombreCom = "";
            string res = dir.listado();
        }

        public ListaDirectorio(string DiTipo)
        {
            InitializeComponent();

            dir.DiNumero = "";
            dir.DiTipo = Tipo = DiTipo;
            dir.DiRFC = "";
            dir.DiNombreCom = "";
            string res = dir.listado();
        }

        private void ListaDirectorio_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("RFC", typeof(string)));
            dt.Columns.Add(new DataColumn("Teléfono", typeof(string)));
            dt.Columns.Add(new DataColumn("E-mail", typeof(string)));

            foreach (DIRECTORIO item in dir.listDir)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.DiNomCorto;
                dr["RFC"] = item.DiRFC;
                cont.DiNumero = item.DiNumero;
                cont.CnNumero = 1;
                cont.CnTipo = "EMP";
                cont.consultaUno();
                dr["Teléfono"] = cont.CnTelefono;
                dr["E-mail"] = cont.CnCorreo;
                dt.Rows.Add(dr);
            }

            dgDireccion.DataSource = dt;
        }

        private void dgDireccion_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            string DiNumero = dir.listDir[idx].DiNumero;

            Directorio ventana = new Directorio(DiNumero, Tipo, modo.update);
            ventana.ShowDialog();

            dir.DiNumero = "";
            dir.DiTipo = Tipo;
            dir.DiRFC = txtRFC.Text.Trim();
            dir.DiNombreCom = txtNombre.Text.Trim();
            string res = dir.listado();
            dt.Clear();
            foreach (DIRECTORIO item in dir.listDir)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.DiNomCorto;
                dr["RFC"] = item.DiRFC;
                cont.DiNumero = item.DiNumero;
                cont.CnNumero = 1;
                cont.CnTipo = "EMP";
                cont.consultaUno();
                dr["Teléfono"] = cont.CnTelefono;
                dr["E-mail"] = cont.CnCorreo;
                dt.Rows.Add(dr);
            }
            dgDireccion.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string DiNumero = "";
            Directorio ventana = new Directorio(DiNumero, Tipo, modo.insert);
            ventana.ShowDialog();

            dir.DiNumero = "";
            dir.DiTipo = Tipo;
            dir.DiRFC = txtRFC.Text.Trim();
            dir.DiNombreCom = txtNombre.Text.Trim();
            string res = dir.listado();
            dt.Clear();
            foreach (DIRECTORIO item in dir.listDir)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.DiNomCorto;
                dr["RFC"] = item.DiRFC;
                cont.DiNumero = item.DiNumero;
                cont.CnNumero = 1;
                cont.CnTipo = "EMP";
                cont.consultaUno();
                dr["Teléfono"] = cont.CnTelefono;
                dr["E-mail"] = cont.CnCorreo;
                dt.Rows.Add(dr);
            }
            dgDireccion.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dir.DiNumero = "";
            dir.DiTipo = Tipo;
            dir.DiRFC = txtRFC.Text.Trim();
            dir.DiNombreCom = txtNombre.Text.Trim();
            string res = dir.listado();
            dt.Clear();
            foreach (DIRECTORIO item in dir.listDir)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.DiNomCorto;
                dr["RFC"] = item.DiRFC;
                cont.DiNumero = item.DiNumero;
                cont.CnNumero = 1;
                cont.CnTipo = "EMP";
                cont.consultaUno();
                dr["Teléfono"] = cont.CnTelefono;
                dr["E-mail"] = cont.CnCorreo;
                dt.Rows.Add(dr);
            }
            dgDireccion.DataSource = dt;
        }
    }
}
