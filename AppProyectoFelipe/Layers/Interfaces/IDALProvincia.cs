using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IDALProvincia
    {
        Provincia ObtenerPorId(int pId);
        Task<IEnumerable<Provincia>> ObtenerTodos();
        Task<Provincia> Guardar(Provincia pProvincia);
        Task<Provincia> Actualizar(Provincia pProvincia);
        Task<bool> Eliminar(int pId);


    }
}
