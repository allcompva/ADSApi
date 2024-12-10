using ADSWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ADSWebApi.Services
{
    public interface ITur_categoria_publicacionService
    {
        public List<tur_categoria_publicacion> read();
        public tur_categoria_publicacion getByPk(int id);
        public int insert(tur_categoria_publicacion obj);
        public void update(tur_categoria_publicacion obj);
        public void delete(int id);
    }
}

