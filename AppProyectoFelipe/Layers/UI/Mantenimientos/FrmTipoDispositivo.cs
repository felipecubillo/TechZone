using AppProyectoFelipe.Layers.BLL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.Electronics.Extensions;

namespace AppProyectoFelipe.Layers.UI.Mantenimientos
{
    public partial class FrmTipoDispositivo : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public FrmTipoDispositivo()
        {
            InitializeComponent();
        }

        private async Task CargarDatos()
        {
            IBLLTipoDispositivo bllTipo = new BLLTipoDispositivo();

            var lista = await bllTipo.ObtenerTodos();

            DgvDatos.AutoGenerateColumns = true;

            DgvDatos.DataSource = null;
            DgvDatos.DataSource = lista;

            if (DgvDatos.Columns["IdTipoDispositivo"] != null)
                DgvDatos.Columns["IdTipoDispositivo"].Visible = false;
        }

        private async void FrmTipoDispositivo_Load(object sender, EventArgs e)
        {
            await CargarDatos();
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            IBLLTipoDispositivo bllTipo = new BLLTipoDispositivo();
            Erp = new ErrorProvider();
            try
            {
                Erp.Clear();
                TipoDispositivo oTipo = new TipoDispositivo();

                if (string.IsNullOrEmpty(TxtDescripcion.Text))
                {
                    Erp.SetError(TxtDescripcion, "Descripcion requerida");
                    TxtDescripcion.Focus();
                    return;
                }

                oTipo.Descripcion = this.TxtDescripcion.Text;
                oTipo.Estado = RdbActivo.Checked;
                oTipo = await bllTipo.Guardar(oTipo);
                await CargarDatos();

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvDatos.CurrentRow != null)
                {
                    TipoDispositivo oTipo = DgvDatos.CurrentRow.DataBoundItem as TipoDispositivo;

                    if (oTipo == null)
                    {
                        MessageBox.Show("Error: el DataGrid no contiene objetos Marca");
                        return;
                    }

                    TxtDescripcion.Text = oTipo.Descripcion;
                    RdbActivo.Checked = oTipo.Estado;
                    RdbInactivo.Checked = !oTipo.Estado;
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
            IBLLTipoDispositivo bllTipo = new BLLTipoDispositivo();

            try
            {
                if (this.DgvDatos.SelectedRows.Count > 0)
                {
                    var fila = this.DgvDatos.SelectedRows[0];

                    int id = Convert.ToInt32(fila.Cells["IdTipoDispositivo"].Value);
                    string descripcion = fila.Cells["Descripcion"].Value.ToString();

                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {descripcion}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool eliminado = await bllTipo.Eliminar(id);

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
    }
}
