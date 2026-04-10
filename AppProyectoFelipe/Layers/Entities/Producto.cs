using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Entities
{
     class Producto
    {
        public int IdProducto { get; set; }

        public string CodigoIndustria { get; set; }

        public int IdTipoDispositivo { get; set; }

        public int IdModelo { get; set; }

        public int IdMarca { get; set; }

        public string Color { get; set; }

        public string Caracteristicas { get; set; }

        public string Extras { get; set; }

        public int CantidadStock { get; set; }

        public bool Estado { get; set; }

        public byte[] DocumentoEspecificaciones { get; set; }

        public string Nombre { get; set; }

        public byte[] Foto { get; set; }

        public decimal PrecioColones { get; set; }

        public decimal PrecioDolares { get; set; }

    }
}
