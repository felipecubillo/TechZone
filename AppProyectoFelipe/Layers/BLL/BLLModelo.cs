using AppProyectoFelipe.Layers.DAL;
using AppProyectoFelipe.Layers.Entities;
using AppProyectoFelipe.Layers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppProyectoFelipe.Layers.BLL
{
    class BLLModelo : IBLLModelo
    {
        public Task<bool> Eliminar(int pId)
        {
            IDALModelo dalModelo = new DALModelo();
            return dalModelo.Eliminar(pId);
        }

        public Task<Modelo> Guardar(Modelo pModelo)
        {
            IDALModelo dalModelo = new DALModelo();
            Task<Modelo> oModelo = null;

            if (dalModelo.ObtenerPorId(pModelo.IdModelo) == null)
                oModelo = dalModelo.Guardar(pModelo);
            else
                oModelo = dalModelo.Actualizar(pModelo);

            return oModelo;
        }

        public List<Modelo> ObtenerPorFiltro(string pDescripcion)
        {
            IDALModelo dalModelo = new DALModelo();
            return dalModelo.ObtenerPorFiltro(pDescripcion);
        }


        public Modelo ObtenerPorId(int pId)
        {
            IDALModelo dalModelo = new DALModelo();
            return dalModelo.ObtenerPorId(pId);
        }

        public Task<IEnumerable<Modelo>> ObtenerTodos()
        {
            IDALModelo dalModelo = new DALModelo();
            return dalModelo.ObtenerTodos();
        }
    }
}
