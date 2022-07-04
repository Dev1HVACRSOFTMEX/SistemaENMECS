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
    public partial class ListaUsuario : Form
    {
        private _Usuario usuario = new _Usuario();
        private DataTable dt = new DataTable("contacto");
        string idDir;

        public ListaUsuario(string DiNumero)
        {
            InitializeComponent();

            idDir = DiNumero;
            usuario.DiNumero = idDir;
            usuario.CnNumero = 0;
            usuario.UsUsuario = "";
            usuario.listado();
        }

        private void ListaUsuario_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Usuario", typeof(string)));
            dt.Columns.Add(new DataColumn("Perfil", typeof(string)));
            dt.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach(USUARIO item in usuario.listUsu)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.UsNombre.Trim();
                dr["Usuario"] = item.UsUsuario.Trim();
                dr["Perfil"] = item.UsPerfil.Trim();
                dr["Estatus"] = item.UsActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgUsuarios.DataSource = dt;
        }

        private void dgUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int CnNumero = usuario.listUsu[e.RowIndex].CnNumero;
            Usuario ventana = new Usuario(idDir, CnNumero, modo.update);
            ventana.ShowDialog();

            usuario.DiNumero = idDir;
            usuario.CnNumero = 0;
            usuario.UsUsuario = "";
            usuario.listado();

            dt.Rows.Clear();
            foreach (USUARIO item in usuario.listUsu)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.UsNombre.Trim();
                dr["Usuario"] = item.UsUsuario.Trim();
                dr["Perfil"] = item.UsPerfil.Trim();
                dr["Estatus"] = item.UsActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgUsuarios.DataSource = dt;
        }

        private void btnAgregaUsu_Click(object sender, EventArgs e)
        {
            Usuario ventana = new Usuario("", 0, modo.insert);
            ventana.ShowDialog();

            usuario.DiNumero = idDir;
            usuario.CnNumero = 0;
            usuario.UsUsuario = "";
            usuario.listado();

            dt.Rows.Clear();
            foreach (USUARIO item in usuario.listUsu)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.UsNombre.Trim();
                dr["Usuario"] = item.UsUsuario.Trim();
                dr["Perfil"] = item.UsPerfil.Trim();
                dr["Estatus"] = item.UsActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgUsuarios.DataSource = dt;
        }
    }
}
