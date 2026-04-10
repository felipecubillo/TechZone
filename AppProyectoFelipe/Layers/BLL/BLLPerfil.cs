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
    class BLLPerfil : IBLLPerfil
    {
        public List<Perfil> ObtenerTodos()
        {
            IDALPerfil dalPerfil = new DALPerfil();
            return dalPerfil.ObtenerTodos();
        }
    }
}
