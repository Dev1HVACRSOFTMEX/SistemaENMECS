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
    public partial class ListaNota : Form
    {
        private _Nota not = new _Nota();
        private DataTable dt = new DataTable("nota");
        //private string[] tipo00 = new string[] { "DCONG", "DNOIN", "DNTIM", "DCLGA", "DCVOF", "DCFPA", "DCCPA", "DCTEN", "PINCL", "PNINC", "PCARA" };
        //private string[] tipo01 = new string[] { "Condiciones Generales de Venta", "No Se Incluye", "Notas Importante", "Clausulas de garantia no validas", "Vigencia Oferta", "Forma de Pago", "Condiciones de Pago", "Tiempo de Entrega", "INCLUYE", "NO INCLUYE", "CARACTERISTICAS" };
        private string[] tipo00 = new string[] { "DCCTM", "DCCVF", "DCCFP", "DCCCP", "DCCTE", "DCCPE", "DCCSE", "DCNIM" };
        private string[] tipo01 = new string[] { "Tipo de Moneda", "Vigencia de la Oferta", "Forma de Pago", "Condiciones de Pago", "Términos de Entrega", "Plazo de Entrega", "Se Excluye", "Notas Importantes" };
        private string[] tipoPar00 = new string[] { "PINCL", "PNINC", "PCARA" };
        private string[] tipoPar01 = new string[] { "INCLUYE", "NO INCLUYE", "CARACTERISTICAS" };

        public ListaNota()
        {
            InitializeComponent();
            /*not.NoIdent = "";
            not.NoTipo = "";
            not.listado();*/

            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            //dt.Columns.Add(new DataColumn("Estatus", typeof(string)));
        }

        private void ListaNota_Load(object sender, EventArgs e)
        {
            int idx = 1;

            cbCategoria.Items.Clear();
            cbCategoria.Items.Insert(0, "<Seleccionar>");
            cbCategoria.Items.Insert(1, "Documento");
            cbCategoria.Items.Insert(2, "Partida");
            cbCategoria.SelectedIndex = 0;
            
            cbTipo.Items.Clear();
            cbTipo.Items.Insert(0, "<Seleccionar>");
            foreach (string item in tipo01)
            {
                cbTipo.Items.Insert(idx, item.Trim());
                idx++;
            }
            cbTipo.SelectedIndex = 0;
            
            foreach (NOTA item in not.listNot)
            {
                DataRow dr = dt.NewRow();
                dr["Descripcion"] = item.NoDescripcion;
                //dr["Estatus"] = item.NoActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }

            dgNota.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string NoIdent = "";
            Nota ventana = new Nota(NoIdent, modo.insert);
            ventana.ShowDialog();

            int idx = cbTipo.SelectedIndex;
            if (idx > 0)
                not.NoTipo = tipo00[idx - 1].Trim();
            else
                not.NoTipo = "";
            not.NoIdent = "";
            not.listado();

            dt.Clear();
            foreach (NOTA item in not.listNot)
            {
                DataRow dr = dt.NewRow();
                dr["Descripcion"] = item.NoDescripcion;
                //dr["Estatus"] = item.NoActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgNota.DataSource = dt;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbTipo.SelectedIndex;
            int idc = cbCategoria.SelectedIndex;
            if (idx > 0)
            {
                not.NoTipo = tipo00[idx - 1].Trim();
                not.NoIdent = "";
                not.listado();

                dt.Clear();
                foreach (NOTA item in not.listNot)
                {
                    DataRow dr = dt.NewRow();
                    dr["Descripcion"] = item.NoDescripcion;
                    //dr["Estatus"] = item.NoActivo == "A" ? "Activo" : "Inactivo";
                    dt.Rows.Add(dr);
                }

                dgNota.DataSource = dt;
            }
            else if (idx == 0)
            {
                not.NoTipo = idc == 0 ? "" : (idc == 1 ? "DC" : "P");
                not.NoIdent = "";
                not.listado();

                dt.Clear();
                foreach (NOTA item in not.listNot)
                {
                    DataRow dr = dt.NewRow();
                    dr["Descripcion"] = item.NoDescripcion;
                    //dr["Estatus"] = item.NoActivo == "A" ? "Activo" : "Inactivo";
                    dt.Rows.Add(dr);
                }

                dgNota.DataSource = dt;
            }

        }

        private void dgNota_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string NoIdent = not.listNot[e.RowIndex].NoIdent;
            Nota ventana = new Nota(NoIdent, modo.update);
            ventana.ShowDialog();

            int idx = cbTipo.SelectedIndex;
            if (idx > 0)
                not.NoTipo = tipo00[idx - 1].Trim();
            else
                not.NoTipo = "";
            not.NoIdent = "";
            not.listado();

            dt.Clear();
            foreach (NOTA item in not.listNot)
            {
                DataRow dr = dt.NewRow();
                dr["Descripcion"] = item.NoDescripcion;
                //dr["Estatus"] = item.NoActivo == "A" ? "Activo" : "Inactivo";
                dt.Rows.Add(dr);
            }
            dgNota.DataSource = dt;
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgNota.DataSource = null;

            int idx = cbCategoria.SelectedIndex;
            int i = 1;
            cbTipo.Items.Clear();
            cbTipo.Items.Insert(0, "<Seleccionar>");
            
            if (idx == 0)
            {
                not.NoTipo = "";
                not.NoIdent = "";
                not.listado();

                dt.Clear();
                foreach (NOTA item in not.listNot)
                {
                    DataRow dr = dt.NewRow();
                    dr["Descripcion"] = item.NoDescripcion;
                    dt.Rows.Add(dr);
                }

                dgNota.DataSource = dt;
            }
            else if (idx == 1)
            {
                foreach (string item in tipo01)
                {
                    cbTipo.Items.Insert(i, tipo01[i - 1]);
                    i++;
                }

                not.NoTipo = "";
                not.NoIdent = "DC";
                not.listado();

                dt.Clear();
                foreach (NOTA item in not.listNot)
                {
                    DataRow dr = dt.NewRow();
                    dr["Descripcion"] = item.NoDescripcion;
                    dt.Rows.Add(dr);
                }

                dgNota.DataSource = dt;
            }
            else if (idx == 2)
            {
                foreach (string item in tipoPar01)
                {
                    cbTipo.Items.Insert(i, tipoPar01[i - 1]);
                    i++;
                }

                not.NoTipo = "";
                not.NoIdent = "P";
                not.listado();

                dt.Clear();
                foreach (NOTA item in not.listNot)
                {
                    DataRow dr = dt.NewRow();
                    dr["Descripcion"] = item.NoDescripcion;
                    dt.Rows.Add(dr);
                }

                dgNota.DataSource = dt;
            }

            cbTipo.SelectedIndex = 0;
        }
    }
}
