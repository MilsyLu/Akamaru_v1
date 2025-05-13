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
    public partial class FrmPropietario : Form
    {
        private IService<Propietario> servicePropietario;

        public FrmPropietario()
        {
            InitializeComponent();
            servicePropietario = new PropietarioService();
        }

        private void FrmPropietario_Load(object sender, EventArgs e)
        {
            CargarListaPropietarios();
        }

        private void CargarListaPropietarios()
        {
            lstPropietarios.DataSource = servicePropietario.Consultar();
            lstPropietarios.DisplayMember = "Nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(new Propietario
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Cedula = txtCedula.Text,
                Telefono = txtTelefono.Text
            });
        }

        private void Guardar(Propietario propietario)
        {
            var mensaje = servicePropietario.Guardar(propietario);
            MessageBox.Show(mensaje);
            CargarListaPropietarios();
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
            var propietarioBuscado = servicePropietario.BuscarId(id);
            VerPropietario(propietarioBuscado);
        }

        private void VerPropietario(Propietario propietario)
        {
            if (propietario == null)
            {
                return;
            }
            txtId.Text = propietario.Id.ToString();
            txtCedula.Text = propietario.Cedula;
            txtNombre.Text = propietario.Nombre;
            txtTelefono.Text = propietario.Telefono;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            txtId.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtId.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            AbrirConsulta();
        }

        private void AbrirConsulta()
        {
            Form f = new FrmConsultaPropietarios();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCedula.Focus();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNombre.Focus();
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTelefono.Focus();
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnGuardar.Focus();
        }
    }
}