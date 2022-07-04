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
using System.IO;

namespace SistemaENMECS.UI
{
    public partial class Configuracion : Form
    {
        private _Configuracion configuracion = new _Configuracion();
        private _Folio folio = new _Folio();
        private _Empresa empresa = new _Empresa();
        private _Plantilla plantilla = new _Plantilla();
        private _GrCarp grcarp = new _GrCarp();
        private _Carpeta carpeta = new _Carpeta();
        private _Nota nota = new _Nota();
        private DataTable dtF = new DataTable("folio");
        private DataTable dtE = new DataTable("empresa");
        private DataTable dtP = new DataTable("plantilla");
        private modo m;
        private modo mF;
        private modo mP;

        public Configuracion()
        {
            InitializeComponent();
            
            gbFolios.Visible = false;
            gbPlantilla.Visible = false;

            folio.FoIdent = "";
            folio.listado();

            empresa.EmIdent = "";
            empresa.listado();

            grcarp.GcIdent = "";
            grcarp.GcDescripcion = "";
            grcarp.listado();

            nota.NoIdent = "";
            nota.NoTipo = "DCONG";
            nota.listado();

            plantilla.PaIdent = "";
            plantilla.listado();
            configuracion.CgIdent = "CONFIG01";
            string res = configuracion.consultaUno();
            if (res == "" & configuracion.CgIdent != null)
                m = modo.update;
            else
                m = modo.insert;
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            ////////////////////////////GRUPO CARPETA////////////////////////////
            cbGrIdent.Items.Clear();
            cbGrIdent.Items.Insert(0, "<Seleccionar>");
            int i = 0, iGrId = 0;
            foreach (GRCARP item in grcarp.listGrC)
            {
                i++;
                cbGrIdent.Items.Insert(i, item.GcDescripcion);
                if (modo.update == m && item.GcIdent == configuracion.CgGcIdent)
                    iGrId = i;
            }
            if (i > 0)
                cbGrIdent.SelectedIndex = 0;

            ////////////////////////////////NOTA////////////////////////////////
            /*cbNoTipo.Items.Clear();
            cbNoTipo.Items.Insert(0, "<Seleccionar>");
            int iNoId = 0;
            i = 0;
            foreach (NOTA item in nota.listNot)
            {
                i++;
                cbNoTipo.Items.Insert(i, item.NoDescripcion);
                if (modo.update == m && item.NoTipo == configuracion.CgCrIdent)
                    iNoId = i;
            }
            if (i > 0)
                cbNoTipo.SelectedIndex = 0;
            */
            ///////////////////////////////MONEDA///////////////////////////////
            cbMoneda.Items.Clear();
            cbMoneda.Items.Insert(0, "<Selección>");
            cbMoneda.Items.Insert(1, "MXP");
            cbMoneda.Items.Insert(2, "USD");
            cbMoneda.SelectedIndex = 0;

            if (modo.update == m)
            {
                txtIdent.Text = configuracion.CgIdent;
                txtImpuesto.Text = configuracion.CgImpuesto;
                txtPjImp.Text = configuracion.CgPjImpuesto.ToString();
                cbMoneda.SelectedIndex = configuracion.CgMoneda == "MXP" ? 1 : (configuracion.CgMoneda == "USD" ? 2 : 0);
                txtPathCot.Text = configuracion.CgPathCot;
                txtPathPry.Text = configuracion.CgPathPry;
                if (iGrId > 0)
                    cbGrIdent.SelectedIndex = iGrId;
                //if (iNoId > 0)
                //    cbCrIdent.SelectedIndex = iNoId;
                txtIdent.ReadOnly = true;

                txtArt.Text = configuracion.CgDfArt;
                txtCli.Text = configuracion.CgDfCli;
                txtPrv.Text = configuracion.CgDfPrv;
                txtEmp.Text = configuracion.CgDfEmp;
                txtPry.Text = configuracion.CgDfPry;
            }

            //////////////////////////////FOLIO//////////////////////////////
            dtF.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dtF.Columns.Add(new DataColumn("Folio", typeof(string)));
            //dtF.Columns.Add(new DataColumn("Ruta", typeof(string)));
            dtF.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach (FOLIO item in folio.listFol)
            {
                DataRow dr = dtF.NewRow();
                dr["Nombre"] = item.FoDescrip.Trim();
                dr["Folio"] = item.FoFolio.ToString().Trim();
                //dr["Ruta"] = item.FoPath.Trim();
                dr["Estatus"] = item.FoActivo == "A" ? "Activo" : "Inactivo";
                dtF.Rows.Add(dr);
            }
            dgFolios.DataSource = dtF;

            //////////////////////////////EMPRESA//////////////////////////////
            dtE.Columns.Add(new DataColumn("Identificador", typeof(string)));
            //dtE.Columns.Add(new DataColumn("Numero Directorio", typeof(string)));
            dtE.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dtE.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach (EMPRESA item in empresa.listEmp)
            {
                DataRow dr = dtE.NewRow();
                dr["Identificador"] = item.EmIdent.Trim();
                //dr["Numero Directorio"] = item.DiNumero.Trim();
                dr["Nombre"] = item.DiNomCorto.Trim();
                dr["Estatus"] = item.EmActivo == "A" ? "Activo" : "Inactivo";
                dtE.Rows.Add(dr);
            }
            dgEmpresa.DataSource = dtE;

            //////////////////////////////PLANTILLA//////////////////////////////
            dtP.Columns.Add(new DataColumn("Identificador", typeof(string)));
            dtP.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dtP.Columns.Add(new DataColumn("Documento", typeof(string)));
            dtP.Columns.Add(new DataColumn("Estatus", typeof(string)));

            foreach (PLANTILLA item in plantilla.listPla)
            {
                DataRow dr = dtP.NewRow();
                dr["Identificador"] = item.PaIdent.Trim();
                dr["Descripcion"] = item.PaDescripcion.Trim();
                dr["Documento"] = item.DoIdent.Trim();
                dr["Estatus"] = item.PaActivo == "A" ? "Activo" : "Inactivo";
                dtP.Rows.Add(dr);
            }
            dgPlantilla.DataSource = dtP;

            tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            configuracion.CgIdent = txtIdent.Text.Trim();
            configuracion.CgImpuesto = txtImpuesto.Text.Trim();
            configuracion.CgPjImpuesto = Convert.ToInt16(txtPjImp.Text.Trim());
            configuracion.CgMoneda = cbMoneda.SelectedItem.ToString();
            configuracion.CgGcIdent = cbGrIdent.SelectedIndex == 0 ? "" : grcarp.listGrC[cbGrIdent.SelectedIndex - 1].GcIdent;
            configuracion.CgCrIdent = cbCrIdent.SelectedIndex == 0 ? "" : carpeta.listCar[cbCrIdent.SelectedIndex - 1].CrIdent;
            configuracion.CgPathPry = txtPathPry.Text;
            configuracion.CgPathCot = txtPathCot.Text;
            configuracion.CgNoTipo = "";            //cbNoTipo.SelectedIndex <= 0 ? "" : nota.listNot[cbNoTipo.SelectedIndex - 1].NoTipo;
            configuracion.CgDfArt = txtArt.Text;
            configuracion.CgDfCli = txtCli.Text;
            configuracion.CgDfPrv = txtPrv.Text;
            configuracion.CgDfEmp = txtEmp.Text;
            configuracion.CgDfPry = txtPry.Text;

            if (modo.update == m)
                configuracion.actualizar();
            else if (modo.insert == m)
            {
                configuracion.guardar();
                txtIdent.ReadOnly = true;
            }
        }

