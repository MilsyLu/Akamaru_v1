namespace GUI
{
    partial class FrmConsulta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVeterinarios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMascotas = new System.Windows.Forms.ComboBox();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.lstEspecies = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.panelMain.Controls.Add(this.panelForm);
            this.panelMain.Controls.Add(this.panelList);
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(15);
            this.panelMain.Size = new System.Drawing.Size(784, 503);
            this.panelMain.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForm.Controls.Add(this.dtpFecha);
            this.panelForm.Controls.Add(this.label5);
            this.panelForm.Controls.Add(this.cbVeterinarios);
            this.panelForm.Controls.Add(this.label4);
            this.panelForm.Controls.Add(this.cbMascotas);
            this.panelForm.Controls.Add(this.txtTratamiento);
            this.panelForm.Controls.Add(this.label3);
            this.panelForm.Controls.Add(this.txtDiagnostico);
            this.panelForm.Controls.Add(this.label2);
            this.panelForm.Controls.Add(this.txtId);
            this.panelForm.Controls.Add(this.label1);
            this.panelForm.Location = new System.Drawing.Point(12, 15);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(318, 376);
            this.panelForm.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(128, 275);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(167, 29);
            this.dtpFecha.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Veterinario:";
            // 
            // cbVeterinarios
            // 
            this.cbVeterinarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVeterinarios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbVeterinarios.FormattingEnabled = true;
            this.cbVeterinarios.Location = new System.Drawing.Point(128, 240);
            this.cbVeterinarios.Name = "cbVeterinarios";
            this.cbVeterinarios.Size = new System.Drawing.Size(167, 29);
            this.cbVeterinarios.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mascota:";
            // 
            // cbMascotas
            // 
            this.cbMascotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMascotas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbMascotas.FormattingEnabled = true;
            this.cbMascotas.Location = new System.Drawing.Point(128, 190);
            this.cbMascotas.Name = "cbMascotas";
            this.cbMascotas.Size = new System.Drawing.Size(167, 29);
            this.cbMascotas.TabIndex = 7;
            // 
            // txtTratamiento
            // 
            this.txtTratamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTratamiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTratamiento.Location = new System.Drawing.Point(128, 141);
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.Size = new System.Drawing.Size(167, 29);
            this.txtTratamiento.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tratamiento:";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnostico.Location = new System.Drawing.Point(128, 91);
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(167, 29);
            this.txtDiagnostico.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Diagnóstico:";
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtId.Location = new System.Drawing.Point(128, 41);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(167, 29);
            this.txtId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.White;
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelList.Controls.Add(this.lstEspecies);
            this.panelList.Controls.Add(this.label6);
            this.panelList.Location = new System.Drawing.Point(336, 15);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(302, 376);
            this.panelList.TabIndex = 1;
            // 
            // lstEspecies
            // 
            this.lstEspecies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstEspecies.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstEspecies.FormattingEnabled = true;
            this.lstEspecies.ItemHeight = 21;
            this.lstEspecies.Location = new System.Drawing.Point(20, 43);
            this.lstEspecies.Name = "lstEspecies";
            this.lstEspecies.Size = new System.Drawing.Size(266, 315);
            this.lstEspecies.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Historial de Consultas";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.btnConsultar);
            this.panelButtons.Controls.Add(this.btnGuardar);
            this.panelButtons.Controls.Add(this.btnNuevo);
            this.panelButtons.Location = new System.Drawing.Point(73, 397);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(509, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(333, 15);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 30);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(60)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(141, 15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(15, 15);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 503);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "FrmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Consultas Veterinarias";
            this.Load += new System.EventHandler(this.FrmConsulta_Load);
            this.panelMain.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbVeterinarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMascotas;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.ListBox lstEspecies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
    }
}