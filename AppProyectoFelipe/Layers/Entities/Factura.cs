using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.Entities
{
     class Factura
    {
        public int IdFactura { get; set; }

        public int IdCliente { get; set; }

        public string IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TotalCRC { get; set; }

        public decimal TotalUSD { get; set; }

        public decimal TipoCambio { get; set; }

        public string TipoPago { get; set; }

        public string Documento { get; set; }

        public string Banco { get; set; }

        public string TipoTarjeta { get; set; }

        public byte[] FirmaCliente { get; set; }

        public byte[] DocumentoXML { get; set; }

        public bool Estado { get; set; }

        //Relacion
        public List<FacturaDetalle> ListaDetalle { get; set; } = new List<FacturaDetalle>();

    }
}
