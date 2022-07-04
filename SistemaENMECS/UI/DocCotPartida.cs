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
    public partial class DocCotPartida : Form
    {
        private _DocCPartida partida = new _DocCPartida();
        private _Articulo articulo = new _Articulo();
        private _Nota nota = new _Nota();
        private _ArtNota artnotaC = new _ArtNota();
        private _ArtNota artnotaI = new _ArtNota();
        private _ArtNota artnotaN = new _ArtNota();
        private _DocCPNota doccpnotaC = new _DocCPNota();
        private _DocCPNota doccpnotaI = new _DocCPNota();
        private _DocCPNota doccpnotaN = new _DocCPNota();
        private List<DOCCPNOTA> descC = new List<DOCCPNOTA>(), descI = new List<DOCCPNOTA>(), descN = new List<DOCCPNOTA>();
        private List<int> iC = new List<int>(), iI = new List<int>(), iN = new List<int>();
        private modo m;
        private string idDoc;
        private string idPrv;
        private int idCon;
        private int idPar;
        private int nCant = 0;
        private int idxC, idxI, idxN;
        private CheckState checkSC, checkSI, checkSN;
        private string[] fin00 = new string[] { "SUM", "INS", "SUMIN", "SERV", "FAB", "MAN" };
        private string[] fin01 = new string[] { "Suministro de", "Instalación de", "Suministro e instalación de", "Servicio de", "Fabricación de", "Maniobras de" };
        private int calculoDescuento = 0;
        private int calculoUtilidad = 0;

        public DocCotPartida(string DoIdent, int CoNumero, int DpNumero, modo mod)
        {
            InitializeComponent();

            idDoc = DoIdent;
            idCon = CoNumero;
            idPar = DpNumero;
            m = mod;

            txtCodigo.ReadOnly = true;

            //nota.

            if (modo.update == m)
            {
                partida.DoIdent = idDoc;
                partida.CoNumero = idCon;
                partida.DpNumero = idPar;
                partida.consultaUno();

                articulo.ArIdent = partida.ArIdent;
                articulo.ArCodigo = "";
                articulo.ArDescripcion = "";
                articulo.ArClasificacion = "";
                articulo.ArModeloCom = "";
                articulo.ArMarca = "";
                articulo.consultaUno();

                artnotaC.ArIdent = partida.ArIdent;
                artnotaC.AnNumero = 0;
                artnotaC.AnTipo = "PCARA";
                artnotaC.NoIdent = "";
                artnotaC.AnCaIdent = "";
                artnotaC.AnCtNumero = 0;
                artnotaC.listado();

                artnotaI.ArIdent = partida.ArIdent;
                artnotaI.AnNumero = 0;
                artnotaI.AnTipo = "PINCL";
                artnotaI.NoIdent = "";
                artnotaI.AnCaIdent = "";
                artnotaI.AnCtNumero = 0;
                artnotaI.listado();

                artnotaN.ArIdent = partida.ArIdent;
                artnotaN.AnNumero = 0;
                artnotaN.AnTipo = "PNINC";
                artnotaN.NoIdent = "";
                artnotaN.AnCaIdent = "";
                artnotaN.AnCtNumero = 0;
                artnotaN.listado();

                doccpnotaC.DoIdent = idDoc;
                doccpnotaC.CoNumero = idCon;
                doccpnotaC.DpNumero = idPar;
                doccpnotaC.DtNumero = 0;
                doccpnotaC.DtTipo = "PCARA";
                doccpnotaC.NoIdent = "";
                doccpnotaC.DtArIdent = "";
                doccpnotaC.DtAnNumero = 0;
                doccpnotaC.listado();

                doccpnotaI.DoIdent = idDoc;
                doccpnotaI.CoNumero = idCon;
                doccpnotaI.DpNumero = idPar;
                doccpnotaI.DtNumero = 0;
                doccpnotaI.DtTipo = "PINCL";
                doccpnotaI.NoIdent = "";
                doccpnotaI.DtArIdent = "";
                doccpnotaI.DtAnNumero = 0;
                doccpnotaI.listado();

                doccpnotaN.DoIdent = idDoc;
                doccpnotaN.CoNumero = idCon;
                doccpnotaN.DpNumero = idPar;
                doccpnotaN.DtNumero = 0;
                doccpnotaN.DtTipo = "PNINC";
                doccpnotaN.NoIdent = "";
                doccpnotaN.DtArIdent = "";
                doccpnotaN.DtAnNumero = 0;
                doccpnotaN.listado();
            }
            else if (modo.insert == m)
            {
                partida.DoIdent = idDoc;
                partida.CoNumero = idCon;
                partida.DpNumero = 0;
                partida.listado();
                nCant = partida.listDCP.Count;
                checkActivo.CheckState = CheckState.Checked;
            }
            lblCDesc.Visible = false;
            txtCDesc.Visible = false;
            btnCSave.Visible = false;
            checkLC.Visible = false;
            
            lblIDesc.Visible = false;
            txtIDesc.Visible = false;
            btnISave.Visible = false;
            checkLI.Visible = false;

            lblNDesc.Visible = false;
            txtNDesc.Visible = false;
            btnNSave.Visible = false;
            checkLN.Visible = false;
        }
        
        private void DocCotPartida_Load(object sender, EventArgs e)
        {
            calculoUtilidad = 6;
            calculoDescuento = 6;
            txtPrecio.Text = "0";
            txtUtilidad.Text = "0";
            txtCosto.Text = "0";
            txtPUni.Text = "0.00";
            txtDescuento.Text = "0";
            txtImporte.Text = "0";
            txtPrecioF.Text = "0";
            txtCantidad.Text = "0";
            calculoUtilidad = 0;
            calculoDescuento = 0;

            cbTrat.Items.Clear();
            cbTrat.Items.Insert(0, "<Selección>");

            cbMoneda.Items.Clear();
            cbMoneda.Items.Insert(0, "<Selección>");
            cbMoneda.Items.Insert(1, "MXN");
            cbMoneda.Items.Insert(2, "USD");
            cbMoneda.SelectedIndex = 0;
            
            int f = 1, idxF = 0;
            cbTrat.Items.Clear();
            cbTrat.Items.Insert(0, "<Selección>");
            foreach (string itemFin in fin00)
            {
                cbTrat.Items.Insert(f, fin01[f - 1]);
                if (partida.DpTratamiento == itemFin)
                    idxF = f;
                f++;
            }
            cbTrat.SelectedIndex = 0;

            if (modo.update == m)
            {
                txtCodigo.Text = articulo.ArCodigo;
                txtPrecio.Text = partida.DpImporte.ToString();
                txtUtilidad.Text = partida.DpPjCosto.ToString();
                txtCosto.Text = partida.DpCosto.ToString();
                txtPUni.Text = partida.DpSubtotal.ToString();
                txtDescuento.Text = partida.DpPjDesc.ToString();
                txtImporte.Text = partida.DpImpDesc.ToString();
                txtPrecioF.Text = partida.DpPrecio.ToString();
                txtDesc.Text = partida.DpDescripcion;
                txtCantidad.Text = partida.DpCantidad.ToString();
                cbMoneda.SelectedIndex = partida.DpMonEx == "MXN" ? 1 : (partida.DpMonEx == "USD" ? 2 : 0);
                checkActivo.CheckState = partida.DpActivo == "A" ? CheckState.Checked : CheckState.Unchecked;
                cbTrat.SelectedIndex = idxF;

                int j = -1;
                DOCCPNOTA desc = new DOCCPNOTA();
                checkLC.Items.Clear();
                foreach (ARTNOTA item00 in artnotaC.listArN)
                {
                    j++;
                    desc.DoIdent = idDoc;
                    desc.CoNumero = idCon;
                    desc.DpNumero = idPar;
                    desc.DtNumero = 0;
                    desc.DtDescripcion = item00.AnDescripcion;
                    desc.DtOrden = item00.AnOrden;
                    desc.NoIdent = item00.NoIdent;
                    desc.DtArIdent = item00.ArIdent;
                    desc.DtAnNumero = item00.AnNumero;
                    desc.DtActivo = item00.AnActivo;
                    foreach (DOCCPNOTA item01 in doccpnotaC.listDPN)
                        if (item00.ArIdent == item01.DtArIdent && item00.AnNumero == item01.DtAnNumero)
                        {
                            desc.DoIdent = item01.DoIdent;
                            desc.CoNumero = item01.CoNumero;
                            desc.DpNumero = item01.DpNumero;
                            desc.DtNumero = item01.DtNumero;
                            desc.DtDescripcion = item01.DtDescripcion;
                            desc.DtOrden = item01.DtOrden;
                            desc.NoIdent = item01.NoIdent;
                            desc.DtArIdent = item01.DtArIdent;
                            desc.DtAnNumero = item01.DtAnNumero;
                            desc.DtActivo = item01.DtActivo;
                            iC.Add(j);
                        }
                    checkLC.Items.Insert(j, desc.DtDescripcion.Trim());
                    descC.Insert(j, desc);
                }
                foreach (int x in iC)
                    if (descC[x].DtActivo == "A")
                        checkLC.SetItemChecked(x, true);
                if (iC.Count >= 0)
                    checkLC.Visible = true;

                j = -1;
                desc = new DOCCPNOTA();
                checkLI.Items.Clear();
                foreach (ARTNOTA item00 in artnotaI.listArN)
                {
                    j++;
                    desc.DoIdent = idDoc;
                    desc.CoNumero = idCon;
                    desc.DpNumero = idPar;
                    desc.DtNumero = 0;
                    desc.DtDescripcion = item00.AnDescripcion;
                    desc.DtOrden = item00.AnOrden;
                    desc.NoIdent = item00.NoIdent;
                    desc.DtArIdent = item00.ArIdent;
                    desc.DtAnNumero = item00.AnNumero;
                    desc.DtActivo = item00.AnActivo;
                    foreach (DOCCPNOTA item01 in doccpnotaI.listDPN)
                        if (item00.ArIdent == item01.DtArIdent && item00.AnNumero == item01.DtAnNumero)
                        {
                            desc.DoIdent = item01.DoIdent;
                            desc.CoNumero = item01.CoNumero;
                            desc.DpNumero = item01.DpNumero;
                            desc.DtNumero = item01.DtNumero;
                            desc.DtDescripcion = item01.DtDescripcion;
                            desc.DtOrden = item01.DtOrden;
                            desc.NoIdent = item01.NoIdent;
                            desc.DtArIdent = item01.DtArIdent;
                            desc.DtAnNumero = item01.DtAnNumero;
                            desc.DtActivo = item01.DtActivo;
                            iI.Add(j);
                        }
                    checkLI.Items.Insert(j, desc.DtDescripcion.Trim());
                    descI.Insert(j, desc);
                }
                foreach (int x in iI)
                    if (descI[x].DtActivo == "A")
                        checkLI.SetItemChecked(x, true);
                if (iI.Count >= 0)
                    checkLI.Visible = true;

                j = -1;
                desc = new DOCCPNOTA();
                checkLN.Items.Clear();
                foreach (ARTNOTA item00 in artnotaN.listArN)
                {
                    j++;
                    desc.DoIdent = idDoc;
                    desc.CoNumero = idCon;
                    desc.DpNumero = idPar;
                    desc.DtNumero = 0;
                    desc.DtDescripcion = item00.AnDescripcion;
                    desc.DtOrden = item00.AnOrden;
                    desc.NoIdent = item00.NoIdent;
                    desc.DtArIdent = item00.ArIdent;
                    desc.DtAnNumero = item00.AnNumero;
                    desc.DtActivo = item00.AnActivo;
                    foreach (DOCCPNOTA item01 in doccpnotaN.listDPN)
                        if (item00.ArIdent == item01.DtArIdent && item00.AnNumero == item01.DtAnNumero)
                        {
                            desc.DoIdent = item01.DoIdent;
                            desc.CoNumero = item01.CoNumero;
                            desc.DpNumero = item01.DpNumero;
                            desc.DtNumero = item01.DtNumero;
                            desc.DtDescripcion = item01.DtDescripcion;
                            desc.DtOrden = item01.DtOrden;
                            desc.NoIdent = item01.NoIdent;
                            desc.DtArIdent = item01.DtArIdent;
                            desc.DtAnNumero = item01.DtAnNumero;
                            desc.DtActivo = item01.DtActivo;
                            iN.Add(j);
                        }
                    checkLN.Items.Insert(j, desc.DtDescripcion.Trim());
                    descN.Insert(j, desc);
                }
                foreach (int x in iN)
                    if (descN[x].DtActivo == "A")
                        checkLN.SetItemChecked(x, true);
                if (iN.Count >= 0)
                    checkLN.Visible = true;
            }
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            SeekArticuloLP ventana = new SeekArticuloLP();
            ventana.ShowDialog();
            if (!(ventana.articulo.ArCodigo == null || ventana.articulo.ArCodigo == ""))
            {
                articulo = ventana.articulo;
                txtCodigo.Text = articulo.ArCodigo.Trim();
                txtDesc.Text = articulo.ArDescripcion.Trim();
                txtUnidad.Text = articulo.ArUnidad.Trim();

                ventana.precioLista.consultaUno();
                txtPrecio.Text = ventana.precioLista.PlPrecioLista.ToString().Trim();
                cbMoneda.SelectedIndex = ventana.precioLista.PlMoneda == "USD" ? 2 : 1;
                idPrv = ventana.precioLista.DiNumero;
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string res = "";
            partida.DpDescripcion = txtDesc.Text;
            partida.DpCantidad = Convert.ToDouble(txtCantidad.Text.Trim());
            partida.DpUnidad = txtUnidad.Text;
            partida.DpCosto = Convert.ToDouble(txtCosto.Text);
            partida.DpPjCosto = Convert.ToDouble(txtUtilidad.Text);
            partida.DpPrecio = Convert.ToDouble(txtPrecioF.Text);
            partida.DpSubtotal = Convert.ToDouble(txtPUni.Text);
            partida.DpPjDesc = Convert.ToDouble(txtDescuento.Text);
            partida.DpImpDesc = Convert.ToDouble(txtImporte.Text);
            partida.DpImporteMoE = 0;
            partida.DpMonEx = cbMoneda.SelectedIndex == 1 ? "MXN" : (cbMoneda.SelectedIndex == 2 ? "USD" : "");
            partida.DpImporte = Convert.ToDouble(txtPrecio.Text);
            partida.DpTratamiento = cbTrat.SelectedIndex == 0 ? "" : fin00[cbTrat.SelectedIndex - 1];
            partida.DpEstatus = "PEND";
            partida.DpAvance = 0;
            partida.DpReferencia = "";
            partida.DpFabricado = "N";
            partida.DpOrden = 0;
            if (modo.insert == m)
            {
                partida.DoIdent = idDoc;
                partida.CoNumero = idCon;
                partida.DpNumero = nCant + 1;
                partida.ArIdent = articulo.ArIdent;
                partida.DiNumero = idPrv == null ? "" : idPrv;
                partida.DpActivo = checkActivo.CheckState == CheckState.Checked ? "A" : "I";
                res = partida.guardar();

                lblCDesc.Visible = false;
                txtCDesc.Visible = false;
                btnCSave.Visible = false;
                checkLC.Visible = true;


                lblIDesc.Visible = false;
                txtIDesc.Visible = false;
                btnISave.Visible = false;
                checkLI.Visible = true;

                lblNDesc.Visible = false;
                txtNDesc.Visible = false;
                btnNSave.Visible = false;
                checkLN.Visible = true;
            }
            else
            {
                partida.DpActivo = checkActivo.CheckState == CheckState.Checked ? "A" : "I";
                res = partida.actualizar();
            }
            if (res == "")
                this.Close();
            else
                MessageBox.Show(res);
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    partida.DpActivo = checkActivo.CheckState == CheckState.Checked ? "A" : "I";
                    partida.actualizar();
                }
                else
                    partida.eliminar();
            }
        }

        private void checkLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            idxC = checkLC.SelectedIndex;
            lblCDesc.Visible = true;
            txtCDesc.Visible = true;
            btnCSave.Visible = true;
            txtCDesc.Text = descC[idxC].DtDescripcion;
            checkSC = checkLC.GetItemCheckState(idxC);
        }

        private void tabPartida_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnPartida_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text != "" && calculoDescuento == 0)
            {
                calculoDescuento = 1;
                double precioUni = Convert.ToDouble(txtPUni.Text);
                double descuento = Convert.ToDouble(txtDescuento.Text);
                if (descuento < 0 || descuento > 100)
                {
                    MessageBox.Show("El descuento debe estar en un rango de 0 a 100 %");
                    txtDescuento.Text = "0";
                }
                else
                {
                    double importe = precioUni * (descuento / 100);
                    double precio = precioUni - importe;
                    txtImporte.Text = importe.ToString();
                    txtPrecioF.Text = precio.ToString();
                }
                calculoDescuento = 0;
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            if (txtImporte.Text != "" && calculoDescuento == 0)
            {
                calculoDescuento = 2;
                double precioUni = Convert.ToDouble(txtPUni.Text);
                double importe = Convert.ToDouble(txtImporte.Text);
                if (importe < 0 || importe > precioUni)
                {
                    MessageBox.Show("El importe debe estar en un rango de 0 a " + precioUni.ToString("N2").Trim());
                    txtImporte.Text = "0";
                }
                else
                {
                    double descuento = importe == 0 ? 0 : Math.Round(importe * 100 / precioUni, 0);
                    double precio = precioUni - importe;
                    txtDescuento.Text = descuento.ToString();
                    txtPrecioF.Text = precio.ToString();
                }
                calculoDescuento = 0;
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioF.Text != "" && calculoDescuento == 0)
            {
                calculoDescuento = 3;
                double precioUni = Convert.ToDouble(txtPUni.Text);
                double precio = Convert.ToDouble(txtPrecioF.Text);
                if (precio < 0 || precio > precioUni)
                {
                    MessageBox.Show("El precio debe estar en un rango de 0 a " + precioUni.ToString("N2".Trim()));
                    txtPrecioF.Text = txtPUni.Text;
                }
                else
                {
                    double importe = precioUni - precio;
                    double descuento = importe == 0 ? 0 : Math.Round(importe * 100 / precioUni);
                    txtImporte.Text = importe.ToString();
                    txtDescuento.Text = descuento.ToString();
                }
                calculoDescuento = 0;
            }
            if (txtPrecioF.Text != "" && txtCantidad.Text != "")
            {
                double precio = Convert.ToDouble(txtPrecioF.Text);
                double cant = Convert.ToDouble(txtCantidad.Text);
                txtImporteF.Text = Math.Round((precio * cant), 2).ToString();
            }
        }

        private void tabInfo_Click(object sender, EventArgs e)
        {

        }

        private void txtUtilidad_TextChanged(object sender, EventArgs e)
        {
            /*if (txtUtilidad.Text != "" && calculoUtilidad == 0)
            {
                calculoUtilidad = 1;
                double costo = Convert.ToDouble(txtPrecio.Text);
                double utili = Convert.ToDouble(txtUtilidad.Text);
                if (utili < 0)
                {
                    MessageBox.Show("La utilidad no puede ser menor a 0");
                    txtUtilidad.Text = "0";
                }
                else
                {
                    double ganancia = costo * (utili / 100);
                    double preUnit = costo + ganancia;
                    txtCosto.Text = ganancia.ToString();
                    txtPUni.Text = preUnit.ToString();

                    calculoDescuento = 6;
                    double descuento = Convert.ToDouble(txtDescuento.Text);
                    double importe = preUnit * (descuento / 100);
                    double precio = preUnit - importe;
                    txtImporte.Text = importe.ToString();
                    txtPrecioF.Text = precio.ToString();
                    calculoDescuento = 0;
                }
                calculoUtilidad = 0;
            }*/
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            /*if (txtCosto.Text != "" && calculoUtilidad == 0)
            {
                calculoUtilidad = 2;
                double costo = Convert.ToDouble(txtPrecio.Text);
                double ganancia = Convert.ToDouble(txtCosto.Text);
                if (ganancia < 0)
                {
                    MessageBox.Show("La ganancia no puede ser menor a 0");
                    txtCosto.Text = "0";
                }
                else
                {
                    double utili = costo == 0 ? 0 : Math.Round(ganancia * 100 / costo, 4);
                    double preUnit = costo + ganancia;
                    txtUtilidad.Text = utili.ToString();
                    txtPUni.Text = preUnit.ToString();

                    calculoDescuento = 6;
                    double descuento = Convert.ToDouble(txtDescuento.Text);
                    double importe = preUnit * (descuento / 100);
                    double precio = preUnit - importe;
                    txtImporte.Text = importe.ToString();
                    txtPrecioF.Text = precio.ToString();
                    calculoDescuento = 0;
                }
                calculoUtilidad = 0;
            }*/
        }

        private void txtPUni_TextChanged(object sender, EventArgs e)
        {
            if (txtPUni.Text != "" && calculoUtilidad == 0)
            {
                calculoUtilidad = 3;
                double costo = Convert.ToDouble(txtPrecio.Text);
                double preUnit = Convert.ToDouble(txtPUni.Text);
                if (preUnit < 0)
                {
                    MessageBox.Show("El Precio Unitario no puede ser menor a 0");
                    txtPUni.Text = txtPrecio.Text;
                }
                else
                {
                    /*double ganancia = preUnit - costo;
                    double utili = costo == 0 ? 0 : Math.Round(ganancia * 100 / costo, 4);
                    txtCosto.Text = ganancia.ToString();
                    txtUtilidad.Text = utili.ToString();*/

                    txtPUni.Text = txtPrecio.Text;

                    calculoDescuento = 6;
                    double descuento = Convert.ToDouble(txtDescuento.Text);
                    double importe = preUnit * (descuento / 100);
                    double precio = preUnit - importe;
                    txtImporte.Text = importe.ToString();
                    txtPrecioF.Text = precio.ToString();
                    calculoDescuento = 0;
                }
                calculoUtilidad = 0;
            }
        }

        private void txtPrecio_TextChanged_1(object sender, EventArgs e)
        {
            if (txtPrecio.Text != "" && calculoUtilidad == 0)
            {
                calculoUtilidad = 4;
                double costo = Convert.ToDouble(txtPrecio.Text);
                if (costo < 0)
                {
                    MessageBox.Show("El Costo no puede ser menor a 0");
                    txtPrecio.Text = "0";
                }
                else
                {
                    double utili = Convert.ToDouble(txtUtilidad.Text);
                    double ganancia = costo * (utili / 100);
                    double preUnit = costo + ganancia;
                    txtCosto.Text = ganancia.ToString();
                    txtPUni.Text = preUnit.ToString();

                    calculoDescuento = 6;
                    double descuento = Convert.ToDouble(txtDescuento.Text);
                    double importe = preUnit * (descuento / 100);
                    double precio = preUnit - importe;
                    txtImporte.Text = importe.ToString();
                    txtPrecioF.Text = precio.ToString();
                    calculoDescuento = 0;
                }
                calculoUtilidad = 0;
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioF.Text != "" && txtCantidad.Text != "")
            {
                double precio = Convert.ToDouble(txtPrecioF.Text);
                double cant = Convert.ToDouble(txtCantidad.Text);
                txtImporteF.Text = Math.Round((precio * cant), 2).ToString();
            }
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            int guar = 0;

            doccpnotaC.DoIdent = idDoc;
            doccpnotaC.CoNumero = idCon;
            doccpnotaC.DpNumero = idPar;
            doccpnotaC.DtNumero = 0;
            doccpnotaC.DtTipo = "";
            doccpnotaC.NoIdent = "";
            doccpnotaC.DtArIdent = artnotaC.listArN[idxC].ArIdent;
            doccpnotaC.DtAnNumero = artnotaC.listArN[idxC].AnNumero;
            doccpnotaC.consultaUno();
            if (!(doccpnotaC.DtAudUsuCre == null))
                guar = 1;


            if (guar == 1)
            {
                doccpnotaC.DtActivo = "A";
                doccpnotaC.actualizar();
            }
            else
            {
                doccpnotaC.DoIdent = idDoc;
                doccpnotaC.CoNumero = idCon;
                doccpnotaC.DpNumero = idPar;
                doccpnotaC.DtNumero = doccpnotaC.listDPN.Count + doccpnotaI.listDPN.Count + doccpnotaN.listDPN.Count + 1;
                doccpnotaC.DtDescripcion = txtCDesc.Text.Trim();
                doccpnotaC.DtTipo = artnotaC.listArN[idxC].AnTipo;
                doccpnotaC.DtOrden = artnotaC.listArN[idxC].AnOrden;
                doccpnotaC.NoIdent = artnotaC.listArN[idxC].NoIdent;
                doccpnotaC.DtArIdent = artnotaC.listArN[idxC].ArIdent;
                doccpnotaC.DtAnNumero = artnotaC.listArN[idxC].AnNumero;
                doccpnotaC.DtActivo = "A";
                doccpnotaC.guardar();
            }

            /*artnotaC.ArIdent = partida.ArIdent;
            artnotaC.AnNumero = 0;
            artnotaC.AnTipo = "PCARA";
            artnotaC.NoIdent = "";
            artnotaC.AnCaIdent = "";
            artnotaC.AnCtNumero = 0;
            artnotaC.listado();*/

            doccpnotaC.DoIdent = idDoc;
            doccpnotaC.CoNumero = idCon;
            doccpnotaC.DpNumero = idPar;
            doccpnotaC.DtNumero = 0;
            doccpnotaC.DtTipo = "PCARA";
            doccpnotaC.NoIdent = "";
            doccpnotaC.DtArIdent = "";
            doccpnotaC.DtAnNumero = 0;
            doccpnotaC.listado();

            int j = -1;
            DOCCPNOTA desc = new DOCCPNOTA();
            checkLC.Items.Clear();
            foreach (ARTNOTA item00 in artnotaC.listArN)
            {
                j++;
                desc.DoIdent = idDoc;
                desc.CoNumero = idCon;
                desc.DpNumero = idPar;
                desc.DtNumero = 0;
                desc.DtDescripcion = item00.AnDescripcion;
                desc.DtOrden = item00.AnOrden;
                desc.NoIdent = item00.NoIdent;
                desc.DtArIdent = item00.ArIdent;
                desc.DtAnNumero = item00.AnNumero;
                desc.DtActivo = item00.AnActivo;
                foreach (DOCCPNOTA item01 in doccpnotaC.listDPN)
                    if (item00.ArIdent == item01.DtArIdent && item00.AnNumero == item01.DtAnNumero)
                    {
                        desc.DoIdent = item01.DoIdent;
                        desc.CoNumero = item01.CoNumero;
                        desc.DpNumero = item01.DpNumero;
                        desc.DtNumero = item01.DtNumero;
                        desc.DtDescripcion = item01.DtDescripcion;
                        desc.DtOrden = item01.DtOrden;
                        desc.NoIdent = item01.NoIdent;
                        desc.DtArIdent = item01.DtArIdent;
                        desc.DtAnNumero = item01.DtAnNumero;
                        desc.DtActivo = item01.DtActivo;
                        iC.Add(j);
                    }
                checkLC.Items.Insert(j, desc.DtDescripcion.Trim());
                descC.Insert(j, desc);
            }
            foreach (int x in iC)
                checkLC.SetItemChecked(x, true);
            if (iC.Count >= 0)
                checkLC.Visible = true;

            lblCDesc.Visible = false;
            txtCDesc.Visible = false;
            btnCSave.Visible = false;
        }

        private void checkLC_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _DocCPNota item = new _DocCPNota();
            item.DoIdent = idDoc;
            item.CoNumero = idCon;
            item.DpNumero = idPar;
            item.DtNumero = 0;
            item.DtTipo = "";
            item.NoIdent = "";
            item.DtArIdent = artnotaC.listArN[idx].ArIdent;
            item.DtAnNumero = artnotaC.listArN[idx].AnNumero;
            item.consultaUno();

            if (item.DtAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    item.DoIdent = idDoc;
                    item.CoNumero = idCon;
                    item.DpNumero = idPar;
                    item.DtNumero = doccpnotaC.listDPN.Count + doccpnotaI.listDPN.Count + doccpnotaN.listDPN.Count + 1;
                    item.DtDescripcion = descC[idx].DtDescripcion;
                    item.DtTipo = descC[idx].DtTipo;
                    item.DtOrden = descC[idx].DtOrden;
                    item.NoIdent = descC[idx].NoIdent;
                    item.DtArIdent = descC[idx].DtArIdent;
                    item.DtAnNumero = descC[idx].DtAnNumero;
                    item.DtActivo = "S";
                    item.guardar();
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (item.DtActivo == "I")
                    {
                        item.DtDescripcion = txtCDesc.Text.Trim();
                        item.DtActivo = "A";
                        item.actualizar();
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (item.DtActivo == "A")
                        item.eliminar();
                }
            }
        }

        private void checkLI_SelectedIndexChanged(object sender, EventArgs e)
        {
            idxI = checkLI.SelectedIndex;
            lblIDesc.Visible = true;
            txtIDesc.Visible = true;
            btnISave.Visible = true;
            txtIDesc.Text = descI[idxI].DtDescripcion;
            checkSI = checkLI.GetItemCheckState(idxI);
        }

        private void btnISave_Click(object sender, EventArgs e)
        {
            int guar = 0;

            doccpnotaI.DoIdent = idDoc;
            doccpnotaI.CoNumero = idCon;
            doccpnotaI.DpNumero = idPar;
            doccpnotaI.DtNumero = 0;
            doccpnotaI.DtTipo = "";
            doccpnotaI.NoIdent = "";
            doccpnotaI.DtArIdent = artnotaI.listArN[idxI].ArIdent;
            doccpnotaI.DtAnNumero = artnotaI.listArN[idxI].AnNumero;
            doccpnotaI.consultaUno();
            if (!(doccpnotaI.DtAudUsuCre == null))
                guar = 1;


            if (guar == 1)
            {
                doccpnotaI.DtActivo = "A";
                doccpnotaI.actualizar();
            }
            else
            {
                doccpnotaI.DoIdent = idDoc;
                doccpnotaI.CoNumero = idCon;
                doccpnotaI.DpNumero = idPar;
                doccpnotaI.DtNumero = doccpnotaC.listDPN.Count + doccpnotaI.listDPN.Count + doccpnotaN.listDPN.Count + 1;
                doccpnotaI.DtDescripcion = txtIDesc.Text.Trim();
                doccpnotaI.DtTipo = artnotaI.listArN[idxI].AnTipo;
                doccpnotaI.DtOrden = artnotaI.listArN[idxI].AnOrden;
                doccpnotaI.NoIdent = artnotaI.listArN[idxI].NoIdent;
                doccpnotaI.DtArIdent = artnotaI.listArN[idxI].ArIdent;
                doccpnotaI.DtAnNumero = artnotaI.listArN[idxI].AnNumero;
                doccpnotaI.DtActivo = "A";
                doccpnotaI.guardar();
            }

            /*artnotaI.ArIdent = partida.ArIdent;
            artnotaI.AnNumero = 0;
            artnotaI.AnTipo = "PINCL";
            artnotaI.NoIdent = "";
            artnotaI.AnCaIdent = "";
            artnotaI.AnCtNumero = 0;
            artnotaI.listado();*/

            doccpnotaI.DoIdent = idDoc;
            doccpnotaI.CoNumero = idCon;
            doccpnotaI.DpNumero = idPar;
            doccpnotaI.DtNumero = 0;
            doccpnotaC.DtTipo = "PINCL";
            doccpnotaC.NoIdent = "";
            doccpnotaI.DtArIdent = "";
            doccpnotaI.DtAnNumero = 0;
            doccpnotaI.listado();

            int j = -1;
            DOCCPNOTA desc = new DOCCPNOTA();
            checkLI.Items.Clear();
            foreach (ARTNOTA item00 in artnotaI.listArN)
            {
                j++;
                desc.DoIdent = idDoc;
                desc.CoNumero = idCon;
                desc.DpNumero = idPar;
                desc.DtNumero = 0;
                desc.DtDescripcion = item00.AnDescripcion;
                desc.DtOrden = item00.AnOrden;
                desc.NoIdent = item00.NoIdent;
                desc.DtArIdent = item00.ArIdent;
                desc.DtAnNumero = item00.AnNumero;
                desc.DtActivo = item00.AnActivo;
                foreach (DOCCPNOTA item01 in doccpnotaI.listDPN)
                    if (item00.ArIdent == item01.DtArIdent && item00.AnNumero == item01.DtAnNumero)
                    {
                        desc.DoIdent = item01.DoIdent;
                        desc.CoNumero = item01.CoNumero;
                        desc.DpNumero = item01.DpNumero;
                        desc.DtNumero = item01.DtNumero;
                        desc.DtDescripcion = item01.DtDescripcion;
                        desc.DtOrden = item01.DtOrden;
                        desc.NoIdent = item01.NoIdent;
                        desc.DtArIdent = item01.DtArIdent;
                        desc.DtAnNumero = item01.DtAnNumero;
                        desc.DtActivo = item01.DtActivo;
                        iI.Add(j);
                    }
                checkLI.Items.Insert(j, desc.DtDescripcion.Trim());
                descI.Insert(j, desc);
            }
            foreach (int x in iI)
                checkLI.SetItemChecked(x, true);
            if (iI.Count >= 0)
                checkLI.Visible = true;

            lblIDesc.Visible = false;
            txtIDesc.Visible = false;
            btnISave.Visible = false;
        }

        private void checkLI_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _DocCPNota item = new _DocCPNota();
            item.DoIdent = idDoc;
            item.CoNumero = idCon;
            item.DpNumero = idPar;
            item.DtNumero = 0;
            item.DtTipo = "";
            item.NoIdent = "";
            item.DtArIdent = artnotaI.listArN[idx].ArIdent;
            item.DtAnNumero = artnotaI.listArN[idx].AnNumero;
            item.consultaUno();

            if (item.DtAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    item.DoIdent = idDoc;
                    item.CoNumero = idCon;
                    item.DpNumero = idPar;
                    item.DtNumero = doccpnotaC.listDPN.Count + doccpnotaI.listDPN.Count + doccpnotaN.listDPN.Count + 1;
                    item.DtDescripcion = descI[idx].DtDescripcion;
                    item.DtTipo = descI[idx].DtTipo;
                    item.DtOrden = descI[idx].DtOrden;
                    item.NoIdent = descI[idx].NoIdent;
                    item.DtArIdent = descI[idx].DtArIdent;
                    item.DtAnNumero = descI[idx].DtAnNumero;
                    item.DtActivo = "S";
                    item.guardar();
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (item.DtActivo == "I")
                    {
                        item.DtDescripcion = txtIDesc.Text.Trim();
                        item.DtActivo = "A";
                        item.actualizar();
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (item.DtActivo == "A")
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
            txtNDesc.Text = descN[idxN].DtDescripcion;
            checkSN = checkLN.GetItemCheckState(idxN);
        }

        private void btnNSave_Click(object sender, EventArgs e)
        {
            int guar = 0;

            doccpnotaN.DoIdent = idDoc;
            doccpnotaN.CoNumero = idCon;
            doccpnotaN.DpNumero = idPar;
            doccpnotaN.DtNumero = 0;
            doccpnotaN.DtTipo = "";
            doccpnotaN.NoIdent = "";
            doccpnotaN.DtArIdent = artnotaN.listArN[idxN].ArIdent;
            doccpnotaN.DtAnNumero = artnotaN.listArN[idxN].AnNumero;
            doccpnotaN.consultaUno();
            if (!(doccpnotaN.DtAudUsuCre == null))
                guar = 1;


            if (guar == 1)
            {
                doccpnotaN.DtActivo = "A";
                doccpnotaN.actualizar();
            }
            else
            {
                doccpnotaN.DoIdent = idDoc;
                doccpnotaN.CoNumero = idCon;
                doccpnotaN.DpNumero = idPar;
                doccpnotaN.DtNumero = doccpnotaC.listDPN.Count + doccpnotaI.listDPN.Count + doccpnotaN.listDPN.Count + 1;
                doccpnotaN.DtDescripcion = txtNDesc.Text.Trim();
                doccpnotaN.DtTipo = artnotaN.listArN[idxN].AnTipo;
                doccpnotaN.DtOrden = artnotaN.listArN[idxN].AnOrden;
                doccpnotaN.NoIdent = artnotaN.listArN[idxN].NoIdent;
                doccpnotaN.DtArIdent = artnotaN.listArN[idxN].ArIdent;
                doccpnotaN.DtAnNumero = artnotaN.listArN[idxN].AnNumero;
                doccpnotaN.DtActivo = "A";
                doccpnotaN.guardar();
            }

            /*artnotaN.ArIdent = partida.ArIdent;
            artnotaN.AnNumero = 0;
            artnotaN.AnTipo = "PNINC";
            artnotaN.NoIdent = "";
            artnotaN.AnCaIdent = "";
            artnotaN.AnCtNumero = 0;
            artnotaN.listado();*/

            doccpnotaN.DoIdent = idDoc;
            doccpnotaN.CoNumero = idCon;
            doccpnotaN.DpNumero = idPar;
            doccpnotaN.DtNumero = 0;
            doccpnotaC.DtTipo = "PNINC";
            doccpnotaC.NoIdent = "";
            doccpnotaN.DtArIdent = "";
            doccpnotaN.DtAnNumero = 0;
            doccpnotaN.listado();

            int j = -1;
            DOCCPNOTA desc = new DOCCPNOTA();
            checkLN.Items.Clear();
            foreach (ARTNOTA item00 in artnotaN.listArN)
            {
                j++;
                desc.DoIdent = idDoc;
                desc.CoNumero = idCon;
                desc.DpNumero = idPar;
                desc.DtNumero = 0;
                desc.DtDescripcion = item00.AnDescripcion;
                desc.DtOrden = item00.AnOrden;
                desc.NoIdent = item00.NoIdent;
                desc.DtArIdent = item00.ArIdent;
                desc.DtAnNumero = item00.AnNumero;
                desc.DtActivo = item00.AnActivo;
                foreach (DOCCPNOTA item01 in doccpnotaN.listDPN)
                    if (item00.ArIdent == item01.DtArIdent && item00.AnNumero == item01.DtAnNumero)
                    {
                        desc.DoIdent = item01.DoIdent;
                        desc.CoNumero = item01.CoNumero;
                        desc.DpNumero = item01.DpNumero;
                        desc.DtNumero = item01.DtNumero;
                        desc.DtDescripcion = item01.DtDescripcion;
                        desc.DtOrden = item01.DtOrden;
                        desc.NoIdent = item01.NoIdent;
                        desc.DtArIdent = item01.DtArIdent;
                        desc.DtAnNumero = item01.DtAnNumero;
                        desc.DtActivo = item01.DtActivo;
                        iN.Add(j);
                    }
                checkLN.Items.Insert(j, desc.DtDescripcion.Trim());
                descN.Insert(j, desc);
            }
            foreach (int x in iN)
                checkLN.SetItemChecked(x, true);
            if (iN.Count >= 0)
                checkLN.Visible = true;

            lblNDesc.Visible = false;
            txtNDesc.Visible = false;
            btnNSave.Visible = false;
        }

        private void checkLN_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _DocCPNota item = new _DocCPNota();
            item.DoIdent = idDoc;
            item.CoNumero = idCon;
            item.DpNumero = idPar;
            item.DtNumero = 0;
            item.DtTipo = "";
            item.NoIdent = "";
            item.DtArIdent = artnotaN.listArN[idx].ArIdent;
            item.DtAnNumero = artnotaN.listArN[idx].AnNumero;
            item.consultaUno();

            if (item.DtAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    item.DoIdent = idDoc;
                    item.CoNumero = idCon;
                    item.DpNumero = idPar;
                    item.DtNumero = doccpnotaC.listDPN.Count + doccpnotaI.listDPN.Count + doccpnotaN.listDPN.Count + 1;
                    item.DtDescripcion = descN[idx].DtDescripcion;
                    item.DtTipo = descN[idx].DtTipo;
                    item.DtOrden = descN[idx].DtOrden;
                    item.NoIdent = descN[idx].NoIdent;
                    item.DtArIdent = descN[idx].DtArIdent;
                    item.DtAnNumero = descN[idx].DtAnNumero;
                    item.DtActivo = "S";
                    item.guardar();
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (item.DtActivo == "I")
                    {
                        item.DtDescripcion = txtNDesc.Text.Trim();
                        item.DtActivo = "A";
                        item.actualizar();
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (item.DtActivo == "A")
                        item.eliminar();
                }
            }
        }
    }
}
