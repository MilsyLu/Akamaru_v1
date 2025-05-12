namespace GUI
{
    partial class FrmConsultaRazas
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
            this.dgvRazas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grillaPrueba = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPrueba)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRazas
            // 
            this.dgvRazas.AllowUserToAddRows = false;
            this.dgvRazas.AllowUserToDeleteRows = false;
            this.dgvRazas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRazas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRazas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvRazas.Location = new System.Drawing.Point(24, 31);
            this.dgvRazas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRazas.Name = "dgvRazas";
            this.dgvRazas.ReadOnly = true;
            this.dgvRazas.RowHeadersWidth = 62;
            this.dgvRazas.RowTemplate.Height = 24;
            this.dgvRazas.Size = new System.Drawing.Size(492, 215);
            this.dgvRazas.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Codigo Raza";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre Raza";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nombre Especie";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(146, 457);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(258, 52);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // grillaPrueba
            // 
            this.grillaPrueba.AllowUserToAddRows = false;
            this.grillaPrueba.AllowUserToDeleteRows = false;
            this.grillaPrueba.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPrueba.Location = new System.Drawing.Point(24, 262);
            this.grillaPrueba.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grillaPrueba.Name = "grillaPrueba";
            this.grillaPrueba.ReadOnly = true;
            this.grillaPrueba.RowHeadersWidth = 62;
            this.grillaPrueba.RowTemplate.Height = 24;
            this.grillaPrueba.Size = new System.Drawing.Size(492, 176);
            this.grillaPrueba.TabIndex = 2;
            // 
            // FrmConsultaRazas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 520);
            this.Controls.Add(this.grillaPrueba);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvRazas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmConsultaRazas";
            this.Text = "FrmConsultaRazas";
            this.Load += new System.EventHandler(this.FrmConsultaRazas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPrueba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRazas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView grillaPrueba;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}