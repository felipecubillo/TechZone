using AppProyectoFelipe.Layers.DAL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.BLL
{
    class BLLFactura : IBLLFactura
    {
        public Factura Guardar(Factura pFactura)
        {
            IDALFactura dalFactura = new DALFactura();
            IBLLElectronico bllElectronico = new BLLElectronico();

            // Vuelve a validar que exista en inventario
            foreach (FacturaDetalle oFacturaDetalle in pFactura.ListaDetalle)
            {
                bllElectronico.AvabilityStock(oFacturaDetalle.IdElectronico, oFacturaDetalle.Cantidad);
            }


            return dalFactura.Guardar(pFactura);
        }
    }
}
