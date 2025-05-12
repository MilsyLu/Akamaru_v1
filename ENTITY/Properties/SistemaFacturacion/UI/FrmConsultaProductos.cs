using System;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmConsultaProductos : Form
    {
        private readonly ProductoService productoService;

        public FrmConsultaProductos()
        {
            InitializeComponent();
            productoService = new ProductoService();
        }

        private void FrmConsultaProductos_Load(object sender, EventArgs e)
        {
            cmbFiltro.SelectedIndex = 0;
            CargarTodosLosProductos();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex == 0) // Todos
            {
                txtValorFiltro.Enabled = false;
                txtValorFiltro.Clear();
            }
            else
            {
                txtValorFiltro.Enabled = true;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            switch (cmbFiltro.SelectedIndex)
            {
                case 0: // Todos
                    CargarTodosLosProductos();
                    break;
                case 1: // Por Estado
                    if (string.IsNullOrEmpty(txtValorFiltro.Text))
                    {
                        MessageBox.Show("Debe ingresar un estado (activo/inactivo)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CargarProductosPorEstado(txtValorFiltro.Text);
                    break;
                case 2: // Por Nombre
                    if (string.IsNullOrEmpty(txtValorFiltro.Text))
                    {
                        MessageBox.Show("Debe ingresar un nombre para filtrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CargarProductosPorNombre(txtValorFiltro.Text);
                    break;
            }
        }

        private void CargarTodosLosProductos()
        {
            dgvProductos.DataSource = productoService.Consultar();
        }

        private void CargarProductosPorEstado(string estado)
        {
            dgvProductos.DataSource = productoService.ConsultarPorEstado(estado);
        }

        private void CargarProductosPorNombre(string nombre)
        {
            dgvProductos.DataSource = productoService.ConsultarPorNombre(nombre);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}