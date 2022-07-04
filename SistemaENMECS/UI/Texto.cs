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
    public partial class Texto : Form
    {
        public Texto(string texto)
        {
            InitializeComponent();
            txtDesc.Text = texto;
        }

        private void Texto_Load(object sender, EventArgs e)
        {

        }
    }
}
