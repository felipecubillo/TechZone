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
    class BLLMarca : IBLLMarca
    {
        public Task<bool> Eliminar(int pId)
        {
            IDALMarca dalMarca = new DALMarca();
            return dalMarca.Eliminar(pId);
        }

        public Task<Marca> Guardar(Marca pMarca)
        {
            IDALMarca dalMarca = new DALMarca();
            Task<Marca> oMarca = null;

            if (dalMarca.ObtenerPorId(pMarca.IdMarca) == null)
                oMarca = dalMarca.Guardar(pMarca);
            else
                oMarca = dalMarca.Actualizar(pMarca);

            return oMarca;
        }

        public List<Marca> ObtenerPorFiltro(string pDescripcion)
        {
            IDALMarca dalMarca = new DALMarca();
            return dalMarca.ObtenerPorFiltro(pDescripcion);
        }

        public Marca ObtenerPorId(int pId)
        {
            IDALMarca dalMarca = new DALMarca();
            return dalMarca.ObtenerPorId(pId);
        }

        public Task<IEnumerable<Marca>> ObtenerTodos()
        {
            IDALMarca dalMarca = new DALMarca();
            return dalMarca.ObtenerTodos();
        }
    }
}
