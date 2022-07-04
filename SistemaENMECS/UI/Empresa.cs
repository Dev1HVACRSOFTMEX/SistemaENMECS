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
    public partial class Empresa : Form
    {
        private _Empresa empresa = new _Empresa();
        private _Directorio directorio = new _Directorio();
        private _GrCarp grcarp = new _GrCarp();
        private string idEmp;
        private modo m;

        public Empresa(string EmIdent, modo mod)
        {
            InitializeComponent();

            idEmp = EmIdent;
            m = mod;
            if (modo.update == m)
            {
                empresa.EmIdent = idEmp;
                string res = empresa.consultaUno();
                txtIdent.ReadOnly = true;
            }
            else if (modo.insert == m)
            {
                txtIdent.ReadOnly = false;
                checkActivo.CheckState = CheckState.Checked;
            }

            directorio.DiNumero = "";
            directorio.DiTipo = "EMP";
            directorio.DiRFC = "";
            directorio.DiNombreCom = "";
            directorio.listado();

            grcarp.GcIdent = "";
            grcarp.GcDescripcion = "";
            grcarp.listado();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            cbDirectorio.Items.Clear();
            cbDirectorio.Items.Insert(0, "<Selección>");
            int idx = 0, indice = 0;
            foreach (DIRECTORIO item in directorio.listDir)
            {
                idx++;
                cbDirectorio.Items.Insert(idx, item.DiNomCorto);
                if (modo.update == m && empresa.DiNumero == item.DiNumero)
                    indice = idx;
            }
            if (idx > 0)
                cbDirectorio.SelectedIndex = 0;

            cbGcIdent.Items.Clear();
            cbGcIdent.Items.Insert(0, "<Selección>");
            cbGrCot.Items.Clear();
            cbGrCot.Items.Insert(0, "<Selección>");
            int idGc = -1, idGrCot = -1;
            idx = 0;
            foreach(GRCARP item in grcarp.listGrC)
            {
                idx++;
                cbGcIdent.Items.Insert(idx, item.GcDescripcion);
                cbGrCot.Items.Insert(idx, item.GcDescripcion);
                if (modo.update == m && empresa.EmGrIdent == item.GcIdent)
                    idGc = idx;
                if (modo.update == m && empresa.EmGrIdCot == item.GcIdent)
                    idGrCot = idx;
            }
            if (idx > 0)
            {
                cbGcIdent.SelectedIndex = 0;
                cbGrCot.SelectedIndex = 0;
            }

            if (modo.update == m)
            {
                txtIdent.Text = empresa.EmIdent;
                txtLogo.Text = empresa.EmLogotipo;
                txtLey1.Text = empresa.EmLeyenda01;
                txtLey4.Text = empresa.EmLeyenda04;
                cbDirectorio.SelectedIndex = indice;
                cbGcIdent.SelectedIndex = idGc == -1 ? 0 : idGc;
                cbGrCot.SelectedIndex = idGrCot == -1 ? 0 : idGrCot;
                txtPre.Text = empresa.EmPrefijo;
                txtPrePry.Text = empresa.EmPrefijoPry;
                checkActivo.Checked = empresa.EmActivo == "A" ? true : false;
            }
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (modo.update == m)
            {
                if (checkActivo.Checked)
                {
                    empresa.actualizar();
                }
                else
                {
                    empresa.eliminar();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            empresa.EmLogotipo = txtLogo.Text.Trim();
            empresa.EmLeyenda01 = txtLey1.Text.Trim();
            empresa.EmLeyenda02 = "";
            empresa.EmLeyenda03 = "";
            empresa.EmLeyenda04 = txtLey4.Text.Trim();
            empresa.EmLeyenda05 = "";
            empresa.DiNumero = cbDirectorio.SelectedIndex == 0 ? "" : directorio.listDir[cbDirectorio.SelectedIndex - 1].DiNumero.Trim();
            empresa.EmGrIdent = grcarp.listGrC[cbGcIdent.SelectedIndex - 1].GcIdent.Trim();
            empresa.EmPrefijo = txtPre.Text;
            empresa.EmPrefijoPry = txtPrePry.Text;
            empresa.EmGrIdent = cbGcIdent.SelectedIndex == 0 ? "" : grcarp.listGrC[cbGcIdent.SelectedIndex - 1].GcIdent;
            empresa.EmGrIdCot = cbGrCot.SelectedIndex == 0 ? "" : grcarp.listGrC[cbGrCot.SelectedIndex - 1].GcIdent;
            empresa.EmActivo = checkActivo.Checked ? "A" : "I";
            if (modo.insert == m)
            {
                empresa.EmIdent = txtIdent.Text.Trim();
                string res = empresa.guardar();
                if (res == "")
                    this.Close();
                else
                    MessageBox.Show(res);
            }
            else if (modo.update == m)
            {
                string res = empresa.actualizar();
                if (res == "")
                    this.Close();
                else
                    MessageBox.Show(res);
            }
        }
    }
}
