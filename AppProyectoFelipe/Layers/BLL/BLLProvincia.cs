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



namespace AppProyectoFelipe.Layers.BLL
{
    class BLLProvincia : IBLLProvincia
    {
        public Task<bool> Eliminar(int pId)
        {
            IDALProvincia dalProvincia = new DALProvincia();
            return dalProvincia.Eliminar(pId);
        }

        public Task<Provincia> Guardar(Provincia pProvincia)
        {
            IDALProvincia dalProvincia = new DALProvincia();
            Task<Provincia> oProvincia = null;

            if (dalProvincia.ObtenerPorId(pProvincia.IdProvincia) == null)
                oProvincia = dalProvincia.Guardar(pProvincia);
            else
                oProvincia = dalProvincia.Actualizar(pProvincia);

            return oProvincia;
        }

        public Provincia ObtenerPorId(int pId)
        {
            IDALProvincia dalProvincia = new DALProvincia();
            return dalProvincia.ObtenerPorId(pId);
        }

        public Provincia ObtenerProvinviaInternet(int pId)
        {
            Provincia provincia = null;
            string json = "";

            // Leer del App.Config el URL con el Key URLPadron
            string url = ConfigurationManager.AppSettings["URLProvincia"];


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

            // Todas las provincias
            List<Provincia> lista = System.Text.Json.JsonSerializer.Deserialize<List<Provincia>>(json);

            provincia = lista.Find(p => p.IdProvincia == pId);

            return provincia;
        }

        public Task<IEnumerable<Provincia>> ObtenerTodos()
        {
            IDALProvincia dalProvincia = new DALProvincia();
            return dalProvincia.ObtenerTodos();
        }
    }
}
