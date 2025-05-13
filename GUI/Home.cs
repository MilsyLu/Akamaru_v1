using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Home : Form
    {
        // Colores de la aplicación
        private Color colorPrimario = Color.FromArgb(67, 142, 185);
        private Color colorSecundario = Color.FromArgb(240, 240, 240);
        private Color colorHover = Color.FromArgb(41, 128, 185);
        private Color colorTexto = Color.White;

        // Paneles para cada sección
        private Panel panelActivo = null;
        private Panel panelMenu;
        private Panel panelContenido;
        private Panel panelSuperior;

        public Home()
        {
            this.SuspendLayout();

            // Configuración del formulario principal
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Name = "FrmPrincipal";
            this.Text = "Sistema de Gestión Veterinaria";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            //this.Icon = new Icon(GetType(), "paw.ico");

            this.ResumeLayout(false);
            ConfigurarDiseno();
        }


        private void ConfigurarDiseno()
        {
            // Panel superior
            panelSuperior = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = colorPrimario,
                Height = 60
            };

            Label lblTitulo = new Label
            {
                Text = "SISTEMA DE GESTIÓN VETERINARIA",
                ForeColor = colorTexto,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            panelSuperior.Controls.Add(lblTitulo);
            this.Controls.Add(panelSuperior);

            // Panel del menú lateral
            panelMenu = new Panel
            {
                Width = 250,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(52, 73, 94)
            };

            // Panel de logo
            Panel panelLogo = new Panel
            {
                Height = 120,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(41, 58, 74)
            };

            Label lblLogo = new Label
            {
                Text = "VetCare",
                ForeColor = colorTexto,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            panelLogo.Controls.Add(lblLogo);
            panelMenu.Controls.Add(panelLogo);

            // Agregar botones al menú
            CrearBotonMenu("Gestionar Especies", "🐾", 0);
            CrearBotonMenu("Gestionar Razas", "🐕", 1);
            CrearBotonMenu("Gestionar Propietarios", "👤", 2);
            CrearBotonMenu("Gestionar Mascotas", "🐈", 3);
            CrearBotonMenu("Gestionar Veterinarios", "👨‍⚕️", 4);
            CrearBotonMenu("Registrar Consulta", "📋", 5);
            CrearBotonMenu("Historial de Consultas", "📊", 6);

            this.Controls.Add(panelMenu);

            // Panel de contenido principal
            panelContenido = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = colorSecundario
            };

            // Agregar panel de bienvenida
            Panel panelBienvenida = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = colorSecundario
            };

            Label lblBienvenida = new Label
            {
                Text = "Bienvenido al Sistema de Gestión Veterinaria",
                ForeColor = Color.FromArgb(52, 73, 94),
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100,
                Padding = new Padding(0, 30, 0, 0)
            };

            Label lblInstrucciones = new Label
            {
                Text = "Seleccione una opción del menú para comenzar",
                ForeColor = Color.FromArgb(52, 73, 94),
                Font = new Font("Segoe UI", 14),
                AutoSize = false,
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Top,
                Height = 50
            };

            // Panel para estadísticas rápidas
            Panel panelEstadisticas = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(40)
            };

            // Crear tarjetas de estadísticas
            panelEstadisticas.Controls.Add(CrearTarjetaEstadistica("Mascotas Registradas", "152", Color.FromArgb(41, 128, 185)));
            panelEstadisticas.Controls.Add(CrearTarjetaEstadistica("Consultas Hoy", "8", Color.FromArgb(39, 174, 96)));
            panelEstadisticas.Controls.Add(CrearTarjetaEstadistica("Propietarios", "87", Color.FromArgb(211, 84, 0)));
            panelEstadisticas.Controls.Add(CrearTarjetaEstadistica("Veterinarios", "5", Color.FromArgb(142, 68, 173)));

            panelBienvenida.Controls.Add(panelEstadisticas);
            panelBienvenida.Controls.Add(lblInstrucciones);
            panelBienvenida.Controls.Add(lblBienvenida);

            panelContenido.Controls.Add(panelBienvenida);
            this.Controls.Add(panelContenido);
        }

        private Panel CrearTarjetaEstadistica(string titulo, string valor, Color color)
        {
            Panel tarjeta = new Panel
            {
                Width = 200,
                Height = 120,
                BackColor = color,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None
            };

            // Redondear bordes con región
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(tarjeta.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(tarjeta.Width - 20, tarjeta.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, tarjeta.Height - 20, 20, 20, 90, 90);
            tarjeta.Region = new Region(path);

            Label lblTitulo = new Label
            {
                Text = titulo,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(0, 10, 0, 0)
            };

            Label lblValor = new Label
            {
                Text = valor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            tarjeta.Controls.Add(lblValor);
            tarjeta.Controls.Add(lblTitulo);

            // Posicionar las tarjetas horizontalmente
            tarjeta.Left = (tarjeta.Width + 20) * (panelContenido.Controls.Count);
            tarjeta.Top = 50;

            return tarjeta;
        }

        private void CrearBotonMenu(string texto, string icono, int posicion)
        {
            Button btn = new Button
            {
                Text = "  " + texto,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Top,
                Height = 60,
                Font = new Font("Segoe UI", 12),
                ForeColor = colorTexto,
                BackColor = Color.FromArgb(52, 73, 94),
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Cursor = Cursors.Hand
            };

            // Agregar icono al botón
            Label lblIcono = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI", 16),
                AutoSize = true,
                Location = new Point(15, 15),
                ForeColor = colorTexto
            };
            btn.Controls.Add(lblIcono);

            // Eventos para efectos hover
            btn.MouseEnter += (sender, e) => {
                btn.BackColor = colorHover;
            };

            btn.MouseLeave += (sender, e) => {
                btn.BackColor = Color.FromArgb(52, 73, 94);
            };

            // Evento click para cambiar de panel
            btn.Click += (sender, e) => {
                // Aquí iría la lógica para cambiar al panel correspondiente
                MessageBox.Show($"Has seleccionado: {texto}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            panelMenu.Controls.Add(btn);
        }
    }
}