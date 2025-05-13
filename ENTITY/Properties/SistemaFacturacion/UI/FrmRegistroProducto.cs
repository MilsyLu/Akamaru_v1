using System;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmRegistroProducto : Form
    {
        private readonly ProductoService productoService;

        public FrmRegistroProducto()
        {
            InitializeComponent();
            productoService = new ProductoService();
        }

        private void txtNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir dígitos, punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrEmpty(txtReferencia.Text))
                {
                    MessageBox.Show("La referencia no puede estar vacía", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtReferencia.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("El nombre no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtExistencias.Text))
                {
                    MessageBox.Show("Las existencias no pueden estar vacías", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtExistencias.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtStockMinimo.Text))
                {
                    MessageBox.Show("El stock mínimo no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStockMinimo.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("El precio unitario no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecioUnitario.Focus();
                    return;
                }

                if (cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbEstado.Focus();
                    return;
                }

                // Crear el producto
                Producto producto = new Producto
                {
                    Referencia = txtReferencia.Text,
                    Nombre = txtNombre.Text,
                    Existencias = int.Parse(txtExistencias.Text),
                    StockMinimo = int.Parse(txtStockMinimo.Text),
                    PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text),
                    Estado = cmbEstado.SelectedItem.ToString()
                };

                // Guardar el producto
                string resultado = productoService.Guardar(producto);

                if (resultado.StartsWith("Error"))
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Producto guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtReferencia.Clear();
            txtNombre.Clear();
            txtExistencias.Clear();
            txtStockMinimo.Clear();
            txtPrecioUnitario.Clear();
            cmbEstado.SelectedIndex = -1;
            txtReferencia.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}