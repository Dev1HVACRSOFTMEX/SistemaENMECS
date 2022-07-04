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
    public partial class Directorio : Form
    {
        private _Directorio direccion = new _Directorio();
        private _Contacto contPrin = new _Contacto();
        private _Contacto contacto = new _Contacto();
        private _Folio folio = new _Folio();
        private _Categoria categoria = new _Categoria();
        private _CategoriaPrv categoriaPrv = new _CategoriaPrv();
        private DataTable dt = new DataTable("contacto");
        private string idDir;
        private string Tipo;
        private tipoFolio tFol;
        private modo m;

        public Directorio(string DiNumero, string DiTipo, modo mod)
        {
            InitializeComponent();

            idDir = DiNumero;
            Tipo = DiTipo;
            tFol = DiTipo == "PRV" ? tipoFolio.PRV : (DiTipo == "CLI" ? tipoFolio.CLI : tFol);
            m = mod;

            if (modo.update == m)
            {
                direccion.DiNumero = idDir;
                direccion.DiTipo = "";
                direccion.DiRFC = "";
                direccion.DiNombreCom = "";
                string res = direccion.consultaUno();
                if (res == "")
                {
                    contacto.DiNumero = idDir;
                    contacto.CnNumero = 1;
                    contacto.CnTipo = "EMP";
                    res = contacto.consultaUno();
                }

                categoria.CaIdent = "";
                categoria.listado();

                categoriaPrv.CaIdent = "";
                categoriaPrv.DiNumero = idDir;
                categoriaPrv.listado();

                tabCInfo.Visible = true;
            }
            else if (modo.insert == m)
                tabCInfo.Visible = false;
            lblDCredito.Visible = false;
            lblLCredito.Visible = false;
            /*lblBenef.Visible = false;
            lblBanco.Visible = false;
            lblSucursal.Visible = false;
            lblNumCta.Visible = false;
            lblCLABE.Visible = false;*/
            txtDCred.Visible = false;
            txtLCred.Visible = false;
            /*txtBenef.Visible = false;
            txtBanco.Visible = false;
            txtSuc.Visible = false;
            txtNumCta.Visible = false;
            txtCLABE.Visible = false;*/
            groupPrv.Visible = false;

            txtDCred.Text = "0";
            txtLCred.Text = "0";
            lblPjDesc.Text = "0";
        }

        private void Directorio_Load(object sender, EventArgs e)
        {
            cbTPersona.Items.Clear();
            cbTPersona.Items.Insert(0, "<Seleccionar>");
            cbTPersona.Items.Insert(1, "Física");
            cbTPersona.Items.Insert(2, "Moral");
            cbTPersona.SelectedIndex = 0;

            cbClasif.Items.Clear();
            cbClasif.Items.Insert(0, "<Seleccionar>");
            cbClasif.Items.Insert(1, "Activo");
            cbClasif.Items.Insert(2, "Prospecto");
            cbClasif.Items.Insert(3, "Probable");
            cbClasif.SelectedIndex = 0;

            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Correo", typeof(string)));
            dt.Columns.Add(new DataColumn("Teléfono", typeof(string)));
            dt.Columns.Add(new DataColumn("Puesto", typeof(string)));
            dt.Columns.Add(new DataColumn("Estatus", typeof(string)));

            if (Tipo == "PRV")
                groupPrv.Visible = true;
            if (Tipo == "CLI")
                tabCInfo.TabPages.Remove(tabCInfo.TabPages[3]);

            if (modo.update == m)
            {
                txtRFC.Text = direccion.DiRFC;
                txtRazon.Text = direccion.DiRazonSocial;
                cbTPersona.SelectedIndex = direccion.DiTipoEmpresa == "FIS" ? 1 : (direccion.DiTipoEmpresa == "MOR" ? 2 : 0);
                txtNomCom.Text = direccion.DiNombreCom;
                TxtNomCorto.Text = direccion.DiNomCorto;
                txtWeb.Text = direccion.DiPaginaWeb;
                cbClasif.SelectedIndex = direccion.DiClasif == "ACT" ? 1 : (direccion.DiClasif == "PRO" ? 2 : (direccion.DiClasif == "PRB" ? 3 : 0));

                checkActivo.Visible = true;
                checkActivo.Checked = direccion.DiActivo == "A" ? true : false;

                txtCalle.Text = direccion.DiCalle;
                txtNumExt.Text = direccion.DiNumExt;
                txtNumInt.Text = direccion.DiNumInt;
                txtColonia.Text = direccion.DiColonia;
                txtCiudad.Text = direccion.DiPoblacion;
                txtMunicipio.Text = direccion.DiMunicipio;
                txtEstado.Text = direccion.DiEstado;
                txtPais.Text = direccion.DiPais;
                txtNacional.Text = direccion.DiNacional;
                txtCP.Text = direccion.DiCP;

                checkCredito.Checked = direccion.DiCCredito == "S" ? true : false;
                txtDCred.Text = direccion.DiDCredito.ToString();
                txtLCred.Text = direccion.DiLCredito.ToString();
                txtBenef.Text = direccion.DiDBBenef;
                txtBanco.Text = direccion.DiDBBanco;
                txtSuc.Text = direccion.DiDBSucursal;
                txtNumCta.Text = direccion.DiDBNumCta;
                txtCLABE.Text = direccion.DiDBCLABE;

                radBtnDis.Checked = direccion.DiTipo2.Trim() == "DIS" ? true : false;
                radBtnFab.Checked = direccion.DiTipo2.Trim() == "FAB" ? true : false;
                txtPjDesc.Text = direccion.DiPjDesc.ToString();

                if (direccion.DiCCredito == "S")
                {
                    lblDCredito.Visible = true;
                    lblLCredito.Visible = true;
                    /*lblBenef.Visible = true;
                    lblBanco.Visible = true;
                    lblSucursal.Visible = true;
                    lblNumCta.Visible = true;
                    lblCLABE.Visible = true;*/
                    txtDCred.Visible = true;
                    txtLCred.Visible = true;
                    /*txtBenef.Visible = true;
                    txtBanco.Visible = true;
                    txtSuc.Visible = true;
                    txtNumCta.Visible = true;
                    txtCLABE.Visible = true;*/
                }
                
                contPrin.DiNumero = direccion.DiNumero;
                contPrin.CnNumero = 1;
                contPrin.CnTipo = "EMP";
                contPrin.consultaUno();
                if (contPrin.CnTipo != null)
                {
                    txtTel.Text = contPrin.CnTelefono;
                    txtCorreo.Text = contPrin.CnCorreo;
                }

                contacto.DiNumero = direccion.DiNumero;
                contacto.CnNumero = 0;
                contacto.CnTipo = "CON";

                contacto.listado();
                foreach (CONTACTO item in contacto.listCon)
                {
                    DataRow dr = dt.NewRow();
                    dr["Nombre"] = item.CnNombre.Trim() + " " + item.CnAPaterno.Trim() + " " + item.CnAMaterno.Trim();
                    dr["Correo"] = item.CnCorreo.Trim();
                    dr["Teléfono"] = item.CnTelefono.Trim();
                    dr["Puesto"] = item.CnPuesto.Trim();
                    dr["Estatus"] = item.CnActivo == "A" ? "Activo" : "Inactivo";
                    dt.Rows.Add(dr);
                }

                cbCategoria.Items.Clear();
                cbCategoria.Items.Insert(0, "<Seleccionar>");
                int idxCat = 1;
                foreach (CATEGORIA item in categoria.listCat)
                {
                    cbCategoria.Items.Insert(idxCat, item.CaDescripcion);
                    idxCat++;
                }
                if (cbCategoria.Items.Count > 1)
                    cbCategoria.SelectedIndex = 0;

                listBCategoria.Items.Clear();
                idxCat = 0;
                foreach(CATEGORIAPRV item in categoriaPrv.listCtp)
                {
                    listBCategoria.Items.Insert(idxCat, item.CaDescripcion);
                    idxCat++;
                }

            }
            else if (modo.insert == m)
                checkActivo.Visible = false;

            dgContactos.DataSource = dt;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            direccion.DiTipo = Tipo;
            direccion.DiTipo2 = "";
            direccion.DiRFC = txtRFC.Text;
            direccion.DiRazonSocial = txtRazon.Text;
            direccion.DiTipoEmpresa = cbTPersona.SelectedIndex == 1 ? "FIS" : (cbTPersona.SelectedIndex == 2 ? "MOR" : "");
            direccion.DiNombreCom = txtNomCom.Text;
            direccion.DiNomCorto = TxtNomCorto.Text;
            direccion.DiPaginaWeb = txtWeb.Text;
            direccion.DiClasif = cbClasif.SelectedIndex == 1 ? "ACT" : (cbClasif.SelectedIndex == 2 ? "PRO" : (cbClasif.SelectedIndex == 3 ? "PRB" : ""));
            direccion.DiActivo = checkActivo.Checked == true ? "A" : "I";

            direccion.DiCalle = txtCalle.Text;
            direccion.DiNumExt = txtNumExt.Text;
            direccion.DiNumInt = txtNumInt.Text;
            direccion.DiColonia = txtColonia.Text;
            direccion.DiPoblacion = txtCiudad.Text;
            direccion.DiMunicipio = txtMunicipio.Text;
            direccion.DiEstado = txtEstado.Text;
            direccion.DiPais = txtPais.Text;
            direccion.DiNacional = txtNacional.Text;
            direccion.DiCP = txtCP.Text;

            direccion.DiCCredito = checkCredito.Checked == true ? "S" : "N";
            direccion.DiDCredito = txtDCred.Text == "" ? 0 : Convert.ToInt32(txtDCred.Text);
            direccion.DiLCredito = txtLCred.Text == "" ? 0 : Convert.ToDouble(txtLCred.Text);
            direccion.DiDBBenef = txtBenef.Text;
            direccion.DiDBBanco = txtBanco.Text;
            direccion.DiDBSucursal = txtSuc.Text;
            direccion.DiDBNumCta = txtNumCta.Text;
            direccion.DiDBCLABE = txtCLABE.Text;

            direccion.DiTipo = Tipo;
            direccion.DiTipo2 = radBtnDis.Checked ? "DIS" : "";
            direccion.DiTipo2 = radBtnFab.Checked ? "FAB" : "";
            direccion.DiPjDesc = lblPjDesc.Text == "" ? 0 : Convert.ToInt16(lblPjDesc.Text);

            contacto.CnTelefono = txtTel.Text;
            contacto.CnCorreo = txtCorreo.Text;
            if (modo.insert == m)
            {
                int f = folio.consecutivo(tFol);
                idDir = tFol.ToString() + f.ToString().Trim().PadLeft(7, '0');
                direccion.DiNumero = idDir;
                direccion.DiRapido = "N";
                string res = direccion.guardar();
                if (res == "")
                {
                    m = modo.update;
                    folio.FoIdent = tFol.ToString();
                    folio.consultaUno();
                    folio.FoFolio = f;
                    folio.actualizar();
                    checkActivo.Visible = true;
                    contacto.DiNumero = idDir;
                    contacto.CnNumero = 1;
                    contacto.CnTipo = "EMP";
                    contacto.CnNombre = "GENERAL";
                    contacto.CnAPaterno = "---";
                    contacto.CnAMaterno = "";
                    contacto.CnPuesto = "GENERAL";
                    contacto.CnNota = "";
                    res = contacto.guardar();
                }
                tabCInfo.Visible = true;
            }
            else
            {
                direccion.actualizar();
                contacto.actualizar();
            }
        }

        private void btnAgregarCon_Click(object sender, EventArgs e)
        {
            int idCon = 0;
            if (contacto.listCon != null && contacto.listCon.Count > 0)
                idCon = contacto.listCon.Count + 1;
            else
                idCon = 1;
            Contacto ventana = new Contacto(idDir, idCon, "CON", modo.insert);
            ventana.ShowDialog();

            contacto.DiNumero = direccion.DiNumero;
            contacto.CnNumero = 0;
            contacto.CnTipo = "CON";
            contacto.listado();

            dt.Clear();
            foreach (CONTACTO item in contacto.listCon)
            {
                DataRow dr = dt.NewRow();
                dr["Nombre"] = item.CnNombre.Trim() + " " + item.CnAPaterno.Trim() + " " + item.CnAMaterno.Trim();
                dr["Correo"] = item.CnCorreo.Trim();
                dr["Teléfono"] = item.CnTelefono.Trim();
                dr["Puesto"] = item.CnPuesto.Trim();
                dr["Estatus"] = item.CnActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }

            dgContactos.DataSource = dt;
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                    direccion.actualizar();
                else
                    direccion.eliminar();
            }
        }

        private void dgContactos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCon = contacto.listCon[e.RowIndex].CnNumero;
            Contacto ventana = new Contacto(idDir, idCon, "CON", modo.update);
            ventana.Show();
        }

        private void btnActUb_Click(object sender, EventArgs e)
        {
            direccion.DiCalle = txtCalle.Text;
            direccion.DiNumExt = txtNumExt.Text;
            direccion.DiNumInt = txtNumInt.Text;
            direccion.DiColonia = txtColonia.Text;
            direccion.DiPoblacion = txtCiudad.Text;
            direccion.DiMunicipio = txtMunicipio.Text;
            direccion.DiEstado = txtEstado.Text;
            direccion.DiPais = txtPais.Text;
            direccion.DiNacional = txtNacional.Text;
            direccion.DiCP = txtCP.Text;
            direccion.actualizar();
        }

        private void btnActBanco_Click(object sender, EventArgs e)
        {
            direccion.DiCCredito = checkCredito.Checked == true ? "S" : "N";
            direccion.DiDCredito = Convert.ToInt32(txtDCred.Text);
            direccion.DiLCredito = Convert.ToDouble(txtLCred.Text);
            direccion.DiDBBenef = txtBenef.Text;
            direccion.DiDBBanco = txtBanco.Text;
            direccion.DiDBSucursal = txtSuc.Text;
            direccion.DiDBNumCta = txtNumCta.Text;
            direccion.DiDBCLABE = txtCLABE.Text;
            direccion.actualizar();
        }

        private void checkCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActivo.CheckState == CheckState.Checked)
            {
                lblDCredito.Visible = true;
                lblLCredito.Visible = true;
                /*lblBenef.Visible = true;
                lblBanco.Visible = true;
                lblSucursal.Visible = true;
                lblNumCta.Visible = true;
                lblCLABE.Visible = true;*/
                txtDCred.Visible = true;
                txtLCred.Visible = true;
                /*txtBenef.Visible = true;
                txtBanco.Visible = true;
                txtSuc.Visible = true;
                txtNumCta.Visible = true;
                txtCLABE.Visible = true;*/
            }
            else
            {
                lblDCredito.Visible = false;
                lblLCredito.Visible = false;
                /*lblBenef.Visible = false;
                lblBanco.Visible = false;
                lblSucursal.Visible = false;
                lblNumCta.Visible = false;
                lblCLABE.Visible = false;*/
                txtDCred.Visible = false;
                txtLCred.Visible = false;
                /*txtBenef.Visible = false;
                txtBanco.Visible = false;
                txtSuc.Visible = false;
                txtNumCta.Visible = false;
                txtCLABE.Visible = false;*/
            }
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            if (cbCategoria.SelectedIndex > 0)
            {
                categoriaPrv.CaIdent = categoria.listCat[cbCategoria.SelectedIndex - 1].CaIdent;
                categoriaPrv.DiNumero = idDir;
                categoriaPrv.consultaUno();
                if (categoriaPrv.CpActivo != null && categoriaPrv.CpActivo == "I")
                {
                    categoriaPrv.CpActivo = "A";
                    categoriaPrv.actualizar();
                }
                else if (categoriaPrv.CpActivo == null)
                {
                    categoriaPrv.CaIdent = categoria.listCat[cbCategoria.SelectedIndex - 1].CaIdent;
                    categoriaPrv.DiNumero = idDir;
                    categoriaPrv.CpActivo = "A";
                    categoriaPrv.guardar();
                }

                categoriaPrv.CaIdent = "";
                categoriaPrv.DiNumero = idDir;
                categoriaPrv.listado();

                listBCategoria.Items.Clear();
                int idxCat = 0;
                foreach (CATEGORIAPRV item in categoriaPrv.listCtp)
                {
                    listBCategoria.Items.Insert(idxCat, item.CaDescripcion);
                    idxCat++;
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listBCategoria.SelectedIndex > -1)
            {
                categoriaPrv.DiNumero = categoriaPrv.listCtp[listBCategoria.SelectedIndex].DiNumero;
                categoriaPrv.CaIdent = categoriaPrv.listCtp[listBCategoria.SelectedIndex].CaIdent;
                categoriaPrv.eliminar();

                categoriaPrv.CaIdent = "";
                categoriaPrv.DiNumero = idDir;
                categoriaPrv.listado();

                listBCategoria.Items.Clear();
                int idxCat = 0;
                foreach (CATEGORIAPRV item in categoriaPrv.listCtp)
                {
                    listBCategoria.Items.Insert(idxCat, item.CaDescripcion);
                    idxCat++;
                }
            }
        }
    }
}
