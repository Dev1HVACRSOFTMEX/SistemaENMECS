using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaENMECS.UI
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            ListaDirectorio ventana = new ListaDirectorio();
            ventana.ShowDialog();
        }

        private void btnPry_Click(object sender, EventArgs e)
        {
            ListaProyecto ventana = new ListaProyecto();
            ventana.ShowDialog();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            ListaDocumento ventana = new ListaDocumento("COT");
            ventana.ShowDialog();
        }
    }
}
