using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Entities
{
     class Cliente
    {
        public int IdCliente { get; set; }

        public int IdTipoIdentificacion { get; set; }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string DireccionExacta { get; set; }

        public string Provincia { get; set; }

        public byte[] Fotografia { get; set; }

        public bool Estado { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellidos;
        }
    }
}
