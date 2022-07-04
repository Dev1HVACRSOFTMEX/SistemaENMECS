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
    public partial class DocCotCuerpo : Form
    {
        private _Configuracion config = new _Configuracion();
        private _Documento documento = new _Documento();
        private _Empresa empresa = new _Empresa();
        private _Concepto concepto = new _Concepto();
        private _DocConcepto docConcepto = new _DocConcepto();
        _DocCPartida par = new _DocCPartida();
        private _DocNota docNota = new _DocNota();
        private _CalVenta calventa = new _CalVenta();
        private _Contacto contacto = new _Contacto();
        private _TipoCambio tipoCambio = new _TipoCambio();
        _Nota nota = new _Nota();
        private string idDoc = "";
        private int idCon;
        private int idPar;
        private modo m;
        private double totalMN;
        private double totalME;
        private int calculoPrecio = 0;
        private double IVA = 0;

        //private string[] tipo00 = new string[] { "DCONG", "DCVOF", "DCFPA", "DCCPA", "DCTRE", "DCNTR", "DCTEN", "DCNTE", "DCCNI", "DNTIM", "DCGAS", "DCLGA" };
        //private string[] tipo01 = new string[] { "Condiciones Generales de Venta", "Vigencia Oferta", "Forma de Pago", "Condiciones de Pago", "Tiempo de Respuesta", "Notas Tiempo de Repuesta", "Tiempo de Entrega", "Notas Tiempo de Entrega", "Cláusulas y Notas adicionales", "Notas Importante", "Garantía de Servicio", "Cláusulas de garantía no validas" };
        private string[] tipo00 = new string[] { "DCCTM", "DCCVF", "DCCFP", "DCCCP", "DCCTE", "DCCPE", "DCCSE", "DCNIM" };
        private string[] tipo01 = new string[] { "Tipo de Moneda", "Vigencia de la Oferta", "Forma de Pago", "Condiciones de Pago", "Términos de Entrega", "Plazo de Entrega", "Se Excluye", "Notas Importantes" };
        private string notasImp = "DCNIM", itemSelAgr = "";

        public DocCotCuerpo(string DoIdent, modo mod)
        {
            InitializeComponent();

            idDoc = DoIdent;
            m = mod;

            documento.DoIdent = idDoc;
            documento.DoTipo = "";
            documento.DiNumero = "";
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = DateTime.Now;
            documento.FeFin = DateTime.Now;
            documento.DoUsuSeg = "";
            documento.DoVendedor = "";
            documento.consultaUno();

            calventa.DoIdent = idDoc;
            calventa.CvOportunidad = "";
            calventa.consultaUno();

            if (documento.DiNumero != null)
            {
                empresa.EmIdent = documento.EmIdent;
                empresa.consultaUno();

                contacto.DiNumero = documento.DiNumero;
                contacto.CnNumero = 0;
                contacto.CnTipo = "CON";
                contacto.listado();
            }

            string cod = tipo00[0];
            nota = new _Nota();
            nota.NoIdent = "";
            nota.NoTipo = cod;
            nota.listado();

            docNota.DoIdent = idDoc;
            docNota.DnNumero = 0;
            docNota.DnTipo = tipo00[0];
            docNota.NoIdent = "";
            docNota.listado();

            docConcepto.DoIdent = idDoc;
            docConcepto.CoNumero = 0;
            docConcepto.listado();

            config.CgIdent = "CFG01";
            config.consultaUno();

            contextAgregar.Visible = false;
            contextEditar.Visible = false;
            contextTexto.Visible = false;
            contextPartidaCot.Visible = false;
        }

        private void DocCotCuerpo_Load(object sender, EventArgs e)
        {
            txtFolio.Text = documento.DoFolio.ToString().Trim();
            txtFecha.Text = documento.DoFecha.ToString().Substring(0, 10);
            txtEmpresa.Text = empresa.DiNomCorto.Trim();
            txtVersion.Text = documento.DoVersionL.Trim() + documento.DoVersion.ToString().Trim();
            txtProyecto.Text = documento.PyNombre.Trim();
            txtCliente.Text = documento.DiNomCorto.Trim();
            txtPjDescPre.Text = documento.DoPjDesc.ToString().Trim();
            txtImpDescPre.Text = documento.DoImpImp.ToString().Trim();
            txtSubTotalD.Text = documento.DoSubTDesc.ToString().Trim();

            //txtTotal.Text = documento.DoTotal.ToString().Trim();
            //txtTotalEx.Text = documento.DoTotalMoE.ToString().Trim();
            if (documento.DoTiCambio == 0)
                txtTipoC.Text = "0";
            else
                txtTipoC.Text = documento.DoTiCambio.ToString().PadRight(7,'0');
            txtRef.Text = documento.DoReferencia.Trim();

            IVA = config.CgPjImpuesto;
            txtIVA.Text = IVA.ToString();

            CrearNodos();

            int i = 0;
            int ban;
            checkNotas.Items.Clear();
            foreach (NOTA item in nota.listNot)
            {
                ban = 0;
                if (docNota.listDoN != null && docNota.listDoN.Count > 0)
                {
                    foreach (DOCNOTA subitem in docNota.listDoN)
                        if (item.NoIdent == subitem.NoIdent)
                        {
                            checkNotas.Items.Insert(i, subitem.DnDescripcion);
                            if (subitem.DnActivo == "A")
                                checkNotas.SetItemChecked(i, true);
                            ban = 1;
                        }

                }
                if (ban == 0)
                    checkNotas.Items.Insert(i, item.NoDescripcion);
                i++;
            }

            cbMoneda.Items.Clear();
            cbMoneda.Items.Insert(0, "<Seleccionar>");
            cbMoneda.Items.Insert(1, "MXN");
            cbMoneda.Items.Insert(2, "USD");

            if (documento.DoMoneda == "MXN")
                cbMoneda.SelectedIndex = 1;
            else if (documento.DoMoneda == "USD")
                cbMoneda.SelectedIndex = 2;
            else
                cbMoneda.SelectedIndex = 0;

            int idx = 1;
            cbPresupuesto.Items.Clear();
            cbPresupuesto.Items.Insert(0, "<Seleccionar>");
            foreach (string item in calventa.presupuesto)
            {
                cbPresupuesto.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
            {
                if (calventa.DoIdent != null)
                    cbPresupuesto.SelectedIndex = calventa.CvPresupuesto;
                else
                    cbPresupuesto.SelectedIndex = 0;
            }

            idx = 1;
            cbAutoridad.Items.Clear();
            cbAutoridad.Items.Insert(0, "<Seleccionar>");
            foreach (string item in calventa.autoridad)
            {
                cbAutoridad.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
            {
                if (calventa.DoIdent != null)
                    cbAutoridad.SelectedIndex = calventa.CvAutoridad;
                else
                    cbAutoridad.SelectedIndex = 0;
            }

            idx = 1;
            cbNecesidad.Items.Clear();
            cbNecesidad.Items.Insert(0, "<Seleccionar>");
            foreach (string item in calventa.necesidad)
            {
                cbNecesidad.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
            {
                if (calventa.DoIdent != null)
                    cbNecesidad.SelectedIndex = calventa.CvNecesidad;
                else
                    cbNecesidad.SelectedIndex = 0;
            }

            idx = 1;
            cbTiempo.Items.Clear();
            cbTiempo.Items.Insert(0, "<Seleccionar>");
            foreach (string item in calventa.tiempo)
            {
                cbTiempo.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
            {
                if (calventa.DoIdent != null)
                    cbTiempo.SelectedIndex = calventa.CvTiempo;
                else
                    cbTiempo.SelectedIndex = 0;
            }

            DataTable dt = new DataTable("notas");
            dt.Columns.Add(new DataColumn("Agrupador", typeof(string)));

            foreach (string item in tipo01)
            {
                DataRow dr = dt.NewRow();
                dr["Agrupador"] = item;
                dt.Rows.Add(dr);
            }

            dgNotas.DataSource = dt;
            itemSelAgr = tipo00[0];
            
            i = 0;
            string nombre = "";
            checkDirigido.Items.Clear();
            if (contacto.listCon != null && contacto.listCon.Count > 0)
            {
                foreach (CONTACTO item in contacto.listCon)
                {
                    nombre = item.CnNombre.Trim() + " " + item.CnAPaterno.Trim() + " " + item.CnAMaterno.Trim();
                    checkDirigido.Items.Insert(i, nombre);
                    if (documento.CnNumero01 == item.CnNumero || documento.CnNumero02 == item.CnNumero || documento.CnNumero03 == item.CnNumero || documento.CnNumero04 == item.CnNumero || documento.CnNumero05 == item.CnNumero)
                        checkDirigido.SetItemChecked(i, true);
                    i++;
                }
            }
            
            if (documento.DoEstatus == "NUEVO")
            {
                btnGuardar.Visible = true;
                btnNew.Visible = true;
                btnRevisar.Visible = false;
                btnCancel.Visible = true;
                btnAprove.Visible = false;
            }
            if (documento.DoEstatus == "EDITA")
            {
                btnGuardar.Visible = true;
                btnNew.Visible = true;
                btnRevisar.Visible = false;
                btnCancel.Visible = true;
                btnAprove.Visible = false;
            }
            if (documento.DoEstatus == "ENVIO")
            {
                btnGuardar.Visible = false;
                btnNew.Visible = false;
                btnRevisar.Visible = true;
                btnCancel.Visible = true;
                btnAprove.Visible = true;
            }
            if (documento.DoEstatus == "CANCE")
            {
                btnGuardar.Visible = false;
                btnNew.Visible = false;
                btnRevisar.Visible = false;
                btnCancel.Visible = false;
                btnAprove.Visible = false;

                cbMoneda.Enabled = false;
                btnConcepto.Visible = false;

                txtTipoC.Enabled = false;
                btnTipoC.Visible = false;
                txtRef.Enabled = false;

                cbPresupuesto.Enabled = false;
                cbAutoridad.Enabled = false;
                cbNecesidad.Enabled = false;
                cbTiempo.Enabled = false;
            }
            if (documento.DoEstatus == "APROB")
            {
                btnGuardar.Visible = false;
                btnNew.Visible = false;
                btnRevisar.Visible = false;
                btnCancel.Visible = false;
                btnAprove.Visible = false;

                cbMoneda.Enabled = false;
                btnConcepto.Visible = false;

                txtTipoC.Enabled = false;
                btnTipoC.Visible = false;
                txtRef.Enabled = false;

                cbPresupuesto.Enabled = false;
                cbAutoridad.Enabled = false;
                cbNecesidad.Enabled = false;
                cbTiempo.Enabled = false;
            }
            if (documento.DoEstatus == "REVIS")
            {
                btnGuardar.Visible = false;
                btnNew.Visible = false;
                btnRevisar.Visible = false;
                btnCancel.Visible = false;
                btnAprove.Visible = false;

                cbMoneda.Enabled = false;
                btnConcepto.Visible = false;

                txtTipoC.Enabled = false;
                btnTipoC.Visible = false;
                txtRef.Enabled = false;

                cbPresupuesto.Enabled = false;
                cbAutoridad.Enabled = false;
                cbNecesidad.Enabled = false;
                cbTiempo.Enabled = false;
            }
        }

        private void CrearNodos()
        {
            try
            {
                int idx = 0;
                par = new _DocCPartida();
                //totalMN = 0;
                //totalME = 0;
                par.DoIdent = idDoc;
                treePartida.Nodes.Clear();
                foreach(DOCCONCEPTO item in docConcepto.listDoC)
                {
                    treePartida.Nodes.Insert(idx, item.CoDescripcion);
                    TreeNode nodoRaiz = treePartida.Nodes[idx];
                    Partida nodoPartida = null;

                    par.CoNumero = item.CoNumero;
                    par.DpNumero = 0;
                    par.listado();
                    foreach (DOCCPARTIDA item00 in par.listDCP)
                    {
                        double totPar = item00.DpCantidad * item00.DpPrecio;
                        //item00.DpImporte
                        nodoPartida = new Partida(item00.ArCodigo.Trim(), item00.DpDescripcion, item00.DpCantidad, item00.DpUnidad, totPar, item00.ArCodigo, 0, 1);
                        nodoRaiz.Nodes.Add(nodoPartida);

                        /*if (item00.DpMonEx == "MXN")
                            totalMN += item00.DpImporte;
                        else
                            totalME += item00.DpImporteMoE;*/
                    }

                    idx++;
                }

                //txtTotal.Text = "$ " + totalMN.ToString("N2").Trim();
                //txtTotalEx.Text = "$ " + totalME.ToString("N2").Trim();
                double tcImporte = txtTipoC.Text == "" ? 0 : Convert.ToDouble(txtTipoC.Text);
                string moneda = cbMoneda.SelectedIndex == 2 ? "USD" : "MXN";
                getSumaPartidas(idDoc, tcImporte, moneda);
            }
            catch (Exception err)
            {
                string er = err.Message;
            }
            finally
            {

            }
        }

        private void RecorrerArbol(TreeNode nodo)
        {
            if (nodo.GetType().Equals(Type.GetType("SistemaENMECS.BLL.Partida")))
                Mostrar((Partida)nodo);
            foreach (TreeNode unNodo in nodo.Nodes)
                RecorrerArbol(unNodo);
        }

        private void Mostrar(Partida nodo)
        {
            ListViewItem elemento = new ListViewItem(nodo.ArIdent, 0);
            elemento.SubItems.Add(nodo.DpDescripcion);
            elemento.SubItems.Add(nodo.DpCantidad.ToString());
            elemento.SubItems.Add(nodo.DpUnidad);
            elemento.SubItems.Add(nodo.DpImporte.ToString());
            listViewPartida.Items.Add(elemento);
        }

        private void treePartida_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listViewPartida.Items.Clear();
            listViewPartida.View = View.Details;
            var a = e.Node.GetType();
            var b = Type.GetType("SistemaENMECS.BLL.Partida");
            bool c = a.Equals(b);
            if (e.Node.GetType().Equals(Type.GetType("SistemaENMECS.BLL.Partida")))
                Mostrar((Partida)e.Node);
            else
                foreach (TreeNode unNodo in treePartida.SelectedNode.Nodes)
                    RecorrerArbol(unNodo);
        }

        private void contextAgregar_Click(object sender, EventArgs e)
        {
            int idPar = 0;
            DocCotPartida ventana = new DocCotPartida(idDoc, idCon, idPar, modo.insert);
            ventana.ShowDialog();

            cargaInfo();
        }

        private void treePartida_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                if (e.Node.Level == 0)
                {
                    treePartida.SelectedNode = e.Node;
                    int idx = e.Node.Index;
                    idCon = docConcepto.listDoC[idx].CoNumero;
                    contextAgregar.Visible = true;
                    contextEditar.Visible = false;
                    contextTexto.Visible = false;
                    contextPartidaCot.Visible = true;
                }
                else if (e.Node.Level == 1)
                {
                    par = new _DocCPartida();
                    treePartida.SelectedNode = e.Node;
                    int idx = e.Node.Parent.Index;
                    idCon = docConcepto.listDoC[idx].CoNumero;
                    par.DoIdent = idDoc;
                    par.CoNumero = idCon;
                    par.DpNumero = 0;
                    par.listado();
                    idPar = par.listDCP[e.Node.Index].DpNumero;
                    contextAgregar.Visible = false;
                    contextEditar.Visible = true;
                    contextTexto.Visible = false;
                    contextPartidaCot.Visible = false;
                }
            }
        }

        private void treePartida_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if(e.Node.GetType().Equals(Type.GetType("SistemaENMECS.BLL.Partida")))
            {
                Partida nodo = (Partida)e.Node;
                nodo.ArIdent = nodo.Text;
            }
        }

        private void btnConcepto_Click(object sender, EventArgs e)
        {
            DocCotConcepto ventana = new DocCotConcepto(idDoc);
            ventana.ShowDialog();

            docConcepto.DoIdent = idDoc;
            docConcepto.CoNumero = 0;
            docConcepto.listado();

            CrearNodos();
        }

        private void contextEditar_Click(object sender, EventArgs e)
        {
            DocCotPartida ventana = new DocCotPartida(idDoc, idCon, idPar, modo.update);
            ventana.ShowDialog();
            cargaInfo();
        }

        private void cargaInfo()
        {
            try
            {
                docConcepto.DoIdent = idDoc;
                docConcepto.CoNumero = 0;
                docConcepto.listado();

                int idx = 0;
                par = new _DocCPartida();
                par.DoIdent = idDoc;
                treePartida.Nodes.Clear();
                foreach (DOCCONCEPTO item in docConcepto.listDoC)
                {
                    treePartida.Nodes.Insert(idx, item.CoDescripcion);
                    TreeNode nodoRaiz = treePartida.Nodes[idx];
                    Partida nodoPartida = null;

                    par.CoNumero = item.CoNumero;
                    par.DpNumero = 0;
                    par.listado();
                    foreach (DOCCPARTIDA item00 in par.listDCP)
                    {
                        nodoPartida = new Partida(item00.ArCodigo.Trim(), item00.DpDescripcion, item00.DpCantidad, item00.DpUnidad, item00.DpImporte, item00.ArCodigo, 0, 1);
                        nodoRaiz.Nodes.Add(nodoPartida);
                    }

                    idx++;
                }
            }
            catch (Exception err)
            {
                string er = err.Message;
            }
            finally
            {

            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Cotizacion reporte = new Cotizacion();

            reporte.generaCotizacion(idDoc);

            MessageBox.Show("Cotización Generada");
        }

        private void dgNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {
                string cod = itemSelAgr = tipo00[idx];
                nota = new _Nota();
                nota.NoIdent = "";
                nota.NoTipo = cod;
                nota.listadoDocNota(idDoc);

                docNota.DoIdent = idDoc;
                docNota.DnNumero = 0;
                docNota.DnTipo = cod;
                docNota.NoIdent = "";
                docNota.listado();

                int i = 0;
                int ban;
                checkNotas.Items.Clear();
                foreach (NOTA item in nota.listNot)
                {
                    ban = 0;
                    if (docNota.listDoN != null && docNota.listDoN.Count > 0)
                    {
                        foreach (DOCNOTA subitem in docNota.listDoN)
                            if (item.NoIdent == subitem.NoIdent)
                            {
                                checkNotas.Items.Insert(i, subitem.DnDescripcion);
                                if (subitem.DnActivo == "A")
                                    checkNotas.SetItemChecked(i, true);
                                ban = 1;
                            }

                    }
                    if (ban == 0)
                        checkNotas.Items.Insert(i, item.NoDescripcion);
                    i++;
                }
                /*int i = 0;
                checkNotas.Items.Clear();
                foreach (NOTA item in nota.listNot)
                {
                    checkNotas.Items.Insert(i, item.NoDescripcion);
                    if (item.NoActivo == "A" && item.DnActivo == "A")
                    {
                        checkNotas.SetItemChecked(i, true);
                    }
                    i++;
                }*/
            }
            /*int idx = e.RowIndex;
            string cod = itemSelAgr= tipo00[idx];
            nota = new _Nota();
            nota.NoIdent = "";
            nota.NoTipo = cod;
            nota.listado();

            docNota.DoIdent = idDoc;
            docNota.DnNumero = 0;
            docNota.DnTipo = "";
            docNota.NoIdent = "";
            docNota.listado();
            
            int i = 0;
            checkNotas.Items.Clear();
            foreach (NOTA item in nota.listNot)
            {
                checkNotas.Items.Insert(i, item.NoDescripcion);
                if (docNota.listDoN != null && docNota.listDoN.Count > 0)
                {
                    foreach (DOCNOTA subitem in docNota.listDoN)
                        if (item.NoIdent == subitem.NoIdent)
                            checkNotas.SetItemChecked(i, true);
                }
                i++;
            }*/
        }

        private void checkNotas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _DocNota item = new _DocNota();
            _DocNota itemDel = new _DocNota();
            bool banNot = false;
            item.DoIdent = idDoc;
            item.DnNumero = 0;
            item.DnTipo = "";       // nota.listNot[idx - 1].NoTipo;
            item.NoIdent = "";
            item.listado();

            item.NoIdent = nota.listNot[idx].NoIdent;
            item.consultaUno();

            if (notasImp != itemSelAgr)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 0; i <= checkNotas.Items.Count - 1; i++)
                    {
                        banNot = checkNotas.GetItemChecked(i);
                        if (banNot && docNota.listDoN[i].DnTipo == itemSelAgr)
                        {
                            itemDel.DoIdent = docNota.listDoN[i].DoIdent;
                            itemDel.DnNumero = docNota.listDoN[i].DnNumero;
                            itemDel.eliminar();
                            checkNotas.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                }
            }

            if (item.DnAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    item.DoIdent = idDoc;
                    item.DnNumero = item.listDoN == null ? 1 : item.listDoN.Count + 1;
                    item.DnTipo = nota.listNot[idx].NoTipo;
                    item.DnDescripcion = nota.listNot[idx].NoDescripcion;
                    item.NoIdent = nota.listNot[idx].NoIdent;
                    item.DnOrden = 0;
                    item.DnActivo = "S";
                    item.guardar();
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (item.DnActivo == "I")
                    {
                        item.DnActivo = "A";
                        item.actualizar();
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (item.DnActivo == "A")
                        item.eliminar();
                }
            }
        }

        private void checkDirigido_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            int num = contacto.listCon[idx].CnNumero;

            if (e.NewValue == CheckState.Checked)
            {
                if (!(documento.CnNumero01 == num || documento.CnNumero02 == num || documento.CnNumero03 == num || documento.CnNumero04 == num || documento.CnNumero05 == num))
                {
                    if (documento.CnNumero01 == 0)
                        documento.CnNumero01 = num;
                    else if (documento.CnNumero02 == 0)
                        documento.CnNumero02 = num;
                    else if (documento.CnNumero03 == 0)
                        documento.CnNumero03 = num;
                    else if (documento.CnNumero04 == 0)
                        documento.CnNumero04 = num;
                    else if (documento.CnNumero05 == 0)
                        documento.CnNumero05 = num;
                    documento.actualizar();
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (!(documento.CnNumero01 == 0 && documento.CnNumero02 == 0 && documento.CnNumero03 == 0 && documento.CnNumero04 == 0 && documento.CnNumero05 == 0))
                {
                    if (documento.CnNumero01 == num)
                        documento.CnNumero01 = 0;
                    else if (documento.CnNumero02 == num)
                        documento.CnNumero02 = 0;
                    else if (documento.CnNumero03 == num)
                        documento.CnNumero03 = 0;
                    else if (documento.CnNumero04 == num)
                        documento.CnNumero04 = 0;
                    else if (documento.CnNumero05 == num)
                        documento.CnNumero05 = 0;
                    documento.actualizar();
                }
            }
        }

        private void dgNotas_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            documento.DoTiCambio = Convert.ToDouble(txtTipoC.Text);
            documento.DoReferencia = txtRef.Text;
            documento.DoDescripcion = txtDescCot.Text.Trim();
            documento.DoSubTotalMoE = 0;
            documento.DoMonEx = "";
            documento.DoMoneda = cbMoneda.SelectedIndex == 1 ? "MXN" : (cbMoneda.SelectedIndex == 2 ? "USD" : documento.DoMoneda);

            documento.DoSubTotal = Convert.ToDouble(txtSubTotalPre.Text);
            documento.DoDesc = Convert.ToDouble(txtImpDescPre.Text);
            documento.DoPjDesc = Convert.ToDouble(txtPjDescPre.Text);
            documento.DoTipoDesc = "";
            documento.DoSubTDesc = Convert.ToDouble(txtSubTotalD.Text);
            documento.DoImpuesto = Convert.ToInt32(txtIVA.Text);
            documento.DoImpImp = Convert.ToDouble(txtImpIVA.Text);
            documento.DoTotal = Convert.ToDouble(txtTotal.Text);

            documento.actualizar();

            if (calventa.CvOportunidad == null)
            {
                calventa.DoIdent = documento.DoIdent;
                calventa.CvPresupuesto = cbPresupuesto.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvAutoridad = cbAutoridad.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvNecesidad = cbNecesidad.SelectedIndex > 0 ? cbNecesidad.SelectedIndex : 0;
                calventa.CvTiempo = cbTiempo.SelectedIndex > 0 ? cbTiempo.SelectedIndex : 0;
                calventa.CvCalificacion = calventa.CvPresupuesto + calventa.CvAutoridad + calventa.CvNecesidad + calventa.CvTiempo;
                if (calventa.CvCalificacion >= 1 && calventa.CvCalificacion <= 5)
                    calventa.CvOportunidad = calventa.oportunidad[0];
                else if (calventa.CvCalificacion >= 6 && calventa.CvCalificacion <= 10)
                    calventa.CvOportunidad = calventa.oportunidad[1];
                else if (calventa.CvCalificacion >= 11 && calventa.CvCalificacion <= 15)
                    calventa.CvOportunidad = calventa.oportunidad[2];
                else if (calventa.CvCalificacion >= 15 && calventa.CvCalificacion <= 20)
                    calventa.CvOportunidad = calventa.oportunidad[3];
                calventa.guardar();
            }
            else
            {
                calventa.DoIdent = documento.DoIdent;
                calventa.CvPresupuesto = cbPresupuesto.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvAutoridad = cbAutoridad.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvNecesidad = cbNecesidad.SelectedIndex > 0 ? cbNecesidad.SelectedIndex : 0;
                calventa.CvTiempo = cbTiempo.SelectedIndex > 0 ? cbTiempo.SelectedIndex : 0;
                calventa.CvCalificacion = calventa.CvPresupuesto + calventa.CvAutoridad + calventa.CvNecesidad + calventa.CvTiempo;
                if (calventa.CvCalificacion >= 1 && calventa.CvCalificacion <= 5)
                    calventa.CvOportunidad = calventa.oportunidad[0];
                else if (calventa.CvCalificacion >= 6 && calventa.CvCalificacion <= 10)
                    calventa.CvOportunidad = calventa.oportunidad[1];
                else if (calventa.CvCalificacion >= 11 && calventa.CvCalificacion <= 15)
                    calventa.CvOportunidad = calventa.oportunidad[2];
                else if (calventa.CvCalificacion >= 15 && calventa.CvCalificacion <= 20)
                    calventa.CvOportunidad = calventa.oportunidad[3];
                calventa.actualizar();
            }
        }

        private void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConversionMoneda();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            documento.DoEstatus = "ENVIO";
            documento.actualizar();

            btnGuardar.Visible = false;
            btnNew.Visible = false;
            btnRevisar.Visible = true;
            btnCancel.Visible = true;
            btnAprove.Visible = true;
        }

        private void guardarDoc()
        {
            documento.DoMoneda = cbMoneda.SelectedIndex == 1 ? "MXN" : (cbMoneda.SelectedIndex == 2 ? "USD" : "");
        }

        private void btnTipoC_Click(object sender, EventArgs e)
        {
            SeekTipoCambio seekVentana = new SeekTipoCambio();
            seekVentana.ShowDialog();
            _TipoCambio tp = seekVentana.tipoCambio;
            txtTipoC.Text = seekVentana.tipoCambio.TcImporte.ToString().Trim();
            txtRef.Text = seekVentana.tipoCambio.TcIdent.Trim();

            ConversionMoneda();
        }

        private void cbPresupuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPresupuesto.SelectedIndex > 0 && cbAutoridad.SelectedIndex > 0 && cbNecesidad.SelectedIndex > 0 && cbTiempo.SelectedIndex > 0)
            {
                int calif = (cbPresupuesto.SelectedIndex) + (cbAutoridad.SelectedIndex) + (cbNecesidad.SelectedIndex) + (cbTiempo.SelectedIndex);
                if (calif >= 1 && calif <= 5)
                {
                    lblOp00.Text = calventa.oportunidad[0];
                    lblInt00.Text = calventa.interes[0];
                    lblPlan00.Text = calventa.plan[0];
                    lblNorte00.Text = calventa.norte[0];
                }
                else if (calif >= 6 && calif <= 10)
                {
                    lblOp00.Text = calventa.oportunidad[1];
                    lblInt00.Text = calventa.interes[1];
                    lblPlan00.Text = calventa.plan[1];
                    lblNorte00.Text = calventa.norte[1];
                }
                else if (calif >= 11 && calif <= 15)
                {
                    lblOp00.Text = calventa.oportunidad[2];
                    lblInt00.Text = calventa.interes[2];
                    lblPlan00.Text = calventa.plan[2];
                    lblNorte00.Text = calventa.norte[2];
                }
                else if (calif >= 16 && calif <= 20)
                {
                    lblOp00.Text = calventa.oportunidad[3];
                    lblInt00.Text = calventa.interes[3];
                    lblPlan00.Text = calventa.plan[3];
                    lblNorte00.Text = calventa.norte[3];
                }

                /*double pj = calif * 100 / 20;
                pj = Math.Round(pj, 2);
                lblCal00.Text = pj.ToString().Trim() + " %";*/
            }
        }

        private void cbAutoridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPresupuesto.SelectedIndex > 0 && cbAutoridad.SelectedIndex > 0 && cbNecesidad.SelectedIndex > 0 && cbTiempo.SelectedIndex > 0)
            {
                int calif = (cbPresupuesto.SelectedIndex) + (cbAutoridad.SelectedIndex) + (cbNecesidad.SelectedIndex) + (cbTiempo.SelectedIndex);
                if (calif >= 1 && calif <= 5)
                {
                    lblOp00.Text = calventa.oportunidad[0];
                    lblInt00.Text = calventa.interes[0];
                    lblPlan00.Text = calventa.plan[0];
                    lblNorte00.Text = calventa.norte[0];
                }
                else if (calif >= 6 && calif <= 10)
                {
                    lblOp00.Text = calventa.oportunidad[1];
                    lblInt00.Text = calventa.interes[1];
                    lblPlan00.Text = calventa.plan[1];
                    lblNorte00.Text = calventa.norte[1];
                }
                else if (calif >= 11 && calif <= 15)
                {
                    lblOp00.Text = calventa.oportunidad[2];
                    lblInt00.Text = calventa.interes[2];
                    lblPlan00.Text = calventa.plan[2];
                    lblNorte00.Text = calventa.norte[2];
                }
                else if (calif >= 16 && calif <= 20)
                {
                    lblOp00.Text = calventa.oportunidad[3];
                    lblInt00.Text = calventa.interes[3];
                    lblPlan00.Text = calventa.plan[3];
                    lblNorte00.Text = calventa.norte[3];
                }

                /*double pj = calif * 100 / 20;
                pj = Math.Round(pj, 2);
                lblCal00.Text = pj.ToString().Trim() + " %";*/
            }
        }

        private void cbNecesidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPresupuesto.SelectedIndex > 0 && cbAutoridad.SelectedIndex > 0 && cbNecesidad.SelectedIndex > 0 && cbTiempo.SelectedIndex > 0)
            {
                int calif = (cbPresupuesto.SelectedIndex) + (cbAutoridad.SelectedIndex) + (cbNecesidad.SelectedIndex) + (cbTiempo.SelectedIndex);
                if (calif >= 1 && calif <= 5)
                {
                    lblOp00.Text = calventa.oportunidad[0];
                    lblInt00.Text = calventa.interes[0];
                    lblPlan00.Text = calventa.plan[0];
                    lblNorte00.Text = calventa.norte[0];
                }
                else if (calif >= 6 && calif <= 10)
                {
                    lblOp00.Text = calventa.oportunidad[1];
                    lblInt00.Text = calventa.interes[1];
                    lblPlan00.Text = calventa.plan[1];
                    lblNorte00.Text = calventa.norte[1];
                }
                else if (calif >= 11 && calif <= 15)
                {
                    lblOp00.Text = calventa.oportunidad[2];
                    lblInt00.Text = calventa.interes[2];
                    lblPlan00.Text = calventa.plan[2];
                    lblNorte00.Text = calventa.norte[2];
                }
                else if (calif >= 16 && calif <= 20)
                {
                    lblOp00.Text = calventa.oportunidad[3];
                    lblInt00.Text = calventa.interes[3];
                    lblPlan00.Text = calventa.plan[3];
                    lblNorte00.Text = calventa.norte[3];
                }

                /*double pj = calif * 100 / 20;
                pj = Math.Round(pj, 2);
                lblCal00.Text = pj.ToString().Trim() + " %";*/
            }
        }

        private void cbTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPresupuesto.SelectedIndex > 0 && cbAutoridad.SelectedIndex > 0 && cbNecesidad.SelectedIndex > 0 && cbTiempo.SelectedIndex > 0)
            {
                int calif = (cbPresupuesto.SelectedIndex) + (cbAutoridad.SelectedIndex) + (cbNecesidad.SelectedIndex) + (cbTiempo.SelectedIndex);
                if (calif >= 1 && calif <= 5)
                    lblOp00.Text = calventa.oportunidad[0];
                else if (calif >= 6 && calif <= 10)
                    lblOp00.Text = calventa.oportunidad[1];
                else if (calif >= 11 && calif <= 15)
                    lblOp00.Text = calventa.oportunidad[2];
                else if (calif >= 16 && calif <= 20)
                    lblOp00.Text = calventa.oportunidad[3];

                /*double pj = calif * 100 / 20;
                pj = Math.Round(pj, 2);
                lblCal00.Text = pj.ToString().Trim() + " %";*/
            }
        }

        private void checkNotas_DoubleClick(object sender, EventArgs e)
        {

        }

        private void contextTexto_Click(object sender, EventArgs e)
        {
            int idx = checkNotas.SelectedIndex;
            if (itemSelAgr != "DCCTE")
            {
                string NoDescripcion = nota.listNot[idx].NoDescripcion;
                Texto ventana = new Texto(NoDescripcion);
                ventana.ShowDialog();
            }
            else
            {
                string DoIdent = nota.listNot[idx].DoIdent;
                string NoIdent = nota.listNot[idx].NoIdent;
                int DnNumero = nota.listNot[idx].DnNumero;
                TextoEdit ventana = new TextoEdit(DoIdent, NoIdent, DnNumero, DnNumero > 0 ? modo.update : modo.select);
                ventana.ShowDialog();

                docNota.DoIdent = idDoc;
                docNota.DnNumero = 0;
                docNota.DnTipo = itemSelAgr;
                docNota.NoIdent = "";
                docNota.listado();

                int i = 0;
                int ban;
                checkNotas.Items.Clear();
                foreach (NOTA item in nota.listNot)
                {
                    ban = 0;
                    if (docNota.listDoN != null && docNota.listDoN.Count > 0)
                    {
                        foreach (DOCNOTA subitem in docNota.listDoN)
                            if (item.NoIdent == subitem.NoIdent)
                            {
                                checkNotas.Items.Insert(i, subitem.DnDescripcion);
                                if (subitem.DnActivo == "A")
                                    checkNotas.SetItemChecked(i, true);
                                ban = 1;
                            }

                    }
                    if (ban == 0)
                        checkNotas.Items.Insert(i, item.NoDescripcion);
                    i++;
                }
            }
        }

        private void checkNotas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                contextAgregar.Visible = false;
                contextEditar.Visible = false;
                contextTexto.Visible = true;
                contextPartidaCot.Visible = false;
            }
        }

        private void lblTiempo_Click(object sender, EventArgs e)
        {

        }

        private void gbReporte_Enter(object sender, EventArgs e)
        {

        }

        private void btnOpVta_Click(object sender, EventArgs e)
        {
            Cotizacion reporte = new Cotizacion();

            reporte.generaBateo();

            MessageBox.Show("Reporte Generado");
        }

        private void contextPartidaCot_Click(object sender, EventArgs e)
        {
            _DocCPartida copiaPartida;
            _DocCPartida newPartida = new _DocCPartida();
            SeekPartidaDoc ventana = new SeekPartidaDoc();
            ventana.ShowDialog();
            if (ventana.partida.DpAudUsuCre != null)
            {
                copiaPartida = ventana.partida;
                newPartida.DoIdent = idDoc;
                newPartida.CoNumero = idCon;
                newPartida.DpNumero = 0;
                newPartida.listado();
                
                newPartida.DpNumero = newPartida.listDCP.Count + 1;
                newPartida.ArIdent = copiaPartida.ArIdent;
                newPartida.DiNumero = copiaPartida.DiNumero;
                newPartida.DpDescripcion = copiaPartida.DpDescripcion;
                newPartida.DpCantidad = copiaPartida.DpCantidad;
                newPartida.DpUnidad = copiaPartida.DpUnidad;
                newPartida.DpCosto = copiaPartida.DpCosto;
                newPartida.DpPjCosto = copiaPartida.DpPjCosto;
                newPartida.DpPrecio = copiaPartida.DpPrecio;
                newPartida.DpSubtotal = copiaPartida.DpSubtotal;
                newPartida.DpPjDesc = copiaPartida.DpPjDesc;

                newPartida.DpImpDesc = copiaPartida.DpImpDesc;
                newPartida.DpImporteMoE = copiaPartida.DpImporteMoE;
                newPartida.DpMonEx = copiaPartida.DpMonEx;
                newPartida.DpImporte = copiaPartida.DpImporte;
                newPartida.DpTratamiento = copiaPartida.DpTratamiento;
                newPartida.DpEstatus = "PEND";
                newPartida.DpAvance = 0;
                newPartida.DpReferencia = copiaPartida.DoIdent.Trim() + "|" + copiaPartida.CoNumero.ToString().Trim() + "|" + copiaPartida.DpNumero.ToString().Trim();
                newPartida.DpFabricado = copiaPartida.DpFabricado;
                newPartida.DpOrden = copiaPartida.DpOrden;
                newPartida.DpActivo = "A";
                newPartida.guardar();

                _DocCPNota docCPNota = new _DocCPNota();
                docCPNota.DoIdent = copiaPartida.DoIdent;
                docCPNota.CoNumero = copiaPartida.CoNumero;
                docCPNota.DpNumero = copiaPartida.DpNumero;
                docCPNota.DtNumero = 0;
                docCPNota.DtTipo = "";
                docCPNota.NoIdent = "";
                docCPNota.DtArIdent = "";
                docCPNota.DtAnNumero = 0;
                docCPNota.listado();

                foreach (DOCCPNOTA item in docCPNota.listDPN)
                {
                    docCPNota.DoIdent = newPartida.DoIdent;
                    docCPNota.CoNumero = newPartida.CoNumero;
                    docCPNota.DpNumero = newPartida.DpNumero;
                    docCPNota.DtNumero = item.DtNumero;
                    docCPNota.DtDescripcion = item.DtDescripcion;
                    docCPNota.DtTipo = item.DtTipo;
                    docCPNota.DtOrden = item.DtOrden;
                    docCPNota.NoIdent = item.NoIdent;
                    docCPNota.DtArIdent = item.DtArIdent;
                    docCPNota.DtAnNumero = item.DtAnNumero;
                    docCPNota.DtActivo = "A";
                    docCPNota.guardar();
                }

                CrearNodos();
            }
        }

        private void listViewPartida_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                contextAgregar.Visible = false;
                contextEditar.Visible = true;
                contextTexto.Visible = false;
                contextPartidaCot.Visible = false;

                par.DoIdent = idDoc;
                par.CoNumero = idCon;
                par.DpNumero = 0;
                par.listado();
                idPar = par.listDCP[listViewPartida.SelectedItems[0].Index].DpNumero;
            }
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if (documento.DoEstatus == "ENVIO")                 //EDITA SIN HABER GENERADO DOCUMENTO
            {
                documento.DoEstatus = "EDITA";

                documento.actualizar();

                btnGuardar.Visible = true;
                btnNew.Visible = true;
                btnRevisar.Visible = false;
                btnCancel.Visible = true;
                btnAprove.Visible = false;
            }
            else if (documento.DoEstatus == "ENVIR")            //EL DOCUMENTO SE GENERO, SI SE EDITA, SE GENERA NUEVO DOCUMENTO
            {
                documento.DoEstatus = "GUARD";
                documento.actualizar();
                //NUEVO DOCUMENTO CON VERSIONADO
            }
        }

        private void getTipoCambio()
        {
            string feIni = DateTime.Today.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Year.ToString().Trim() + " 00:00:00";
            string feFin = DateTime.Today.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Year.ToString().Trim() + " 23:59:59";
            _TipoCambio tc = new _TipoCambio();
            tc.TcIdent = "";
            tc.FeIni = Convert.ToDateTime(feIni);
            tc.FeFin = Convert.ToDateTime(feFin);
            tc.listado();
            if (tc.listTiC[0].TcIdent == null && documento.DoTiCambio == 0)
                MessageBox.Show("No hay registrado tipo de cambio para el día de hoy.");
            else if ((tc.listTiC[0].TcIdent != null && tc.listTiC[0].TcIdent != "") && documento.DoTiCambio == 0)
                txtTipoC.Text = tc.listTiC[0].TcImporte.ToString("N2");

        }

        private void txtPjDescPre_TextChanged(object sender, EventArgs e)
        {
            if (txtPjDescPre.Text != "" && calculoPrecio == 0)
            {
                calculoPrecio = 1;
                double pjDesc = Convert.ToDouble(txtPjDescPre.Text);
                if (pjDesc > 0)
                {
                    double subTotal = Convert.ToDouble(txtSubTotalPre.Text);
                    double impDesc = Math.Round(subTotal * (pjDesc / 100), 2);
                    txtImpDescPre.Text = impDesc.ToString();
                    double subTotalD = subTotal + impDesc;

                    txtSubTotalD.Text = subTotalD.ToString();
                    IVA = Convert.ToDouble(txtIVA.Text);
                    double impIVA = subTotalD * (IVA / 100);
                    txtImpIVA.Text = impIVA.ToString();
                    totalMN = subTotalD + impIVA;
                    txtTotal.Text = totalMN.ToString();
                    totalME = totalMN / Convert.ToDouble(txtTipoC.Text);
                    txtTotalEx.Text = totalME.ToString();
                }
                calculoPrecio = 0;
            }
        }

        private void txtImpDescPre_TextChanged(object sender, EventArgs e)
        {
            if(txtImpDescPre.Text != "" && calculoPrecio == 0)
            {
                calculoPrecio = 2;
                double impDesc = Convert.ToDouble(txtImpDescPre.Text);
                if (impDesc > 0)
                {
                    double subTotal = Convert.ToDouble(txtSubTotalPre.Text);
                    double pjDesc = Math.Round(subTotal * 100 / impDesc, 2);
                    txtPjDescPre.Text = pjDesc.ToString();
                    impDesc = Math.Round(subTotal * (pjDesc / 100), 2);
                    txtImpDescPre.Text = impDesc.ToString();

                    double subTotalD = subTotal + impDesc;
                    txtSubTotalD.Text = subTotalD.ToString();
                    IVA = Convert.ToDouble(txtIVA.Text);
                    double impIVA = subTotalD * (IVA / 100);
                    txtImpIVA.Text = impIVA.ToString();
                    totalMN = subTotalD + impIVA;
                    txtTotal.Text = totalMN.ToString();
                    totalME = totalMN / Convert.ToDouble(txtTipoC.Text);
                    txtTotalEx.Text = totalME.ToString();
                }
                calculoPrecio = 0;
            }
        }

        private void btnActFol_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            txtFechaFol.Text = hoy.ToString().Substring(0, 10);
            txtVerFol.Text = txtVersion.Text;
            string[] ini = txtFolio.Text.Split('-');
            txtFolioFol.Text = ini[0] + "-" + txtFechaFol.Text.Substring(8, 2) + txtFechaFol.Text.Substring(3, 2) + txtFechaFol.Text.Substring(0, 2) + "-" + ini[2];
        }

        private void btnGuardarFol_Click(object sender, EventArgs e)
        {
            if (txtFechaFol.Text != "" && txtFolioFol.Text != "")
            {
                documento.DoFecha = Convert.ToDateTime(txtFechaFol.Text);
                documento.DoVersionL = txtVerFol.Text.Substring(0, 1);
                documento.DoVersion = Convert.ToInt32(txtVerFol.Text.Substring(1, (txtVerFol.Text.Length - 1)));
                documento.DoFolio = txtFolioFol.Text.Trim();
                documento.actualizar();
            }
        }

        private void txtTipoC_Leave(object sender, EventArgs e)
        {
            ConversionMoneda();
        }
                
        private void getSumaPartidas(string docFolio, double tcImporte, string moneda)
        {
            _DocCPartida partidas = new _DocCPartida();
            partidas.DoIdent = docFolio;
            partidas.CoNumero = 0;
            partidas.DpNumero = 0;
            partidas.listado();

            double subtMN = 0, subtMNT = 0;
            double subtME = 0, subtMET = 0;
            double subtCO = 0, subTT = 0;

            foreach (DOCCPARTIDA item in partidas.listDCP)
            {
                if (item.DpMonEx == "MXN")
                    subtMN += (item.DpPrecio * item.DpCantidad);
                else
                    subtME += (item.DpPrecio * item.DpCantidad);
            }
            txtSubTotalPreMXN.Text = subtMN.ToString();
            txtSubTotalPreMOE.Text = subtME.ToString();
            if (calculoPrecio == 0)
            {
                calculoPrecio = 3;

                if (moneda == "MXN")
                {
                    subtCO = subtME * tcImporte;
                    subTT = subtMNT = Math.Round((subtMN + subtCO), 2);
                    txtSubTotalPre.Text = subTT.ToString();
                }
                else if (moneda == "USD")
                {
                    if (subtME > 0)
                        subtCO = subtMN / tcImporte;
                    subTT = subtMET = Math.Round((subtME + subtCO), 2);
                    txtSubTotalPre.Text = subTT.ToString();
                }
                txtPjDescPre.Text = txtPjDescPre.Text == "" ? "0" : txtPjDescPre.Text;
                double pjDesc = Convert.ToDouble(txtPjDescPre.Text);
                double impDesc = 0;
                double subTotalD = 0;
                if (pjDesc > 0)
                {
                    impDesc = Math.Round(subTT * (pjDesc / 100), 2);
                    txtImpDescPre.Text = impDesc.ToString();
                }
                subTotalD = subTT + impDesc;
                txtSubTotalD.Text = subTotalD.ToString();
                IVA = Convert.ToDouble(txtIVA.Text);
                double impIVA = subTotalD * (IVA / 100);
                txtImpIVA.Text = impIVA.ToString();
                totalMN = subTotalD + impIVA;
                txtTotal.Text = totalMN.ToString();
                double tipoCam = Convert.ToDouble(txtTipoC.Text);
                if (tipoCam > 0)
                    totalME = totalMN / tipoCam;
                else
                    totalME = 0;
                txtTotalEx.Text = totalME.ToString();

                calculoPrecio = 0;
            }
        }

        private void btnGuardarOp_Click(object sender, EventArgs e)
        {
            if (calventa.CvOportunidad == null)
            {
                calventa.DoIdent = documento.DoIdent;
                calventa.CvPresupuesto = cbPresupuesto.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvAutoridad = cbAutoridad.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvNecesidad = cbNecesidad.SelectedIndex > 0 ? cbNecesidad.SelectedIndex : 0;
                calventa.CvTiempo = cbTiempo.SelectedIndex > 0 ? cbTiempo.SelectedIndex : 0;
                calventa.CvCalificacion = calventa.CvPresupuesto + calventa.CvAutoridad + calventa.CvNecesidad + calventa.CvTiempo;
                if (calventa.CvCalificacion >= 1 && calventa.CvCalificacion <= 5)
                    calventa.CvOportunidad = calventa.oportunidad[0];
                else if (calventa.CvCalificacion >= 6 && calventa.CvCalificacion <= 10)
                    calventa.CvOportunidad = calventa.oportunidad[1];
                else if (calventa.CvCalificacion >= 11 && calventa.CvCalificacion <= 15)
                    calventa.CvOportunidad = calventa.oportunidad[2];
                else if (calventa.CvCalificacion >= 15 && calventa.CvCalificacion <= 20)
                    calventa.CvOportunidad = calventa.oportunidad[3];
                calventa.guardar();
            }
            else
            {
                calventa.DoIdent = documento.DoIdent;
                calventa.CvPresupuesto = cbPresupuesto.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvAutoridad = cbAutoridad.SelectedIndex > 0 ? cbPresupuesto.SelectedIndex : 0;
                calventa.CvNecesidad = cbNecesidad.SelectedIndex > 0 ? cbNecesidad.SelectedIndex : 0;
                calventa.CvTiempo = cbTiempo.SelectedIndex > 0 ? cbTiempo.SelectedIndex : 0;
                calventa.CvCalificacion = calventa.CvPresupuesto + calventa.CvAutoridad + calventa.CvNecesidad + calventa.CvTiempo;
                if (calventa.CvCalificacion >= 1 && calventa.CvCalificacion <= 5)
                    calventa.CvOportunidad = calventa.oportunidad[0];
                else if (calventa.CvCalificacion >= 6 && calventa.CvCalificacion <= 10)
                    calventa.CvOportunidad = calventa.oportunidad[1];
                else if (calventa.CvCalificacion >= 11 && calventa.CvCalificacion <= 15)
                    calventa.CvOportunidad = calventa.oportunidad[2];
                else if (calventa.CvCalificacion >= 15 && calventa.CvCalificacion <= 20)
                    calventa.CvOportunidad = calventa.oportunidad[3];
                calventa.actualizar();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            documento.DoEstatus = "CANCE";
            documento.actualizar();

            btnGuardar.Visible = false;
            btnNew.Visible = false;
            btnRevisar.Visible = false;
            btnCancel.Visible = false;
            btnAprove.Visible = false;
        }

        private void btnAprove_Click(object sender, EventArgs e)
        {
            documento.DoEstatus = "APROB";
            documento.actualizar();

            btnGuardar.Visible = false;
            btnNew.Visible = false;
            btnRevisar.Visible = true;
            btnCancel.Visible = true;
            btnAprove.Visible = false;
        }

        private void ConversionMoneda()
        {
            double subTMX = Convert.ToDouble(txtSubTotalPreMXN.Text);
            double subTUS = Convert.ToDouble(txtSubTotalPreMOE.Text);
            double tipoCam = Convert.ToDouble(txtTipoC.Text);
            string moneda = cbMoneda.SelectedIndex == 2 ? "USD" : "MXN";

            getSumaPartidas(idDoc, tipoCam, moneda);

            if (cbMoneda.SelectedIndex == 1)
            {
                if (tipoCam > 0 && subTUS > 0)
                {
                    subTMX = Math.Round(subTMX + (subTUS * tipoCam), 4);
                    txtSubTotalPre.Text = subTMX.ToString();
                }
                else if (tipoCam == 0 && subTUS > 0)
                {
                    MessageBox.Show("Es necesario seleccionar un tipo de cambio, porque la Moneda esta en MXN");
                    txtSubTotalPre.Text = "0";
                }
            }
            else if (cbMoneda.SelectedIndex == 2)
            {
                if (tipoCam > 0 && subTMX > 0)
                {
                    subTUS = Math.Round(subTUS + (subTMX / tipoCam), 4);
                    txtSubTotalPre.Text = subTUS.ToString();
                }
                else if (tipoCam == 0 && subTMX > 0)
                {
                    MessageBox.Show("Es necesario seleccionar un tipo de cambio, porque la Moneda esta en USD");
                    txtSubTotalPre.Text = "0";
                }
            }
        }
    }
}
