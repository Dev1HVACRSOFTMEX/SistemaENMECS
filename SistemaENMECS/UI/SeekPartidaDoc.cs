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
    public partial class SeekPartidaDoc : Form
    {
        public _DocCPartida partida = new _DocCPartida();
        private PARTIDASDOC item = new PARTIDASDOC();
        private List<PARTIDASDOC> lista = new List<PARTIDASDOC>();
        private _Codigo objetivo = new _Codigo();
        private _Codigo tipoVent;
        private _Codigo general = new _Codigo();
        private DataTable dt = new DataTable("partida");
        private int idx = -1;

        public SeekPartidaDoc()
        {
            InitializeComponent();

            item.DiNomCorto = "";
            item.PyNombre = "";
            item.PyObjetivo = "";
            item.PyTipoSis = "";
            item.DoDescripcion = "";
            item.DcDescripcion = "";
            item.DpDescripcion = "";
            partida.partidaDoc = item;

            partida.listadoPartidas();

            objetivo.CdCategoria = "PRY";
            objetivo.CdGrupo = "FIN";
            objetivo.CdTipo = "";
            objetivo.listado();

            tipoVent = new _Codigo();
            tipoVent.CdCategoria = "FIN";
            tipoVent.CdGrupo = "";
            tipoVent.CdTipo = "";
            tipoVent.listado();

            string cod = "";
            general.listCod = new List<CODIGO>();
            foreach (CODIGO item in tipoVent.listCod)
            {
                if (cod != item.CdTipo)
                {
                    cod = item.CdTipo;
                    general.listCod.Add(item);
                }
            }
        }

        private void SeekPartidaDoc_Load(object sender, EventArgs e)
        {
            int i = 1;
            cbObjetivo.Items.Clear();
            cbObjetivo.Items.Insert(0, "<Seleccionar>");
            foreach (CODIGO item in objetivo.listCod)
            {
                cbObjetivo.Items.Insert(i, item.CdDescripcion);
                i++;
            }
            if (i > 1)
                cbObjetivo.SelectedIndex = 0;

            string cod = "";
            i = 1;
            cbTipoSis.Items.Clear();
            cbTipoSis.Items.Insert(0, "<Seleccionar>");
            foreach (CODIGO item in general.listCod)
            {
                cbTipoSis.Items.Insert(i, item.CdDescripcion);
                i++;
            }
            if (i > 1)
                cbTipoSis.SelectedIndex = 0;

            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripción", typeof(string)));

            foreach (PARTIDASDOC item in partida.partidasDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Cliente"] = item.DiNomCorto.Trim();
                dr["Descripción"] = item.DpDescripcion.Trim();
                dt.Rows.Add(dr);
            }
            dgPartida.DataSource = dt;
        }

        private void cbObjetivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxO = cbObjetivo.SelectedIndex;
            if (idxO > 0)
            {
                tipoVent = new _Codigo();
                tipoVent.CdCategoria = objetivo.listCod[idxO - 1].CdGrupo;
                tipoVent.CdGrupo = objetivo.listCod[idxO - 1].CdTipo;
                tipoVent.CdTipo = "";
                tipoVent.listado();

                int i = 1;
                cbTipoSis.Items.Clear();
                cbTipoSis.Items.Insert(0, "<Seleccionar>");
                foreach (CODIGO item in tipoVent.listCod)
                {
                    cbTipoSis.Items.Insert(i, item.CdDescripcion);
                    i++;
                }
                if (i > 1)
                    cbTipoSis.SelectedIndex = 0;
            }
            else if (idxO == 0)
            {
                int i = 1;
                cbTipoSis.Items.Clear();
                cbTipoSis.Items.Insert(0, "<Seleccionar>");
                foreach (CODIGO item in general.listCod)
                {
                    cbTipoSis.Items.Insert(i, item.CdDescripcion);
                    i++;
                }
                if (i > 1)
                    cbTipoSis.SelectedIndex = 0;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipo = "";

            if (cbObjetivo.SelectedIndex > 0)
                tipo = cbTipoSis.SelectedIndex > 0 ? tipoVent.listCod[cbTipoSis.SelectedIndex - 1].CdTipo : "";
            else if (cbObjetivo.SelectedIndex == 0)
                tipo = cbTipoSis.SelectedIndex > 0 ? general.listCod[cbTipoSis.SelectedIndex - 1].CdTipo : "";

            item.DiNomCorto = txtNomCorto.Text;
            item.PyNombre = "";
            item.PyObjetivo = cbObjetivo.SelectedIndex > 0 ? objetivo.listCod[cbObjetivo.SelectedIndex - 1].CdTipo : "";
            item.PyTipoSis = tipo;
            item.DoDescripcion = txtDocumento.Text;
            item.DcDescripcion = txtConcepto.Text;
            item.DpDescripcion = txtPartida.Text;
            partida.partidaDoc = item;

            partida.listadoPartidas();

            dt.Rows.Clear();
            foreach (PARTIDASDOC item in partida.partidasDoc)
            {
                DataRow dr = dt.NewRow();
                dr["Cliente"] = item.DiNomCorto.Trim();
                dr["Descripción"] = item.DpDescripcion.Trim();
                dt.Rows.Add(dr);
            }
            dgPartida.DataSource = dt;

            idx = -1;
            txtDescripcion.Text = "";
            partida.DoIdent = "";
            partida.CoNumero = 0;
            partida.DpNumero = 0;
        }

        private void dgPartida_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            txtDescripcion.Text = partida.partidasDoc[idx].DpDescripcion;
            partida.DoIdent = partida.partidasDoc[idx].DoIdent;
            partida.CoNumero = partida.partidasDoc[idx].CoNumero;
            partida.DpNumero = partida.partidasDoc[idx].DpNumero;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idx > -1)
            {
                partida.consultaUno();
                this.Close();
            }
            else
                MessageBox.Show("Es necesario se seleccione una Partida");
        }
    }
}
