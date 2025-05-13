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
    public partial class FrmMascota : Form
    {
        private IService<Propietario> servicePropietario;
        private IService<Mascota> serviceMascota;
        private RazaService serviceRaza;

        public FrmMascota()
        {
            InitializeComponent();
            servicePropietario = new PropietarioService();
            serviceMascota = new MascotaService();
            serviceRaza = new RazaService();
        }

        private void FrmMascota_Load(object sender, EventArgs e)
        {
            CargarComboPropietarios();
            CargarComboRazas();
            CargarListaMascotas();
        }

        private void CargarListaMascotas()
        {
            var listaMascotas = serviceMascota.Consultar();
            lstMascotas.DataSource = listaMascotas;
            lstMascotas.DisplayMember = "Nombre";
        }

        private void CargarComboPropietarios()
        {
            var listaPropietarios = servicePropietario.Consultar();
            cbPropietarios.DataSource = listaPropietarios;
            cbPropietarios.DisplayMember = "Nombre";
            cbPropietarios.ValueMember = "Id";
        }

        private void CargarComboRazas()
        {
            var listaRazas = serviceRaza.Consultar();
            cbRazas.DataSource = listaRazas;
            cbRazas.DisplayMember = "Nombre";
            cbRazas.ValueMember = "Id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(new Mascota
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Edad = int.Parse(txtEdad.Text),
                propietario = new Propietario { Id = (int)cbPropietarios.SelectedValue },
                raza = new Raza { Id = (int)cbRazas.SelectedValue }
            });
        }

        private void Guardar(Mascota mascota)
        {
            var mensaje = serviceMascota.Guardar(mascota);
            MessageBox.Show(mensaje);
            CargarListaMascotas();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            AbrirConsulta();
        }

        private void AbrirConsulta()
        {
            Form f = new FrmConsultaMascotas();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
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
            var mascotaBuscada = serviceMascota.BuscarId(id);
            VerMascota(mascotaBuscada);
        }

        private void VerMascota(Mascota mascota)
        {
            if (mascota == null)
            {
                return;
            }
            txtId.Text = mascota.Id.ToString();
            txtNombre.Text = mascota.Nombre;
            txtEdad.Text = mascota.Edad.ToString();
            cbPropietarios.SelectedValue = mascota.propietario.Id;
            cbRazas.SelectedValue = mascota.raza.Id;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtId.Focus();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNombre.Focus();
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}