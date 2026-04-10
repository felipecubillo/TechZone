using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IDALCliente
    {
        List<Cliente> ObtenerPorFiltro(string pDescripcion);
        Cliente ObtenerPorId(string pId);
        Task<IEnumerable<Cliente>> ObtenerTodos();
        Task<Cliente> Guardar(Cliente pCliente);
        Task<Cliente> Actualizar(Cliente pCliente);
        Task<bool> Eliminar(string pId);
    }
}
