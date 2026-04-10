using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.DAL
{
    class DALCliente : IDALCliente
    {
        public Task<Cliente> Actualizar(Cliente pCliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(string pId)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Guardar(Cliente pCliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerPorFiltro(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public Cliente ObtenerPorId(string pId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
