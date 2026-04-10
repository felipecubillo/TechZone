using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProyectoFelipe.Layers.UI.Procesos
{
    public partial class FrmFacturacion : Form
    {
        public FrmFacturacion()
        {
            InitializeComponent();

            this.Text = "Facturación";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // ===== ENCABEZADO =====
            GroupBox gbEncabezado = new GroupBox()
            {
                Text = "Datos Generales",
                Location = new Point(10, 10),
                Size = new Size(1060, 80)
            };

            Label lblFactura = new Label() { Text = "Factura #", Location = new Point(20, 30) };
            TextBox txtFactura = new TextBox() { Location = new Point(90, 25), Width = 100 };

            Label lblCliente = new Label() { Text = "Cliente", Location = new Point(220, 30) };
            ComboBox cmbCliente = new ComboBox() { Location = new Point(280, 25), Width = 200 };

            Label lblVendedor = new Label() { Text = "Vendedor", Location = new Point(500, 30) };
            ComboBox cmbVendedor = new ComboBox() { Location = new Point(580, 25), Width = 200 };

            Label lblFecha = new Label() { Text = "Fecha", Location = new Point(800, 30) };
            DateTimePicker dtpFecha = new DateTimePicker() { Location = new Point(850, 25), Width = 180 };

            gbEncabezado.Controls.AddRange(new Control[] {
            lblFactura, txtFactura,
            lblCliente, cmbCliente,
            lblVendedor, cmbVendedor,
            lblFecha, dtpFecha
        });

            // ===== DETALLE =====
            GroupBox gbDetalle = new GroupBox()
            {
                Text = "Detalle de Productos",
                Location = new Point(10, 100),
                Size = new Size(1060, 280)
            };

            DataGridView dgv = new DataGridView()
            {
                Location = new Point(10, 25),
                Size = new Size(1040, 240),
                AllowUserToAddRows = false
            };

            dgv.Columns.Add("Codigo", "Código");
            dgv.Columns.Add("Producto", "Producto");
            dgv.Columns.Add("Precio", "Precio");
            dgv.Columns.Add("Cantidad", "Cantidad");
            dgv.Columns.Add("Subtotal", "Subtotal");

            gbDetalle.Controls.Add(dgv);

            // ===== TOTALES =====
            GroupBox gbTotales = new GroupBox()
            {
                Text = "Totales",
                Location = new Point(750, 390),
                Size = new Size(320, 120)
            };

            Label lblSubtotal = new Label() { Text = "Subtotal ₡", Location = new Point(20, 30) };
            TextBox txtSubtotal = new TextBox() { Location = new Point(120, 25), Width = 150 };

            Label lblIVA = new Label() { Text = "IVA", Location = new Point(20, 60) };
            TextBox txtIVA = new TextBox() { Location = new Point(120, 55), Width = 150 };

            Label lblTotal = new Label() { Text = "Total ₡", Location = new Point(20, 90) };
            TextBox txtTotal = new TextBox() { Location = new Point(120, 85), Width = 150 };

            gbTotales.Controls.AddRange(new Control[] {
            lblSubtotal, txtSubtotal,
            lblIVA, txtIVA,
            lblTotal, txtTotal
        });

            // ===== PAGO =====
            GroupBox gbPago = new GroupBox()
            {
                Text = "Forma de Pago",
                Location = new Point(10, 390),
                Size = new Size(350, 150)
            };

            Label lblTipoPago = new Label() { Text = "Tipo", Location = new Point(20, 30) };
            ComboBox cmbPago = new ComboBox()
            {
                Location = new Point(80, 25),
                Width = 200
            };

            cmbPago.Items.AddRange(new string[] {
            "Tarjeta", "Transferencia", "SINPE"
        });

            Label lblDetallePago = new Label()
            {
                Text = "Datos del pago...",
                Location = new Point(20, 70),
                AutoSize = true
            };

            gbPago.Controls.AddRange(new Control[] {
            lblTipoPago, cmbPago, lblDetallePago
        });

            // ===== FIRMA =====
            GroupBox gbFirma = new GroupBox()
            {
                Text = "Firma del Cliente",
                Location = new Point(380, 390),
                Size = new Size(350, 150)
            };

            PictureBox picFirma = new PictureBox()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            gbFirma.Controls.Add(picFirma);

            // ===== BOTONES =====
            Button btnGuardar = new Button()
            {
                Text = "Guardar",
                Location = new Point(750, 550),
                Size = new Size(100, 40)
            };

            Button btnFacturar = new Button()
            {
                Text = "Facturar",
                Location = new Point(860, 550),
                Size = new Size(100, 40)
            };

            Button btnSalir = new Button()
            {
                Text = "Salir",
                Location = new Point(970, 550),
                Size = new Size(100, 40)
            };

            // ===== AGREGAR TODO =====
            this.Controls.AddRange(new Control[] {
            gbEncabezado,
            gbDetalle,
            gbTotales,
            gbPago,
            gbFirma,
            btnGuardar,
            btnFacturar,
            btnSalir
        });
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {

        }
    }
}
