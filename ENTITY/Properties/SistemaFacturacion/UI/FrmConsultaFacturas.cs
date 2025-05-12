using System;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class FrmConsultaFacturas : Form
    {
        private readonly FacturaService facturaService;

        public FrmConsultaFacturas()
        {
            InitializeComponent();
            facturaService = new FacturaService();
        }

        private void FrmConsultaFacturas_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            dgvFacturas.DataSource = facturaService.Consultar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}