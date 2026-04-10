using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.DAL
{
    class DALProvincia : IDALProvincia
    {
        public Task<Provincia> Actualizar(Provincia pProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int pId)
        {
            throw new NotImplementedException();
        }

        public Task<Provincia> Guardar(Provincia pProvincia)
        {
            throw new NotImplementedException();
        }

        public Provincia ObtenerPorId(int pId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Provincia>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
