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
    public partial class Usuario : Form
    {
        private _Usuario usuario = new _Usuario();
        private _Directorio directorio = new _Directorio();
        private _Contacto contacto = new _Contacto();
        private string idDir;
        private string DiTipo;
        private string UsPerfil;
        private int idCon;
        private modo m;
        private string[] tipoDir00 = { "EMP", "CLI", "PRV" };
        private string[] tipoDir01 = { "Empresa", "Cliente", "Proveedor" };
        private string[] perfil00 = { "ADMIN", "VENTA", "CONTA" };
        private string[] perfil01 = { "Administrador", "Ventas", "Contabilidad" };

        public Usuario(string DiNumero, int CnNumero, modo mod)
        {
            InitializeComponent();

            idDir = DiNumero;
            idCon = CnNumero;
            m = mod;

            if (modo.update == m)
            {
                usuario.DiNumero = idDir;
                usuario.CnNumero = idCon;
                usuario.UsUsuario = "";
                usuario.consultaUno();

                directorio.DiNumero = idDir;
                directorio.DiTipo = "";
                directorio.DiRFC = "";
                directorio.DiNombreCom = "";
                directorio.consultaUno();

                contacto.DiNumero = idDir;
                contacto.CnNumero = idCon;
                contacto.CnTipo = "";
                contacto.consultaUno();
            }
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            DiTipo = directorio.DiTipo == null ? "" : directorio.DiTipo;
            UsPerfil = usuario.UsPerfil == null ? "" : usuario.UsPerfil;

            cbTipo.Items.Insert(0, "<Seleccionar>");
            int i = 1, sel = 0;
            foreach (string item in tipoDir01)
            {
                cbTipo.Items.Insert(i, item);
                if (DiTipo == tipoDir00[i - 1])
                    sel = i;
                i++;
            }
            if (i > 1)
                cbTipo.SelectedIndex = sel == 0 ? 0 : sel;

            cbPerfil.Items.Insert(0, "<Seleccionar>");
            i = 1;
            int selP = 0;
            foreach(string item in perfil01)
            {
                cbPerfil.Items.Insert(i, item);
                if (UsPerfil == perfil00[i - 1])
                    selP = i;
                i++;
            }
            if (i > 1)
                cbPerfil.SelectedIndex = selP == 0 ? 0 : selP;

            if (modo.update == m)
            {
                txtNombre.Text = usuario.UsNombre;
                txtUsuario.Text = usuario.UsUsuario;
                txtPassword.Text = usuario.UsPassword;
                checkActivo.Checked = usuario.UsActivo == "A" ? true : false;
            }
            else if (modo.insert == m)
                checkActivo.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idx = cbPerfil.SelectedIndex - 1;
            int valido = 0;
            if (cbDir.SelectedIndex > 0 && cbContacto.SelectedIndex > 0)
            {
                usuario.DiNumero = directorio.listDir[cbDir.SelectedIndex - 1].DiNumero;
                usuario.CnNumero = contacto.listCon[cbContacto.SelectedIndex - 1].CnNumero;
            }
            else
            {
                MessageBox.Show("Es importante seleccionar el contacto para logueo");
                valido = 1;
            }
            usuario.UsNombre = txtNombre.Text;
            usuario.UsUsuario = txtUsuario.Text;
            usuario.UsPerfil = idx < 0 ? "" : perfil00[idx];
            if (modo.insert == m)
            {
                if (valido == 0)
                    usuario.guardar();
            }
            else if (modo.update == m)
            {
                if (txtPassword.Text.Trim() == usuario.UsPassword.Trim())
                    usuario.UsPassword = usuario.UsPassword;
                else
                    usuario.UsPassword = usuario.hashString(txtPassword.Text.Trim(), txtUsuario.Text.Trim());
                usuario.actualizar();
            }

            this.Close();
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    usuario.actualizar();
                }
                else
                {
                    usuario.eliminar();
                }
            }
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbTipo.SelectedIndex - 1;
            int sel = 0;
            if (idx < 0)
            {
                DiTipo = "";
                directorio.listDir = null;

                cbDir.Items.Clear();
                cbDir.Items.Insert(0, "<Seleccionar>");
            }
            else
            {
                DiTipo = tipoDir00[idx];
                directorio.DiNumero = "";
                directorio.DiTipo = DiTipo;
                directorio.DiRFC = "";
                directorio.DiNombreCom = "";
                directorio.listado();
                
                cbDir.Items.Clear();
                cbDir.Items.Insert(0, "<Seleccionar>");
                int i = 1;
                foreach(DIRECTORIO item in directorio.listDir)
                {
                    cbDir.Items.Insert(i, item.DiNomCorto);
                    if (idDir == item.DiNumero)
                        sel = i;
                    i++;
                }
            }
            cbDir.SelectedIndex = sel == 0 ? 0 : sel;
        }

        private void cbDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbDir.SelectedIndex - 1;
            int sel = 0;
            if (idx < 0)
            {
                contacto.listCon = null;

                cbContacto.Items.Clear();
                cbContacto.Items.Insert(0, "<Seleccionar>");
            }
            else
            {
                string DiNumero = "";
                DiNumero = directorio.listDir[idx].DiNumero;
                contacto.DiNumero = DiNumero;
                contacto.CnNumero = 0;
                contacto.CnTipo = "";
                contacto.listado();

                cbContacto.Items.Clear();
                cbContacto.Items.Insert(0, "<Seleccionar>");
                int i = 1;
                string valor = "";
                foreach(CONTACTO item in contacto.listCon)
                {
                    valor = item.CnNombre.Trim() + " " + item.CnAPaterno.Trim() + " " + item.CnAMaterno + (item.CnPuesto.Trim() == "" ? " | Sin Puesto" : " | " + (item.CnPuesto.Trim()));
                    cbContacto.Items.Insert(i, valor);
                    if (idCon == item.CnNumero)
                        sel = i;
                    i++;
                }
            }
            cbContacto.SelectedIndex = sel == 0 ? 0 : sel;
        }
    }
}
