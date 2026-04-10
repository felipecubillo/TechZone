using AppProyectoFelipe.Layers.DAL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using AppProyectoFelipe.Layers.Entities.DTO;



namespace AppProyectoFelipe.Layers.BLL
{
    class BLLProvincia : IBLLProvincia
    {
        private readonly string _urlProvincias;

        public BLLProvincia()
        {
            // Leer del App.Config las URLs para las APIs
            _urlProvincias = ConfigurationManager.AppSettings["URLProvincia"];

        }

        public async Task<List<UbicacionDTO.Provincia>> ObtenerProvinciasAsync()
        {
            return await ObtenerDatosDeApi<List<UbicacionDTO.Provincia>>(_urlProvincias);
        }

        private async Task<T> ObtenerDatosDeApi<T>(string url)
        {
            string json = "";

            // Crear una solicitud GET para obtener los datos
            WebRequest solicitud = WebRequest.Create(url);
            // Método GET
            solicitud.Method = "GET";

            using (WebResponse respuestaWeb = await solicitud.GetResponseAsync())
            {
                // Leer datos
                using (StreamReader lector = new StreamReader(respuestaWeb.GetResponseStream()))
                {
                    json = await lector.ReadToEndAsync();
                }
            }

            // Deserializar JSON usando Newtonsoft.Json
            T resultado = JsonConvert.DeserializeObject<T>(json);

            return resultado;
        }
    }
}
