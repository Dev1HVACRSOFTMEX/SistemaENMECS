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
    public partial class Contacto : Form
    {
        private _Contacto contacto = new _Contacto();
        private modo m;
        private string idDir;
        private int idCon;
        private string Tipo;

        public Contacto(string DiNumero, int CnNumero, string CnTipo, modo mod)
        {
            InitializeComponent();

            idDir = DiNumero;
            idCon = CnNumero;
            Tipo = CnTipo;
            m = mod;

            if (modo.update == m)
            {
                contacto.DiNumero = DiNumero;
                contacto.CnNumero = CnNumero;
                contacto.CnTipo = Tipo;
                string res = contacto.consultaUno();
            }
        }

        private void Contacto_Load(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                txtNombre.Text = contacto.CnNombre;
                txtPaterno.Text = contacto.CnAPaterno;
                txtMaterno.Text = contacto.CnAMaterno;
                txtCorreo.Text = contacto.CnCorreo;
                txtTel.Text = contacto.CnTelefono;
                txtPuesto.Text = contacto.CnPuesto;
                txtGradoEst.Text = contacto.CnGradoEst;
                txtAbrev.Text = contacto.CnAbrGraEst;
                txtCedula.Text = contacto.CnCedula;
                txtNota.Text = contacto.CnNota;
                checkActivo.Checked = contacto.CnActivo == "A" ? true : false;
            }
            else if (modo.insert == m)
                checkActivo.CheckState = CheckState.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            contacto.CnNombre = txtNombre.Text.Trim();
            contacto.CnAPaterno = txtPaterno.Text.Trim();
            contacto.CnAMaterno = txtMaterno.Text.Trim();
            contacto.CnCorreo = txtCorreo.Text.Trim();
            contacto.CnTelefono = txtTel.Text.Trim();
            contacto.CnPuesto = txtPuesto.Text.Trim();
            contacto.CnGradoEst = txtGradoEst.Text.Trim();
            contacto.CnAbrGraEst = txtAbrev.Text.Trim();
            contacto.CnCedula = txtCedula.Text.Trim();
            contacto.CnNota = txtNota.Text.Trim();

            string res = "";

            if (modo.insert == m)
            {
                contacto.DiNumero = idDir;
                contacto.CnNumero = idCon;      // + 1;
                contacto.CnTipo = Tipo;
                res = contacto.guardar();
            }
            else if (modo.update == m)
                res = contacto.actualizar();
            
            //if (res == "")
            //    this.Close();
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    contacto.actualizar();
                }
                else
                {
                    contacto.eliminar();
                }
            }
        }
    }
}
