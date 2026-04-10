using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
    interface IDALPerfil
    {
        List<Perfil> ObtenerTodos();

    }
}
