namespace AppProyectoFelipe.Layers.UI.Mantenimientos
{
    partial class FrmMantClientes
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdbExtranjero = new System.Windows.Forms.RadioButton();
            this.RdbNacional = new System.Windows.Forms.RadioButton();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.TxtApellidos = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtIdentificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RdbMujer = new System.Windows.Forms.RadioButton();
            this.RdbHombre = new System.Windows.Forms.RadioButton();
            this.CboProvincia = new System.Windows.Forms.ComboBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.TtxCorreo = new System.Windows.Forms.TextBox();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PtbFoto = new System.Windows.Forms.PictureBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.Erp = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.RdbInactivo = new System.Windows.Forms.RadioButton();
            this.RdbActivo = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RdbExtranjero);
            this.groupBox2.Controls.Add(this.RdbNacional);
            this.groupBox2.Location = new System.Drawing.Point(28, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 69);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de identificacion";
            // 
            // RdbExtranjero
            // 
            this.RdbExtranjero.AutoSize = true;
            this.RdbExtranjero.Location = new System.Drawing.Point(144, 34);
            this.RdbExtranjero.Name = "RdbExtranjero";
            this.RdbExtranjero.Size = new System.Drawing.Size(106, 24);
            this.RdbExtranjero.TabIndex = 25;
            this.RdbExtranjero.TabStop = true;
            this.RdbExtranjero.Text = "Extranjero";
            this.RdbExtranjero.UseVisualStyleBackColor = true;
            // 
            // RdbNacional
            // 
            this.RdbNacional.AutoSize = true;
            this.RdbNacional.Location = new System.Drawing.Point(27, 34);
            this.RdbNacional.Name = "RdbNacional";
            this.RdbNacional.Size = new System.Drawing.Size(95, 24);
            this.RdbNacional.TabIndex = 17;
            this.RdbNacional.TabStop = true;
            this.RdbNacional.Text = "Nacional";
            this.RdbNacional.UseVisualStyleBackColor = true;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(353, 220);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(42, 36);
            this.BtnBuscar.TabIndex = 33;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 100);
            this.panel1.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(454, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 59);
            this.label10.TabIndex = 0;
            this.label10.Text = "Clientes";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnBorrar);
            this.groupBox1.Controls.Add(this.BtnSalir);
            this.groupBox1.Controls.Add(this.BtnEditar);
            this.groupBox1.Controls.Add(this.BtnNuevo);
            this.groupBox1.Location = new System.Drawing.Point(428, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 100);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Location = new System.Drawing.Point(356, 34);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(126, 48);
            this.BtnBorrar.TabIndex = 23;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(518, 34);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(126, 48);
            this.BtnSalir.TabIndex = 22;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(188, 34);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(126, 48);
            this.BtnEditar.TabIndex = 1;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(26, 34);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(126, 48);
            this.BtnNuevo.TabIndex = 0;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.Location = new System.Drawing.Point(146, 359);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(192, 26);
            this.TxtApellidos.TabIndex = 30;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(146, 287);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(192, 26);
            this.TxtNombre.TabIndex = 29;
            // 
            // TxtIdentificacion
            // 
            this.TxtIdentificacion.Location = new System.Drawing.Point(137, 225);
            this.TxtIdentificacion.Name = "TxtIdentificacion";
            this.TxtIdentificacion.Size = new System.Drawing.Size(192, 26);
            this.TxtIdentificacion.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Apellidos: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Identificacion: ";
            // 
            // RdbMujer
            // 
            this.RdbMujer.AutoSize = true;
            this.RdbMujer.Location = new System.Drawing.Point(256, 413);
            this.RdbMujer.Name = "RdbMujer";
            this.RdbMujer.Size = new System.Drawing.Size(73, 24);
            this.RdbMujer.TabIndex = 47;
            this.RdbMujer.TabStop = true;
            this.RdbMujer.Text = "Mujer";
            this.RdbMujer.UseVisualStyleBackColor = true;
            // 
            // RdbHombre
            // 
            this.RdbHombre.AutoSize = true;
            this.RdbHombre.Location = new System.Drawing.Point(137, 415);
            this.RdbHombre.Name = "RdbHombre";
            this.RdbHombre.Size = new System.Drawing.Size(91, 24);
            this.RdbHombre.TabIndex = 46;
            this.RdbHombre.TabStop = true;
            this.RdbHombre.Text = "Hombre";
            this.RdbHombre.UseVisualStyleBackColor = true;
            // 
            // CboProvincia
            // 
            this.CboProvincia.FormattingEnabled = true;
            this.CboProvincia.Location = new System.Drawing.Point(137, 665);
            this.CboProvincia.Name = "CboProvincia";
            this.CboProvincia.Size = new System.Drawing.Size(192, 28);
            this.CboProvincia.TabIndex = 45;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(137, 602);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(192, 26);
            this.TxtDireccion.TabIndex = 44;
            // 
            // TtxCorreo
            // 
            this.TtxCorreo.Location = new System.Drawing.Point(137, 539);
            this.TtxCorreo.Name = "TtxCorreo";
            this.TtxCorreo.Size = new System.Drawing.Size(192, 26);
            this.TtxCorreo.TabIndex = 43;
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Location = new System.Drawing.Point(137, 476);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(192, 26);
            this.TxtTelefono.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 796);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 20);
            this.label9.TabIndex = 40;
            this.label9.Text = "Fotografia: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 668);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Provincia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 605);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "Direccion: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Correo: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Telefono: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Sexo: ";
            // 
            // PtbFoto
            // 
            this.PtbFoto.Location = new System.Drawing.Point(137, 796);
            this.PtbFoto.Name = "PtbFoto";
            this.PtbFoto.Size = new System.Drawing.Size(192, 146);
            this.PtbFoto.TabIndex = 48;
            this.PtbFoto.TabStop = false;
            this.PtbFoto.Click += new System.EventHandler(this.PtbFoto_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(877, 828);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(126, 48);
            this.BtnCancelar.TabIndex = 50;
            this.BtnCancelar.Text = " Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // DgvDatos
            // 
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(428, 264);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.RowHeadersWidth = 62;
            this.DgvDatos.RowTemplate.Height = 28;
            this.DgvDatos.Size = new System.Drawing.Size(679, 536);
            this.DgvDatos.TabIndex = 49;
            // 
            // Erp
            // 
            this.Erp.ContainerControl = this;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(596, 828);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(126, 48);
            this.BtnAceptar.TabIndex = 51;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // RdbInactivo
            // 
            this.RdbInactivo.AutoSize = true;
            this.RdbInactivo.Location = new System.Drawing.Point(113, 42);
            this.RdbInactivo.Name = "RdbInactivo";
            this.RdbInactivo.Size = new System.Drawing.Size(89, 24);
            this.RdbInactivo.TabIndex = 54;
            this.RdbInactivo.TabStop = true;
            this.RdbInactivo.Text = "Inactivo";
            this.RdbInactivo.UseVisualStyleBackColor = true;
            // 
            // RdbActivo
            // 
            this.RdbActivo.AutoSize = true;
            this.RdbActivo.Location = new System.Drawing.Point(10, 42);
            this.RdbActivo.Name = "RdbActivo";
            this.RdbActivo.Size = new System.Drawing.Size(77, 24);
            this.RdbActivo.TabIndex = 53;
            this.RdbActivo.TabStop = true;
            this.RdbActivo.Text = "Activo";
            this.RdbActivo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RdbActivo);
            this.groupBox3.Controls.Add(this.RdbInactivo);
            this.groupBox3.Location = new System.Drawing.Point(23, 699);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 75);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado";
            // 
            // FrmMantClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 947);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.PtbFoto);
            this.Controls.Add(this.RdbMujer);
            this.Controls.Add(this.RdbHombre);
            this.Controls.Add(this.CboProvincia);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.TtxCorreo);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtApellidos);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.TxtIdentificacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMantClientes";
            this.Text = "FrmMantClientes";
            this.Load += new System.EventHandler(this.FrmMantClientes_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PtbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RdbExtranjero;
        private System.Windows.Forms.RadioButton RdbNacional;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtIdentificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PtbFoto;
        private System.Windows.Forms.RadioButton RdbMujer;
        private System.Windows.Forms.RadioButton RdbHombre;
        private System.Windows.Forms.ComboBox CboProvincia;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.TextBox TtxCorreo;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView DgvDatos;
        private System.Windows.Forms.ErrorProvider Erp;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.RadioButton RdbInactivo;
        private System.Windows.Forms.RadioButton RdbActivo;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}