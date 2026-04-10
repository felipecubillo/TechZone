using AppProyectoFelipe.Layers.BLL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using AppProyectoFelipe.Properties;
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

namespace AppProyectoFelipe
{
    public partial class FrmInicioSesion : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private int contador = 0;

        public FrmInicioSesion()
        {
            InitializeComponent();
        }

        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"{this.Text}. Versión Electronics : {Application.ProductVersion}";
                // Leer app.config con el nombre de la Empresa                 
                // this.Text = ConfigurationManager.AppSettings["NombreEmpresa"] + " " + Application.ProductName + " Versión:  " + Application.ProductVersion ;


                //  _Desafio = random.Next(1000) * 1000;
                // _Desafio = 3333333;
                // var image = QuickResponse.
                //     QuickResponseGenerador(_Desafio.ToString(), 53);
                // this.pcbLogin.SizeMode = PictureBoxSizeMode.StretchImage;
                //this.pcbLogin.Image = image;


                _myLogControlEventos.InfoFormat("Inicio Login");
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlpPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async Task btnAceptar_Click(object sender, EventArgs e)
        {
            // Debe validar los datos requeridos
            IBLLUsuario bllUsuario = new BLLUsuario();
            Erp.Clear();
            Usuario oUsuario = null;
            try
            {

                if (string.IsNullOrEmpty(this.txtLogin.Text))
                {
                    Erp.SetError(txtLogin, "Usuario requerido");
                    this.txtLogin.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    Erp.SetError(txtPassword, "Contrasena requerida");
                    this.txtPassword.Focus();
                    return;
                }

                oUsuario = bllUsuario.IdUsuario(this.txtLogin.Text,
                                           this.txtPassword.Text);

                if (oUsuario == null)
                {
                    ++contador;
                    MessageBox.Show("Error en el acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Si el contador es 3 cierre la aplicación
                    if (contador == 3)
                    {
                        // se devuelve Cancel
                        MessageBox.Show("Se equivocó en 3 ocasiones, el Sistema se Cerrará por seguridad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _myLogControlEventos.WarnFormat("Se equivocó + de 3 ocasiones Login: {0}", this.txtLogin.Text);
                        this.DialogResult = DialogResult.Cancel;
                        Application.Exit();
                    }
                }
                else
                {

                    oUsuario.IdUsuario = this.txtLogin.Text.Trim();
                    oUsuario.Nombre = oUsuario.Nombre;
                    oUsuario.IdPerfil = oUsuario.IdPerfil;

                    //EfectoConexionNoAsync();
                    //bool respuesta = await EfectoConexion();

                    // Log de errores
                    _myLogControlEventos.InfoFormat("Accedió a la aplicación :{0}", oUsuario.Nombre);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        //private async Task<bool> EfectoConexion()
        //{
        //    //Efecto en la barra de entrada.
        //    toolStripPbBarra.Visible = true;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        await Task.Delay(150);
        //        //Thread.Sleep(100);
        //        this.toolStripPbBarra.Value += 10;
        //        this.sttBarraInferior.Refresh();
        //    }
        //    return true;

        //}
    }
}
