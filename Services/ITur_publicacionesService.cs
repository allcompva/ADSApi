using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public interface ITur_publicacionesService
    {
        public List<Tur_publicaciones> read();
        public Tur_publicaciones getByPk(string cuit);
        public Models.Details getByDetails(string cuit, string mail);

        public List<Tur_publicaciones> GetByCategoria(int id);
        public List<Tur_publicaciones> GetByCategoriaMail(int id, string mail);
        public int insert(Tur_publicaciones obj);
        public void update(Tur_publicaciones obj);
        public void delete(Tur_publicaciones obj);
    }
}

