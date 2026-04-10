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
    public partial class FrmMarca : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public FrmMarca()
        {
            InitializeComponent();
        }

        private async Task CargarDatos()
        {
            IBLLMarca bllMarca = new BLLMarca();

            var lista = await bllMarca.ObtenerTodos();

            DgvDatos.AutoGenerateColumns = true;

            DgvDatos.DataSource = null;
            DgvDatos.DataSource = lista;

            if (DgvDatos.Columns["IdMarca"] != null)
                DgvDatos.Columns["IdMarca"].Visible = false;
        }

        private async void FrmMarca_Load(object sender, EventArgs e)
        {
            await CargarDatos();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            IBLLMarca bllMarca = new BLLMarca();
            Erp = new ErrorProvider();
            try
            {
                Erp.Clear();
                Marca oMarca = new Marca();

                if (string.IsNullOrEmpty(TxtDescripcion.Text))
                {
                    Erp.SetError(TxtDescripcion, "Descripcion requerida");
                    TxtDescripcion.Focus();
                    return;
                }

                oMarca.Descripcion = this.TxtDescripcion.Text;
                oMarca.Estado = RdbActivo.Checked;
                oMarca = await bllMarca.Guardar(oMarca);
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
                    Marca oMarca = DgvDatos.CurrentRow.DataBoundItem as Marca;

                    if (oMarca == null)
                    {
                        MessageBox.Show("Error: el DataGrid no contiene objetos Marca");
                        return;
                    }

                    TxtDescripcion.Text = oMarca.Descripcion;
                    RdbActivo.Checked = oMarca.Estado;
                    RdbInactivo.Checked = !oMarca.Estado;
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
            IBLLMarca bLLMarca = new BLLMarca();

            try
            {
                if (this.DgvDatos.SelectedRows.Count > 0)
                {
                    var fila = this.DgvDatos.SelectedRows[0];

                    int id = Convert.ToInt32(fila.Cells["IdMarca"].Value);
                    string descripcion = fila.Cells["Descripcion"].Value.ToString();

                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {descripcion}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool eliminado = await bLLMarca.Eliminar(id);

                        if (eliminado)
                            MessageBox.Show("Registro eliminado correctamente");
                        else
                            MessageBox.Show("No se eliminó ningún registro");

                        await CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !");
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
