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
    public partial class TextoEdit : Form
    {
        private string strNota01, strNota02, DoIdent, NoIdent;
        private int DnNumero;
        private modo m;
        private _Nota nota = new _Nota();
        private _DocNota docNota = new _DocNota();

        public TextoEdit(string docId, string notId, int numId, modo mod)
        {
            InitializeComponent();

            DoIdent = docId;
            NoIdent = notId;
            DnNumero = numId;
            m = mod;
            
            nota.NoIdent = NoIdent;
            nota.NoTipo = "";
            nota.consultaUno();

            strNota01 = strNota02 = nota.NoDescripcion;

            int car1 = 0, car2 = 0, car3 = 0;
            string ciudad = "", estado = "";

            if (DnNumero > 0)
            {
                docNota.DoIdent = DoIdent;
                docNota.DnNumero = DnNumero;
                docNota.DnTipo = "";
                docNota.NoIdent = "";
                docNota.consultaUno();

                car1 = nota.NoDescripcion.IndexOf('<');
                car2 = docNota.DnDescripcion.IndexOf(',') + 2;
                car3 = docNota.DnDescripcion.IndexOf('.');

                ciudad = docNota.DnDescripcion.Substring(car1, car2 - car1 - 2);
                estado = docNota.DnDescripcion.Substring(car2, car3 - car2);

                txtCiudad.Text = ciudad;
                txtEstado.Text = estado;

                strNota01 = docNota.DnDescripcion;
            }
        }

        private void TextoEdit_Load(object sender, EventArgs e)
        {
            txtNota.Text = strNota01;

            if (txtCiudad.Text == string.Empty)
            {
                txtCiudad.Text = txtCiudad.Tag.ToString();
                txtCiudad.ForeColor = Color.Gray;
            }

            if (txtEstado.Text == string.Empty)
            {
                txtEstado.Text = txtEstado.Tag.ToString();
                txtEstado.ForeColor = Color.Gray;
            }
        }

        private void txtCiudad_Enter(object sender, EventArgs e)
        {
            if (txtCiudad.Tag.ToString() == txtCiudad.Text)
            {
                txtCiudad.Clear();
                txtCiudad.ForeColor = Color.Black;
            }
        }

        private void txtCiudad_Leave(object sender, EventArgs e)
        {
            if (txtCiudad.Text == string.Empty)
            {
                txtCiudad.Text = txtCiudad.Tag.ToString();
                txtCiudad.ForeColor = Color.Gray;
            }
        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {
            strNota02 = strNota01;
            if ((txtCiudad.Text != txtCiudad.Tag.ToString()) && (txtCiudad.Text != string.Empty))
                txtNota.Text = strNota02 = strNota02.Replace("<Ciudad>", txtCiudad.Text);

            if ((txtEstado.Text != txtEstado.Tag.ToString()) && (txtEstado.Text != string.Empty))
                txtNota.Text = strNota02.Replace("<Estado>", txtEstado.Text);
        }
        
        private void txtEstado_Enter(object sender, EventArgs e)
        {
            if (txtEstado.Tag.ToString() == txtEstado.Text)
            {
                txtEstado.Clear();
                txtEstado.ForeColor = Color.Black;
            }
        }
        
        private void txtEstado_Leave(object sender, EventArgs e)
        {
            if (txtEstado.Text == string.Empty)
            {
                txtEstado.Text = txtEstado.Tag.ToString();
                txtEstado.ForeColor = Color.Gray;
            }
        }
        
        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            strNota02 = strNota01;
            if ((txtCiudad.Text != txtCiudad.Tag.ToString()) && (txtCiudad.Text != string.Empty))
                txtNota.Text  = strNota02 = strNota02.Replace("<Ciudad>", txtCiudad.Text);

            if ((txtEstado.Text != txtEstado.Tag.ToString()) && (txtEstado.Text != string.Empty))
                txtNota.Text = strNota02.Replace("<Estado>", txtEstado.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            docNota.DoIdent = DoIdent;
            docNota.DnDescripcion = txtNota.Text.Trim();
            docNota.DnTipo = nota.NoTipo;
            docNota.DnOrden = 0;
            docNota.NoIdent = nota.NoIdent;
            if (m == modo.insert)
            {
                docNota.DnNumero = 0;
                docNota.DnTipo = "";
                docNota.NoIdent = "";
                docNota.listado();
                docNota.DnNumero = docNota.listDoN.Count + 1;
                docNota.guardar();

                this.Close();
            }
            else if (m == modo.update)
            {
                docNota.DnNumero = DnNumero;
                docNota.actualizar();

                this.Close();
            }
        }
    }
}
