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
    public partial class Proyecto : Form
    {
        private _Proyecto proyecto = new _Proyecto();
        private _Directorio directorio = new _Directorio();
        private _Documento documento = new _Documento();
        private _Empresa empresa = new _Empresa();
        private _Codigo estatus = new _Codigo();
        private _Codigo objetivo = new _Codigo();
        private _Codigo tipoVent;
        private _Codigo estados = new _Codigo();
        private _Folio folio = new _Folio();
        private _Carpeta carppry = new _Carpeta();
        private _Carpeta carpcot = new _Carpeta();
        private _PryCarp prycarp = new _PryCarp();
        private _Configuracion configuracion = new _Configuracion();
        private DataTable dt = new DataTable("documento");
        private int fol;
        int idxDir = 0;
        int idxEst = 0;
        int idxObj = 0;
        int idxLug = 0;
        int idxEmp = 0;
        int idxTSi = 0;
        private string idPry;
        private modo m;

        public Proyecto(string PyNumero, modo mod)
        {
            InitializeComponent();

            idPry = PyNumero;
            m = mod;

            estatus.CdCategoria = "EST";
            estatus.CdGrupo = "STA";
            estatus.CdTipo = "";
            estatus.listado();

            objetivo.CdCategoria = "PRY";
            objetivo.CdGrupo = "FIN";
            objetivo.CdTipo = "";
            objetivo.listado();

            estados.CdCategoria = "EST";
            estados.CdGrupo = "REP";
            estados.CdTipo = "";
            estados.listado();

            directorio.DiNumero = "";
            directorio.DiTipo = "CLI";
            directorio.DiRFC = "";
            directorio.DiNombreCom = "";
            directorio.listado();

            configuracion.CgIdent = "CFG01";
            configuracion.consultaUno();

            empresa.EmIdent = "";
            empresa.listado();

            if (modo.update == m)
            {
                proyecto.PyNumero = idPry;
                proyecto.PyNombre = "";
                proyecto.DiNombre = "";
                string res = proyecto.consultaUno();

                documento.DoIdent = "";
                documento.DoTipo = "COT";
                documento.DiNumero = "";
                documento.EmIdent = "";
                documento.DoEstatus = "";
                documento.FeIni = Convert.ToDateTime("2020-01-01");
                documento.FeFin = DateTime.Now;
                documento.PyNumero = idPry;
                documento.DoUsuSeg = "";
                documento.DoVendedor = "";
                documento.listado();

                lblCPry.Visible = true;
                lblCCot.Visible = true;
                checkListCPry.Visible = true;
                checkListCCot.Visible = true;
            }
            else
            {
                checkActivo.CheckState = CheckState.Checked;
                fol = folio.consecutivo(tipoFolio.PRY);

                lblCPry.Visible = false;
                lblCCot.Visible = false;
                checkListCPry.Visible = false;
                checkListCCot.Visible = false;
            }

            /*if (m == modo.insert)
            {
                tabCarpeta.Visible = false;
            }
            else if (m == modo.update)
            {
                tabCarpeta.Visible = true;
            }*/
        }

        private void Proyecto_Load(object sender, EventArgs e)
        {
            int i = 1;
            cbCliente.Items.Clear();
            cbCliente.Items.Insert(0, "<Seleccionar>");
            foreach (DIRECTORIO item in directorio.listDir)
            {
                cbCliente.Items.Insert(i, item.DiNomCorto);
                if ((proyecto.DiNumero != null) && (item.DiNumero.Trim() == proyecto.DiNumero.Trim()))
                    idxDir = i;
                i++;
            }
            if (i > 1)
                cbCliente.SelectedIndex = 0;

            i = 1;
            cbEstatus.Items.Clear();
            cbEstatus.Items.Insert(0, "<Seleccionar>");
            foreach (CODIGO item in estatus.listCod)
            {
                cbEstatus.Items.Insert(i, item.CdDescripcion);
                if ((proyecto.PyEstatus != null) && (item.CdTipo.Trim() == proyecto.PyEstatus.Trim()))
                    idxEst = i;
                i++;
            }
            if (i > 1)
                cbEstatus.SelectedIndex = 0;

            i = 1;
            cbObjetivo.Items.Clear();
            cbObjetivo.Items.Insert(0, "<Seleccionar>");
            foreach (CODIGO item in objetivo.listCod)
            {
                cbObjetivo.Items.Insert(i, item.CdDescripcion);
                if ((proyecto.PyObjetivo != null) && (item.CdTipo.Trim() == proyecto.PyObjetivo.Trim()))
                    idxObj = i;
                i++;
            }
            if (i > 1)
                cbObjetivo.SelectedIndex = 0;

            i = 1;
            cbLugar.Items.Clear();
            cbLugar.Items.Insert(0, "<Seleccionar>");
            foreach (CODIGO item in estados.listCod)
            {
                cbLugar.Items.Insert(i, item.CdDescripcion);
                if ((proyecto.PyNomCorA != null) && (item.CdTipo.Trim() == proyecto.PyNomCorA.Trim()))
                    idxLug = i;
                i++;
            }
            if (i > 1)
                cbLugar.SelectedIndex = 0;

            i = 1;
            cbEmpresa.Items.Clear();
            cbEmpresa.Items.Insert(0, "<Seleccionar>");
            foreach (EMPRESA item in empresa.listEmp)
            {
                cbEmpresa.Items.Insert(i, item.DiNomCorto);
                if ((proyecto.EmIdent != null) && (item.EmIdent.Trim() == proyecto.EmIdent.Trim()))
                    idxEmp = i;
                i++;
            }
            if (i > 1)
                cbEmpresa.SelectedIndex = 0;

            Nombre();

            if (modo.update == m)
            {
                txtNumero.Text = proyecto.PyNumero.ToString();
                cbEstatus.SelectedIndex = idxEst > 0 ? idxEst : 0;
                cbCliente.SelectedIndex = idxDir > 0 ? idxDir : 0;
                cbEmpresa.SelectedIndex = idxEmp > 0 ? idxEmp : 0;
                cbObjetivo.SelectedIndex = idxObj > 0 ? idxObj : 0;
                cbTipoSis.SelectedIndex = idxTSi > 0 ? idxTSi : 0;
                cbLugar.SelectedIndex = idxLug > 0 ? idxLug : 0;
                txtNombre.Text = proyecto.PyNombre.Trim();
                txtNomCarp.Text = proyecto.PyNomCarp.Trim();
                cbCliente.SelectedValue = proyecto.DiNumero;
                checkActivo.Checked = proyecto.PyActivo == "A" ? true : false;

                string carpetapry = @"" + configuracion.CgPathPry.Trim() + proyecto.PyNomCarp.Trim() + "\\";
                string[] carpPry;
                if (Directory.Exists(carpetapry))
                    carpPry = Directory.GetDirectories(carpetapry);
                string carpetacot = @"" + configuracion.CgPathCot.Trim() + proyecto.PyNomCarp.Trim() + "\\";
                string[] carpCot;
                if (Directory.Exists(carpetacot))
                    carpCot = Directory.GetDirectories(carpetacot);

                dt.Columns.Add(new DataColumn("Folio", typeof(string)));
                dt.Columns.Add(new DataColumn("Version", typeof(string)));
                dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
                dt.Columns.Add(new DataColumn("Empresa", typeof(string)));
                dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
                dt.Columns.Add(new DataColumn("Estatus", typeof(string)));

                foreach (DOCUMENTO item in documento.listDoc)
                {
                    if (item.DoEstatus != "CANCE")
                    {
                        DataRow dr = dt.NewRow();
                        dr["Folio"] = item.DoFolio;
                        dr["Version"] = "Q" + item.DoVersionL.Trim() + item.DoVersion.ToString().Trim();
                        dr["Fecha"] = item.DoFecha;
                        dr["Empresa"] = item.EmNombre;
                        dr["Cliente"] = item.DiNomCorto;
                        dr["Estatus"] = item.DoEstatus;
                        dt.Rows.Add(dr);
                    }
                }

                dgDoc.DataSource = dt;
            }
            else
            {
                txtNumero.Text = fol.ToString();
                tabCarpeta.TabPages.Remove(tabCarpeta.TabPages[2]);
            }
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                    proyecto.actualizar();
                else
                    proyecto.eliminar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            proyecto.PyNombre = txtNombre.Text.Trim();
            proyecto.PyNomCorA = cbLugar.SelectedIndex < 1 ? "" : estados.listCod[cbLugar.SelectedIndex - 1].CdTipo.Trim();
            proyecto.PyNomCarp = txtNomCarp.Text.Trim();
            proyecto.PyObjetivo = cbObjetivo.SelectedIndex < 1 ? "" : objetivo.listCod[cbObjetivo.SelectedIndex - 1].CdTipo.Trim();
            proyecto.PyTipoSis = cbTipoSis.SelectedIndex < 1 ? "" : tipoVent.listCod[cbTipoSis.SelectedIndex - 1].CdTipo.Trim();
            proyecto.DiNumero = cbCliente.SelectedIndex < 1 ? "" : directorio.listDir[cbCliente.SelectedIndex - 1].DiNumero.Trim();
            proyecto.EmIdent = cbEmpresa.SelectedIndex < 1 ? "" : empresa.listEmp[cbEmpresa.SelectedIndex - 1].EmIdent.Trim();
            /*proyecto.PyUsuCam = "";
            proyecto.PyFeCam = proyecto.PyFeCam;*/
            proyecto.PyEstatus = cbEstatus.SelectedIndex < 1 ? "" : estatus.listCod[cbEstatus.SelectedIndex - 1].CdTipo.Trim();
            proyecto.PyEstado = cbLugar.SelectedIndex < 1 ? "" : estados.listCod[cbLugar.SelectedIndex - 1].CdTipo.Trim();
            proyecto.PyClasif = "";
            proyecto.PyActivo = checkActivo.Checked == true ? "A" : "I";

            if (modo.insert == m)
            {
                proyecto.PyNumero = txtNumero.Text.Trim();
                proyecto.PyFolio = fol;
                proyecto.PyMaster = "";
                proyecto.PyCambio = "";
                string res = proyecto.guardar();
                if (res == "")
                {
                    folio.FoFolio = fol;
                    folio.actualizar();
                }

                //string carppry = configuracion.CgPathPry + txtNomCarp.Text;
                //string carpcot = configuracion.CgPathCot + txtNomCarp.Text;
                string carppry = txtNomCarp.Text;
                string carpcot = txtNomCarp.Text;
                if (Directory.Exists(configuracion.CgPathPry.Trim()))
                {
                    if (!Directory.Exists(carppry) && res == "")
                    {
                        Directory.CreateDirectory(carppry);

                        lblCPry.Visible = true;
                        lblCCot.Visible = true;
                        checkListCPry.Visible = true;
                        checkListCCot.Visible = true;

                        tabCarpeta.SelectedIndex = 1;
                    }
                }
                else
                    MessageBox.Show("No hay acceso a " + configuracion.CgPathPry.Trim());
            }
            else if (modo.update == m)
                proyecto.actualizar();

            this.Close();
        }

        private void cbObjetivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbObjetivo.SelectedIndex;
            if (idx > 0)
            {
                tipoVent = new _Codigo();
                tipoVent.CdCategoria = objetivo.listCod[idx - 1].CdGrupo;
                tipoVent.CdGrupo = objetivo.listCod[idx - 1].CdTipo;
                tipoVent.CdTipo = "";
                tipoVent.listado();

                int i = 1;
                cbTipoSis.Items.Clear();
                cbTipoSis.Items.Insert(0, "<Seleccionar>");
                foreach (CODIGO item in tipoVent.listCod)
                {
                    cbTipoSis.Items.Insert(i, item.CdDescripcion);
                    if (proyecto.PyTipoSis != null)
                        if (item.CdTipo.Trim() == proyecto.PyTipoSis.Trim())
                            idxTSi = i;
                    i++;
                }
                if (i > 1)
                    cbTipoSis.SelectedIndex = 0;
            }
            Nombre();
        }

        private void cbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nombre();
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nombre();
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbEmpresa.SelectedIndex - 1;

            if (idx >= 0 && modo.update == m)
            {
                if (empresa.listEmp[idx].EmGrIdent != null && empresa.listEmp[idx].EmGrIdent != "")
                {
                    carppry.GcIdent = empresa.listEmp[idx].EmGrIdent;
                    carppry.CrIdent = "";
                    carppry.CrNombre = "";
                    carppry.listado();

                    prycarp.PyNumero = proyecto.PyNumero;
                    prycarp.GcIdent = carppry.GcIdent;
                    prycarp.CrIdent = "";
                    prycarp.listado();

                    int idxPry = -1;
                    checkListCPry.Items.Clear();
                    foreach (CARPETA item in carppry.listCar)
                    {
                        idxPry++;
                        checkListCPry.Items.Insert(idxPry, item.CrNombre);
                        if (prycarp.listPyC != null)
                            foreach (PRYCARP item00 in prycarp.listPyC)
                                if (item.CrIdent == item00.CrIdent)
                                    checkListCPry.SetItemChecked(idxPry, true);
                    }

                    /*foreach (CARPETA item in carppry.listCar)
                    {
                        int existe = 0;
                        if (prycarp.listPyC != null)
                            foreach (PRYCARP item00 in prycarp.listPyC)
                                if (item.CrIdent == item00.CrIdent)
                                    existe = 1;

                        if (existe == 0)
                        {
                            idxPry++;
                            checkListCPry.Items.Insert(idxPry, item.CrNombre);
                        }
                    }*/
                }

                if (empresa.listEmp[idx].EmGrIdCot != null && empresa.listEmp[idx].EmGrIdCot != "")
                {
                    carpcot.GcIdent = empresa.listEmp[idx].EmGrIdCot;
                    carpcot.CrIdent = "";
                    carpcot.CrNombre = "";
                    carpcot.listado();

                    prycarp.PyNumero = "";
                    prycarp.GcIdent = carpcot.GcIdent;
                    prycarp.CrIdent = "";

                    int idxCot = -1;
                    checkListCCot.Items.Clear();
                    foreach (CARPETA item in carpcot.listCar)
                    {
                        idxCot++;
                        checkListCCot.Items.Insert(idxCot, item.CrNombre);
                        if (prycarp.listPyC != null)
                            foreach (PRYCARP item00 in prycarp.listPyC)
                                if (item.CrIdent == item00.CrIdent)
                                    checkListCCot.SetItemChecked(idxCot, true);
                    }

                    /*foreach (CARPETA item in carpcot.listCar)
                    {
                        int existe = 0;
                        if (prycarp.listPyC != null)
                            foreach (PRYCARP item00 in prycarp.listPyC)
                                if (item.CrIdent == item00.CrIdent)
                                    existe = 1;
                        if (existe == 0)
                        {
                            idxCot++;
                            checkListCCot.Items.Insert(idxCot, item.CrNombre);
                        }
                    }*/
                }
            }
            Nombre();
        }

        private void cbTipoSis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nombre();
        }
        
        private void cbLugar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nombre();
        }

        private void Nombre()
        {
            string nombre = "";
            string part = "";
            nombre = txtNumero.Text.Trim().PadLeft(4, '0');
            part = cbObjetivo.SelectedIndex < 1 ? "" : objetivo.listCod[cbObjetivo.SelectedIndex - 1].CdTipo.ToLower().Trim();
            nombre += part == "" ? "" : part.Substring(0, 1).ToUpper() + part.Substring(1);
            part = cbTipoSis.SelectedIndex < 1 ? "" : tipoVent.listCod[cbTipoSis.SelectedIndex - 1].CdTipo.ToLower().Trim();
            nombre += part == "" ? "" : part.Substring(0, 1).ToUpper() + part.Substring(1);
            part = cbLugar.SelectedIndex < 1 ? "" : estados.listCod[cbLugar.SelectedIndex - 1].CdTipo.ToLower().Trim();
            nombre += part == "" ? "" : part.Substring(0, 1).ToUpper() + part.Substring(1);
            nombre += "-";
            part = cbCliente.SelectedIndex < 1 ? "" : directorio.listDir[cbCliente.SelectedIndex - 1].DiNomCorto.ToLower().Trim();
            nombre += part == "" ? "" : part.Substring(0, 1).ToUpper() + part.Substring(1);
            nombre += "_";
            part = cbEstatus.SelectedIndex < 1 ? "" : estatus.listCod[cbEstatus.SelectedIndex - 1].CdTipo.ToLower().Trim();
            nombre += part == "" ? "" : part.Substring(0, 1).ToUpper() + part.Substring(1);
            txtNombre.Text = nombre.Trim();
            txtNomCarp.Text = "P:\\" + (cbEmpresa.SelectedIndex < 1 ? "" : empresa.listEmp[cbEmpresa.SelectedIndex - 1].EmPrefijoPry.Trim()) + nombre.Trim();
        }

        private void checkListCPry_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _PryCarp item = new _PryCarp();
            item.PyNumero = proyecto.PyNumero;
            item.GcIdent = carppry.listCar[idx].GcIdent;
            item.CrIdent = carppry.listCar[idx].CrIdent;
            item.consultaUno();

            if (item.PcAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (Directory.Exists(configuracion.CgPathPry.Trim()))
                    {
                        item.PyNumero = proyecto.PyNumero;
                        item.GcIdent = carppry.listCar[idx].GcIdent;
                        item.CrIdent = carppry.listCar[idx].CrIdent;
                        item.PcActivo = "A";
                        string res = item.guardar();
                        if (res == "")
                            Directory.CreateDirectory(configuracion.CgPathPry.Trim() + txtNomCarp.Text.Trim() + "\\" + carppry.listCar[idx].CrNombre.Trim());
                    }
                    else
                        MessageBox.Show("No hay acceso a " + configuracion.CgPathPry.Trim());
                }
            }
            else
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    e.NewValue = CheckState.Checked;
                }
            }
        }

        private void checkListCCot_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int idx = e.Index;
            _PryCarp item = new _PryCarp();
            item.PyNumero = proyecto.PyNumero;
            item.GcIdent = carpcot.listCar[idx].GcIdent;
            item.CrIdent = carpcot.listCar[idx].CrIdent;
            item.consultaUno();

            if (item.PcAudUsuCre == null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (Directory.Exists(configuracion.CgPathCot.Trim()))
                    {
                        item.PyNumero = proyecto.PyNumero;
                        item.GcIdent = carpcot.listCar[idx].GcIdent;
                        item.CrIdent = carpcot.listCar[idx].CrIdent;
                        item.PcActivo = "A";
                        string res = item.guardar();
                        if (res == "")
                            Directory.CreateDirectory(configuracion.CgPathCot.Trim() + txtNomCarp.Text.Trim() + "\\" + carpcot.listCar[idx].CrNombre.Trim());
                    }
                    else
                        MessageBox.Show("No hay acceso a " + configuracion.CgPathCot.Trim());
                }
            }
            else
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    e.NewValue = CheckState.Checked;
                }
            }
        }

        private void btnNCli_Click(object sender, EventArgs e)
        {
            string DiNumero = "";
            Directorio ventana = new Directorio(DiNumero, "CLI", modo.insert);
            ventana.ShowDialog();

            directorio.DiNumero = "";
            directorio.DiTipo = "CLI";
            directorio.DiRFC = "";
            directorio.DiNombreCom = "";
            directorio.listado();

            int i = 0;
            cbCliente.Items.Clear();
            cbCliente.Items.Insert(0, "<Seleccionar>");
            foreach (DIRECTORIO item in directorio.listDir)
            {
                i++;
                cbCliente.Items.Insert(i, item.DiNomCorto);
            }
            cbCliente.SelectedIndex = 0;
        }

        private void dgDoc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            string DoIdent = documento.listDoc[idx].DoIdent;
            DocCotCuerpo ventana = new DocCotCuerpo(DoIdent, modo.update);
            ventana.ShowDialog();

            documento.DoIdent = "";
            documento.DoTipo = "COT";
            documento.DiNumero = "";
            documento.EmIdent = "";
            documento.DoEstatus = "";
            documento.FeIni = Convert.ToDateTime("2020-01-01");
            documento.FeFin = DateTime.Now;
            documento.PyNumero = idPry;
            documento.DoUsuSeg = "";
            documento.DoVendedor = "";
            documento.listado();

            dt.Rows.Clear();
            foreach (DOCUMENTO item in documento.listDoc)
            {
                if (item.DoEstatus != "CANCE")
                {
                    DataRow dr = dt.NewRow();
                    dr["Folio"] = item.DoFolio;
                    dr["Version"] = "Q" + item.DoVersionL.Trim() + item.DoVersion.ToString().Trim();
                    dr["Fecha"] = item.DoFecha;
                    dr["Empresa"] = item.EmNombre;
                    dr["Cliente"] = item.DiNomCorto;
                    dr["Estatus"] = item.DoEstatus;
                    dt.Rows.Add(dr);
                }
            }
            dgDoc.DataSource = dt;
        }
    }
}
