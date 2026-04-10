using AppProyectoFelipe.Layers.DAL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.BLL
{
    class BLLUsuario : IBLLUsuario
    {
        public bool Borrar(string pIdUsuario)
        {
            IDALUsuario dalUsuario = new DALUsuario();
            return dalUsuario.Borrar(pIdUsuario);
        }

        public Usuario Guardar(Usuario pUsuario)
        {
            IDALUsuario dalUsuario = new DALUsuario();
            string mensaje = "";
            Usuario oUsuario = null;

            if (!IsValidPassword(pUsuario.Contrasena, ref mensaje))
            {
                throw new Exception(mensaje);
            }

            // Encriptar la contraseña.
            pUsuario.Contrasena = Cryptography.EncrypthAES(pUsuario.Contrasena);

            if (dalUsuario.ObtenerPorId(pUsuario.IdUsuario) != null)
                oUsuario = dalUsuario.Actualizar(pUsuario);
            else
                oUsuario = dalUsuario.Guardar(pUsuario);
            return oUsuario;
        }

        private bool IsValidPassword(string contrasena, ref string mensaje)
        {
            if (contrasena.Trim().Length <= 6)
            {
                mensaje = "El password debe ser mayor o igual a 6 caracteres";
                return false;
            }

            if (contrasena.Trim().Length > 10)
            {
                mensaje = "El password debe ser mayor o igual a 6 caracteres y menor  o igual que 10";
                return false;
            }

            return true;
        }

        public Usuario IdUsuario(string pIdUsuario, string pContrasena)
        {
            IDALUsuario dalUsuario = new DALUsuario();
            // Encriptar el password
            string crytpPasswd = Cryptography.EncrypthAES(pContrasena);

            return dalUsuario.IdUsuario(pIdUsuario, crytpPasswd);
        }

        public Usuario ObtenerPorId(string pIdUsuario)
        {
            IDALUsuario dalUsuario = new DALUsuario();
            return dalUsuario.ObtenerPorId(pIdUsuario);
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            IDALUsuario dalUsuario = new DALUsuario();
            return dalUsuario.ObtenerTodos();
        }
    }
}
