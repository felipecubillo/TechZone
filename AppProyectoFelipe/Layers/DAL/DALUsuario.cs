using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Electronics.Extensions;

namespace AppProyectoFelipe.Layers.DAL
{
    class DALUsuario : IDALUsuario
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public Usuario Actualizar(Usuario pUsuario)
        {
            SqlCommand command = new SqlCommand();
            Usuario oUsuario = null;

            command.Parameters.AddWithValue("@IdPerfil", pUsuario.IdPerfil);
            command.Parameters.AddWithValue("@Contrasena", pUsuario.Contrasena);
            command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            command.Parameters.AddWithValue("@Estado", pUsuario.Estado);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_UPDATE_Usuario";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oUsuario = pUsuario;
            }

            return oUsuario;
        }

        public bool Borrar(int pIdUsuario)
        {
            bool retorno = false;
            double row = 0d;
            SqlCommand command = new SqlCommand();


            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_DELETE_Usuario_ByID";

            command.Parameters.AddWithValue("@IdUsuario", pIdUsuario);

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            if (row > 0)
                retorno = true;

            return retorno;
        }

        public Usuario Guardar(Usuario pUsuario)
        {
            SqlCommand command = new SqlCommand();
            Usuario oUsuario = null;

            double row = 0;
            command.Parameters.AddWithValue("@IdPerfil", pUsuario.IdPerfil);
            command.Parameters.AddWithValue("@Contrasena", pUsuario.Contrasena);
            command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
            command.Parameters.AddWithValue("@Estado", pUsuario.Estado);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_INSERT_Usuario";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            // Si devuelve filas quiere decir que se salvo entonces extraerlo
            if (row > 0)
                oUsuario = this.ObtenerPorId(pUsuario.IdUsuario);

            return oUsuario;
        }

        public Usuario IdUsuario(int pIdUsuario, string pContrasena)
        {

            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            string msg = "";
            try
            {
                command.CommandText = @"select * from usuario with (rowlock)  where IdUsuario = @pIdUsuario and Contrasena = @pContrasena";
                command.Parameters.AddWithValue("@pIdUsuario", pIdUsuario);
                command.Parameters.AddWithValue("@pContrasena", pContrasena);
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                        oUsuario.IdPerfil = int.Parse(reader["IdPerfil"].ToString());
                        oUsuario.Contrasena = reader["Contrasena"].ToString();
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString());
                    }
                }

                return oUsuario;
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

        public Usuario ObtenerPorId(int pIdUsuario)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;

            command.Parameters.AddWithValue("@IdUsuario", pIdUsuario);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_SELECT_Usuario_ByID";


            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    oUsuario = new Usuario();
                    {
                        oUsuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                        oUsuario.IdPerfil = int.Parse(reader["IdPerfil"].ToString());
                        oUsuario.Contrasena = reader["Contrasena"].ToString();
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString());
                    }
                }
            }
            return oUsuario;
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            IList<Usuario> lista = new List<Usuario>();

            using (SqlCommand command = new SqlCommand())
            {

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "usp_SELECT_Marca_All";

                try
                {
                    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                    {
                        using (IDataReader reader = db.ExecuteReader(command))
                        {
                            while (reader.Read())
                            {
                                Usuario oUsuario = new Usuario();
                                {
                                    oUsuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                                    oUsuario.IdPerfil = int.Parse(reader["IdPerfil"].ToString());
                                    oUsuario.Contrasena = reader["Contrasena"].ToString();
                                    oUsuario.Nombre = reader["Nombre"].ToString();
                                    oUsuario.Estado = bool.Parse(reader["Estado"].ToString());
                                    lista.Add(oUsuario);
                                }
                                ;
                                lista.Add(oUsuario);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _MyLogControlEventos.Error("Error en GetAllLogin", ex);
                    throw;
                }
            }
            return lista;
        }
    }
}
