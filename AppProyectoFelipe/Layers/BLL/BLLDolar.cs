using AppProyectoFelipe.Layers.Entities.BCCR;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.BLL
{
    class BLLDolar : IBLLDolar
    {
        public double GetVentaDolar()
        {
            double tipoCambioVenta = 1;
            ServicesBCCR services = new ServicesBCCR();
            List<Dolar> cambioDolar = services.GetDolar(DateTime.Today, DateTime.Today, "v").ToList();
            if (cambioDolar != null)
            {
                tipoCambioVenta = cambioDolar[0].Monto;
            }

            return tipoCambioVenta;
        }
    }
}
