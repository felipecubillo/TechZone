using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Entities
{
     class Usuario
    {
        public int IdUsuario {  get; set; }

        public int IdPerfil { get; set; }

        public string Contrasena { set; get; }

        public string Nombre { set; get; }

        public bool Estado { set; get; }
    }
}
