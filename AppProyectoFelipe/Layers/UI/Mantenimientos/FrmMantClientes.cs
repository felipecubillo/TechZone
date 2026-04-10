using AppProyectoFelipe.Layers.BLL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Entities.DTO;
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
using static AppProyectoFelipe.Layers.Entities.DTO.UbicacionDTO;

namespace AppProyectoFelipe.Layers.UI.Mantenimientos
{
    public partial class FrmMantClientes : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private readonly BLLProvincia _BLLProvincia;
        private byte[] _fotoBytes;

        public FrmMantClientes()
        {
            InitializeComponent();
            _BLLProvincia = new BLLProvincia();
        }

        private void ChangeState(EstadoMantenimiento estado)
        {
            Erp.Clear();
            this.TxtIdentificacion.Clear();
            this.TxtNombre.Clear();
            this.TxtApellidos.Clear();
            this.TtxCorreo.Clear();
            this.TxtIdentificacion.Enabled = false;
            this.TxtNombre.Enabled = false;
            this.TxtApellidos.Enabled = false;
            this.TtxCorreo.Enabled = false;

            this.BtnNuevo.Enabled = false;
            //this.btnCancelar.Enabled = false;
            this.BtnBuscar.Enabled = false;
            this.CboProvincia.Enabled = false;

            // Coloca el primer item por defecto
            if (CboProvincia.Items.Count > 0)
                this.CboProvincia.SelectedIndex = 0;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.TxtIdentificacion.Enabled = true;
                    this.RdbExtranjero.Enabled = true;
                    this.RdbNacional.Enabled = true;
                    this.TxtNombre.Enabled = true;
                    this.TxtApellidos.Enabled = true;
                    this.TtxCorreo.Enabled = true;
                    this.CboProvincia.Enabled = true;
                    this.RdbMujer.Enabled = true;
                    this.RdbHombre.Enabled = true;
                    this.TxtDireccion.Enabled = true;
                    this.TxtTelefono.Enabled = true;
                    this.CboProvincia.Enabled = true;
                    //this.BTNAceptar.Enabled = true;
                    this.BtnCancelar.Enabled = true;
                    this.BtnBuscar.Enabled = true;
                    TxtIdentificacion.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.TxtIdentificacion.Enabled = false;
                    this.TxtNombre.Enabled = true;
                    this.TxtApellidos.Enabled = true;
                    this.TtxCorreo.Enabled = true;
                    this.CboProvincia.Enabled = true;
                    //this.BTNAceptar.Enabled = true;
                    this.BtnCancelar.Enabled = true;
                    TxtNombre.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private async Task CargarProvincias()
        {
            List<Provincia> provincias = await _BLLProvincia.ObtenerProvinciasAsync();
            CboProvincia.DataSource = provincias;
            CboProvincia.DisplayMember = "Descripcion";
            CboProvincia.ValueMember = "IdProvincia";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.ChangeState(EstadoMantenimiento.Nuevo);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Cliente oCliente = null;
            try
            {
                if (this.DgvDatos.SelectedRows.Count > 0)
                {
                    this.ChangeState(EstadoMantenimiento.Editar);

                    oCliente = this.DgvDatos.SelectedRows[0].DataBoundItem as Cliente;

                    if (RdbExtranjero.Checked)
                    {
                        TxtIdentificacion.ReadOnly = false;
                        TxtNombre.ReadOnly = false;
                        this.TxtApellidos.Text = oCliente.Apellidos;
                        this.RdbHombre.Checked = oCliente.Sexo == "Hombre";
                        this.RdbMujer.Checked = oCliente.Sexo == "Mujer";
                        this.TtxCorreo.Text = oCliente.Correo;
                        this.TxtDireccion.Text = oCliente.DireccionExacta;
                        this.TxtTelefono.Text = oCliente.Telefono;
                        this.CboProvincia.Text = oCliente.Provincia;
                    }
                    else if (RdbNacional.Checked)
                    {
                        TxtIdentificacion.ReadOnly = true;
                        TxtNombre.ReadOnly = true;
                        this.RdbHombre.Checked = oCliente.Sexo == "Hombre";
                        this.RdbMujer.Checked = oCliente.Sexo == "Mujer";
                        this.TtxCorreo.Text = oCliente.Correo;
                        this.TxtDireccion.Text = oCliente.DireccionExacta;
                        this.TxtTelefono.Text = oCliente.Telefono;
                        this.CboProvincia.Text = oCliente.Provincia;
                    }

                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            IBLLPadron bllPadron = new BLLPadron();
            try
            {
                Erp.Clear();

                if (string.IsNullOrEmpty(TxtIdentificacion.Text))
                {
                    Erp.SetError(TxtIdentificacion, "Identificacion requerida");
                    TxtIdentificacion.Focus();
                    return;
                }

                if (TxtIdentificacion.Text.Trim().Length != 9)
                {
                    Erp.SetError(TxtIdentificacion, "Largo de la Cédula 9 digitos");
                    TxtIdentificacion.Focus();
                    return;
                }

                PadronDTO oPadronDTO = bllPadron.GetById(TxtIdentificacion.Text.Trim());


                string[] array = oPadronDTO.nombre.Split(' ');

                // 1 nombres y dos apellidos
                if (array.Length == 3)
                {
                    TxtNombre.Text = array[0];
                    TxtApellidos.Text = array[1];
                }

                // 2 nombres y dos apellidos
                if (array.Length == 4)
                {
                    TxtNombre.Text = array[0] + " " + array[1];
                    TxtApellidos.Text = array[2];
                }

                // Ejemplo con varios nombres. 203960070 - ANTONIO MARIA DE LA TRINIDAD RODRIGUEZ CHAVES 
                // 2 nombres y dos apellidos
                // Nota: No se valida apellidos compuestos por ejemplo Maria de la O
                if (array.Length > 4)
                {
                    TxtNombre.Text = array[0] + " " + array[1];
                    TxtApellidos.Text = array[array.Length - 2];
                }

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PtbFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var ms = new MemoryStream(File.ReadAllBytes(ofd.FileName)))
                {
                    PtbFoto.Image = Image.FromStream(ms);
                }

                _fotoBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.ChangeState(EstadoMantenimiento.Ninguno);
        }


        private async void FrmMantClientes_Load(object sender, EventArgs e)
        {
            await  CargarProvincias();
            await CargarDatos();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task CargarDatos()
        {
            IBLLCliente bllCliente = new BLLCliente();

            var lista = await bllCliente.ObtenerTodos();

            DgvDatos.AutoGenerateColumns = true;

            DgvDatos.DataSource = null;
            DgvDatos.DataSource = lista;

            if (DgvDatos.Columns["IdCliente"] != null)
                DgvDatos.Columns["IdCliente"].Visible = false;
        }

        private async void BtnAceptar_Click(object sender, EventArgs e)
        {
            IBLLCliente bllCliente = new BLLCliente();
            Erp = new ErrorProvider();
            try
            {
                Erp.Clear();
                Cliente oCliente = new Cliente();

                if (string.IsNullOrEmpty(TxtIdentificacion.Text))
                {
                    Erp.SetError(TxtIdentificacion, "Numero de identificacion requerido");
                    TxtIdentificacion.Focus();
                    return;
                }

                oCliente.IdTipoIdentificacion = RdbNacional.Checked ? 1 : 2;
                oCliente.Identificacion = this.TxtIdentificacion.Text;
                oCliente.Nombre = this.TxtNombre.Text;
                oCliente.Apellidos = this.TxtApellidos.Text;
                oCliente.Sexo = RdbHombre.Checked ? "M" : "F";
                oCliente.Telefono = this.TxtTelefono.Text;
                oCliente.Correo = this.TtxCorreo.Text;
                oCliente.DireccionExacta = TxtDireccion.Text;
                oCliente.Provincia = CboProvincia.SelectedItem.ToString();
                oCliente.Estado = RdbActivo.Checked;
                oCliente.Fotografia = _fotoBytes;

                oCliente = await bllCliente.Guardar(oCliente);
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            IBLLCliente bllCliente = new BLLCliente();

            try
            {
                if (this.DgvDatos.SelectedRows.Count > 0)
                {
                    this.ChangeState(EstadoMantenimiento.Borrar);

                    var fila = this.DgvDatos.SelectedRows[0];

                    string identificacion = fila.Cells["Identificacion"].Value.ToString();
                    string nombre = fila.Cells["Nombre"].Value.ToString();

                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {identificacion} {nombre}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool eliminado = await bllCliente.Eliminar(i);

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
    }
}
