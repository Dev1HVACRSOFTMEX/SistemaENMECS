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
    public partial class ListaArtCli : Form
    {
        private string idArt;
        private _Articulo articulo = new _Articulo();
        private DataTable dt = new DataTable();

        public ListaArtCli(string ArIdent)
        {
            InitializeComponent();

            idArt = ArIdent;

            articulo.ArIdent = idArt;
            articulo.listadoCLI();
        }

        private void ListaArtCli_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn("Ident", typeof(string)));
            dt.Columns.Add(new DataColumn("Cliente", typeof(string)));
            dt.Columns.Add(new DataColumn("Documento", typeof(string)));

            foreach (ARTICULOCLIENTES item in articulo.listDir)
            {
                DataRow dr = dt.NewRow();
                dr["Ident"] = item.DiNumero;
                dr["Cliente"] = item.DiNombreCom;
                dr["Documento"] = item.DoFolio;

                dt.Rows.Add(dr);
            }

            dgDir.DataSource = dt;
        }
    }
}
