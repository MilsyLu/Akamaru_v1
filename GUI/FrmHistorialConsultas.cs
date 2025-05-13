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
    public partial class FrmHistorialConsultas : Form
    {
        ConsultaVeterinariaService serviceConsulta;
        MascotaService serviceMascota;

        public FrmHistorialConsultas()
        {
            InitializeComponent();
            serviceConsulta = new ConsultaVeterinariaService();
            serviceMascota = new MascotaService();
        }

        private void FrmHistorialConsultas_Load(object sender, EventArgs e)
        {
            CargarGrillaConsultas();
            CargarComboMascotas();
        }

        private void CargarComboMascotas()
        {
            var listaMascotas = serviceMascota.Consultar();
            cbMascotas.DataSource = listaMascotas;
            cbMascotas.DisplayMember = "Nombre";
            cbMascotas.ValueMember = "Id";
        }

        private void CargarGrillaConsultas()
        {
            var listaConsultas = serviceConsulta.ConsultarDTO();
            dgvConsultas.DataSource = listaConsultas;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarPorMascota((int)cbMascotas.SelectedValue);
        }

        private void FiltrarPorMascota(int mascotaId)
        {
            var listaConsultas = serviceConsulta.ConsultarPorMascota(mascotaId);
            dgvConsultas.DataSource = listaConsultas;
        }


    }
}