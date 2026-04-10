using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IBLLProvincia
    {
        Task<List<UbicacionDTO.Provincia>> ObtenerProvinciasAsync();
    }
}
