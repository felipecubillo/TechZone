using AppProyectoFelipe.Layers.Entities.BCCR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProyectoFelipe.Layers.UI
{
    public partial class FrmMenuPrincipal : Form
    {
        private System.Windows.Forms.Timer timerTipoCambio;
        private DateTime ultimaFechaActualizacion;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            CargarTipoCambio();

            timerTipoCambio = new System.Windows.Forms.Timer();
            timerTipoCambio.Interval = 3600000; // 1 hora
            timerTipoCambio.Tick += TimerTipoCambio_Tick;
            timerTipoCambio.Start();
        }

        private void CargarTipoCambio()
        {
            decimal tipoCambio = ObtenerTipoCambioVenta();
            if (tipoCambio > 0)
            {
                LblTipoCambio.Text = $"₡ {tipoCambio:N2} (BCCR)";
                ultimaFechaActualizacion = DateTime.Today;
            }
            else
            {
                LblTipoCambio.Text = "Error al obtener tipo de cambio";
            }
        }
        private void TimerTipoCambio_Tick(object sender, EventArgs e)
        {
            // Solo actualizar si es un nuevo día
            if (DateTime.Today > ultimaFechaActualizacion)
            {
                CargarTipoCambio();
            }
        }

        private decimal ObtenerTipoCambioVenta()
        {
            try
            {
                // Instancia el servicio
                ServicesBCCR service = new ServicesBCCR();

                // Define las fechas (hoy)
                DateTime fechaHoy = DateTime.Now;

                // Llama al método GetDolar con el indicador de venta ("v")
                var tipoCambio = service.GetDolar(fechaHoy, fechaHoy, "v").FirstOrDefault();

                if (tipoCambio != null)
                {
                    return (decimal)tipoCambio.Monto; // Retorna el monto del tipo de cambio.
                }
                else
                {
                    throw new Exception("No se encontró el tipo de cambio para la fecha especificada.");
                }
            }
            catch (Exception ex)
            {
                // Maneja los errores
                MessageBox.Show($"Error al obtener el tipo de cambio de venta: {ex.Message}");
                return 0m; // Retorna 0 como valor por defecto en caso de error.
            }
        }
    }
}
