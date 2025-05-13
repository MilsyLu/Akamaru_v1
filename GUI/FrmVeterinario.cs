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
    public partial class FrmVeterinario : Form
    {
        private IService<Veterinario> serviceVeterinario;

        public FrmVeterinario()
        {
            InitializeComponent();
            serviceVeterinario = new VeterinarioService();
        }

        private void FrmVeterinario_Load(object sender, EventArgs e)
        {
            CargarListaVeterinarios();
        }

        private void CargarListaVeterinarios()
        {
            lstVeterinarios.DataSource = serviceVeterinario.Consultar();
            lstVeterinarios.DisplayMember = "Nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(new Veterinario
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Especialidad = txtEspecialidad.Text
            });
        }

        private void Guardar(Veterinario veterinario)
        {
            var mensaje = serviceVeterinario.Guardar(veterinario);
            MessageBox.Show(mensaje);
            CargarListaVeterinarios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                Buscar(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}");
            }
        }

        private void Buscar(int id)
        {
            var veterinarioBuscado = serviceVeterinario.BuscarId(id);
            VerVeterinario(veterinarioBuscado);
        }

        private void VerVeterinario(Veterinario veterinario)
        {
            if (veterinario == null)
            {
                return;
            }
            txtId.Text = veterinario.Id.ToString();
            txtNombre.Text = veterinario.Nombre;
            txtEspecialidad.Text = veterinario.Especialidad;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEspecialidad.Text = string.Empty;
            txtId.Focus();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}