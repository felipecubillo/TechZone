using AppProyectoFelipe.Layers.Entities.DTO;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.BLL
{
    class BLLPadron : IBLLPadron
    {
        public PadronDTO GetById(string pId)
        {
            string json = "";

            // Leer del App.Config el URL con el Key URLPadron
            string URLPadron = ConfigurationManager.AppSettings["URLPadron"];

            // Concatenar el Id al URL
            string url = URLPadron + pId;


            // Creates a GET request to fetch  
            WebRequest request = WebRequest.Create(url);
            // Verb GET
            request.Method = "GET";


            // GetResponse returns a web response containing the response to the request
            using (WebResponse webResponse = request.GetResponse())
            {
                // Reading data
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                json = reader.ReadToEnd();
            }


            PadronDTO oPadronDTO = JsonSerializer.Deserialize<PadronDTO>(json);

            return oPadronDTO;
        }
    }
}
