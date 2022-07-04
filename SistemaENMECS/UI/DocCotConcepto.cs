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
    public partial class DocCotConcepto : Form
    {
        private _Concepto concepto = new _Concepto();
        private _DocConcepto docConcepto = new _DocConcepto();
        private _DocConcepto docConceptoCheck = new _DocConcepto();
        private string idDoc = "";

        public DocCotConcepto(string DoIdent)
        {
            InitializeComponent();

            idDoc = DoIdent;

            concepto.CoNumero = 0;
            concepto.listado();

            docConcepto.DoIdent = idDoc;
            docConcepto.CoNumero = 0;
            docConcepto.listado();

            docConceptoCheck.DoIdent = idDoc;
        }

        private void DocCotConcepto_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (CONCEPTO item in concepto.listCon)
            {
                CheckState check = new CheckState();
                foreach (DOCCONCEPTO subitem in docConcepto.listDoC)
                {
                    if (item.CoNumero == subitem.CoNumero)
                        check = CheckState.Checked;
                }
                checkedConcepto.Items.Add(item.CoDescripcion, check);
                //checkedConcepto.Items.Insert(i, check);

                //checkedConcepto.Items.Insert(i, item.CoDescripcion);
                i++;
            }
        }

        private void checkedConcepto_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            docConceptoCheck.DoIdent = idDoc;
            docConceptoCheck.CoNumero = concepto.listCon[idx].CoNumero;
            docConceptoCheck.DcDescripcion = concepto.listCon[idx].CoDescripcion;
            docConceptoCheck.DcPjDesc = 0;
            docConceptoCheck.DcImpDesc = 0;
            docConceptoCheck.DcSubtotal = 0;
            docConceptoCheck.DcTotal = 0;
            docConceptoCheck.DcMoneda = "MXN";
            docConceptoCheck.DcEstatus = "PEND";
            docConceptoCheck.DcAvance = 0;
            docConceptoCheck.DcReferencia = "";
            docConceptoCheck.DcOrden = 0;
            docConcepto.CoNumero = docConceptoCheck.CoNumero;
            docConcepto.consultaUno();
            if (docConcepto.DcAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                    docConceptoCheck.guardar();
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    docConceptoCheck.DcActivo = "A";
                    docConceptoCheck.actualizar();
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    docConceptoCheck.eliminar();
                }
            }
        }
    }
}
