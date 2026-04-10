namespace AppProyectoFelipe.Layers.UI.Mantenimientos
{
    partial class FrmTipoDispositivo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.RdbInactivo = new System.Windows.Forms.RadioButton();
            this.RdbActivo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Erp = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnBorrar);
            this.groupBox1.Controls.Add(this.BtnEditar);
            this.groupBox1.Controls.Add(this.BtnAgregar);
            this.groupBox1.Location = new System.Drawing.Point(372, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 100);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.Location = new System.Drawing.Point(350, 34);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(126, 48);
            this.BtnBorrar.TabIndex = 22;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = true;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(34, 499);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(73, 48);
            this.BtnSalir.TabIndex = 21;
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
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(26, 34);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(126, 48);
            this.BtnAgregar.TabIndex = 0;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // DgvDatos
            // 
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(372, 254);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.RowHeadersWidth = 62;
            this.DgvDatos.RowTemplate.Height = 28;
            this.DgvDatos.Size = new System.Drawing.Size(679, 293);
            this.DgvDatos.TabIndex = 29;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(136, 137);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(192, 26);
            this.TxtDescripcion.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Descripcion: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 100);
            this.panel1.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(325, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(453, 59);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tipo de dispositivo";
            // 
            // RdbInactivo
            // 
            this.RdbInactivo.AutoSize = true;
            this.RdbInactivo.Location = new System.Drawing.Point(251, 206);
            this.RdbInactivo.Name = "RdbInactivo";
            this.RdbInactivo.Size = new System.Drawing.Size(89, 24);
            this.RdbInactivo.TabIndex = 34;
            this.RdbInactivo.TabStop = true;
            this.RdbInactivo.Text = "Inactivo";
            this.RdbInactivo.UseVisualStyleBackColor = true;
            // 
            // RdbActivo
            // 
            this.RdbActivo.AutoSize = true;
            this.RdbActivo.Location = new System.Drawing.Point(148, 206);
            this.RdbActivo.Name = "RdbActivo";
            this.RdbActivo.Size = new System.Drawing.Size(77, 24);
            this.RdbActivo.TabIndex = 33;
            this.RdbActivo.TabStop = true;
            this.RdbActivo.Text = "Activo";
            this.RdbActivo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Estado:";
            // 
            // Erp
            // 
            this.Erp.ContainerControl = this;
            // 
            // FrmTipoDispositivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 575);
            this.Controls.Add(this.RdbInactivo);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.RdbActivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.label2);
            this.Name = "FrmTipoDispositivo";
            this.Text = "FrmTipoDispositivo";
            this.Load += new System.EventHandler(this.FrmTipoDispositivo_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.DataGridView DgvDatos;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton RdbInactivo;
        private System.Windows.Forms.RadioButton RdbActivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider Erp;
    }
}