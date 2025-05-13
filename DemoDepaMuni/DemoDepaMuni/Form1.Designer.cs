namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRigth = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnDepartamento = new System.Windows.Forms.RadioButton();
            this.rbtnMunicipio = new System.Windows.Forms.RadioButton();
            this.lstDepartamentos = new System.Windows.Forms.ListBox();
            this.lstMunicipios = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnMunicipio);
            this.groupBox1.Controls.Add(this.rbtnDepartamento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(24, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstMunicipios);
            this.groupBox2.Controls.Add(this.lstDepartamentos);
            this.groupBox2.Controls.Add(this.btnRigth);
            this.groupBox2.Controls.Add(this.btnLeft);
            this.groupBox2.Location = new System.Drawing.Point(24, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 299);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registros";
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(395, 71);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(89, 40);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "<-------";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRigth
            // 
            this.btnRigth.Location = new System.Drawing.Point(395, 133);
            this.btnRigth.Name = "btnRigth";
            this.btnRigth.Size = new System.Drawing.Size(89, 40);
            this.btnRigth.TabIndex = 3;
            this.btnRigth.Text = "------>";
            this.btnRigth.UseVisualStyleBackColor = true;
            this.btnRigth.Click += new System.EventHandler(this.btnRigth_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(493, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(628, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 40);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(279, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(170, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // rbtnDepartamento
            // 
            this.rbtnDepartamento.AutoSize = true;
            this.rbtnDepartamento.Location = new System.Drawing.Point(32, 31);
            this.rbtnDepartamento.Name = "rbtnDepartamento";
            this.rbtnDepartamento.Size = new System.Drawing.Size(92, 17);
            this.rbtnDepartamento.TabIndex = 8;
            this.rbtnDepartamento.TabStop = true;
            this.rbtnDepartamento.Text = "Departamento";
            this.rbtnDepartamento.UseVisualStyleBackColor = true;
            // 
            // rbtnMunicipio
            // 
            this.rbtnMunicipio.AutoSize = true;
            this.rbtnMunicipio.Location = new System.Drawing.Point(32, 54);
            this.rbtnMunicipio.Name = "rbtnMunicipio";
            this.rbtnMunicipio.Size = new System.Drawing.Size(70, 17);
            this.rbtnMunicipio.TabIndex = 9;
            this.rbtnMunicipio.TabStop = true;
            this.rbtnMunicipio.Text = "Municipio";
            this.rbtnMunicipio.UseVisualStyleBackColor = true;
            // 
            // lstDepartamentos
            // 
            this.lstDepartamentos.FormattingEnabled = true;
            this.lstDepartamentos.Location = new System.Drawing.Point(6, 27);
            this.lstDepartamentos.Name = "lstDepartamentos";
            this.lstDepartamentos.Size = new System.Drawing.Size(383, 238);
            this.lstDepartamentos.TabIndex = 4;
            // 
            // lstMunicipios
            // 
            this.lstMunicipios.FormattingEnabled = true;
            this.lstMunicipios.Location = new System.Drawing.Point(502, 24);
            this.lstMunicipios.Name = "lstMunicipios";
            this.lstMunicipios.Size = new System.Drawing.Size(241, 238);
            this.lstMunicipios.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnMunicipio;
        private System.Windows.Forms.RadioButton rbtnDepartamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstMunicipios;
        private System.Windows.Forms.ListBox lstDepartamentos;
        private System.Windows.Forms.Button btnRigth;
        private System.Windows.Forms.Button btnLeft;
    }
}

