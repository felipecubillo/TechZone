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
    public partial class FrmModelo : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public FrmModelo()
        {
            InitializeComponent();
        }

        private async Task CargarDatos()
        {
            IBLLModelo bllModelo = new BLLModelo();

            var lista = await bllModelo.ObtenerTodos();

            DgvDatos.AutoGenerateColumns = true;

            DgvDatos.DataSource = null;
            DgvDatos.DataSource = lista;

            if (DgvDatos.Columns["IdModelo"] != null)
                DgvDatos.Columns["IdModelo"].Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            IBLLModelo bllModelo = new BLLModelo();
            Erp = new ErrorProvider();
            try
            {
                Erp.Clear();
                Modelo oModelo = new Modelo();

                if (string.IsNullOrEmpty(TxtDescripcion.Text))
                {
                    Erp.SetError(TxtDescripcion, "Descripcion requerida");
                    TxtDescripcion.Focus();
                    return;
                }

                oModelo.Descripcion = this.TxtDescripcion.Text;
                oModelo.Estado = RdbActivo.Checked;
                oModelo = await bllModelo.Guardar(oModelo);
                await CargarDatos();

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void FrmModelo_Load(object sender, EventArgs e)
        {
           await CargarDatos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvDatos.CurrentRow != null)
                {
                    Modelo oModelo = DgvDatos.CurrentRow.DataBoundItem as Modelo;

                    if (oModelo == null)
                    {
                        MessageBox.Show("Error: el DataGrid no contiene objetos Marca");
                        return;
                    }

                    TxtDescripcion.Text = oModelo.Descripcion;
                    RdbActivo.Checked = oModelo.Estado;
                    RdbInactivo.Checked = !oModelo.Estado;
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
            IBLLModelo bllModelo = new BLLModelo();

            try
            {
                if (this.DgvDatos.SelectedRows.Count > 0)
                {
                    var fila = this.DgvDatos.SelectedRows[0];

                    int id = Convert.ToInt32(fila.Cells["IdModelo"].Value);
                    string descripcion = fila.Cells["Descripcion"].Value.ToString();

                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {descripcion}?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool eliminado = await bllModelo.Eliminar(id);

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
