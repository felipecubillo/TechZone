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
    class DALMarca : IDALMarca
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public async Task<Marca> Actualizar(Marca pMarca)
        {
            double row = 0;
            SqlCommand command = new SqlCommand();

            Marca oMarca = new Marca();

            command.Parameters.AddWithValue("@Descripcion", pMarca.Descripcion);
            command.Parameters.AddWithValue("@Estado", pMarca.Estado);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_UPDATE_Marca";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            // Si devuelve filas quiere decir que se salvo entonces extraerlo
            if (row > 0)
                oMarca = this.ObtenerPorId(pMarca.IdMarca);

            return oMarca;
        }

        public async Task<bool> Eliminar(int pId)
        {
            bool retorno = false;
            double row = 0d;
            SqlCommand command = new SqlCommand();


            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_DELETE_Marca_ByID";

            command.Parameters.AddWithValue("@IdMarca", pId);

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            if (row > 0)
                retorno = true;

            return retorno;
        }

        public async Task<Marca> Guardar(Marca pMarca)
        {
            SqlCommand command = new SqlCommand();
            Marca oMarca = null;

            double row = 0;
            command.Parameters.AddWithValue("@Descripcion", pMarca.Descripcion);
            command.Parameters.AddWithValue("@Estado", pMarca.Estado);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_INSERT_Marca";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
            }

            // Si devuelve filas quiere decir que se salvo entonces extraerlo
            if (row > 0)
                oMarca = this.ObtenerPorId(pMarca.IdMarca);

            return oMarca;
        }

        public List<Marca> ObtenerPorFiltro(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public Marca ObtenerPorId(int pId)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Marca oMarca = null;

            command.Parameters.AddWithValue("@IdMarca", pId);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "usp_SELECT_Marca_ByID";


            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    oMarca = new Marca();
                    {
                        oMarca.IdMarca = int.Parse(reader["IdMarca"].ToString());
                        oMarca.Descripcion = reader["Descripcion"].ToString();
                        oMarca.Estado = bool.Parse(reader["Estado"].ToString());
                    }
                }
            }
            return oMarca;
        }

        public async Task<IEnumerable<Marca>> ObtenerTodos()
        {
            IList<Marca> lista = new List<Marca>();

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
                                Marca oMarca = new Marca();
                                {
                                    Marca oMarca1 = new Marca();
                                    oMarca.IdMarca = int.Parse(reader["IdMarca"].ToString());
                                    oMarca.Descripcion = reader["Descripcion"].ToString();
                                    oMarca.Estado = bool.Parse(reader["Estado"].ToString());
                                    lista.Add(oMarca);
                                }
                                ;
                                lista.Add(oMarca);
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
