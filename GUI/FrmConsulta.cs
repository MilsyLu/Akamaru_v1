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
    public partial class FrmConsulta : Form
    {
        private IService<Mascota> serviceMascota;
        private IService<Veterinario> serviceVeterinario;
        private IService<ConsultaVeterinaria> serviceConsulta;

        public FrmConsulta()
        {
            InitializeComponent();
            serviceMascota = new MascotaService();
            serviceVeterinario = new VeterinarioService();
            serviceConsulta = new ConsultaVeterinariaService();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CargarComboMascotas();
            CargarComboVeterinarios();
            dtpFecha.Value = DateTime.Now;
        }

        private void CargarComboMascotas()
        {
            var listaMascotas = serviceMascota.Consultar();
            cbMascotas.DataSource = listaMascotas;
            cbMascotas.DisplayMember = "Nombre";
            cbMascotas.ValueMember = "Id";
        }
    
        private void CargarComboVeterinarios()
        {
            var listaVeterinarios = serviceVeterinario.Consultar();
            cbVeterinarios.DataSource = listaVeterinarios;
            cbVeterinarios.DisplayMember = "Nombre";
            cbVeterinarios.ValueMember = "Id";
        }

        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var consulta = new ConsultaVeterinaria
        //        {
        //            Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
        //            Diagnostico = txtDiagnostico.Text,
        //            Tratamiento = txtTratamiento.Text,
        //            Fecha = dtpFecha.Value,
        //            Mascota = (int)cbMascotas.SelectedValue,
        //            Veterinario = (int)cbVeterinarios.SelectedValue
        //        };
        //        Guardar(consulta);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var consulta = new ConsultaVeterinaria
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    Diagnostico = txtDiagnostico.Text,
                    Tratamiento = txtTratamiento.Text,
                    Fecha = dtpFecha.Value
                };

                // Obtener las mascotas y veterinarios completos por su Id
                int mascotaId = (int)cbMascotas.SelectedValue;
                int veterinarioId = (int)cbVeterinarios.SelectedValue;

                // Usar los servicios para obtener los objetos completos
                Mascota mascota = serviceMascota.BuscarId(mascotaId);
                Veterinario veterinario = serviceVeterinario.BuscarId(veterinarioId);

                // Asignar los objetos completos a la consulta
                consulta.AsignarMascota(mascota);
                consulta.AsignarVeterinario(veterinario);

                Guardar(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void Guardar(ConsultaVeterinaria consulta)
        {
            var mensaje = serviceConsulta.Guardar(consulta);
            MessageBox.Show(mensaje);
            Nuevo();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            AbrirConsulta();
        }

        private void AbrirConsulta()
        {
            Form f = new FrmHistorialConsultas();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            txtId.Text = string.Empty;
            txtDiagnostico.Text = string.Empty;
            txtTratamiento.Text = string.Empty;
            dtpFecha.Value = DateTime.Now;
            txtId.Focus();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}