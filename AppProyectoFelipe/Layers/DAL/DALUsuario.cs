using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.DAL
{
    class DALUsuario : IDALUsuario
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public Usuario Actualizar(Usuario pUsuario)
        {
            SqlCommand command = new SqlCommand();
            Usuario oUsuario = null;

           

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_UPDATE_Modelo";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oUsuario = pUsuario;
            }

            return oUsuario;
        }

        public bool Borrar(string pIdUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Guardar(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario IdUsuario(string pIdUsuario, string pContrasena)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorId(string pIdUsuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
