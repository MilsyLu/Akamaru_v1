using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmNuevaFactura : Form
    {
        private readonly FacturaService facturaService;
        private readonly ProductoService productoService;
        private Factura facturaActual;
        private List<DetalleFactura> detallesTemporales;

        public FrmNuevaFactura()
        {
            InitializeComponent();
            facturaService = new FacturaService();
            productoService = new ProductoService();
            detallesTemporales = new List<DetalleFactura>();
        }

        private void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            // Inicializar la factura
            int nuevoId = facturaService.ObtenerSiguienteIdFactura();
            facturaActual = new Factura(nuevoId, DateTime.Now);
            txtNumeroFactura.Text = nuevoId.ToString();

            // Cargar productos activos
            CargarProductos();

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Actualizar total
            ActualizarTotal();
        }

        private void CargarProductos()
        {
            var productos = productoService.ConsultarPorEstado("activo");
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Referencia";
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalles.DataSource = detallesTemporales;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir dígitos y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    MessageBox.Show("Debe ingresar una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                    return;
                }

                int cantidad = int.Parse(txtCantidad.Text);
                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                    return;
                }

                // Obtener el producto seleccionado
                Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;

                // Validar disponibilidad
                string validacion = facturaService.ValidarDisponibilidadProducto(productoSeleccionado.Referencia, cantidad);
                if (!string.IsNullOrEmpty(validacion))
                {
                    MessageBox.Show(validacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear detalle
                DetalleFactura detalle = new DetalleFactura(
                    facturaService.ObtenerSiguienteIdDetalle() + detallesTemporales.Count,
                    facturaActual.IdFactura,
                    facturaActual.FechaFactura,
                    productoSeleccionado.Referencia,
                    productoSeleccionado.Nombre,
                    cantidad,
                    productoSeleccionado.PrecioUnitario
                );

                // Agregar a la lista temporal
                detallesTemporales.Add(detalle);

                // Actualizar DataGridView
                dgvDetalles.DataSource = null;
                dgvDetalles.DataSource = detallesTemporales;

                // Actualizar total
                ActualizarTotal();

                // Limpiar campos
                txtCantidad.Clear();
                cmbProducto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (var detalle in detallesTemporales)
            {
                total += detalle.ValorItemVendido;
            }
            txtTotal.Text = total.ToString("C");
            facturaActual.ValorTotal = total;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (detallesTemporales.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto a la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Actualizar fecha de la factura
                facturaActual.FechaFactura = dtpFechaFactura.Value;

                // Asignar detalles a la factura
                facturaActual.Detalles = new List<DetalleFactura>(detallesTemporales);

                // Guardar factura
                string resultado = facturaService.Guardar(facturaActual);

                if (resultado.StartsWith("Error"))
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Factura guardada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}