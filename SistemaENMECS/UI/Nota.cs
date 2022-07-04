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
    public partial class Nota : Form
    {
        private _Nota not = new _Nota();
        private _Folio folio = new _Folio();
        private string idNot;
        private modo m;

        //private string[] tipo00 = new string[] { "DCONG", "DCVOF", "DCFPA", "DCCPA", "DCTRE", "DCNTR", "DCTEN", "DCNTE", "DCCNI", "DNTIM", "DCGAS", "DCLGA" };
        //private string[] tipo01 = new string[] { "Condiciones Generales de Venta", "Vigencia Oferta", "Forma de Pago", "Condiciones de Pago", "Tiempo de Respuesta", "Notas Tiempo de Repuesta", "Tiempo de Entrega", "Notas Tiempo de Entrega", "Cláusulas y Notas adicionales", "Notas Importante", "Garantía de Servicio", "Cláusulas de garantía no validas" };
        private string[] tipo00 = new string[] { "DCCTM", "DCCVF", "DCCFP", "DCCCP", "DCCTE", "DCCPE", "DCCSE", "DCNIM" };
        private string[] tipo01 = new string[] { "Tipo de Moneda", "Vigencia de la Oferta", "Forma de Pago", "Condiciones de Pago", "Términos de Entrega", "Plazo de Entrega", "Se Excluye", "Notas Importantes" };
        private string[] tipoPar00 = new string[] { "PINCL", "PNINC", "PCARA" };
        private string[] tipoPar01 = new string[] { "INCLUYE", "NO INCLUYE", "CARACTERISTICAS" };

        public Nota(string NoIdent, modo mod)
        {
            InitializeComponent();

            idNot = NoIdent;
            m = mod;

            if (modo.update == m)
            {
                not.NoIdent = NoIdent;
                not.NoTipo = "";
                not.consultaUno();
                cbTipo.Enabled = false;
                cbCategoria.Enabled = false;
            }
            else if (modo.insert == m)
                checkActivo.Checked = true;
        }

        private void Nota_Load(object sender, EventArgs e)
        {
            int i = 0, idx = 0;
            if (modo.update == m)
            {
                string inicial = not.NoTipo.Substring(0, 1);
                if (inicial == "D")
                {
                    foreach (string item in tipo01)
                    {
                        cbTipo.Items.Insert(i, tipo01[i]);
                        if (modo.update == m && not.NoTipo.Trim() == tipo00[i].Trim())
                            idx = i;
                        i++;
                    }
                }
                else
                {
                    foreach (string item in tipoPar01)
                    {
                        cbTipo.Items.Insert(i, tipoPar01[i]);
                        if (modo.update == m && not.NoTipo.Trim() == tipoPar00[i].Trim())
                            idx = i;
                        i++;
                    }
                }
            }
            else
            {
                cbTipo.Items.Clear();
                cbTipo.Items.Insert(0, "<Seleccionar>");
                cbTipo.SelectedIndex = 0;
            }

            cbCategoria.Items.Clear();
            cbCategoria.Items.Insert(0, "<Seleccionar>");
            cbCategoria.Items.Insert(1, "Documento");
            cbCategoria.Items.Insert(2, "Partida");
            cbCategoria.SelectedIndex = 0;
            if (modo.update == m)
                cbCategoria.SelectedIndex = not.NoTipo.Substring(0, 1) == "D" ? 1 : 2;

            if (modo.update == m)
            {
                txtIdent.Text = not.NoIdent;
                cbTipo.SelectedIndex = idx + 1;
                txtDesc.Text = not.NoDescripcion;
                checkActivo.Checked = not.NoActivo == "A" ? true : false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbCategoria.SelectedIndex == 1)
                not.NoTipo = tipo00[cbTipo.SelectedIndex - 1];
            else if (cbCategoria.SelectedIndex == 2)
                not.NoTipo = tipoPar00[cbTipo.SelectedIndex - 1];
            else
                not.NoTipo = "";
            not.NoDescripcion = txtDesc.Text;
            not.EfIdent = "";
            not.NoActivo = checkActivo.Checked ? "A" : "I";
            if (modo.insert == m)
            {
                int fol = 0;
                folio.FoIdent = tipoFolio.NOT.ToString();
                string res = folio.consultaUno();
                fol = folio.FoFolio;
                not.NoIdent = fol.ToString();
                res = not.guardar();
                txtIdent.Text = fol.ToString();

                if (res == "")
                {
                    fol++;
                    folio.FoFolio = fol;
                    folio.actualizar();
                }
            }
            else if (modo.update == m)
                not.actualizar();

            this.Close();
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    not.NoActivo = "A";
                    not.actualizar();
                }
                else
                {
                    not.eliminar();
                }
            }
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 1;
            cbTipo.Items.Clear();
            cbTipo.Items.Insert(0, "<Seleccionar>");
            if (cbCategoria.SelectedIndex == 1)
            {
                foreach (string item in tipo01)
                {
                    cbTipo.Items.Insert(i, tipo01[i-1]);
                    i++;
                }
            }
            else if (cbCategoria.SelectedIndex == 2)
            {
                foreach (string item in tipoPar01)
                {
                    cbTipo.Items.Insert(i, tipoPar01[i-1]);
                    i++;
                }
            }
            cbTipo.SelectedIndex = 0;
        }
    }
}
