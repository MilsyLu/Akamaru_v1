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
    public partial class Loby: Form
    {
        public Loby()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childform)
        {
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnVistaInterna.Controls.Add(childform);
            childform.BringToFront();
            childform.Show();
            
        }

        public void Loby_Load(object sender, EventArgs e)
        {
           
        }

        private void btnEspecies_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_Especie());
        }
        private void btnRazas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmRaza());
        }
        private void btnPropietarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmPropietario());
        }
        private void btnMascotas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmMascota());
        }
        private void btnVeterinarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmVeterinario());
        }
        private void btnConsultas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmConsulta());
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