        private void btnAddFolio_Click(object sender, EventArgs e)
        {
            gbFolios.Visible = true;
            mF = modo.insert;
            txtIdFol.Text = "";
            txtFolio.Text = "";
            txtPathFol.Text = "";
            checkActF.Checked = false;
            txtIdFol.ReadOnly = false;
        }

        private void dgFolios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            folio.FoIdent = folio.listFol[idx].FoIdent.Trim();
            folio.consultaUno();
            txtIdFol.Text = folio.FoIdent.Trim();
            txtDescFol.Text = folio.FoDescrip.Trim();
            txtFolio.Text = folio.FoFolio.ToString().Trim();
            txtPathFol.Text = folio.FoPath.Trim();
            checkActF.Checked = folio.FoActivo == "A" ? true : false;
            mF = modo.update;
            txtIdFol.ReadOnly = true;
            gbFolios.Visible = true;
        }

        private void checkActF_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == mF)
            {
                if (checkActF.Checked)
                {
                    folio.actualizar();
                }
                else
                {
                    folio.eliminar();
                }
            }
        }

        private void btnGuardaFol_Click(object sender, EventArgs e)
        {
            folio.FoDescrip = txtDescFol.Text.Trim();
            folio.FoFolio = Convert.ToInt32(txtFolio.Text.Trim());
            folio.FoPath = txtPathFol.Text.Trim();
            folio.FoActivo = checkActF.Checked ? "A" : "I";

            if (modo.insert == mF)
            {
                folio.FoIdent = txtIdFol.Text.Trim();
                folio.FoTipo = txtIdFol.Text.Trim();
                folio.guardar();
            }
            else if (modo.update == mF)
                folio.actualizar();
            gbFolios.Visible = false;
            folio.FoIdent = "";
            folio.listado();

            dtF.Clear();
            foreach (FOLIO item in folio.listFol)
            {
                DataRow dr = dtF.NewRow();
                dr["Nombre"] = item.FoDescrip.Trim();
                dr["Folio"] = item.FoFolio.ToString().Trim();
                //dr["Ruta"] = item.FoPath.Trim();
                dr["Estatus"] = item.FoActivo == "A" ? "Activo" : "Inactivo";
                dtF.Rows.Add(dr);
            }
            dgFolios.DataSource = dtF;
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            string EmIdent = "";
            Empresa ventana = new Empresa(EmIdent, modo.insert);
            ventana.ShowDialog();

            dtE.Clear();
            empresa.EmIdent = "";
            empresa.listado();
            foreach (EMPRESA item in empresa.listEmp)
            {
                DataRow dr = dtE.NewRow();
                dr["Identificador"] = item.EmIdent.Trim();
                //dr["Numero Directorio"] = item.DiNumero.Trim();
                dr["Nombre"] = item.DiNomCorto.Trim();
                dr["Estatus"] = item.EmActivo == "A" ? "Activo" : "Inactivo";
                dtE.Rows.Add(dr);
            }
            dgEmpresa.DataSource = dtE;
        }

        private void dgEmpresa_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string EmIdent = empresa.listEmp[e.RowIndex].EmIdent;
            Empresa ventana = new Empresa(EmIdent, modo.update);
            ventana.ShowDialog();

            dtE.Clear();
            empresa.EmIdent = "";
            empresa.listado();
            foreach (EMPRESA item in empresa.listEmp)
            {
                DataRow dr = dtE.NewRow();
                dr["Identificador"] = item.EmIdent.Trim();
                //dr["Numero Directorio"] = item.DiNumero.Trim();
                dr["Nombre"] = item.DiNomCorto.Trim();
                dr["Estatus"] = item.EmActivo == "A" ? "Activo" : "Inactivo";
                dtE.Rows.Add(dr);
            }
            dgEmpresa.DataSource = dtE;
        }

        private void checkActPla_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == mP)
            {
                if (checkActPla.Checked)
                {
                    plantilla.actualizar();
                }
                else
                {
                    plantilla.eliminar();
                }
            }
        }

        private void btnAddPla_Click(object sender, EventArgs e)
        {
            mP = modo.insert;
            txtIdentP.Text = "";
            txtDescP.Text = "";
            txtDocP.Text = "";
            checkActPla.Checked = false;
            txtIdentP.ReadOnly = false;
            gbPlantilla.Visible = true;
            txtIdentP.ReadOnly = false;
        }

        private void btnBuscarDoc_Click(object sender, EventArgs e)
        {

        }

        private void dgPlantilla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mP = modo.update;
            txtIdentP.Text = plantilla.listPla[e.RowIndex].PaIdent;
            txtDescP.Text = plantilla.listPla[e.RowIndex].PaDescripcion;
            txtDocP.Text = plantilla.listPla[e.RowIndex].DoIdent;
            checkActPla.Checked = plantilla.listPla[e.RowIndex].PaActivo == "A" ? true : false;
            txtIdentP.ReadOnly = true;
            gbPlantilla.Visible = true;
        }

        private void btnGuardarP_Click(object sender, EventArgs e)
        {
            plantilla.PaDescripcion = txtDescP.Text.Trim();
            plantilla.DoIdent = txtDocP.Text.Trim();
            plantilla.PaActivo = checkActPla.Checked ? "A" : "I";
            if (modo.insert == mP)
            {
                plantilla.PaIdent = txtIdentP.Text.Trim();
                plantilla.guardar();
            }
            else if (modo.update == mP)
                plantilla.actualizar();
            gbPlantilla.Visible = false;
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog archivo = new OpenFileDialog())
            {
                archivo.InitialDirectory = "c:\\";
                //archivo.Filter = "Excel (*.xlsx)|*.xlsx||ALL files (*.*)|*.*";
                archivo.FilterIndex = 2;
                archivo.RestoreDirectory = true;

                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    txtRutaCarga.Text = archivo.FileName;
                }
            }
        }

        private void btnCli_Click(object sender, EventArgs e)
        {
            DAL.CargaDB carg = new DAL.CargaDB();
            string ruta = txtRutaCarga.Text.Trim();
            if (ruta != "")
            {
                carg.CargaDireccion(ruta, "CLI");
                MessageBox.Show("Terminó");
            }
            else
                MessageBox.Show("Indicar una ruta de archivo");
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            DAL.CargaDB carg = new DAL.CargaDB();
            string ruta = txtRutaCarga.Text.Trim();
            if (ruta != "")
            {
                carg.CargaDireccion(ruta, "PRV");
                MessageBox.Show("Terminó");
            }
            else
                MessageBox.Show("Indicar una ruta de archivo");
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {

        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            DAL.CargaDB carg = new DAL.CargaDB();
            string ruta = txtRutaCarga.Text.Trim();
            if (ruta != "")
            {
                carg.CargaProducto(ruta);
                MessageBox.Show("Terminó");
            }
            else
                MessageBox.Show("Indicar una ruta de archivo");
        }

        private void btnServ_Click(object sender, EventArgs e)
        {

        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            DAL.CargaDB carg = new DAL.CargaDB();
            string ruta = txtRutaCarga.Text.Trim();
            if (ruta != "")
            {
                carg.CargaConcepto(ruta);
                MessageBox.Show("Terminó");
            }
            else
                MessageBox.Show("Indicar una ruta de archivo");
        }

        private void btnBCarp_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (var carpeta = new FolderBrowserDialog())
            {
                if (carpeta.ShowDialog() == DialogResult.OK)
                {
                    txtPathFol.Text = carpeta.SelectedPath.Trim();
                }
            }
        }

        private void cbGrIdent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbGrIdent.SelectedIndex, i = 0, iCrId = 0;

            cbCrIdent.Items.Clear();
            cbCrIdent.Items.Insert(0, "<Seleccionar>");
            if (idx > 0)
            {
                carpeta.GcIdent = grcarp.listGrC[idx - 1].GcIdent;
                carpeta.CrIdent = "";
                carpeta.CrNombre = "";
                carpeta.listado();

                foreach (CARPETA item in carpeta.listCar)
                {
                    i++;
                    cbCrIdent.Items.Insert(i, item.CrNombre);
                    if (modo.update == m && item.CrIdent == configuracion.CgCrIdent)
                        iCrId = i;
                }

                if (i > 0)
                    cbCrIdent.SelectedIndex = 0;

                if (iCrId > 0)
                    cbCrIdent.SelectedIndex = iCrId;
            }
        }
    }
}
