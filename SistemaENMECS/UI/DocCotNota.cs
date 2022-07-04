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
    public partial class DocCotNota : Form
    {
        public _Nota nota = new _Nota();
        public _DocNota docnota = new _DocNota();
        public _DocCPNota doccpnota = new _DocCPNota();
        private string[] tipo00 = new string[] { "DCONG", "DNOIN", "DNTIM", "DCLGA", "DCVOF", "DCFPA", "DCCPA", "DCTEN" };
        private string[] tipo01 = new string[] { "Condiciones Generales de Venta", "No Se Incluye", "Notas Importante", "Clausulas de garantia no validas", "Vigencia Oferta", "Forma de Pago", "Condiciones de Pago", "Tiempo de Entrega" };
        private string[] tipoPar00 = new string[] { "PINCL", "PNINC", "PCARA" };
        private string[] tipoPar01 = new string[] { "INCLUYE", "NO INCLUYE", "CARACTERISTICAS"};
        private string tipo;
        private string idDoc;
        private int idCon;
        private int idPar;

        public DocCotNota()
        {
            InitializeComponent();
            tipo = "DOC";
            idDoc = "";
            idCon = 0;
            idPar = 0;
            groupNota.Visible = false;
        }

        public DocCotNota(string tipoNot, string DoIdent)
        {
            InitializeComponent();
            tipo = tipoNot;
            docnota.DoIdent = idDoc = DoIdent;
            docnota.DnNumero = 0;
            idCon = 0;
            idPar = 0;
            docnota.listado();
            groupNota.Visible = false;
        }

        public DocCotNota(string tipoNot, string DoIdent, int CoNumero, int DpNumero)
        {
            InitializeComponent();
            tipo = tipoNot;
            doccpnota.DoIdent = idDoc = DoIdent;
            doccpnota.CoNumero = idCon = CoNumero;
            doccpnota.DpNumero = idPar = DpNumero;
            doccpnota.DtNumero = 0;
            doccpnota.listado();
            groupNota.Visible = false;
        }

        private void DocCotNota_Load(object sender, EventArgs e)
        {
            int idx = 1;
            cbTipo.Items.Clear();
            cbTipo.Items.Insert(0, "<Seleccionar>");
            if (tipo == "DOC")
            {
                foreach (string item in tipo01)
                {
                    cbTipo.Items.Insert(idx, item.Trim());
                    idx++;
                }
            }
            else if (tipo == "PAR")
            {
                foreach (string item in tipoPar01)
                {
                    cbTipo.Items.Insert(idx, item.Trim());
                    idx++;
                }
            }
            cbTipo.SelectedIndex = 0;

            cbDesc.Items.Clear();
            cbDesc.Items.Insert(0, "<Seleccionar>");
            cbDesc.SelectedIndex = 0;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbTipo.SelectedIndex;
            if (idx > 0)
            {
                if (tipo == "DOC")
                    nota.NoTipo = tipo00[idx - 1].Trim();
                else if (tipo == "PAR")
                    nota.NoTipo = tipoPar00[idx - 1].Trim();
                else
                    nota.NoTipo = "";
                nota.NoIdent = "";
                nota.listado();

                int idx1 = 1;
                cbDesc.Items.Clear();
                cbDesc.Items.Insert(0, "<Seleccionar>");
                foreach (NOTA item in nota.listNot)
                {
                    cbDesc.Items.Insert(idx1, item.NoDescripcion);
                    idx1++;
                }
                cbDesc.SelectedIndex = 0;

                checkedNota.Items.Clear();
                if (tipo == "DOC")
                {
                    docnota.DoIdent = idDoc;
                    docnota.DnNumero = 0;
                    docnota.listado();

                    int idx0 = 0;
                    foreach (DOCNOTA item in docnota.listDoN)
                    {
                        checkedNota.Items.Insert(idx0, item.DnDescripcion);
                        idx0++;
                    }
                }
                else if (tipo == "PAR")
                {
                    doccpnota.DoIdent = idDoc;
                    doccpnota.CoNumero = idCon;
                    doccpnota.DpNumero = idPar;
                    doccpnota.DtNumero = 0;
                    doccpnota.listado();

                    int idx0 = 0;
                    foreach (DOCCPNOTA item in doccpnota.listDPN)
                    {
                        checkedNota.Items.Insert(idx0, item.DtDescripcion);
                        idx0++;
                    }
                }
            }
        }

        private void cbDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbDesc.SelectedIndex;
            nota.NoIdent = nota.listNot[idx - 1].NoIdent;
            nota.NoTipo = "";
            nota.consultaUno();
            txtDesc.Text = nota.NoDescripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tipo == "COT")
            {
                if (docnota.listDoN == null)
                    docnota.DnNumero = 1;
                else
                    docnota.DnNumero = docnota.listDoN.Count + 1;
                docnota.DnDescripcion = txtDesc.Text.Trim();

                int idx = cbTipo.SelectedIndex;
                if (tipo == "DOC")
                    docnota.DnTipo = tipo00[idx - 1].Trim();
                else if (tipo == "PAR")
                    docnota.DnTipo = tipoPar00[idx - 1].Trim();
                else
                    docnota.DnTipo = "";

                docnota.NoIdent = nota.listNot[cbDesc.SelectedIndex - 1].NoIdent;
                docnota.DnOrden = 0;
                docnota.DnActivo = "A";
                docnota.guardar();

                checkedNota.Items.Clear();
                int idx0 = 0;
                foreach (DOCNOTA item in docnota.listDoN)
                {
                    checkedNota.Items.Insert(idx0, item.DnDescripcion);
                    idx0++;
                }
            }
            else if (tipo == "PAR")
            {
                if (doccpnota.listDPN == null)
                    doccpnota.DtNumero = 1;
                else
                    doccpnota.DtNumero = doccpnota.listDPN.Count + 1;

                doccpnota.NoIdent = nota.listNot[cbDesc.SelectedIndex - 1].NoIdent;
                doccpnota.CoNumero = idCon;
                doccpnota.DpNumero = idPar;
                doccpnota.DtDescripcion = txtDesc.Text.Trim();
                doccpnota.DtOrden = 0;
                doccpnota.NoIdent = nota.listNot[cbDesc.SelectedIndex - 1].NoIdent;
                doccpnota.DtActivo = "A";
                doccpnota.guardar();

                checkedNota.Items.Clear();
                int idx0 = 0;
                foreach (DOCCPNOTA item in doccpnota.listDPN)
                {
                    checkedNota.Items.Insert(idx0, item.DtDescripcion);
                    idx0++;
                }
            }
        }

        private void checkedNota_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            CheckState estado = e.CurrentValue;
            if (tipo == "COT")
            {
                _DocNota dnot = new _DocNota();
                dnot.DoIdent = docnota.listDoN[idx].DoIdent;
                dnot.DnNumero = docnota.listDoN[idx].DnNumero;
                dnot.consultaUno();
                if (estado == CheckState.Checked)
                {
                    dnot.DnActivo = "A";
                    dnot.actualizar();
                }
                else if (estado == CheckState.Unchecked)
                    dnot.eliminar();
            }
            else if (tipo == "PAR")
            {
                _DocCPNota dcpn = new _DocCPNota();
                dcpn.DoIdent = doccpnota.listDPN[idx].DoIdent;
                dcpn.CoNumero = doccpnota.listDPN[idx].CoNumero;
                dcpn.DpNumero = doccpnota.listDPN[idx].DpNumero;
                dcpn.DtNumero = doccpnota.listDPN[idx].DtNumero;
                dcpn.consultaUno();
                if (estado == CheckState.Checked)
                {
                    dcpn.DtActivo = "A";
                    dcpn.actualizar();
                }
                else if (estado == CheckState.Unchecked)
                    dcpn.eliminar();
            }
        }
    }
}
