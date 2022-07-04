using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaENMECS.BLL
{
    class Partida : TreeNode
    {
        public string ArIdent;
        public string DpDescripcion;
        public double DpCantidad;
        public string DpUnidad;
        public double DpImporte;

        public Partida(string id, string desc, double cant, string uni, double imp)
        {
            ArIdent = id;
            DpDescripcion = desc;
            DpCantidad = cant;
            DpUnidad = uni;
            DpImporte = imp;
        }

        public Partida(string id, string desc, double cant, string uni, double imp, string etiq, int img0, int img1)
            : base(etiq, img0, img1)
        {
            ArIdent = id;
            DpDescripcion = desc;
            DpCantidad = cant;
            DpUnidad = uni;
            DpImporte = imp;
        }
    }
}
