using System;
using BLL;
using Entity;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1: Form
    {
        private IServicios<Departamento> serviciosDepartamentos;
        private IServicios<Municipio> serviciosMunicipios;
        
        
        public Form1()
        {
            InitializeComponent();
            serviciosDepartamentos = new ServiciosDepartamento();
            serviciosMunicipios = new ServiciosMunicipio();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {
            Boolean ok;
            if (rbtnDepartamento.Checked)
            {

                ok = Validaciones(txtNombre.Text, lstDepartamentos.Items);
                if (ok) { lstDepartamentos.Items.Add(txtNombre.Text); }
            }
            else if (rbtnMunicipio.Checked)
            {
                ok = Validaciones(txtNombre.Text, lstMunicipios.Items);
                if (ok) { lstMunicipios.Items.Add(txtNombre.Text); }
            }
            txtNombre.Clear();
        }

        private Boolean Validaciones(string nombre, ListBox.ObjectCollection lista)
        {


            if (lista.Contains(nombre) | string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, revise la informacion: No Ingreso Nada o Ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else { return true; }

           
        }

        private void Eliminar()
        {
            if (lstDepartamentos.SelectedItem != null)
            {
                lstDepartamentos.Items.Remove(lstDepartamentos.SelectedItem);
            }
            if (lstMunicipios.SelectedItem != null)
            {
                lstMunicipios.Items.Remove(lstMunicipios.SelectedItem);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            string nombre = lstMunicipios.SelectedItem.ToString();
            MoverDato(lstMunicipios.Items, lstDepartamentos.Items, nombre);
        }

        private void MoverDato(ListBox.ObjectCollection listaOrigen, ListBox.ObjectCollection listaDestino, string nombre)
        {
            bool ok;
            ok = Validaciones(nombre, listaDestino);
            if (ok)
            {
                listaDestino.Add(nombre);
                listaOrigen.Remove(nombre);
            }
        }

        private void btnRigth_Click(object sender, EventArgs e)
        {
            string nombre = lstDepartamentos.SelectedItem.ToString();
            MoverDato(lstDepartamentos.Items, lstMunicipios.Items, nombre);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbtnDepartamento.Checked = true;
        }
    }
}
