using AppProyectoFelipe.Layers.BLL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Entities.BCCR;
using AppProyectoFelipe.Layers.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.Electronics.Extensions;

namespace AppProyectoFelipe.Layers.UI.Mantenimientos
{
    public partial class FrmProductos : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private IBLLTipoDispositivo _IBLLTipoDispositivo;
        private IBLLMarca _IBLLMarca;
        private IBLLModelo _IBLLModelo;
        private byte[] _documentoBytes;
        private byte[] _fotoBytes;

        private System.Windows.Forms.Timer timerTipoCambio;
        private DateTime ultimaFechaActualizacion;

        public FrmProductos()
        {
            InitializeComponent();
            _IBLLTipoDispositivo = new BLLTipoDispositivo();
            _IBLLMarca = new BLLMarca();
            _IBLLModelo = new BLLModelo();
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {

        }

        private void BtnDocumento_Click(object sender, EventArgs e)
        {

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

        private async Task CargarDatos()
        {
            IBLLProducto bllProducto = new BLLProducto();

            var listaProductos = await bllProducto.ObtenerTodos();
            var listaMarcas = await _IBLLMarca.ObtenerTodos();
            var listaModelos = await _IBLLModelo.ObtenerTodos();
            var listaTipos = await _IBLLTipoDispositivo.ObtenerTodos();

            var listaMostrar = listaProductos.Select(p => new
            {
                p.IdProducto,
                p.CodigoIndustria,
                p.Nombre,
                p.Color,
                p.Caracteristicas,
                p.Extras,
                p.CantidadStock,
                p.PrecioColones,
                p.PrecioDolares,
                p.Estado,

                Marca = listaMarcas.FirstOrDefault(m => m.IdMarca == p.IdMarca)?.Descripcion,
                Modelo = listaModelos.FirstOrDefault(m => m.IdModelo == p.IdModelo)?.Descripcion,
                TipoDispositivo = listaTipos.FirstOrDefault(t => t.IdTipoDispositivo == p.IdTipoDispositivo)?.Descripcion
            }).ToList();

            DgvDatos.AutoGenerateColumns = true;
            DgvDatos.DataSource = null;
            DgvDatos.DataSource = listaMostrar;

            if (DgvDatos.Columns["IdProducto"] != null)
                DgvDatos.Columns["IdProducto"].Visible = false;

            DgvDatos.Columns["CodigoIndustria"].HeaderText = "Código";
            DgvDatos.Columns["CantidadStock"].HeaderText = "Stock";
            DgvDatos.Columns["PrecioColones"].HeaderText = "Precio ₡";
            DgvDatos.Columns["PrecioDolares"].HeaderText = "Precio $";
            DgvDatos.Columns["TipoDispositivo"].HeaderText = "Tipo";
            DgvDatos.Columns["Caracteristicas"].HeaderText = "Características";
            DgvDatos.Columns["Extras"].HeaderText = "Extras";
            DgvDatos.Columns["Caracteristicas"].Width = 200;
            DgvDatos.Columns["Extras"].Width = 200;
        }

        private async Task CargarCombos()
        {
            CmbTipoDisp.DataSource = await _IBLLTipoDispositivo.ObtenerTodos();
            CmbTipoDisp.DisplayMember = "Descripcion";
            CmbTipoDisp.ValueMember = "IdTipoDispositivo";

            CmbMarca.DataSource = await _IBLLMarca.ObtenerTodos();
            CmbMarca.DisplayMember = "Descripcion";
            CmbMarca.ValueMember = "IdMarca";

            CmbModelo.DataSource = await _IBLLModelo.ObtenerTodos();
            CmbModelo.DisplayMember = "Descripcion";
            CmbModelo.ValueMember = "IdModelo";

            CmbTipoDisp.SelectedIndex = -1;
            CmbMarca.SelectedIndex = -1;
            CmbModelo.SelectedIndex = -1;
        }

        private async void FrmProductos_Load(object sender, EventArgs e)
        {
            await CargarDatos();
            await CargarCombos();

            CargarTipoCambio();

            timerTipoCambio = new System.Windows.Forms.Timer();
            timerTipoCambio.Interval = 3600000; // 1 hora
            timerTipoCambio.Tick += TimerTipoCambio_Tick;
            timerTipoCambio.Start();
        }

        private void TimerTipoCambio_Tick(object sender, EventArgs e)
        {
            // Solo actualizar si es un nuevo día
            if (DateTime.Today > ultimaFechaActualizacion)
            {
                CargarTipoCambio();
            }
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            IBLLProducto bllProducto = new BLLProducto();
            Erp = new ErrorProvider();
            try
            {
                Erp.Clear();
                Producto oProducto = new Producto();

                if (string.IsNullOrEmpty(TxtCodigoBarras.Text))
                {
                    Erp.SetError(TxtCodigoBarras, "Codigo requerido");
                    TxtCodigoBarras.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(TxtNombre.Text))
                {
                    Erp.SetError(TxtNombre, "Nombre requerida");
                    TxtNombre.Focus();
                    return;
                }

                if (CmbMarca.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una marca");
                    return;
                }

                if (CmbModelo.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un modelo");
                    return;
                }

                if (CmbTipoDisp.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un tipo de dispositivo");
                    return;
                }

                oProducto.CodigoIndustria = this.TxtCodigoBarras.Text;
                oProducto.Nombre = this.TxtNombre.Text;

                oProducto.IdTipoDispositivo = Convert.ToInt32(this.CmbTipoDisp.SelectedValue);
                oProducto.IdMarca = Convert.ToInt32(this.CmbMarca.SelectedValue);
                oProducto.IdModelo = Convert.ToInt32(this.CmbModelo.SelectedValue);
                oProducto.Color = this.TxtColor.Text;
                oProducto.CantidadStock = Convert.ToInt32(this.NudCantidadStock.Value);
                oProducto.Caracteristicas = this.TxtCaracteristicas.Text;
                oProducto.Extras = this.TxtExtras.Text;
                oProducto.DocumentoEspecificaciones = _documentoBytes;
                oProducto.PrecioColones = Convert.ToDecimal(this.TxtPrecioColones.Text);
                oProducto.PrecioDolares = Convert.ToDecimal(this.TxtPrecioDolares.Text);
                oProducto.Estado = RdbActivo.Checked;
                oProducto.Foto = _fotoBytes;


                oProducto = await bllProducto.Guardar(oProducto);
                await CargarDatos();

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PtbImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var ms = new MemoryStream(File.ReadAllBytes(ofd.FileName)))
                {
                    PtbImagen.Image = Image.FromStream(ms);
                }

                _fotoBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvDatos.CurrentRow != null)
                {
                    Producto oProducto = DgvDatos.CurrentRow.DataBoundItem as Producto;

                    if (oProducto == null)
                    {
                        MessageBox.Show("Error: el DataGrid no contiene objetos productos");
                        return;
                    }

                    TxtCodigoBarras.Text = oProducto.CodigoIndustria;
                    TxtNombre.Text = oProducto.Nombre;
                    TxtColor.Text = oProducto.Color;
                    TxtCaracteristicas.Text = oProducto.Caracteristicas;
                    TxtExtras.Text = oProducto.Extras;

                    TxtPrecioColones.Text = oProducto.PrecioColones.ToString();
                    TxtPrecioDolares.Text = oProducto.PrecioDolares.ToString();

                    CmbTipoDisp.SelectedValue = oProducto.IdTipoDispositivo;
                    CmbMarca.SelectedValue = oProducto.IdMarca;
                    CmbModelo.SelectedValue = oProducto.IdModelo;

                    NudCantidadStock.Value = oProducto.CantidadStock;

                    RdbActivo.Checked = oProducto.Estado;
                    RdbInactivo.Checked = !oProducto.Estado;

                    if (oProducto.Foto != null)
                    {
                        using (MemoryStream ms = new MemoryStream(oProducto.Foto))
                        {
                            PtbImagen.Image = Image.FromStream(ms);
                        }

                        _fotoBytes = oProducto.Foto;
                    }

                    _documentoBytes = oProducto.DocumentoEspecificaciones;
                    TxtDocumentos.Text = _documentoBytes != null ? "Documento cargado" : "";
                }
                else
                {
                    MessageBox.Show("Seleccione un registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            IBLLProducto bllProducto = new BLLProducto();

            try
            {
                if (this.DgvDatos.SelectedRows.Count > 0)
                {
                    var fila = this.DgvDatos.SelectedRows[0];

                    int id = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                    string nombre = fila.Cells["Nombre"].Value.ToString();

                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {nombre}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool eliminado = await bllProducto.Eliminar(id);

                        if (eliminado)
                            MessageBox.Show("Registro eliminado correctamente");
                        else
                            MessageBox.Show("No se eliminó ningún registro");

                        await CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TxtDocumentos.Text = ofd.FileName;

                _documentoBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void TxtPrecioColones_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtPrecioColones.Text, out decimal montoColones))
            {
                decimal tipoCambio = ObtenerTipoCambioVenta();
                TxtPrecioDolares.Text = (montoColones / tipoCambio).ToString("N2");
            }
        }
    }
}
