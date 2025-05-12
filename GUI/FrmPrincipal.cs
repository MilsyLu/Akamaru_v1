using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void gestionarEspeciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Frm_Especie());
        }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void gestionarRazasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmRaza());
        }

        private void gestionarPropietariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmPropietario());
        }

        private void gestionarMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmMascota());
        }

        private void gestionarVeterinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmVeterinario());
        }

        private void registrarConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmConsulta());
        }

        private void historialConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmHistorialConsultas());
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}