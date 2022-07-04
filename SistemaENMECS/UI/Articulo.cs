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
    public partial class Articulo : Form
    {
        private _Articulo articulo = new _Articulo();
        private _Categoria categoria = new _Categoria();
        private _Folio folio = new _Folio();
        private _CategoriaPrv categoriaPrv = new _CategoriaPrv();
        private _PrecioLista precioLista = new _PrecioLista();
        private _ArtNota artnotaC = new _ArtNota();
        private _ArtNota artnotaI = new _ArtNota();
        private _ArtNota artnotaN = new _ArtNota();
        private _CatNota catnotaC = new _CatNota();
        private _CatNota catnotaI = new _CatNota();
        private _CatNota catnotaN = new _CatNota();
        private string idAr;
        private int fol = 0, idxC, idxI, idxN, idxPL = -1;
        private CheckState checkSC, checkSI, checkSN;
        private List<ARTNOTA> descC = new List<ARTNOTA>(), descI = new List<ARTNOTA>(), descN = new List<ARTNOTA>();
        modo m;
        private List<int> iC = new List<int>();
        private List<int> iI = new List<int>();
        private List<int> iN = new List<int>();
        private string[] clas00 = new string[] { "PRO", "SER", "ACC", "REF", "CON" };
        private string[] clas01 = new string[] { "Producto", "Servicio", "Accesorio", "Refacción", "Consumible" };
        private string[] cat00 = new string[] { "VEN", "AIL", "AIA", "REF" };
        private string[] cat01 = new string[] { "Ventilación", "Aire Lavado", "Aire Acondicionado", "Refrigeración" };
        private string[] uso00 = new string[] { "INY", "EXT", "IE" };
        private string[] uso01 = new string[] { "Inyección", "Extracción", "Iny/Ext" };
        private DataTable dtPrv = new DataTable();

        public Articulo(string ArIdent, modo mod)
        {
            InitializeComponent();

            idAr = ArIdent;
            m = mod;

            categoria.CaIdent = "";
            categoria.listado();
            txtIdent.ReadOnly = true;
            btnListCli.Visible = false;

            if (modo.update == m)
            {
                articulo.ArIdent = idAr;
                articulo.ArCodigo = "";
                articulo.ArDescripcion = "";
                articulo.ArClasificacion = "";
                articulo.ArModeloCom = "";
                articulo.ArMarca = "";
                articulo.consultaUno();

                artnotaC.ArIdent = idAr;
                artnotaC.AnNumero = 0;
                artnotaC.AnTipo = "PCARA";
                artnotaC.NoIdent = "";
                artnotaC.AnCaIdent = "";
                artnotaC.AnCtNumero = 0;
                artnotaC.listado();
                
                artnotaI.ArIdent = idAr;
                artnotaI.AnNumero = 0;
                artnotaI.AnTipo = "PINCL";
                artnotaI.NoIdent = "";
                artnotaI.AnCaIdent = "";
                artnotaI.AnCtNumero = 0;
                artnotaI.listado();

                artnotaN.ArIdent = idAr;
                artnotaN.AnNumero = 0;
                artnotaN.AnTipo = "PNINC";
                artnotaN.NoIdent = "";
                artnotaN.AnCaIdent = "";
                artnotaN.AnCtNumero = 0;
                artnotaN.listado();

                btnListCli.Visible = true;
            }
        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            /*cbMoneda.Items.Clear();
            cbMoneda.Items.Insert(0, "<Selección>");
            cbMoneda.Items.Insert(1, "MXP");
            cbMoneda.Items.Insert(2, "USD");
            cbMoneda.SelectedIndex = 0;*/

            int idx = 1;
            cbClasif.Items.Clear();
            cbClasif.Items.Insert(0, "<Selección>");
            foreach (string item in clas01)
            {
                cbClasif.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
                cbClasif.SelectedIndex = 0;

            idx = 1;
            cbCategoria.Items.Clear();
            cbCategoria.Items.Insert(0, "<Selección>");
            foreach (string item in cat01)
            {
                cbCategoria.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
                cbCategoria.SelectedIndex = 0;

            idx = 1;
            cbUso.Items.Clear();
            cbUso.Items.Insert(0, "<Selección>");
            foreach (string item in uso01)
            {
                cbUso.Items.Insert(idx, item);
                idx++;
            }
            if (idx > 1)
                cbUso.SelectedIndex = 0;

            idx = 1;
            cbMonPrv.Items.Clear();
            cbMonPrv.Items.Insert(0, "<Selección>");
            cbMonPrv.Items.Insert(1, "MXN");
            cbMonPrv.Items.Insert(2, "USD");
            cbMonPrv.SelectedIndex = 0;

            gbPrecio.Visible = false;

            idx = 1;
            int sel = 0;
            cbGen.Items.Clear();
            cbGen.Items.Insert(0, "<Selección>");
            foreach (CATEGORIA item in categoria.listCat)
            {
                cbGen.Items.Insert(idx, item.CaDescripcion);
                if (modo.update == m && item.CaIdent == articulo.ArGenerico)
                    sel = idx;
                idx++;
            }
            if (idx > 1)
                cbGen.SelectedIndex = 0;

            if (modo.update == m)
            {
                cbClasif.SelectedIndex = Array.IndexOf(clas00, articulo.ArClasificacion) + 1;
                cbCategoria.SelectedIndex = Array.IndexOf(cat00, articulo.ArCategoria) + 1;
                cbUso.SelectedIndex = Array.IndexOf(uso00, articulo.ArUso.Trim()) + 1;
                cbGen.SelectedIndex = sel;
                txtIdent.Text = articulo.ArIdent.ToString().Trim();
                txtCodigo.Text = articulo.ArCodigo.Trim();
                txtCodCom.Text = articulo.ArCodCom.Trim();
                txtDesc.Text = articulo.ArDescripcion.Trim();
                /*txtPrecio.Text = articulo.ArPrecioPub.ToString().Trim();
                cbMoneda.SelectedIndex = articulo.ArMoneda == "MXP" ? 1 : (articulo.ArMoneda == "USD" ? 2 : 0);*/
                txtUnidad.Text = articulo.ArUnidad.Trim();
                txtTipo.Text = articulo.ArTipo.Trim();
                txtModCom.Text = articulo.ArModeloCom.Trim();
                txtMarca.Text = articulo.ArMarca.Trim();
                txtPeso.Text = articulo.ArPeso;
                txtAlto.Text = articulo.ArAlto;
                txtLargo.Text = articulo.ArLargo;
                txtAncho.Text = articulo.ArAncho;
                checkActivo.Checked = articulo.ArActivo == "A" ? true : false;

                categoriaPrv.DiNumero = "";
                categoriaPrv.CaIdent = categoria.listCat[sel - 1].CaIdent;
                categoriaPrv.listado();

                idx = 0;
                listPrvCat.Items.Clear();
                foreach (CATEGORIAPRV item in categoriaPrv.listCtp)
                {
                    listPrvCat.Items.Insert(idx, item.DiNombreCom);
                    idx++;
                }

                precioLista.ArIdent = idAr;
                precioLista.DiNumero = "";
                precioLista.listado();

                dtPrv.Columns.Add(new DataColumn("Nombre", typeof(string)));
                dtPrv.Columns.Add(new DataColumn("Precio", typeof(string)));
                dtPrv.Columns.Add(new DataColumn("Moneda", typeof(string)));
                dtPrv.Columns.Add(new DataColumn("Fecha", typeof(string)));
                foreach (PRECIOLISTA item in precioLista.listPrl)
                {
                    DateTime fec = item.PlAudFeMod.Year == 1 ? item.PlAudFeCre : item.PlAudFeMod;
                    DataRow dr = dtPrv.NewRow();
                    dr["Nombre"] = item.DiNomCorto;
                    dr["Precio"] = item.PlPrecioLista.ToString();
                    dr["Moneda"] = item.PlMoneda;
                    dr["Fecha"] = fec.Day.ToString().PadLeft(2, '0') + "/" + fec.Month.ToString().PadLeft(2, '0') + "/" + fec.Year.ToString();
                    dtPrv.Rows.Add(dr);
                }
                dgPrvLP.DataSource = dtPrv;
                
                txtCodigo.ReadOnly = true;
                cbClasif.Enabled = false;
                btnEspeci.Visible = false;
            }
            else
            {
                checkActivo.CheckState = CheckState.Checked;
                //txtPrecio.Text = "0.00";
                btnEspeci.Visible = true;
            }
            
            lblCDesc.Visible = false;
            txtCDesc.Visible = false;
            btnCSave.Visible = false;

            lblIDesc.Visible = false;
            txtIDesc.Visible = false;
            btnISave.Visible = false;

            lblNDesc.Visible = false;
            txtNDesc.Visible = false;
            btnNSave.Visible = false;
        }

        private void cbClasif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClasif.SelectedIndex > 0)
            {
                int idx = cbClasif.SelectedIndex - 1;
                if (clas00[idx] == "SER")
                {
                    lblCCo.Visible = false;
                    txtCodCom.Visible = false;
                    lblMCo.Visible = false;
                    txtModCom.Visible = false;
                    lblMar.Visible = false;
                    txtMarca.Visible = false;
                    lblCat.Visible = false;
                    cbCategoria.Visible = false;
                    lblUso.Visible = false;
                    cbUso.Visible = false;
                    lblTipo.Visible = false;
                    txtTipo.Visible = false;
                    lblGen.Visible = false;
                    cbGen.Visible = false;

                    if (txtIdent.Text == "")
                    {
                        fol = folio.consecutivo(tipoFolio.SER);
                        txtIdent.Text = tipoFolio.SER.ToString() + fol.ToString().Trim().PadLeft(7, '0');
                    }
                }
                else
                {
                    lblCCo.Visible = true;
                    txtCodCom.Visible = true;
                    lblMCo.Visible = true;
                    txtModCom.Visible = true;
                    lblMar.Visible = true;
                    txtMarca.Visible = true;
                    lblCat.Visible = true;
                    cbCategoria.Visible = true;
                    lblUso.Visible = true;
                    cbUso.Visible = true;
                    lblTipo.Visible = true;
                    txtTipo.Visible = true;
                    lblGen.Visible = true;
                    cbGen.Visible = true;

                    if (txtIdent.Text == "")
                    {
                        fol = folio.consecutivo(tipoFolio.PRO);
                        txtIdent.Text = tipoFolio.PRO.ToString() + fol.ToString().Trim().PadLeft(7, '0');
                    }
                }
            }
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    articulo.ArActivo = checkActivo.Checked ? "A" : "I";
                    articulo.actualizar();
                }
                else
                {
                    articulo.eliminar();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            articulo.ArCodigo = txtCodigo.Text.Trim();
            articulo.ArCodCom = txtCodCom.Text.Trim();
            articulo.ArDescripcion = txtDesc.Text.Trim();
            articulo.ArCosto = 0;
            articulo.ArPrecioPub = 0;//Convert.ToDouble(txtPrecio.Text.Trim());
            articulo.ArMoneda = "MXN";//cbMoneda.SelectedIndex == 1 ? "MXP" : (cbMoneda.SelectedIndex == 2 ? "USD" : "");
            articulo.ArUnidad = txtUnidad.Text.Trim();
            articulo.ArClasificacion = cbClasif.SelectedIndex == 0 ? "" : clas00[cbClasif.SelectedIndex - 1];
            articulo.ArCategoria = cbCategoria.SelectedIndex == 0 ? "" : cat00[cbCategoria.SelectedIndex - 1];
            articulo.ArUso = cbUso.SelectedIndex == 0 ? "" : uso00[cbUso.SelectedIndex - 1];
            articulo.ArTipo = txtTipo.Text.Trim();
            articulo.ArModeloCom = txtModCom.Text.Trim();
            articulo.ArMarca = txtMarca.Text.Trim();
            articulo.ArGenerico = cbGen.SelectedIndex == 0 ? "" : categoria.listCat[cbGen.SelectedIndex - 1].CaIdent;
            articulo.ArAlto = txtAlto.Text.Trim();
            articulo.ArLargo = txtLargo.Text.Trim();
            articulo.ArAncho = txtAncho.Text.Trim();
            articulo.ArPeso = txtPeso.Text.Trim();
            articulo.ArActivo = checkActivo.Checked == true ? "A" : "I";
            if (modo.update == m)
            {
                articulo.actualizar();
            }
            else
            {
                articulo.ArIdent = txtIdent.Text.Trim();
                string res = articulo.guardar();
                if (res == "")
                {
                    /*int idx = cbClasif.SelectedIndex - 1;
                    if (clas00[idx] == "SER")
                    {
                        folio.FoIdent = tipoFolio.SER.ToString();
                    }
                    else
                    {
                        folio.FoIdent = tipoFolio.PRO.ToString();
                    }
                    //folio.consultaUno();*/
                    folio.FoFolio = fol;
                    folio.actualizar();
                }
                else
                    MessageBox.Show(res);
            }
            this.Close();
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            //txtPrecio.Text = Convert.ToDouble(txtPrecio.Text).ToString("f");
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            txtCodigo.Text = txtCodigo.Text.ToUpper();
        }

        private void txtDesc_Leave(object sender, EventArgs e)
        {
            txtDesc.Text = txtDesc.Text.ToUpper();
        }

        private void txtUnidad_Leave(object sender, EventArgs e)
        {
            txtUnidad.Text = txtUnidad.Text.ToUpper();
        }

        private void txtCodCom_Leave(object sender, EventArgs e)
        {
            txtCodCom.Text = txtCodCom.Text.ToUpper();
        }
        
        private void txtModCom_Leave(object sender, EventArgs e)
        {
            txtModCom.Text = txtModCom.Text.ToUpper();
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {
            txtMarca.Text = txtMarca.Text.ToUpper();
        }
        
        private void txtTipo_Leave(object sender, EventArgs e)
        {
            txtTipo.Text = txtTipo.Text.ToUpper();
        }
        
        private void btnEspeci_Click(object sender, EventArgs e)
        {
            Especificacion ventana = new Especificacion();
            ventana.ShowDialog();
            txtIdent.Text = ventana.codigo;
        }
        
        private void cbGen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbGen.SelectedIndex;
            if (modo.update == m && idx > 0)
            {
                idx--;

                lblCategoria.Text = categoria.listCat[idx].CaDescripcion;
                categoriaPrv.CaIdent = categoria.listCat[idx].CaIdent;
                categoriaPrv.DiNumero = "";
                categoriaPrv.listado();

                catnotaC.CaIdent = categoria.listCat[idx].CaIdent;
                catnotaC.CtNumero = 0;
                catnotaC.CtTipo = "PCARA";
                catnotaC.NoIdent = "";
                catnotaC.listado();

                int j = -1;
                ARTNOTA desc = new ARTNOTA();
                checkLC.Items.Clear();
                foreach (CATNOTA item00 in catnotaC.listCaN)
                {
                    j++;
                    desc.ArIdent = "";
                    desc.AnNumero = 0;
                    desc.AnDescripcion = item00.CtDescripcion;
                    desc.AnTipo = item00.CtTipo;
                    desc.AnOrden = item00.CtOrden;
                    desc.NoIdent = item00.NoIdent;
                    desc.AnCaIdent = item00.CaIdent;
                    desc.AnCtNumero = item00.CtNumero;
                    desc.AnActivo = item00.CtActivo;
                    foreach (ARTNOTA item01 in artnotaC.listArN)
                        if (item00.CaIdent == item01.AnCaIdent && item00.CtNumero == item01.AnCtNumero)
                        {
                            desc.ArIdent = item01.ArIdent;
                            desc.AnNumero = item01.AnNumero;
                            desc.AnDescripcion = item01.AnDescripcion;
                            desc.AnTipo = item01.AnTipo;
                            desc.AnOrden = item01.AnOrden;
                            desc.NoIdent = item01.NoIdent;
                            desc.AnCaIdent = item01.AnCaIdent;
                            desc.AnCtNumero = item01.AnCtNumero;
                            desc.AnActivo = item01.AnActivo;
                            iC.Add(j);
                        }
                    checkLC.Items.Insert(j, desc.AnDescripcion.Trim());
                    descC.Insert(j, desc);
                }
                foreach (int x in iC)
                    if (descC[x].AnActivo == "A")
                        checkLC.SetItemChecked(x, true);
                if (iC.Count > 0)
                    checkLC.Visible = true;

                catnotaI.CaIdent = categoria.listCat[idx].CaIdent;
                catnotaI.CtNumero = 0;
                catnotaI.CtTipo = "PINCL";
                catnotaI.NoIdent = "";
                catnotaI.listado();

                j = -1;
                desc = new ARTNOTA();
                checkLI.Items.Clear();
                foreach (CATNOTA item00 in catnotaI.listCaN)
                {
                    j++;
                    desc.ArIdent = "";
                    desc.AnNumero = 0;
                    desc.AnDescripcion = item00.CtDescripcion;
                    desc.AnTipo = item00.CtTipo;
                    desc.AnOrden = item00.CtOrden;
                    desc.NoIdent = item00.NoIdent;
                    desc.AnCaIdent = item00.CaIdent;
                    desc.AnCtNumero = item00.CtNumero;
                    desc.AnActivo = item00.CtActivo;
                    foreach (ARTNOTA item01 in artnotaI.listArN)
                        if (item00.CaIdent == item01.AnCaIdent && item00.CtNumero == item01.AnCtNumero)
                        {
                            desc.ArIdent = item01.ArIdent;
                            desc.AnNumero = item01.AnNumero;
                            desc.AnDescripcion = item01.AnDescripcion;
                            desc.AnTipo = item01.AnTipo;
                            desc.AnOrden = item01.AnOrden;
                            desc.NoIdent = item01.NoIdent;
                            desc.AnCaIdent = item01.AnCaIdent;
                            desc.AnCtNumero = item01.AnCtNumero;
                            desc.AnActivo = item01.AnActivo;
                            iI.Add(j);
                        }
                    checkLI.Items.Insert(j, desc.AnDescripcion.Trim());
                    descI.Insert(j, desc);
                }
                foreach (int x in iI)
                    if (descI[x].AnActivo == "A")
                        checkLI.SetItemChecked(x, true);
                if (iI.Count >= 0)
                    checkLI.Visible = true;

                catnotaN.CaIdent = categoria.listCat[idx].CaIdent;
                catnotaN.CtNumero = 0;
                catnotaN.CtTipo = "PNINC";
                catnotaN.NoIdent = "";
                catnotaN.listado();

                j = -1;
                desc = new ARTNOTA();
                checkLN.Items.Clear();
                foreach (CATNOTA item00 in catnotaN.listCaN)
                {
                    j++;
                    desc.ArIdent = "";
                    desc.AnNumero = 0;
                    desc.AnDescripcion = item00.CtDescripcion;
                    desc.AnTipo = item00.CtTipo;
                    desc.AnOrden = item00.CtOrden;
                    desc.NoIdent = item00.NoIdent;
                    desc.AnCaIdent = item00.CaIdent;
                    desc.AnCtNumero = item00.CtNumero;
                    desc.AnActivo = item00.CtActivo;
                    foreach (ARTNOTA item01 in artnotaN.listArN)
                        if (item00.CaIdent == item01.AnCaIdent && item00.CtNumero == item01.AnCtNumero)
                        {
                            desc.ArIdent = item01.ArIdent;
                            desc.AnNumero = item01.AnNumero;
                            desc.AnDescripcion = item01.AnDescripcion;
                            desc.AnTipo = item01.AnTipo;
                            desc.AnOrden = item01.AnOrden;
                            desc.NoIdent = item01.NoIdent;
                            desc.AnCaIdent = item01.AnCaIdent;
                            desc.AnCtNumero = item01.AnCtNumero;
                            desc.AnActivo = item01.AnActivo;
                            iN.Add(j);
                        }
                    checkLN.Items.Insert(j, desc.AnDescripcion.Trim());
                    descN.Insert(j, desc);
                }
                foreach (int x in iN)
                    if (descN[x].AnActivo == "A")
                        checkLN.SetItemChecked(x, true);
                if (iN.Count >= 0)
                    checkLN.Visible = true;

                j = -1;
                listPrvCat.Items.Clear();
                foreach (CATEGORIAPRV item in categoriaPrv.listCtp)
                {
                    j++;
                    listPrvCat.Items.Insert(j, item.CaDescripcion);
                }
            }
        }

        private void checkLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            idxC = checkLC.SelectedIndex;
            lblCDesc.Visible = true;
            txtCDesc.Visible = true;
            btnCSave.Visible = true;
            txtCDesc.Text = descC[idxC].AnDescripcion;
            checkSC = checkLC.GetItemCheckState(idxC);
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            int guar = 0;

            artnotaC.ArIdent = idAr;
            artnotaC.AnNumero = 0;
            artnotaC.AnTipo = "";
            artnotaC.NoIdent = "";
            artnotaC.AnCaIdent = catnotaC.listCaN[idxC].CaIdent;
            artnotaC.AnCtNumero = catnotaC.listCaN[idxC].CtNumero;
            artnotaC.consultaUno();
            if (!(artnotaC.AnAudUsuCre == null))
                guar = 1;
            
            if (guar == 1)
            {
                artnotaC.AnActivo = "A";
                artnotaC.actualizar();
            }
            else
            {
                artnotaC.ArIdent = idAr;
                artnotaC.AnNumero = artnotaC.listArN.Count + artnotaI.listArN.Count + artnotaN.listArN.Count + 1;
                artnotaC.AnDescripcion = txtCDesc.Text;
                artnotaC.AnTipo = catnotaC.listCaN[idxC].CtTipo;
                artnotaC.AnOrden = catnotaC.listCaN[idxC].CtOrden;
                artnotaC.NoIdent = catnotaC.listCaN[idxC].NoIdent;
                artnotaC.AnCaIdent = catnotaC.listCaN[idxC].CaIdent;
                artnotaC.AnCtNumero = catnotaC.listCaN[idxC].CtNumero;
                artnotaC.AnActivo = "A";
                artnotaC.guardar();
            }

            int idx = cbGen.SelectedIndex;
            idx--;
            
            /*catnotaC.CaIdent = categoria.listCat[idx].CaIdent;
            catnotaC.CtNumero = 0;
            catnotaC.CtTipo = "PCARA";
            catnotaC.NoIdent = "";
            catnotaC.listado();*/

            artnotaC.ArIdent = idAr;
            artnotaC.AnNumero = 0;
            artnotaC.AnTipo = "PCARA";
            artnotaC.NoIdent = "";
            artnotaC.AnCaIdent = "";
            artnotaC.AnCtNumero = 0;
            artnotaC.listado();

            int j = -1, x;
            ARTNOTA desc = new ARTNOTA();
            checkLC.Items.Clear();
            foreach (CATNOTA item00 in catnotaC.listCaN)
            {
                j++;
                x = -1;
                desc.ArIdent = "";
                desc.AnNumero = 0;
                desc.AnDescripcion = item00.CtDescripcion;
                desc.AnTipo = item00.CtTipo;
                desc.AnOrden = item00.CtOrden;
                desc.NoIdent = item00.NoIdent;
                desc.AnCaIdent = item00.CaIdent;
                desc.AnCtNumero = item00.CtNumero;
                desc.AnActivo = item00.CtActivo;
                foreach (ARTNOTA item01 in artnotaC.listArN)
                    if (item00.CaIdent == item01.AnCaIdent && item00.CtNumero == item01.AnCtNumero)
                    {
                        desc.ArIdent = item01.ArIdent;
                        desc.AnNumero = item01.AnNumero;
                        desc.AnDescripcion = item01.AnDescripcion;
                        desc.AnTipo = item01.AnTipo;
                        desc.AnOrden = item01.AnOrden;
                        desc.NoIdent = item01.NoIdent;
                        desc.AnCaIdent = item01.AnCaIdent;
                        desc.AnCtNumero = item01.AnCtNumero;
                        desc.AnActivo = item01.AnActivo;
                        x = j;
                    }
                checkLC.Items.Insert(j, desc.AnDescripcion.Trim());
                if (x >= 0)
                    checkLC.SetItemChecked(x, true);
                descC.Insert(j, desc);
            }

            lblCDesc.Visible = false;
            txtCDesc.Visible = false;
            btnCSave.Visible = false;
        }
        
        private void checkLC_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _ArtNota item = new _ArtNota();
            item.ArIdent = idAr;
            item.AnNumero = 0;
            item.AnTipo = "";
            item.NoIdent = "";
            item.AnCaIdent = catnotaC.listCaN[idx].CaIdent;
            item.AnCtNumero = catnotaC.listCaN[idx].CtNumero;
            item.consultaUno();

            if (item.AnAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    item.ArIdent = idAr;
                    item.AnNumero = artnotaC.listArN.Count + artnotaI.listArN.Count + artnotaN.listArN.Count + 1;
                    item.AnDescripcion = descC[idx].AnDescripcion;
                    item.AnTipo = descC[idx].AnTipo;
                    item.AnOrden = descC[idx].AnOrden;
                    item.NoIdent = descC[idx].NoIdent;
                    item.AnCaIdent = descC[idx].AnCaIdent;
                    item.AnCtNumero = descC[idx].AnCtNumero;
                    item.AnActivo = "S";
                    item.guardar();
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (item.AnActivo == "I")
                    {
                        item.AnDescripcion = txtCDesc.Text.Trim();
                        item.AnActivo = "A";
                        item.actualizar();
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (item.AnActivo == "A")
                        item.eliminar();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idxPL >= 0)
            {
                precioLista.ArIdent = precioLista.listPrl[idxPL].ArIdent;
                precioLista.DiNumero = precioLista.listPrl[idxPL].DiNumero;
                precioLista.eliminar();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (listPrvCat.SelectedIndex > -1)
            {
                precioLista.ArIdent = idAr;
                precioLista.DiNumero = categoriaPrv.listCtp[listPrvCat.SelectedIndex].DiNumero;
                precioLista.consultaUno();
                if (precioLista.PlActivo != null && precioLista.PlActivo == "I")
                {
                    precioLista.PlActivo = "A";
                    precioLista.actualizar();
                }
                else if (precioLista.PlActivo == null)
                {
                    precioLista.ArIdent = idAr;
                    precioLista.DiNumero = categoriaPrv.listCtp[listPrvCat.SelectedIndex].DiNumero;
                    precioLista.PlPrecioLista = 0;
                    precioLista.PlMoneda = "MXN";
                    precioLista.PlCodPrv = "";
                    precioLista.PlPlazo = "";
                    precioLista.PlReferencia = "";
                    precioLista.PlObservacion = "";
                    precioLista.guardar();
                }
                
                precioLista.ArIdent = idAr;
                precioLista.DiNumero = "";
                precioLista.listado();

                dtPrv.Clear();
                foreach (PRECIOLISTA item in precioLista.listPrl)
                {
                    DateTime fec = item.PlAudFeMod.Year == 1 ? item.PlAudFeCre : item.PlAudFeMod;
                    DataRow dr = dtPrv.NewRow();
                    dr["Nombre"] = item.DiNomCorto;
                    dr["Precio"] = item.PlPrecioLista.ToString();
                    dr["Moneda"] = item.PlMoneda;
                    dr["Fecha"] = fec.Day.ToString().PadLeft(2, '0') + "/" + fec.Month.ToString().PadLeft(2, '0') + "/" + fec.Year.ToString();
                    dtPrv.Rows.Add(dr);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (idxPL >= 0)
            {
                precioLista.ArIdent = precioLista.listPrl[idxPL].ArIdent;
                precioLista.DiNumero = precioLista.listPrl[idxPL].DiNumero;
                precioLista.consultaUno();

                precioLista.ArIdent = precioLista.listPrl[idxPL].ArIdent;
                precioLista.DiNumero = precioLista.listPrl[idxPL].DiNumero;
                precioLista.PlPrecioLista = Convert.ToDouble(txtPrePrv.Text);
                precioLista.PlMoneda = cbMonPrv.SelectedIndex == 1 ? "MXN" : (cbMonPrv.SelectedIndex == 2 ? "USD" : "MXN");
                precioLista.PlCodPrv = txtCodPrv.Text;
                precioLista.PlPlazo = txtPlazo.Text;
                precioLista.PlReferencia = "";
                precioLista.PlObservacion = "";
                if (precioLista.PlActivo == null)
                {
                    precioLista.PlActivo = "A";
                    precioLista.guardar();
                }
                else
                {
                    precioLista.PlActivo = "A";
                    precioLista.actualizar();
                }
                gbPrecio.Visible = false;

                precioLista.ArIdent = idAr;
                precioLista.DiNumero = "";
                precioLista.listado();

                dtPrv.Clear();
                foreach (PRECIOLISTA item in precioLista.listPrl)
                {
                    DateTime fec = item.PlAudFeMod.Year == 1 ? item.PlAudFeCre : item.PlAudFeMod;
                    DataRow dr = dtPrv.NewRow();
                    dr["Nombre"] = item.DiNomCorto;
                    dr["Precio"] = item.PlPrecioLista.ToString();
                    dr["Moneda"] = item.PlMoneda;
                    dr["Fecha"] = fec.Day.ToString().PadLeft(2, '0') + "/" + fec.Month.ToString().PadLeft(2, '0') + "/" + fec.Year.ToString();
                    dtPrv.Rows.Add(dr);
                }
            }
        }

        private void dgPrvLP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idxPL = e.RowIndex;
            gbPrecio.Visible = true;
            txtPrv.Text = precioLista.listPrl[idxPL].DiNomCorto;
            txtPrePrv.Text = precioLista.listPrl[idxPL].PlPrecioLista.ToString();
            cbMonPrv.SelectedIndex = precioLista.listPrl[idxPL].PlMoneda == "MXN" ? 1 : (precioLista.listPrl[idxPL].PlMoneda == "USD" ? 2 : 0);
            txtCodPrv.Text = precioLista.listPrl[idxPL].PlCodPrv;
            txtPlazo.Text = precioLista.listPrl[idxPL].PlPlazo;
        }

        private void btnListCli_Click(object sender, EventArgs e)
        {
            ListaArtCli ventana = new ListaArtCli(idAr);
            ventana.ShowDialog();
        }

        private void dgPrvLP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void checkLI_SelectedIndexChanged(object sender, EventArgs e)
        {
            idxI = checkLI.SelectedIndex;
            lblIDesc.Visible = true;
            txtIDesc.Visible = true;
            btnISave.Visible = true;
            txtIDesc.Text = descI[idxI].AnDescripcion;
            checkSI = checkLI.GetItemCheckState(idxI);
        }

        private void btnISave_Click(object sender, EventArgs e)
        {
            int guar = 0;

            artnotaI.ArIdent = idAr;
            artnotaI.AnNumero = 0;
            artnotaI.AnTipo = "";
            artnotaI.NoIdent = "";
            artnotaI.AnCaIdent = catnotaI.listCaN[idxI].CaIdent;
            artnotaI.AnCtNumero = catnotaI.listCaN[idxI].CtNumero;
            artnotaI.consultaUno();
            if (!(artnotaI.AnAudUsuCre == null))
                guar = 1;

            if(guar == 1)
            {
                artnotaI.AnActivo = "A";
                artnotaI.actualizar();
            }
            else
            {
                artnotaI.ArIdent = idAr;
                artnotaI.AnNumero = artnotaC.listArN.Count + artnotaI.listArN.Count + artnotaN.listArN.Count + 1;
                artnotaI.AnDescripcion = txtIDesc.Text;
                artnotaI.AnTipo = catnotaI.listCaN[idxI].CtTipo;
                artnotaI.AnOrden = catnotaI.listCaN[idxI].CtOrden;
                artnotaI.NoIdent = catnotaI.listCaN[idxI].NoIdent;
                artnotaI.AnCaIdent = catnotaI.listCaN[idxI].CaIdent;
                artnotaI.AnCtNumero = catnotaI.listCaN[idxI].CtNumero;
                artnotaI.AnActivo = "A";
                artnotaI.guardar();
            }

            int idx = cbGen.SelectedIndex;
            idx--;

            /*catnotaI.CaIdent = categoria.listCat[idx].CaIdent;
            catnotaI.CtNumero = 0;
            catnotaI.CtTipo = "PINCL";
            catnotaI.NoIdent = "";
            catnotaI.listado();*/

            artnotaI.ArIdent = idAr;
            artnotaI.AnNumero = 0;
            artnotaI.AnTipo = "PINCL";
            artnotaI.NoIdent = "";
            artnotaI.AnCaIdent = "";
            artnotaI.AnCtNumero = 0;
            artnotaI.listado();

            int j = -1, x;
            ARTNOTA desc = new ARTNOTA();
            checkLI.Items.Clear();
            foreach (CATNOTA item00 in catnotaI.listCaN)
            {
                j++;
                x = -1;
                desc.ArIdent = "";
                desc.AnNumero = 0;
                desc.AnDescripcion = item00.CtDescripcion;
                desc.AnTipo = item00.CtTipo;
                desc.AnOrden = item00.CtOrden;
                desc.NoIdent = item00.NoIdent;
                desc.AnCaIdent = item00.CaIdent;
                desc.AnCtNumero = item00.CtNumero;
                desc.AnActivo = item00.CtActivo;
                foreach (ARTNOTA item01 in artnotaI.listArN)
                    if (item00.CaIdent == item01.AnCaIdent && item00.CtNumero == item01.AnCtNumero)
                    {
                        desc.ArIdent = item01.ArIdent;
                        desc.AnNumero = item01.AnNumero;
                        desc.AnDescripcion = item01.AnDescripcion;
                        desc.AnTipo = item01.AnTipo;
                        desc.AnOrden = item01.AnOrden;
                        desc.NoIdent = item01.NoIdent;
                        desc.AnCaIdent = item01.AnCaIdent;
                        desc.AnCtNumero = item01.AnCtNumero;
                        desc.AnActivo = item01.AnActivo;
                        x = j;
                    }
                checkLI.Items.Insert(j, desc.AnDescripcion.Trim());
                if (x >= 0)
                    checkLI.SetItemChecked(x, true);
                descI.Insert(j, desc);
            }

            lblIDesc.Visible = false;
            txtIDesc.Visible = false;
            btnISave.Visible = false;
        }

        private void checkLI_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _ArtNota item = new _ArtNota();
            item.ArIdent = idAr;
            item.AnNumero = 0;
            item.AnTipo = "";
            item.NoIdent = "";
            item.AnCaIdent = catnotaI.listCaN[idx].CaIdent;
            item.AnCtNumero = catnotaI.listCaN[idx].CtNumero;
            item.consultaUno();

            if (item.AnAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    item.ArIdent = idAr;
                    item.AnNumero = artnotaC.listArN.Count + artnotaI.listArN.Count + artnotaN.listArN.Count + 1;
                    item.AnDescripcion = descI[idx].AnDescripcion;
                    item.AnTipo = descI[idx].AnTipo;
                    item.AnOrden = descI[idx].AnOrden;
                    item.NoIdent = descI[idx].NoIdent;
                    item.AnCaIdent = descI[idx].AnCaIdent;
                    item.AnCtNumero = descI[idx].AnCtNumero;
                    item.AnActivo = "S";
                    item.guardar();
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (item.AnActivo == "I")
                    {
                        item.AnDescripcion = txtIDesc.Text.Trim();
                        item.AnActivo = "A";
                        item.actualizar();
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (item.AnActivo == "A")
                        item.eliminar();
                }
            }
        }

        private void checkLN_SelectedIndexChanged(object sender, EventArgs e)
        {
            idxN = checkLN.SelectedIndex;
            lblNDesc.Visible = true;
            txtNDesc.Visible = true;
            btnNSave.Visible = true;
            txtNDesc.Text = descN[idxN].AnDescripcion;
            checkSN = checkLN.GetItemCheckState(idxN);
        }

        private void btnNSave_Click(object sender, EventArgs e)
        {
            int guar = 0;

            artnotaN.ArIdent = idAr;
            artnotaN.AnNumero = 0;
            artnotaN.AnTipo = "";
            artnotaN.NoIdent = "";
            artnotaN.AnCaIdent = catnotaN.listCaN[idxN].CaIdent;
            artnotaN.AnCtNumero = catnotaN.listCaN[idxN].CtNumero;
            artnotaN.consultaUno();
            if (!(artnotaN.AnAudUsuCre == null))
                guar = 1;

            if (guar == 1)
            {
                artnotaN.AnActivo = "A";
                artnotaN.actualizar();
            }
            else
            {
                artnotaN.ArIdent = idAr;
                artnotaN.AnNumero = artnotaC.listArN.Count + artnotaI.listArN.Count + artnotaN.listArN.Count + 1;
                artnotaN.AnDescripcion = txtNDesc.Text;
                artnotaN.AnTipo = catnotaN.listCaN[idxN].CtTipo;
                artnotaN.AnOrden = catnotaN.listCaN[idxN].CtOrden;
                artnotaN.NoIdent = catnotaN.listCaN[idxN].NoIdent;
                artnotaN.AnCaIdent = catnotaN.listCaN[idxN].CaIdent;
                artnotaN.AnCtNumero = catnotaN.listCaN[idxN].CtNumero;
                artnotaN.AnActivo = "A";
                artnotaN.guardar();
            }

            int idx = cbGen.SelectedIndex;
            idx--;

            /*catnotaN.CaIdent = categoria.listCat[idx].CaIdent;
            catnotaN.CtNumero = 0;
            catnotaN.CtTipo = "PNINC";
            catnotaN.NoIdent = "";
            catnotaN.listado();*/

            artnotaN.ArIdent = idAr;
            artnotaN.AnNumero = 0;
            artnotaN.AnTipo = "PNINC";
            artnotaN.NoIdent = "";
            artnotaN.AnCaIdent = "";
            artnotaN.AnCtNumero = 0;
            artnotaN.listado();

            int j = -1, x;
            ARTNOTA desc = new ARTNOTA();
            checkLN.Items.Clear();
            foreach (CATNOTA item00 in catnotaN.listCaN)
            {
                j++;
                x = -1;
                desc.ArIdent = "";
                desc.AnNumero = 0;
                desc.AnDescripcion = item00.CtDescripcion;
                desc.AnTipo = item00.CtTipo;
                desc.AnOrden = item00.CtOrden;
                desc.NoIdent = item00.NoIdent;
                desc.AnCaIdent = item00.CaIdent;
                desc.AnCtNumero = item00.CtNumero;
                desc.AnActivo = item00.CtActivo;
                foreach (ARTNOTA item01 in artnotaN.listArN)
                    if (item00.CaIdent == item01.AnCaIdent && item00.CtNumero == item01.AnCtNumero)
                    {
                        desc.ArIdent = item01.ArIdent;
                        desc.AnNumero = item01.AnNumero;
                        desc.AnDescripcion = item01.AnDescripcion;
                        desc.AnTipo = item01.AnTipo;
                        desc.AnOrden = item01.AnOrden;
                        desc.NoIdent = item01.NoIdent;
                        desc.AnCaIdent = item01.AnCaIdent;
                        desc.AnCtNumero = item01.AnCtNumero;
                        desc.AnActivo = item01.AnActivo;
                        x = j;
                    }
                checkLN.Items.Insert(j, desc.AnDescripcion.Trim());
                if (x >= 0)
                    checkLN.SetItemChecked(x, true);
                descN.Insert(j, desc);
            }

            lblIDesc.Visible = false;
            txtIDesc.Visible = false;
            btnISave.Visible = false;
        }

        private void checkLN_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _ArtNota item = new _ArtNota();
            item.ArIdent = idAr;
            item.AnNumero = 0;
            item.AnTipo = "";
            item.NoIdent = "";
            item.AnCaIdent = catnotaN.listCaN[idx].CaIdent;
            item.AnCtNumero = catnotaN.listCaN[idx].CtNumero;
            item.consultaUno();

            if (item.AnAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    item.ArIdent = idAr;
                    item.AnNumero = artnotaC.listArN.Count + artnotaI.listArN.Count + artnotaN.listArN.Count + 1;
                    item.AnDescripcion = descI[idx].AnDescripcion;
                    item.AnTipo = descI[idx].AnTipo;
                    item.AnOrden = descI[idx].AnOrden;
                    item.NoIdent = descI[idx].NoIdent;
                    item.AnCaIdent = descI[idx].AnCaIdent;
                    item.AnCtNumero = descI[idx].AnCtNumero;
                    item.AnActivo = "S";
                    item.guardar();
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (item.AnActivo == "I")
                    {
                        item.AnDescripcion = txtNDesc.Text.Trim();
                        item.AnActivo = "A";
                        item.actualizar();
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (item.AnActivo == "A")
                        item.eliminar();
                }
            }
        }

        private void tabArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCDesc.Visible = false;
            txtCDesc.Visible = false;
            btnCSave.Visible = false;
            txtCDesc.Text = "";

            lblIDesc.Visible = false;
            txtIDesc.Visible = false;
            btnISave.Visible = false;
            txtIDesc.Text = "";

            lblNDesc.Visible = false;
            txtNDesc.Visible = false;
            btnNSave.Visible = false;
            txtNDesc.Text = "";
        }
    }
}
