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
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRazas
            // 
            this.dgvRazas.AllowUserToAddRows = false;
            this.dgvRazas.AllowUserToDeleteRows = false;
            this.dgvRazas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRazas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRazas.Location = new System.Drawing.Point(24, 31);
            this.dgvRazas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRazas.Name = "dgvRazas";
            this.dgvRazas.ReadOnly = true;
            this.dgvRazas.RowHeadersWidth = 62;
            this.dgvRazas.RowTemplate.Height = 24;
            this.dgvRazas.Size = new System.Drawing.Size(517, 256);
            this.dgvRazas.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(149, 306);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(258, 52);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmConsultaRazas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 405);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvRazas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmConsultaRazas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Razas";
            this.Load += new System.EventHandler(this.FrmConsultaRazas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRazas;
        private System.Windows.Forms.Button btnSalir;
    }
}