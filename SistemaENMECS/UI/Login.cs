using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Configuration;
using SistemaENMECS.BLL;

namespace SistemaENMECS.UI
{
    public partial class Login : Form
    {
        lecturaEscritura objleerEscribir = new lecturaEscritura();
        private ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        private string serial = string.Empty;
        private string manufacturer = string.Empty;
        private string product = string.Empty;
        private string v1 = string.Empty;
        private string v2 = string.Empty;
        private string v3 = string.Empty;


        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _Usuario user = new _Usuario();
            _TipoCambio tipoCambio = new _TipoCambio();
            _Configuracion cfg = new _Configuracion();

            cfg.CgIdent = ConfigurationManager.AppSettings["CgIdent"];
            cfg.consultaUno();

            string hoy1 = DateTime.Today.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Year.ToString() + " 00:00:00";
            string hoy2 = DateTime.Today.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Today.Year.ToString() + " 23:59:59";

            string hash = user.hashString(txtPassword.Text.Trim(), txtUsuario.Text.Trim());
            user.DiNumero = "";
            user.CnNumero = 0;
            user.UsUsuario = txtUsuario.Text.Trim();
            string res = user.login();
            string ban = "S";

            tipoCambio.TcIdent = "";
            tipoCambio.FeIni = Convert.ToDateTime(hoy1);
            tipoCambio.FeFin = Convert.ToDateTime(hoy2);

            int ds = (int)DateTime.Today.DayOfWeek;
            if (user.UsUsuario == null)
                MessageBox.Show("Usuario o Contraseña incorrecto, verificar datos");
            else
            {
                if (txtUsuario.Text.Trim() == user.UsUsuario.Trim() && hash.Trim() == user.UsPassword.Trim())
                {
                    //if (DateTime.Today.DayOfWeek.ToString().Substring(0, 1) != "S")
                    if (ds >= 1 && ds <= 5)
                    {
                        tipoCambio.listado();
                        if (tipoCambio.listTiC.Count == 0)
                        {
                            MessageBox.Show("Es importante colocar el tipo de cambio del día de hoy del Diario Oficial de la Federación.");
                            ban = "S";
                        }
                    }
                    if (res == "" && ban == "S")
                    {
                        usuarioCache.nombreUsuario = user.UsUsuario;
                        usuarioCache.idConfig = cfg.CgIdent;
                        usuarioCache.pathPry = cfg.CgPathPry;
                        usuarioCache.pathCot = cfg.CgPathCot;
                        usuarioCache.pathCotDf = ConfigurationManager.AppSettings["pathCotDf"];
                    }
                    else
                        usuarioCache.nombreUsuario = "";
                    if (usuarioCache.nombreUsuario != "")
                    {
                        if (user.UsPerfil == "ADMIN")
                        {
                            Admin ventana = new Admin();
                            this.Hide();
                            ventana.Show();
                        }
                        else if (user.UsPerfil == "VENTA")
                        {
                            Ventas ventana = new Ventas();
                            this.Hide();
                            ventana.Show();
                        }
                    }
                    else
                        MessageBox.Show("Usuario o Contraseña incorrecto, verificar datos");
                }
                else
                    MessageBox.Show("Usuario o Contraseña incorrecto, verificar datos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Cotizacion pdf = new Cotizacion();

            pdf.generaBateo();*/

            /*_Documento doc = new _Documento();
            doc.EmIdent = "BK";
            doc.DoFecha = Convert.ToDateTime("01/08/2021");
            doc.PyNumero = "0";
            doc.DoVersionL = "B";
            doc.foliador(modo.insert, 'S');*/

            /*Cotizacion pdf = new Cotizacion();
            pdf.termsCond();*/

            /*SeekTipoCambio ventana = new SeekTipoCambio();
            ventana.ShowDialog();*/

            /*TextoEdit ventana = new TextoEdit();
            ventana.ShowDialog();*/

            /*SeekPartidaDoc ventana = new SeekPartidaDoc();
            ventana.ShowDialog();*/
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                if (txtUsuario.Text != "" && txtPassword.Text != "")
                    btnAceptar_Click(sender, e);
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                if (txtUsuario.Text != "" && txtPassword.Text != "")
                    btnAceptar_Click(sender, e);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            foreach (ManagementObject mo in mos.Get())
            {
                try
                {
                    serial = mo.GetPropertyValue("SerialNumber").ToString();
                    manufacturer = mo.GetPropertyValue("Manufacturer").ToString();
                    product = mo.GetPropertyValue("Product").ToString();
                }
                catch
                { }
            }

            v1 = Convert.ToString(objleerEscribir.asignarTextos("v1:", "ini.ini"));
            v2 = Convert.ToString(objleerEscribir.asignarTextos("v2:", "ini.ini"));
            v3 = Convert.ToString(objleerEscribir.asignarTextos("v3:", "ini.ini"));

            if (serial != v1)
            {
                MessageBox.Show("Este equipo no tiene autorización de uso de licencia HVAC/R Software", "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                Close();
            }

            if (manufacturer != v2)
            {
                MessageBox.Show("Este equipo no tiene autorización de uso de licencia HVAC/R Software", "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                Close();
            }

            if (product != v3)
            {
                MessageBox.Show("Este equipo no tiene autorización de uso de licencia HVAC/R Software", "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                Close();
            }

        }
    }
}
