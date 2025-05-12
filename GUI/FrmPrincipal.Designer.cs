namespace GUI
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionarEspeciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarRazasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarPropietariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarMascotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarVeterinariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeConsultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarEspeciesToolStripMenuItem,
            this.gestionarRazasToolStripMenuItem,
            this.gestionarPropietariosToolStripMenuItem,
            this.gestionarMascotasToolStripMenuItem,
            this.gestionarVeterinariosToolStripMenuItem,
            this.registrarConsultaToolStripMenuItem,
            this.historialDeConsultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(957, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionarEspeciesToolStripMenuItem
            // 
            this.gestionarEspeciesToolStripMenuItem.Image = global::GUI.Properties.Resources.especies;
            this.gestionarEspeciesToolStripMenuItem.Name = "gestionarEspeciesToolStripMenuItem";
            this.gestionarEspeciesToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.gestionarEspeciesToolStripMenuItem.Text = "Gestionar Especies";
            this.gestionarEspeciesToolStripMenuItem.Click += new System.EventHandler(this.gestionarEspeciesToolStripMenuItem_Click);
            // 
            // gestionarRazasToolStripMenuItem
            // 
            this.gestionarRazasToolStripMenuItem.Image = global::GUI.Properties.Resources.razas;
            this.gestionarRazasToolStripMenuItem.Name = "gestionarRazasToolStripMenuItem";
            this.gestionarRazasToolStripMenuItem.Size = new System.Drawing.Size(125, 28);
            this.gestionarRazasToolStripMenuItem.Text = "Gestionar Razas";
            this.gestionarRazasToolStripMenuItem.Click += new System.EventHandler(this.gestionarRazasToolStripMenuItem_Click);
            // 
            // gestionarPropietariosToolStripMenuItem
            // 
            this.gestionarPropietariosToolStripMenuItem.Name = "gestionarPropietariosToolStripMenuItem";
            this.gestionarPropietariosToolStripMenuItem.Size = new System.Drawing.Size(135, 28);
            this.gestionarPropietariosToolStripMenuItem.Text = "Gestionar Propietarios";
            this.gestionarPropietariosToolStripMenuItem.Click += new System.EventHandler(this.gestionarPropietariosToolStripMenuItem_Click);
            // 
            // gestionarMascotasToolStripMenuItem
            // 
            this.gestionarMascotasToolStripMenuItem.Name = "gestionarMascotasToolStripMenuItem";
            this.gestionarMascotasToolStripMenuItem.Size = new System.Drawing.Size(122, 28);
            this.gestionarMascotasToolStripMenuItem.Text = "Gestionar Mascotas";
            this.gestionarMascotasToolStripMenuItem.Click += new System.EventHandler(this.gestionarMascotasToolStripMenuItem_Click);
            // 
            // gestionarVeterinariosToolStripMenuItem
            // 
            this.gestionarVeterinariosToolStripMenuItem.Name = "gestionarVeterinariosToolStripMenuItem";
            this.gestionarVeterinariosToolStripMenuItem.Size = new System.Drawing.Size(133, 28);
            this.gestionarVeterinariosToolStripMenuItem.Text = "Gestionar Veterinarios";
            this.gestionarVeterinariosToolStripMenuItem.Click += new System.EventHandler(this.gestionarVeterinariosToolStripMenuItem_Click);
            // 
            // registrarConsultaToolStripMenuItem
            // 
            this.registrarConsultaToolStripMenuItem.Name = "registrarConsultaToolStripMenuItem";
            this.registrarConsultaToolStripMenuItem.Size = new System.Drawing.Size(115, 28);
            this.registrarConsultaToolStripMenuItem.Text = "Registrar Consulta";
            this.registrarConsultaToolStripMenuItem.Click += new System.EventHandler(this.registrarConsultaToolStripMenuItem_Click);
            // 
            // historialDeConsultasToolStripMenuItem
            // 
            this.historialDeConsultasToolStripMenuItem.Name = "historialDeConsultasToolStripMenuItem";
            this.historialDeConsultasToolStripMenuItem.Size = new System.Drawing.Size(134, 28);
            this.historialDeConsultasToolStripMenuItem.Text = "Historial de Consultas";
            this.historialDeConsultasToolStripMenuItem.Click += new System.EventHandler(this.historialConsultasToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 422);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionarEspeciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarRazasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarPropietariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarMascotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarVeterinariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeConsultasToolStripMenuItem;
    }
}