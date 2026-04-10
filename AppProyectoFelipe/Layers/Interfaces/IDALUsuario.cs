using AppProyectoFelipe.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Interfaces
{
     interface IDALUsuario
    {
        Usuario IdUsuario(int pIdUsuario, string pContrasena);
        IEnumerable<Usuario> ObtenerTodos();
        Usuario Guardar(Usuario pUsuario);
        Usuario Actualizar(Usuario pUsuario);
        Usuario ObtenerPorId(int pIdUsuario);
        bool Borrar(int pIdUsuario);
    }
}
