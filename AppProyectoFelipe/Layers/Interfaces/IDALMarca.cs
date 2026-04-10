using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IDALMarca
    {
        List<Marca> ObtenerPorFiltro(string pDescripcion);
        Marca ObtenerPorId(int pId);
        Task<IEnumerable<Marca>> ObtenerTodos();
        Task<Marca> Guardar(Marca pMarca);
        Task<Marca> Actualizar(Marca pMarca);
        Task<bool> Eliminar(int pId);
    }
}
