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
    class DALCliente : IDALCliente
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public async Task<Cliente> Actualizar(Cliente pCliente)
        {
            double row = 0;
            SqlCommand command = new SqlCommand();

            Cliente oCliente = new Cliente();

            command.Parameters.AddWithValue("@IdTipoIdentificacion", pCliente.IdTipoIdentificacion);
            command.Parameters.AddWithValue("@Identificacion", pCliente.Identificacion);
            command.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
            command.Parameters.AddWithValue("@Apellidos", pCliente.Nombre);
            command.Parameters.AddWithValue("@Sexo", pCliente.Sexo);
            command.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
            command.Parameters.AddWithValue("@Correo", pCliente.Correo);
            command.Parameters.AddWithValue("@DireccionExacta", pCliente.DireccionExacta);
            command.Parameters.AddWithValue("@Provincia", pCliente.Provincia);
            command.Parameters.AddWithValue("@Estado", pCliente.Estado);
            command.Parameters.AddWithValue("@Fotografia", pCliente.Fotografia);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_UPDATE_Cliente";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            // Si devuelve filas quiere decir que se salvo entonces extraerlo
            if (row > 0)
                oCliente = this.ObtenerPorId(pCliente.Identificacion);

            return oCliente;
        }

        public async Task<bool> Eliminar(string pId)
        {
            bool retorno = false;
            double row = 0d;
            SqlCommand command = new SqlCommand();


            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_DELETE_Cliente_ByID";

            command.Parameters.AddWithValue("@IdCliente", pId);

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            if (row > 0)
                retorno = true;

            return retorno;
        }

        public async Task<Cliente> Guardar(Cliente pCliente)
        {
            SqlCommand command = new SqlCommand();
            Cliente oCliente = null;

            double row = 0;
            command.Parameters.AddWithValue("@IdTipoIdentificacion", pCliente.IdTipoIdentificacion);
            command.Parameters.AddWithValue("@Identificacion", pCliente.Identificacion);
            command.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
            command.Parameters.AddWithValue("@Apellidos", pCliente.Nombre);
            command.Parameters.AddWithValue("@Sexo", pCliente.Sexo);
            command.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
            command.Parameters.AddWithValue("@Correo", pCliente.Correo);
            command.Parameters.AddWithValue("@DireccionExacta", pCliente.DireccionExacta);
            command.Parameters.AddWithValue("@Provincia", pCliente.Provincia);
            command.Parameters.AddWithValue("@Estado", pCliente.Estado);
            command.Parameters.AddWithValue("@Fotografia", pCliente.Fotografia);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_INSERT_Cliente";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            // Si devuelve filas quiere decir que se salvo entonces extraerlo
            if (row > 0)
                oCliente = this.ObtenerPorId(pCliente.Identificacion);

            return oCliente;

        }

        public List<Cliente> ObtenerPorFiltro(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public Cliente ObtenerPorId(string pId)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Cliente oCliente = null;

            command.Parameters.AddWithValue("@IdCliente", pId);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_SELECT_Cliente_ByID";


            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    oCliente = new Cliente();
                    {
                        oCliente.IdCliente = int.Parse(reader["IdCliente"].ToString());
                        oCliente.IdTipoIdentificacion = int.Parse(reader["IdTipoIdentificacion"].ToString());
                        oCliente.Identificacion = reader["Identificacion"].ToString();
                        oCliente.Nombre = reader["Nombre"].ToString();
                        oCliente.Apellidos = reader["Apellidos"].ToString();
                        oCliente.Sexo = reader["Sexo"].ToString();
                        oCliente.Telefono = reader["Telefono"].ToString();
                        oCliente.Correo = reader["Correo"].ToString();
                        oCliente.DireccionExacta = reader["DireccionExacta"].ToString();
                        oCliente.Provincia = reader["Provincia"].ToString();
                        oCliente.Estado = bool.Parse(reader["Estado"].ToString());
                        oCliente.Fotografia = (byte[])reader["Fotografia"];

                    }
                }
            }
            return oCliente;
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            IList<Cliente> lista = new List<Cliente>();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "usp_SELECT_Cliente_All";

                try
                {
                    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                    {
                        using (IDataReader reader = db.ExecuteReader(command))
                        {
                            while (reader.Read())
                            {
                                Cliente oCliente = new Cliente
                                {
                                    IdCliente = int.Parse(reader["IdCliente"].ToString()),
                                    IdTipoIdentificacion = int.Parse(reader["IdTipoIdentificacion"].ToString()),
                                    Identificacion = reader["Identificacion"].ToString(),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellidos = reader["Apellidos"].ToString(),
                                    Sexo = reader["Sexo"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Correo = reader["Correo"].ToString(),
                                    DireccionExacta = reader["DireccionExacta"].ToString(),
                                    Provincia = reader["Provincia"].ToString(),
                                    Estado = bool.Parse(reader["Estado"].ToString()),
                                    Fotografia = (byte[])reader["Fotografia"]
                                };

                                lista.Add(oCliente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _MyLogControlEventos.Error("Error en ObtenerTodos", ex);
                    throw;
                }
            }
            return lista;
        }
    }
}
