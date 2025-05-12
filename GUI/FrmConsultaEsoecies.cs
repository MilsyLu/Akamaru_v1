using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace GUI
{
    public partial class FrmConsultaEsoecies: Form
    {
        IService<Especie> serviceEspecie;
        public FrmConsultaEsoecies()
        {
            InitializeComponent();
            serviceEspecie = new EspecieService();
        }

        private void CargarEspecies()
        {
            var lista = serviceEspecie.Consultar();

            dgvEspecies.DataSource = lista;
            //foreach (var item in lista)
            //{
            //    dgvEspecies.Rows.Add(item.Id, item.Nombre);
            //}
            // Ajusta la altura del DataGridView
            int alturaFila = dgvEspecies.RowTemplate.Height;
            int cantidadFilas = dgvEspecies.Rows.Count;
            dgvEspecies.Height = (alturaFila * cantidadFilas) + dgvEspecies.ColumnHeadersHeight;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmConsultaEsoecies_Load(object sender, EventArgs e)
        {
            CargarEspecies();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada
                if (dgvEspecies.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar una especie para eliminar", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obtener la especie seleccionada
                Especie especieSeleccionada = (Especie)dgvEspecies.CurrentRow.DataBoundItem;

                // Confirmar la eliminación
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la especie '{especieSeleccionada.Nombre}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al servicio para eliminar
                    string respuesta = serviceEspecie.Eliminar(especieSeleccionada.Id);

                    // Verificar si la eliminación fue exitosa basado en el mensaje de respuesta
                    if (respuesta.StartsWith("Error"))
                    {
                        MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Especie eliminada correctamente",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar la lista de especies
                        CargarEspecies();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

