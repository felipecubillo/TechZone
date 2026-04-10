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
    class DALModelo : IDALModelo
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public async Task<Modelo> Actualizar(Modelo pModelo)
        {
            SqlCommand command = new SqlCommand();
            Modelo oModelo = null;

            command.Parameters.AddWithValue("@IdModelo", pModelo.IdModelo);
            command.Parameters.AddWithValue("@Descripcion", pModelo.Descripcion);
            command.Parameters.AddWithValue("@Estado", pModelo.Estado);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_UPDATE_Modelo";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oModelo = pModelo;
            }

            return oModelo;
        }

        public async Task<bool> Eliminar(int pId)
        {
            bool retorno = false;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_DELETE_Modelo_ByID";

            command.Parameters.AddWithValue("@IdModelo", pId);

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    retorno = true;
            }

            return retorno;
        }

        public async Task<Modelo> Guardar(Modelo pModelo)
        {
            SqlCommand command = new SqlCommand();
            Modelo oModelo = null;

            command.Parameters.AddWithValue("@Descripcion", pModelo.Descripcion);
            command.Parameters.AddWithValue("@Estado", pModelo.Estado);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_INSERT_Modelo";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oModelo = pModelo;
            }

            return oModelo;
        }

        public List<Modelo> ObtenerPorFiltro(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public Modelo ObtenerPorId(int pId)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Modelo oModelo = null;

            command.Parameters.AddWithValue("@IdModelo", pId);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_SELECT_Modelo_ByID";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    oModelo = new Modelo
                    {
                        IdModelo = int.Parse(reader["IdModelo"].ToString()),
                        Descripcion = reader["Descripcion"].ToString(),
                        Estado = bool.Parse(reader["Estado"].ToString())
                    };
                }
            }

            return oModelo;
        }

        public async Task<IEnumerable<Modelo>> ObtenerTodos()
        {
            IList<Modelo> lista = new List<Modelo>();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SELECT_Modelo_All";

                try
                {
                    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                    {
                        using (IDataReader reader = db.ExecuteReader(command))
                        {
                            while (reader.Read())
                            {
                                Modelo oModelo = new Modelo
                                {
                                    IdModelo = int.Parse(reader["IdModelo"].ToString()),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = bool.Parse(reader["Estado"].ToString())
                                };

                                lista.Add(oModelo);
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

