using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.DAL
{
    class DALMarca : IDALMarca
    {
        public Task<Marca> Actualizar(Marca pMarca)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int pId)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Guardar(Marca pMarca)
        {
            throw new NotImplementedException();
        }

        public List<Marca> ObtenerPorFiltro(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public Marca ObtenerPorId(int pId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Marca>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
