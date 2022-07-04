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
    public partial class Concepto : Form
    {
        private _Concepto con = new _Concepto();
        private _Folio folio = new _Folio();
        private int idCon;
        private modo m;

        public Concepto(int CoNumero, modo mod)
        {
            InitializeComponent();

            m = mod;
            idCon = CoNumero;

            if (modo.update == m)
            {
                con.CoNumero = idCon;
                con.consultaUno();
            }
        }

        private void Concepto_Load(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                txtIdent.Text = con.CoNumero.ToString().Trim();
                txtDesc.Text = con.CoDescripcion.Trim();
                checkActivo.Checked = con.CoActivo == "A" ? true : false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            con.CoDescripcion = txtDesc.Text.Trim();
            con.CoActivo = checkActivo.Checked ? "A" : "I";
            if (modo.insert == m)
            {
                int fol = 0;
                folio.FoIdent = tipoFolio.CON.ToString();
                string res = folio.consultaUno();
                fol = folio.FoFolio;
                con.CoNumero = fol;
                con.guardar();

                txtIdent.Text = fol.ToString();

                fol++;
                folio.FoFolio = fol;
                folio.actualizar();
            }
            else if (modo.update == m)
                con.actualizar();
            this.Close();
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    con.CoActivo = checkActivo.Checked ? "A" : "I";
                    con.actualizar();
                }
                else
                {
                    con.eliminar();
                }
            }
        }
    }
}
