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
    public partial class FrmConsultaPropietarios : Form
    {
        IService<Propietario> servicePropietario;

        public FrmConsultaPropietarios()
        {
            InitializeComponent();
            servicePropietario = new PropietarioService();
        }

        private void FrmConsultaPropietarios_Load(object sender, EventArgs e)
        {
            CargarPropietarios();
        }

        private void CargarPropietarios()
        {
            var lista = servicePropietario.Consultar();
            dgvPropietarios.DataSource = lista;

            int alturaFila = dgvPropietarios.RowTemplate.Height;
            int cantidadFilas = dgvPropietarios.Rows.Count;
            dgvPropietarios.Height = (alturaFila * cantidadFilas) + dgvPropietarios.ColumnHeadersHeight;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}