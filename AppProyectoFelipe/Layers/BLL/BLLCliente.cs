using AppProyectoFelipe.Layers.DAL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.BLL
{
    class BLLCliente : IBLLCliente
    {
        public Task<bool> Eliminar(string pId)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.Eliminar(pId);
        }

        public Task<Cliente> Guardar(Cliente pCliente)
        {
            IDALCliente dalCliente = new DALCliente();
            Task<Cliente> oCliente = null;

            if (dalCliente.ObtenerPorId(pCliente.Identificacion) == null)
                oCliente = dalCliente.Guardar(pCliente);
            else
                oCliente = dalCliente.Actualizar(pCliente);

            return oCliente;
        }

        public List<Cliente> ObtenerPorFiltro(string pDescripcion)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.ObtenerPorFiltro(pDescripcion);
        }

        public Cliente ObtenerPorId(string pId)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.ObtenerPorId(pId);
        }

        public Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.ObtenerTodos();
        }
    }
}
