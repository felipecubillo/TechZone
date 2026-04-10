using AppProyectoFelipe.Layers.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IBLLPadron
    {
        PadronDTO GetById(string pId);

    }
}
