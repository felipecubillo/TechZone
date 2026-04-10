using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IBLLModelo
    {
        List<Modelo> ObtenerPorFiltro(string pDescripcion);
        Modelo ObtenerPorId(int pId);
        Task<IEnumerable<Modelo>> ObtenerTodos();
        Task<Modelo> Guardar(Modelo pModelo);
        Task<bool> Eliminar(int pId);
    }
}
