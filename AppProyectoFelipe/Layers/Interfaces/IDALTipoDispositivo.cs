using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IDALTipoDispositivo
    {
        List<TipoDispositivo> ObtenerPorFiltro(string pDescripcion);
        TipoDispositivo ObtenerPorId(int pId);
        Task<IEnumerable<TipoDispositivo>> ObtenerTodos();
        Task<TipoDispositivo> Guardar(TipoDispositivo pTipo);
        Task<TipoDispositivo> Actualizar(TipoDispositivo pTipo);
        Task<bool> Eliminar(int pId);
    }
}
