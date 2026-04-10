using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Electronics.Extensions;

namespace AppProyectoFelipe.Layers.DAL
{
    class DALPerfil : IDALPerfil
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public List<Perfil> ObtenerTodos()
        {
            StringBuilder conexion = new StringBuilder();

            IDataReader reader = null;
            List<Perfil> lista = new List<Perfil>();
            SqlCommand command = new SqlCommand();
            string msg = "";
            string sql = @" select * from  Perfil ";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Perfil oPerfil = new Perfil();
                        oPerfil.IdPerfil = int.Parse(reader["IdPerfil"].ToString());
                        oPerfil.Descripcion = reader["Descripcion"].ToString();
                        lista.Add(oPerfil);
                    }
                }

                return lista;
            }
            catch (SqlException er)
            {
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
