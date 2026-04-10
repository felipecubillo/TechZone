using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Entities
{
     class Cliente
    {
        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string DireccionExacta { get; set; }

        public int IdProvincia { get; set; }

        public byte[] Fotografia { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellidos;
        }
    }
}
