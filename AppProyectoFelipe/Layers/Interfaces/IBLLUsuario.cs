using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IBLLUsuario
    {
        Usuario IdUsuario(string pIdUsuario, string pContrasena);
        IEnumerable<Usuario> ObtenerTodos();
        Usuario Guardar(Usuario pUsuario);
        Usuario ObtenerPorId(string pIdUsuario);
        bool Borrar(string pIdUsuario);
    }
}
