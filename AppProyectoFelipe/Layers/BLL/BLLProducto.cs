using AppProyectoFelipe.Layers.DAL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.BLL
{
    class BLLProducto : IBLLProducto
    {
        public Task<bool> Eliminar(int pId)
        {
            IDALProducto dalProducto = new DALProducto();
            return dalProducto.Eliminar(pId);
        }

        public Task<Producto> Guardar(Producto pProducto)
        {
            IDALProducto dalProducto = new DALProducto();
            Task<Producto> oProducto = null;

            if (dalProducto.ObtenerPorId(pProducto.IdProducto) == null)
                oProducto = dalProducto.Guardar(pProducto);
            else
                oProducto = dalProducto.Actualizar(pProducto);

            return oProducto;
        }

        public List<Producto> ObtenerPorFiltro(string pDescripcion)
        {
            IDALProducto dalProducto = new DALProducto();
            return dalProducto.ObtenerPorFiltro(pDescripcion);
        }

        public Producto ObtenerPorId(int pId)
        {
            IDALProducto dalProducto = new DALProducto();
            return dalProducto.ObtenerPorId(pId);
        }

        public Task<IEnumerable<Producto>> ObtenerTodos()
        {
            IDALProducto dalProducto = new DALProducto();
            return dalProducto.ObtenerTodos();
        }
    }
}
