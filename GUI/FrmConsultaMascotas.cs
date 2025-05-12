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
    public partial class FrmConsultaMascotas : Form
    {
        MascotaService serviceMascota;
        IService<Propietario> servicePropietario;

        bool comboCargado;

        public FrmConsultaMascotas()
        {
            InitializeComponent();
            serviceMascota = new MascotaService();
            servicePropietario = new PropietarioService();
        }

        private void FrmConsultaMascotas_Load(object sender, EventArgs e)
        {
            CargarGrillaMascotas();
            CargarComboPropietarios();
            comboCargado = true;
        }

        //private void CargarComboPropietarios()
        //{
        //    var listaPropietarios = servicePropietario.Consultar();
        //    cbPropietarios.DataSource = listaPropietarios;
        //    cbPropietarios.DisplayMember = "Nombre";
        //    cbPropietarios.ValueMember = "Id";
        //}

        private void CargarComboPropietarios()
        {
            var listaPropietarios = servicePropietario.Consultar();

            // Verificar si la lista tiene elementos
            if (listaPropietarios != null && listaPropietarios.Count > 0)
            {
                cbPropietarios.DataSource = listaPropietarios;
                cbPropietarios.DisplayMember = "Nombre";
                cbPropietarios.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No hay propietarios disponibles.");
            }
        }


        private void CargarGrillaMascotas()
        {
            var listaMascotas = serviceMascota.ConsultarDTO();
            dgvMascotas.DataSource = listaMascotas;


            int alturaFila = dgvMascotas.RowTemplate.Height;
            int cantidadFilas = dgvMascotas.Rows.Count;
            dgvMascotas.Height = (alturaFila * cantidadFilas) + dgvMascotas.ColumnHeadersHeight;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarPorPropietario((int)cbPropietarios.SelectedValue);
        }

        private void FiltrarPorPropietario(int propietarioId)
        {
            var listaMascotas = serviceMascota.ConsultarPorPropietario(propietarioId);
            dgvMascotas.DataSource = listaMascotas;
        }

        //private void cbPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbPropietarios.SelectedValue != null)
        //    {
        //        int idPropietario = (int)cbPropietarios.SelectedValue;  // Aquí ya se obtiene el Id como int
        //        CargarGrillaMascotasPorPropietario(idPropietario);
        //    }
        //}
        //private void cbPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Asegurarse de que el SelectedValue no sea nulo y que sea un entero
        //    if (cbPropietarios.SelectedValue != null && cbPropietarios.SelectedValue is int idPropietario)
        //    {
        //        // Llamamos a la función que filtra por propietario
        //        CargarGrillaMascotasPorPropietario(idPropietario);
        //    }
        //    else
        //    {
        //        MessageBox.Show("El valor seleccionado no es un propietario válido.");
        //    }
        //}
        private void cbPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Solo ejecutar cuando el ComboBox ha sido completamente cargado y tiene un valor seleccionado
            if (comboCargado && cbPropietarios.SelectedValue != null && cbPropietarios.SelectedValue is int idPropietario)
            {
                CargarGrillaMascotasPorPropietario(idPropietario);
            }
        }


        private void CargarGrillaMascotasPorPropietario(int idPropietario)
        {
            var listaMascotas = serviceMascota.ConsultarDTOPorPropietario(idPropietario);
            dgvMascotas.DataSource = listaMascotas;

            AjustarTamañoGrilla();
        }
        private void AjustarTamañoGrilla()
        {
            int alturaFila = dgvMascotas.RowTemplate.Height;
            int cantidadFilas = dgvMascotas.Rows.Count;
            dgvMascotas.Height = (alturaFila * cantidadFilas) + dgvMascotas.ColumnHeadersHeight;
        }


    }
}