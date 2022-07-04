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
    public partial class Admin : Form
    {
        private Point ancla;

        public Admin()
        {
            InitializeComponent();
        }

        private void btnCfg_Click(object sender, EventArgs e)
        {
            /*Configuracion ventana = new Configuracion();
            ventana.ShowDialog();*/
            AbrirForm(new Configuracion());
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            /*ListaCategoria ventana = new ListaCategoria();
            ventana.ShowDialog();*/
            AbrirForm(new ListaCategoria());
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            /*ListaConcepto ventana = new ListaConcepto();
            ventana.ShowDialog();*/
            AbrirForm(new ListaConcepto());
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            /*ListaNota ventana = new ListaNota();
            ventana.ShowDialog();*/
            AbrirForm(new ListaNota());
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            /*ListaDirectorio ventana = new ListaDirectorio("CLI");
            ventana.ShowDialog();*/
            AbrirForm(new ListaDirectorio("CLI"));
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            /*ListaDirectorio ventana = new ListaDirectorio("PRV");
            ventana.ShowDialog();*/
            AbrirForm(new ListaDirectorio("PRV"));
        }

        private void btnPla_Click(object sender, EventArgs e)
        {
            /*ListaPlantilla ventana = new ListaPlantilla();
            ventana.ShowDialog();*/
            AbrirForm(new ListaPlantilla());
        }

        private void btnPry_Click(object sender, EventArgs e)
        {
            /*ListaProyecto ventana = new ListaProyecto();
            ventana.ShowDialog();*/
            AbrirForm(new ListaProyecto());
        }

        private void btnUsu_Click(object sender, EventArgs e)
        {
            /*ListaUsuario ventana = new ListaUsuario("EMP0000001");
            ventana.ShowDialog();*/
            AbrirForm(new ListaUsuario("EMP0000001"));
        }

        private void btnTiC_Click(object sender, EventArgs e)
        {
            /*TipoCambio ventana = new TipoCambio();
            ventana.ShowDialog();*/
            AbrirForm(new TipoCambio());
        }

        private void btnArt_Click(object sender, EventArgs e)
        {
            /*ListaArticulo ventana = new ListaArticulo();
            ventana.ShowDialog();*/
            AbrirForm(new ListaArticulo());
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            /*ListaDocumento ventana = new ListaDocumento("COT");
            ventana.ShowDialog();*/
            AbrirForm(new ListaDocumento("COT"));
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            /*ListaCodigo ventana = new ListaCodigo();
            ventana.ShowDialog();*/
            AbrirForm(new ListaCodigo());
        }

        private void btnGenCod_Click(object sender, EventArgs e)
        {
            /*Especificacion ventana = new Especificacion();
            ventana.ShowDialog();*/
            AbrirForm(new Especificacion());
        }

        private void btnCarpetas_Click(object sender, EventArgs e)
        {
            /*ListaCarpeta ventana = new ListaCarpeta();
            ventana.ShowDialog();*/
            AbrirForm(new ListaCarpeta());
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            ancla.X = 20;
            ancla.Y = 250;

            subDir.Visible = false;
            subCat.Visible = false;

            Point loc = ancla;
            btnTiC.Location = loc;
            pTipC.Location = loc;
            loc.Y += pTipC.Size.Height;
            btnCatalogo.Location = loc;
            pCatal.Location = loc;
        }

        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            Point loc = ancla;
            if (subDir.Visible)
            {
                subDir.Visible = false;
                
                btnTiC.Location = loc;
                pTipC.Location = loc;
                loc.Y += pTipC.Size.Height;
                btnCatalogo.Location = loc;
                pCatal.Location = loc;
            }
            else
            {
                subDir.Visible = true;
                subCat.Visible = false;
                
                loc.Y += subDir.Size.Height;
                btnTiC.Location = loc;
                pTipC.Location = loc;
                loc.Y += pTipC.Size.Height;
                btnCatalogo.Location = loc;
                pCatal.Location = loc;
            }
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            Point loc = ancla;
            if (subCat.Visible)
            {
                subCat.Visible = false;
                
                btnTiC.Location = loc;
                pTipC.Location = loc;
                loc.Y += pTipC.Size.Height;
                btnCatalogo.Location = loc;
                pCatal.Location = loc;
            }
            else
            {
                subCat.Visible = true;
                subDir.Visible = false;

                btnTiC.Location = loc;
                pTipC.Location = loc;
                loc.Y += pTipC.Size.Height;
                btnCatalogo.Location = loc;
                pCatal.Location = loc;
                loc = btnCatalogo.Location;
                loc.Y += btnCatalogo.Size.Height;
                subCat.Location = loc;
            }
        }

        private void AbrirForm(object formInterno)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formInterno as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
    }
}
