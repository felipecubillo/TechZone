using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IDALProducto
    {
        List<Producto> ObtenerPorFiltro(string pDescripcion);
        Producto ObtenerPorId(int pId);
        Task<IEnumerable<Producto>> ObtenerTodos();
        Task<Producto> Guardar(Producto pProducto);
        Task<Producto> Actualizar(Producto pProducto);
        Task<bool> Eliminar(int pId);
    }
}
