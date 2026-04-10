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
using System.Windows.Forms;

namespace AppProyectoFelipe.Layers.DAL
{
    class DALProducto : IDALProducto
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");


        public async Task<Producto> Actualizar(Producto pProducto)
        {
            SqlCommand command = new SqlCommand();
            Producto oProducto = null;

            command.Parameters.AddWithValue("@CodigoIndustria", pProducto.CodigoIndustria);
            command.Parameters.AddWithValue("@IdTipoDispositivo", pProducto.IdTipoDispositivo);
            command.Parameters.AddWithValue("@IdModelo", pProducto.IdModelo);
            command.Parameters.AddWithValue("@IdMarca", pProducto.IdMarca);
            command.Parameters.AddWithValue("@Color", pProducto.Color);
            command.Parameters.AddWithValue("@Caracteristicas", pProducto.Caracteristicas);
            command.Parameters.AddWithValue("@Extras", pProducto.Extras);
            command.Parameters.AddWithValue("@CantidadStock", pProducto.CantidadStock);
            command.Parameters.AddWithValue("@Estado", pProducto.Estado);
            command.Parameters.AddWithValue("@DocumentoEspecificaciones", pProducto.DocumentoEspecificaciones);
            command.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
            command.Parameters.AddWithValue("@Foto", pProducto.Foto);
            command.Parameters.AddWithValue("@PrecioColones", pProducto.PrecioColones);
            command.Parameters.AddWithValue("@PrecioDolares", pProducto.PrecioDolares);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_UPDATE_Producto";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oProducto = pProducto;
            }

            return oProducto;
        }

        public async Task<bool> Eliminar(int pId)
        {
            bool retorno = false;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_DELETE_Producto_ByID";

            command.Parameters.AddWithValue("@IdProducto", pId);

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    retorno = true;
            }

            return retorno;
        }

        public async Task<Producto> Guardar(Producto pProducto)
        {
            SqlCommand command = new SqlCommand();
            Producto oModelo = null;

            command.Parameters.AddWithValue("@CodigoIndustria", pProducto.CodigoIndustria);
            command.Parameters.AddWithValue("@IdTipoDispositivo", pProducto.IdTipoDispositivo);
            command.Parameters.AddWithValue("@IdModelo", pProducto.IdModelo);
            command.Parameters.AddWithValue("@IdMarca", pProducto.IdMarca);
            command.Parameters.AddWithValue("@Color", pProducto.Color);
            command.Parameters.AddWithValue("@Caracteristicas", pProducto.Caracteristicas);
            command.Parameters.AddWithValue("@Extras", pProducto.Extras);
            command.Parameters.AddWithValue("@CantidadStock", pProducto.CantidadStock);
            command.Parameters.AddWithValue("@Estado", pProducto.Estado);
            command.Parameters.AddWithValue("@DocumentoEspecificaciones", pProducto.DocumentoEspecificaciones);
            command.Parameters.AddWithValue("@Nombre", pProducto.Nombre);
            command.Parameters.AddWithValue("@Foto", pProducto.Foto);
            command.Parameters.AddWithValue("@PrecioColones", pProducto.PrecioColones);
            command.Parameters.AddWithValue("@PrecioDolares", pProducto.PrecioDolares);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_INSERT_Producto";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                if (row > 0)
                    oModelo = pProducto;
            }

            return oModelo;
        }

        public List<Producto> ObtenerPorFiltro(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public Producto ObtenerPorId(int pId)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Producto oProducto = null;

            command.Parameters.AddWithValue("@IdProducto", pId);

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_SELECT_Producto_ByID";

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                reader = db.ExecuteReader(command);

                if (reader.Read())
                {
                    oProducto = new Producto
                    {
                        IdProducto = int.Parse(reader["IdProducto"].ToString()),
                        CodigoIndustria = reader["CodigoIndustria"].ToString(),
                        IdTipoDispositivo = int.Parse(reader["IdTipoDispositivo"].ToString()),
                        IdModelo = int.Parse(reader["IdModelo"].ToString()),
                        IdMarca = int.Parse(reader["IdMarca"].ToString()),
                        Color = reader["Color"].ToString(),
                        Caracteristicas = reader["Caracteristicas"].ToString(),
                        Extras = reader["Extras"].ToString(),
                        CantidadStock = int.Parse(reader["CantidadStock"].ToString()),
                        Estado = bool.Parse(reader["Estado"].ToString()),
                        DocumentoEspecificaciones = (byte[])reader["DocumentoEspecificaciones"],
                        Nombre = reader["Nombre"].ToString(),
                        Foto = (byte[])reader["Foto"],
                        PrecioColones = Convert.ToDecimal(reader["PrecioColones"]),
                        PrecioDolares = Convert.ToDecimal(reader["PrecioDolares"])
                    };
                }
            }

            return oProducto;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodos()
        {
            IList<Producto> lista = new List<Producto>();

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "usp_SELECT_Producto_All";

                try
                {
                    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                    {
                        using (IDataReader reader = db.ExecuteReader(command))
                        {
                            while (reader.Read())
                            {
                                Producto oProducto = new Producto
                                {
                                    IdProducto = int.Parse(reader["IdProducto"].ToString()),
                                    CodigoIndustria = reader["CodigoIndustria"].ToString(),
                                    IdTipoDispositivo = int.Parse(reader["IdTipoDispositivo"].ToString()),
                                    IdModelo = int.Parse(reader["IdModelo"].ToString()),
                                    IdMarca = int.Parse(reader["IdMarca"].ToString()),
                                    Color = reader["Color"].ToString(),
                                    Caracteristicas = reader["Caracteristicas"].ToString(),
                                    Extras = reader["Extras"].ToString(),
                                    CantidadStock = int.Parse(reader["CantidadStock"].ToString()),
                                    Estado = bool.Parse(reader["Estado"].ToString()),
                                    DocumentoEspecificaciones = (byte[])reader["DocumentoEspecificaciones"],
                                    Nombre = reader["Nombre"].ToString(),
                                    Foto = (byte[])reader["Foto"],
                                    PrecioColones = Convert.ToDecimal(reader["PrecioColones"]),
                                    PrecioDolares = Convert.ToDecimal(reader["PrecioDolares"])
                                };
                                lista.Add(oProducto);
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
