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
    public partial class Frm_Especie: Form
    {
        private IService<Especie> serviceEspecie;
        public Frm_Especie()
        {
            InitializeComponent();
            serviceEspecie = new EspecieService();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(new Especie(int.Parse(txtId.Text),txtNombre.Text));
        }

        private void Guardar(Especie especie)
        {
            if (string.IsNullOrWhiteSpace(especie.Nombre))
            {
                MessageBox.Show("El nombre de la especie no puede estar vacío.");
                return;
            }

            // Validación de nombre repetido
            var especieExistente = ((EspecieService)serviceEspecie).BuscarPorNombre(especie.Nombre);
            if (especieExistente != null)
            {
                MessageBox.Show("Ya existe una especie con ese nombre.");
                return;
            }

            var mensaje = serviceEspecie.Guardar(especie);
            MessageBox.Show(mensaje);
            CargarListaEspecies();
            Nuevo();
        }


        private void CargarListaEspecies()
        {
            lstEspecies.DataSource = serviceEspecie.Consultar();
            lstEspecies.DisplayMember = "Nombre";
        }

        private void Frm_Especie_Load(object sender, EventArgs e)
        {
            CargarListaEspecies();
            ActivarNombre_btnGuardar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar(int.Parse(txtId.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Error al buscar la especie");
            }
            finally
            {
                if (int.TryParse(txtId.Text, out int id))
                {
                    Buscar(id);
                }
                else
                {
                    MessageBox.Show("El id no es valido");
                }
            }
        }

        private void Buscar(int id)
        {
            var especieBuscada = serviceEspecie.BuscarId(id);
            VerEspecie(especieBuscada);
        }

        private void VerEspecie(Especie especie)
        {
            if (especie == null)
            {
                ActivarNombre_btnGuardar();
                return;
            }
            else
            {
                txtId.Text = especie.Id.ToString();
                txtNombre.Text = especie.Nombre;
                txtNombre.ReadOnly = true;
                txtNombre.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void ActivarNombre_btnGuardar()
        {
            txtNombre.Enabled = true;
            txtNombre.ReadOnly = false;
            btnGuardar.Enabled = true;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtId.Focus();
            txtId.ReadOnly = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            AbrirConsulta();
        }

        private void AbrirConsulta()
        {
            Form f = new FrmConsultaEsoecies();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        //private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        //{
        //    txtId.Focus();
        //}

        //private void txtId_KeyDown(object sender, KeyEventArgs e)
        //{
        //    txtNombre.Focus();
        //}

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números y teclas de control como Backspace
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.AliceBlue;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.Gray;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var especieBuscada = serviceEspecie.BuscarId(int.Parse(txtId.Text));
                if (especieBuscada!=null)
                {
                    VerEspecie(especieBuscada);
                }
                else
                {
                    txtNombre.Text = "";
                    ActivarNombre_btnGuardar();
                }
                
            }
            catch (Exception)
            {
                Nuevo();
            }
            
        }

        private void panelList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Especie especie = null;

            // Si hay un ID válido en el textbox, úsalo.
            if (int.TryParse(txtId.Text, out int id) && id > 0)
            {
                especie = serviceEspecie.BuscarId(id);
            }
            // Si no hay un ID válido, intenta usar la selección del listbox
            else if (lstEspecies.SelectedItem is Especie seleccionada)
            {
                especie = seleccionada;
            }

            if (especie == null)
            {
                MessageBox.Show("Seleccione una especie válida para eliminar.");
                return;
            }

            var confirmResult = MessageBox.Show(
                $"¿Está seguro que desea eliminar la especie \"{especie.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var mensaje = serviceEspecie.Eliminar(especie.Id);
                MessageBox.Show(mensaje);
                CargarListaEspecies();
                Nuevo();
            }
        }

        private void lstEspecies_DoubleClick(object sender, EventArgs e)
        {
            if (lstEspecies.SelectedItem is Especie especie)
            {
                var confirmResult = MessageBox.Show(
                    $"¿Desea eliminar la especie \"{especie.Nombre}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    var mensaje = serviceEspecie.Eliminar(especie.Id);
                    MessageBox.Show(mensaje);
                    CargarListaEspecies();
                    Nuevo();
                }
            }
        }

        private void lstEspecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEspecies.SelectedItem is Especie especie)
            {
                txtId.Text = especie.Id.ToString();
                txtNombre.Text = especie.Nombre;
            }
            btnGuardar.Enabled = false;
            txtNombre.Enabled = false;
            txtNombre.ReadOnly = true;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstEspecies.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una especie de la lista.");
                return;
            }

            // Obtener la especie seleccionada
            Especie especieSeleccionada = (Especie)lstEspecies.SelectedItem;

            // Mostrar un cuadro de diálogo para ingresar el nuevo nombre
            string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese el nuevo nombre para la especie \"{especieSeleccionada.Nombre}\"",
                "Editar Nombre de Especie",
                especieSeleccionada.Nombre); // Poner el nombre actual como valor por defecto

            // Si el nuevo nombre no es vacío, lo actualizamos
            if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != especieSeleccionada.Nombre)
            {
                especieSeleccionada.Nombre = nuevoNombre;

                var mensaje = serviceEspecie.Modificar(especieSeleccionada);
                MessageBox.Show(mensaje);
                CargarListaEspecies(); // Recargar la lista para reflejar los cambios
            }
            else
            {
                MessageBox.Show("El nombre no ha sido modificado o es inválido.");
            }
        }


    }
}
