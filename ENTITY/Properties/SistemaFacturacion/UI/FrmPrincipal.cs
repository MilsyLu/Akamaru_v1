// GUI/FrmPrincipal.cs
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void registrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroProducto frm = new FrmRegistroProducto();
            frm.ShowDialog();
        }

        private void consultarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaProductos frm = new FrmConsultaProductos();
            frm.ShowDialog();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaFactura frm = new FrmNuevaFactura();
            frm.ShowDialog();
        }

        private void consultarFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaFacturas frm = new FrmConsultaFacturas();
            frm.ShowDialog();
        }
    }
}