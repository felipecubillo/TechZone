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
    class DALTipoDispositivo : IDALTipoDispositivo
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public async Task<TipoDispositivo> Actualizar(TipoDispositivo pTipo)
        {
            SqlCommand command = new SqlCommand();
            TipoDispositivo oTipo = null;

            command.Parameters.AddWithValue("@Descripcion", pTipo.Descripcion);
            command.Parameters.AddWithValue("@Estado", pTipo.Estado);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_UPDATE_TipoDispositivo";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oTipo = pTipo;
            }

            return oTipo;
        }

        public async Task<bool> Eliminar(int pId)
        {
            bool retorno = false;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_DELETE_TipoDispositivo_ByID";

            command.Parameters.AddWithValue("@IdTipoDispositivo", pId);

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    retorno = true;
            }

            return retorno;
        }

        public async Task<TipoDispositivo> Guardar(TipoDispositivo pTipo)
        {
            SqlCommand command = new SqlCommand();
            TipoDispositivo oTipo = null;

            command.Parameters.AddWithValue("@Descripcion", pTipo.Descripcion);
            command.Parameters.AddWithValue("@Estado", pTipo.Estado);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_INSERT_TipoDispositivo";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oTipo = pTipo;
            }

            return oTipo;
        }

        public List<TipoDispositivo> ObtenerPorFiltro(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public TipoDispositivo ObtenerPorId(int pId)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            TipoDispositivo oTipo = null;

            command.Parameters.AddWithValue("@IdTipoDispositivo", pId);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_SELECT_TipoDispositivo_ByID";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    oTipo = new TipoDispositivo
                    {
                        IdTipoDispositivo = int.Parse(reader["IdTipoDispositivo"].ToString()),
                        Descripcion = reader["Descripcion"].ToString(),
                        Estado = bool.Parse(reader["Estado"].ToString())
                    };
                }
            }

            return oTipo;
        }

        public async Task<IEnumerable<TipoDispositivo>> ObtenerTodos()
        {
            IList<TipoDispositivo> lista = new List<TipoDispositivo>();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SELECT_TipoDispositivo_All";

                try
                {
                    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                    {
                        using (IDataReader reader = db.ExecuteReader(command))
                        {
                            while (reader.Read())
                            {
                                TipoDispositivo oTipo = new TipoDispositivo
                                {
                                    IdTipoDispositivo = int.Parse(reader["IdTipoDispositivo"].ToString()),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Estado = bool.Parse(reader["Estado"].ToString())
                                };
                                lista.Add(oTipo);
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
