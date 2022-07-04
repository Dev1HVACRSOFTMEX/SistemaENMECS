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
    public partial class DocCotizacion : Form
    {
        private _Documento documento = new _Documento();
        private _Empresa empresa = new _Empresa();
        private _Proyecto proyecto;
        private _Directorio cliente;
        private _Plantilla plantilla;
        private _Documento planDoc = new _Documento();
        private _Folio folio = new _Folio();
        private string idDo;
        private string tipo;
        //private int fol;
        private modo m;

        public DocCotizacion(string DoIdent, string DoTipo, modo mod)
        {
            InitializeComponent();

            idDo = DoIdent;
            tipo = DoTipo;
            m = mod;

            empresa.EmIdent = "";
            empresa.listado();

            lblDesc.Visible = false;
            txtFecha.Text = DateTime.Now.ToString().Substring(0, 10);
            txtTipo.Text = tipo == "COT" ? "COTIZACION" : "";

            //fol = folio.consecutivo(tipoFolio.COT);
        }

        private void DocCotizacion_Load(object sender, EventArgs e)
        {
            cbEmpresa.Items.Clear();
            cbEmpresa.Items.Insert(0, "<Selección>");
            int idx = 1;
            foreach (EMPRESA item in empresa.listEmp)
            {
                cbEmpresa.Items.Insert(idx, item.DiNomCorto.Trim());
                idx++;
            }
            cbEmpresa.SelectedIndex = 0;
            //txtFolio.Text = fol.ToString();
        }

        private void btnPry_Click(object sender, EventArgs e)
        {
            SeekProyecto seek = new SeekProyecto();
            seek.ShowDialog();
            proyecto = seek.proyecto;
            if (proyecto.PyNombre != null && proyecto.PyNombre != "")
            {
                if (cbEmpresa.SelectedIndex > 0 && (proyecto.EmIdent.Trim() != empresa.listEmp[cbEmpresa.SelectedIndex - 1].EmIdent))
                    MessageBox.Show("El proyecto elegido, tiene asignada la empresa: " + proyecto.EmIdent.Trim() + " no cohincide con la empresa asignada a la cotización, favor de verificar la información.");
                else
                {
                    txtProyecto.Text = proyecto.PyNombre.Trim();
                    if (cbEmpresa.SelectedIndex == 0)
                    {
                        int j = 0;
                        foreach (EMPRESA itemEmp in empresa.listEmp)
                        {
                            j++;
                            if (itemEmp.EmIdent == proyecto.EmIdent)
                                cbEmpresa.SelectedIndex = j;
                        }
                    }
                }
            }
            else
                txtProyecto.Text = "";
        }

        private void btnCli_Click(object sender, EventArgs e)
        {
            SeekDirectorio seek = new SeekDirectorio("CLI");
            seek.ShowDialog();
            cliente = seek.directorio;
            if (cliente.DiNombreCom != null && cliente.DiNombreCom != "")
                txtCliente.Text = cliente.DiNombreCom;
            else
                txtCliente.Text = "";
        }

        private void btnPla_Click(object sender, EventArgs e)
        {
            SeekPlantilla seek = new SeekPlantilla();
            seek.ShowDialog();
            plantilla = seek.plantilla;
            lblDesc.Text = "";
            if (plantilla.PaIdent != null && plantilla.PaIdent != "")
            {
                txtPlantilla.Text = plantilla.PaIdent;
                lblDesc.Text = plantilla.PaDescripcion;
                lblDesc.Visible = true;

                planDoc.DoIdent = plantilla.DoIdent;
                planDoc.DoTipo = "";
                planDoc.DiNumero = "";
                planDoc.DiNumero = "";
                planDoc.EmIdent = "";
                planDoc.DoEstatus = "";
                planDoc.FeIni = DateTime.Now;
                planDoc.FeFin = DateTime.Now;
                planDoc.DoUsuSeg = "";
                planDoc.DoVendedor = "";
                planDoc.consultaUno();
            }
            else
            {
                txtPlantilla.Text = "";
                lblDesc.Text = "";
                lblDesc.Visible = false;
                planDoc.DoIdent = "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string res = "";
            if (planDoc.DoIdent != "" && planDoc.DoIdent != null)
            {
                /*documento = planDoc.copiaDocumento();
                documento.PyNumero = proyecto.PyNumero;
                documento.EmIdent = cbEmpresa.SelectedIndex < 1 ? "" : empresa.listEmp[cbEmpresa.SelectedIndex - 1].EmIdent;
                documento.DiNumero = cliente.DiNumero == null ? "" : cliente.DiNumero;*/
                planDoc.PyNumero = proyecto.PyNumero;
                planDoc.DoTipo = tipo;
                planDoc.EmIdent = cbEmpresa.SelectedIndex < 1 ? "" : empresa.listEmp[cbEmpresa.SelectedIndex - 1].EmIdent;
                planDoc.DiNumero = cliente.DiNumero == null ? "" : cliente.DiNumero;
                planDoc.DoFecha = DateTime.Now;
                planDoc.DoFechaIni = DateTime.Now.AddDays(-1);
                planDoc.DoFechaFin = DateTime.Now.AddDays(-1);
                planDoc.DoEstatus = "NUEVO";
                planDoc.DoUsuSeg = usuarioCache.nombreUsuario;
                documento = planDoc.copiaDocumento();
            }
            else
            {
                documento.PyNumero = proyecto.PyNumero;
                documento.EmIdent = cbEmpresa.SelectedIndex < 1 ? "" : empresa.listEmp[cbEmpresa.SelectedIndex - 1].EmIdent;
                documento.DiNumero = cliente.DiNumero == null ? "" : cliente.DiNumero;
                documento.CnNumero01 = 0;
                documento.CnNumero02 = 0;
                documento.CnNumero03 = 0;
                documento.CnNumero04 = 0;
                documento.CnNumero05 = 0;
                documento.DoSubTotalMoE = 0;
                documento.DoTotalMoE = 0;
                documento.DoMonEx = "";
                documento.DoSubTotal = 0;
                documento.DoDesc = 0;
                documento.DoPjDesc = 0;
                documento.DoTipoDesc = "";
                documento.DoSubTDesc = 0;
                documento.DoImpuesto = 0;
                documento.DoImpImp = 0;
                documento.DoTotal = 0;
                documento.DoMoneda = "MXN";
                documento.DoNombre = "";
                documento.DoPath = "";
                documento.DoEstatus = documento.DoEstatus == null ? "" : documento.DoEstatus;
                documento.DoAvance = 0;
                documento.DoTiCambio = 0;
                documento.DoReferencia = "";
                documento.DoDescripcion = "";
                documento.DoDocRef = "";
                documento.DoVendedor = "";
                documento.DoActivo = "A";
                if (modo.insert == m)
                {
                    txtFolio.Text = documento.foliador(m, 'N');
                    documento.DoIdent = txtFolio.Text;
                    documento.DoTipo = tipo;
                    documento.DoFolio = txtFolio.Text;
                    documento.DoVersion = 1;
                    documento.DoVersionL = documento.DoVersionL == "" || documento.DoVersionL == null ? "A" : documento.DoVersionL;
                    documento.DoFecha = DateTime.Now;
                    documento.DoFechaIni = DateTime.Now.AddDays(-1);
                    documento.DoFechaFin = DateTime.Now.AddDays(-1);
                    documento.DoEstatus = "NUEVO";
                    documento.DoUsuSeg = usuarioCache.nombreUsuario;

                    documento.DoGrupo = txtFolio.Text;
                    documento.DoGrupoOrden = 1;

                    res = documento.guardar();
                    /*if (res == "")
                    {
                        folio.FoFolio = fol;
                        folio.actualizar();
                    }*/
                }
                else if (modo.update == m)
                    res = documento.actualizar();
            }

            if (res == "")
            {
                DocCotCuerpo ventana = new DocCotCuerpo(documento.DoIdent, m);
                ventana.ShowDialog();
            }
            else
                MessageBox.Show(res);
        }
    }
}
