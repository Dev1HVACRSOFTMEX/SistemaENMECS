using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaENMECS.UI
{
    public partial class Especificacion : Form
    {
        private string[] lin00 = new string[] { "BFL-RL", "BFL-CH", "DGL-RL", "UFL-RL", "UFL-CH", "UFL-CX", "BFL-RV", "UIL-RP", "UEL-CH", "UPL-RL" };
        private string[] ver00 = new string[] { "A", "B", "C" };
        private string[] tam00 = new string[] { "050", "100", "150", "200", "201", "202", "251", "250", "300", "350", "400", "500", "600" };
        private string[] mat00 = new string[] { "G", "I", "N" };
        private string[] aca00 = new string[] { "0", "H", "X" };
        private string[] ais00 = new string[] { "0", "1", "2" };
        private string[] eta00 = new string[] { "1", "2", "3" };
        private string[] uso00 = new string[] { "0", "S", "E" };
        public string codigo = "";

        public Especificacion()
        {
            InitializeComponent();
        }

        private void Especificacion_Load(object sender, EventArgs e)
        {
            int i = 1;
            cbLinea.Items.Clear();
            cbLinea.Items.Insert(0, "<Seleccionar>");
            foreach (string item in lin00)
            {
                cbLinea.Items.Insert(i, item);
                i++;
            }
            cbLinea.SelectedIndex = 0;

            i = 1;
            cbTamanio.Items.Clear();
            cbTamanio.Items.Insert(0, "<Seleccionar>");
            foreach (string item in tam00)
            {
                cbTamanio.Items.Insert(i, item);
                i++;
            }
            cbTamanio.SelectedIndex = 0;
        }

        private string generaCodigo()
        {
            string codigo = "";

            int idx = cbLinea.SelectedIndex;
            codigo = idx > 0 ? lin00[idx - 1] : "";

            codigo += rbCompacta.Checked ? "A" : (rbEstandar.Checked ? "S" : (rbEspecial.Checked ? "E" : ""));

            idx = cbTamanio.SelectedIndex;
            codigo += idx > 0 ? tam00[idx - 1] : "";
            
            codigo += rbGalvanizado.Checked ? "-G" : (rbInoxidable.Checked ? "-I" : (rbLaminaN.Checked ? "-N" : ""));

            codigo += rbNatural.Checked ? "0" : (rbPintura.Checked ? "H" : (rbEpoxica.Checked ? "X" : ""));

            codigo += rbSinAisla.Checked ? "0" : (rbAisla1.Checked ? "1" : (rbAisla2.Checked ? "2" : (rbAisla3.Checked ? "3" : (rbAisla4.Checked ? "4" : (rbAisla5.Checked ? "5" : "")))));

            codigo += rb1Et.Checked ? "1" : (rb2Et.Checked ? "2" : (rb3Et.Checked ? "3" : (rb4Et.Checked ? "4" : (rb5Et.Checked ? "5" : ""))));

            codigo += rbNoIndicado.Checked ? "0" : (rbInyeccion.Checked ? "S" : (rbExtraccion.Checked ? "E" : ""));

            return codigo;
        }

        private void cbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void cbTamanio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbCompacta_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbEstandar_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbEspecial_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbGalvanizado_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbInoxidable_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbLaminaN_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbNatural_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbPintura_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbEpoxica_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbNoIndicado_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbInyeccion_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbExtraccion_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rb1Et_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rb2Et_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rb3Et_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbSinAisla_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbAisla1_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbAisla2_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim().Length >= 16)
            {
                codigo = txtCodigo.Text;
                this.Close();
            }
            else
                MessageBox.Show("Es necesario indicar todos los valores");
        }

        private void rbAisla3_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbAisla4_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }

        private void rbAisla5_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = generaCodigo();
        }
    }
}
