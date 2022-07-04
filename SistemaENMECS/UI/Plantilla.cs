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
    public partial class Plantilla : Form
    {
        private _Plantilla plantilla = new _Plantilla();
        private _Documento doc;
        private _Configuracion cfg = new _Configuracion();
        private string DoIdent = "";
        private modo m;
        private string idPa;

        public Plantilla(string PaIdent, modo mod)
        {
            InitializeComponent();

            idPa = PaIdent;
            m = mod;

            cfg.CgIdent = "CFG01";
            cfg.consultaUno();

            if (modo.update == m)
            {
                plantilla.PaIdent = idPa;
                plantilla.consultaUno();
            }
        }

        private void Plantilla_Load(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                txtIdent.ReadOnly = true;
                txtIdent.Text = plantilla.PaIdent.Trim();
                txtDesc.Text = plantilla.PaDescripcion.Trim();
                checkActivo.Checked = plantilla.PaActivo == "A" ? true : false;
                string pref = plantilla.DoIdent.Substring(0, 3);

                doc = new _Documento();
                doc.DoIdent = plantilla.DoIdent;
                doc.DoTipo = "";
                doc.DiNumero = cfg.CgDfCli;
                doc.EmIdent = cfg.CgDfEmp;
                doc.DoEstatus = "";
                doc.FeIni = Convert.ToDateTime("2020-01-01");
                doc.FeFin = DateTime.Now;
                doc.DoUsuSeg = usuarioCache.nombreUsuario;
                doc.DoVendedor = "";
                doc.consultaUno();

                txtDoc.Text = doc.DoFolio == null ? plantilla.DoIdent : doc.DoFolio.Trim();
                
                if (doc.DoAudUsuCre == null)
                {
                    btnGenerar.Visible = true;
                    btnEditar.Visible = false;
                }
                else
                {
                    btnGenerar.Visible = false;
                    if (pref == "PLA")
                        btnEditar.Visible = true;
                }

                if (pref == "PLA")
                    btnBuscaDoc.Visible = false;
            }
            else if (modo.insert == m)
            {
                DateTime now = DateTime.Now;
                txtDoc.Text = "PLA-" + now.Year.ToString().Substring(2, 2).PadLeft(2, '0') + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0') + "_" + now.Hour.ToString().PadLeft(2, '0') + now.Minute.ToString().PadLeft(2, '0') + now.Second.ToString().PadLeft(2, '0');
                checkActivo.Checked = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            plantilla.PaDescripcion = txtDesc.Text.Trim();
            plantilla.DoIdent = DoIdent.Trim() == "" ? txtDoc.Text.Trim() : DoIdent.Trim();
            plantilla.PaActivo = checkActivo.Checked ? "A" : "I";
            if (modo.insert == m)
            {
                _Plantilla verif = new _Plantilla();
                verif.PaIdent = txtIdent.Text;
                verif.PaDescripcion = "";
                verif.consultaUno();

                if (verif.PaAudUsuCre == null)
                {
                    plantilla.PaIdent = txtIdent.Text;
                    plantilla.guardar();
                    txtIdent.ReadOnly = true;
                }
                else
                    MessageBox.Show("El Identificador ya se encuentra registrado, favor de cambiarlo");

                btnGenerar.Visible = true;
            }
            else if (modo.update == m)
                plantilla.actualizar();
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    plantilla.PaActivo = checkActivo.Checked ? "A" : "I";
                    plantilla.actualizar();
                }
                else
                {
                    plantilla.eliminar();
                }
            }
        }

        private void btnBuscaDoc_Click(object sender, EventArgs e)
        {
            SeekDocumento ventana = new SeekDocumento("COT");
            ventana.ShowDialog();
            _Documento documento = ventana.documento;
            txtDoc.Text = documento.DoFolio;
            DoIdent = documento.DoIdent;
            btnGenerar.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string pref = txtDoc.Text.Substring(0, 3);
            if (pref == "PLA")
            {
                doc = new _Documento();
                doc.DoIdent = plantilla.DoIdent;
                doc.DoTipo = "PCT";
                doc.DiNumero = "";
                doc.EmIdent = "";
                doc.DoEstatus = "";
                doc.FeIni = Convert.ToDateTime("2020-01-01");
                doc.FeFin = DateTime.Now;
                doc.DoUsuSeg = usuarioCache.nombreUsuario;
                doc.DoVendedor = "";
                doc.consultaUno();

                if (doc.DoAudUsuCre == null)
                {
                    doc.DoIdent = plantilla.DoIdent;
                    doc.DoTipo = "PCT";
                    doc.DoFolio = plantilla.DoIdent;
                    doc.DoVersion = 1;
                    doc.DoVersionL = "A";
                    doc.DoFecha = DateTime.Now;
                    doc.PyNumero = cfg.CgDfPry;
                    doc.EmIdent = cfg.CgDfEmp;
                    doc.DiNumero = cfg.CgDfCli;
                    doc.CnNumero01 = 0;
                    doc.CnNumero02 = 0;
                    doc.CnNumero03 = 0;
                    doc.CnNumero04 = 0;
                    doc.CnNumero05 = 0;
                    doc.DoSubTotalMoE = 0;
                    doc.DoTotalMoE = 0;
                    doc.DoMonEx = "";
                    doc.DoSubTotal = 0;
                    doc.DoDesc = 0;
                    doc.DoPjDesc = 0;
                    doc.DoTipoDesc = "";
                    doc.DoSubTDesc = 0;
                    doc.DoImpuesto = 0;
                    doc.DoImpImp = 0;
                    doc.DoTotal = 0;
                    doc.DoMoneda = "MXN";
                    doc.DoNombre = "";
                    doc.DoPath = "";
                    doc.DoEstatus = "NUEVO";
                    doc.DoAvance = 0;
                    doc.DoTiCambio = 0;
                    doc.DoReferencia = "";
                    doc.DoDescripcion = "";
                    doc.DoDocRef = "";
                    doc.DoVendedor = "";
                    doc.DoFechaIni = DateTime.Now.AddDays(-1);
                    doc.DoFechaFin = DateTime.Now.AddDays(-1);
                    doc.DoUsuSeg = usuarioCache.nombreUsuario;
                    doc.DoGrupo = plantilla.DoIdent;
                    doc.DoGrupoOrden = 1;
                    doc.DoActivo = "A";
                    doc.guardar();

                    btnGenerar.Visible = false;
                    btnEditar.Visible = true;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DocCotCuerpo ventana = new DocCotCuerpo(plantilla.DoIdent, modo.update);
            ventana.ShowDialog();
        }
    }
}
