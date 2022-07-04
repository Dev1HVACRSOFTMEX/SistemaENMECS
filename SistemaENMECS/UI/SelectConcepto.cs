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
    public partial class SelectConcepto : Form
    {
        private _Concepto concepto = new _Concepto();
        private string id;

        public SelectConcepto()
        {
            InitializeComponent();
        }

        public SelectConcepto(string DoIdent)
        {
            InitializeComponent();

            id = DoIdent;
        }

        private void SelectConcepto_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        /*
        private void checkListConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        */
        private void Mostrar()
        {
            concepto.CoNumero = 0;
            concepto.listado();

            _DocConcepto docCon = new _DocConcepto();
            docCon.DoIdent = id;

            int idx = 0;
            checkListConcepto.Items.Clear();
            foreach (CONCEPTO item in concepto.listCon)
            {
                checkListConcepto.Items.Insert(idx, item.CoDescripcion);
                if (docCon.listDoC != null && docCon.listDoC.Count > 0)
                {
                    foreach (DOCCONCEPTO item2 in docCon.listDoC)
                    {
                        if (item.CoNumero == item2.CoNumero)
                            checkListConcepto.SetItemChecked(idx, true);
                        else
                            checkListConcepto.SetItemChecked(idx, false);
                    }
                }
                idx++;
            }
        }

        private void checkListConcepto_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _DocConcepto item = new _DocConcepto();
            if (e.NewValue == CheckState.Checked)
            {
                item.DoIdent = id;
                item.CoNumero = concepto.listCon[idx].CoNumero;
                item.DcDescripcion = concepto.listCon[idx].CoDescripcion;
                item.DcPjDesc = 0;
                item.DcImpDesc = 0;
                item.DcSubtotal = 0;
                item.DcTotal = 0;
                item.DcMoneda = "MXN";
                item.DcEstatus = "PEND";
                item.DcAvance = 0;
                item.DcOrden = 0;
                item.guardar();
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                item.DoIdent = id;
                item.CoNumero = concepto.listCon[idx].CoNumero;
                item.DcOrden = 0;
                item.eliminar();
            }
        }
    }
}
