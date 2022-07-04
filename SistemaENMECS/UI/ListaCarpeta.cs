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
    public partial class ListaCarpeta : Form
    {
        _GrCarp grcarp = new _GrCarp();
        _Carpeta carpeta = new _Carpeta();
        DataTable dt = new DataTable("Carpeta");
        modo grM = modo.none;
        modo crM = modo.none;
        int idxCr = 0;

        public ListaCarpeta()
        {
            InitializeComponent();

            gbDatos.Visible = false;
            gbCarpeta.Visible = false;
            btnEditGrupo.Visible = false;
            btnAddCar.Visible = false;

            grcarp.GcIdent = "";
            grcarp.GcDescripcion = "";
            grcarp.listado();
        }

        private void ListaCarpeta_Load(object sender, EventArgs e)
        {
            cbGcIdent.Items.Clear();
            cbGcIdent.Items.Insert(0, "<Seleccionar>");
            if (grcarp.listGrC != null)
            {
                int i = 1;
                foreach (GRCARP item in grcarp.listGrC)
                {
                    cbGcIdent.Items.Insert(i, item.GcDescripcion.Trim());
                    i++;
                }
                cbGcIdent.SelectedIndex = 0;
            }

            //////////////////////////////Carpetas//////////////////////////////
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Carpeta", typeof(string)));
            
            dgCarpetas.DataSource = dt;
        }

        private void btnAddGrupo_Click(object sender, EventArgs e)
        {
            gbDatos.Visible = true;
            txtGcIdent.Enabled = true;

            txtGcIdent.Text = "";
            txtGcDescripcion.Text = "";
            txtGcPath.Text = "";

            grM = modo.insert;
        }

        private void btnEditGrupo_Click(object sender, EventArgs e)
        {
            gbDatos.Visible = true;
            txtGcIdent.Enabled = false;

            grcarp.GcIdent = grcarp.listGrC[cbGcIdent.SelectedIndex - 1].GcIdent;
            grcarp.GcDescripcion = "";
            grcarp.consultaUno();
            
            txtGcIdent.Text = grcarp.GcIdent;
            txtGcDescripcion.Text = grcarp.GcDescripcion;
            txtGcPath.Text = grcarp.GcPath;

            grM = modo.update;
        }

        private void cbGcIdent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbGcIdent.SelectedIndex;

            gbDatos.Visible = false;
            gbCarpeta.Visible = false;

            if (idx > 0)
            {
                btnAddGrupo.Visible = false;
                btnEditGrupo.Visible = true;
                btnAddCar.Visible = true;

                carpeta.GcIdent = grcarp.listGrC[idx - 1].GcIdent;
                carpeta.CrIdent = "";
                carpeta.CrNombre = "";
                carpeta.listado();

                dt.Rows.Clear();
                foreach (CARPETA item in carpeta.listCar)
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = item.CrIdent.Trim();
                    dr["Carpeta"] = item.CrNombre.ToString().Trim();
                    dt.Rows.Add(dr);
                }
                dgCarpetas.DataSource = dt;
            }
            else
            {
                btnAddGrupo.Visible = true;
                btnEditGrupo.Visible = false;
                btnAddCar.Visible = false;
                
                dt.Rows.Clear();
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            gbCarpeta.Visible = true;
            txtCrIdent.Enabled = true;

            txtCrIdent.Text = "";
            txtCrNombre.Text = "";
            ckeckActivo.CheckState = CheckState.Checked;

            crM = modo.insert;
        }

        private void dgCarpetas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            idxCr = e.RowIndex;

            gbCarpeta.Visible = true;
            txtCrIdent.Enabled = false;

            txtCrIdent.Text = carpeta.listCar[idx].CrIdent;
            txtCrNombre.Text = carpeta.listCar[idx].CrNombre;
            ckeckActivo.Checked = carpeta.listCar[idx].CrActivo == "A" ? true : false;

            crM = modo.update;
        }

        private void btnGuardaGrupo_Click(object sender, EventArgs e)
        {
            grcarp.GcDescripcion = txtGcDescripcion.Text;
            grcarp.GcPath = txtGcPath.Text;
            grcarp.GcActivo = "A";

            if (grM == modo.insert)
            {
                grcarp.GcIdent = txtGcIdent.Text;
                grcarp.guardar();
            }
            else
                grcarp.actualizar();

            gbDatos.Visible = false;

            grcarp.GcIdent = "";
            grcarp.GcDescripcion = "";
            grcarp.listado();

            cbGcIdent.Items.Clear();
            cbGcIdent.Items.Insert(0, "<Seleccionar>");
            if (grcarp.listGrC != null)
            {
                int i = 1;
                foreach (GRCARP item in grcarp.listGrC)
                {
                    cbGcIdent.Items.Insert(i, item.GcDescripcion.Trim());
                    i++;
                }
                cbGcIdent.SelectedIndex = 0;
            }
        }

        private void btnGuardaCar_Click(object sender, EventArgs e)
        {
            carpeta.CrNombre = txtCrNombre.Text;
            carpeta.CrActivo = "A";

            if (crM == modo.insert)
            {
                carpeta.GcIdent = grcarp.listGrC[cbGcIdent.SelectedIndex - 1].GcIdent;
                carpeta.CrIdent = txtCrIdent.Text;
                carpeta.guardar();
            }
            else
            {
                carpeta.GcIdent = carpeta.listCar[idxCr].GcIdent;
                carpeta.CrIdent = carpeta.listCar[idxCr].CrIdent;
                carpeta.CrActivo = ckeckActivo.CheckState == CheckState.Checked ? "A" : "I";
                carpeta.actualizar();
            }

            gbCarpeta.Visible = false;

            carpeta.GcIdent = grcarp.listGrC[cbGcIdent.SelectedIndex - 1].GcIdent;
            carpeta.CrIdent = "";
            carpeta.CrNombre = "";
            carpeta.listado();

            dt.Rows.Clear();
            foreach (CARPETA item in carpeta.listCar)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.CrIdent.Trim();
                dr["Carpeta"] = item.CrNombre.ToString().Trim();
                dt.Rows.Add(dr);
            }
            dgCarpetas.DataSource = dt;
        }
    }
}
