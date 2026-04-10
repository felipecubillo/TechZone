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
    class BLLTipoDispositivo : IBLLTipoDispositivo
    {
        public Task<bool> Eliminar(int pId)
        {
            IDALTipoDispositivo dalTipo = new DALTipoDispositivo();
            return dalTipo.Eliminar(pId);
        }

        public Task<TipoDispositivo> Guardar(TipoDispositivo pTipo)
        {
            IDALTipoDispositivo dalTipo = new DALTipoDispositivo();
            Task<TipoDispositivo> oTipo = null;

            if (dalTipo.ObtenerPorId(pTipo.IdTipoDispositivo) == null)
                oTipo = dalTipo.Guardar(pTipo);
            else
                oTipo = dalTipo.Actualizar(pTipo);

            return oTipo;
        }

        public List<TipoDispositivo> ObtenerPorFiltro(string pDescripcion)
        {
            IDALTipoDispositivo dalTipo = new DALTipoDispositivo();
            return dalTipo.ObtenerPorFiltro(pDescripcion);
        }

        public TipoDispositivo ObtenerPorId(int pId)
        {
            IDALTipoDispositivo dalTipo = new DALTipoDispositivo();
            return dalTipo.ObtenerPorId(pId);
        }

        public Task<IEnumerable<TipoDispositivo>> ObtenerTodos()
        {
            IDALTipoDispositivo dalTipo = new DALTipoDispositivo();
            return dalTipo.ObtenerTodos();
        }
    }
}
