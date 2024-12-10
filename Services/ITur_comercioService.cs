using ADSWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSWebApi.Services
{
    public interface ITur_comercioService
    {
        public List<Tur_comercio> read(int idCate);
        public List<Tur_comercio> readAll(int idCate);
        public Tur_comercio getByPk(string cuit);
        public Models.Details getDetails(string cuit);
        public int insert(Tur_comercio obj);
        public void update(Tur_comercio obj);
        public void delete(string cuit);
        public void CambioEstado(string cuit, string estado);
    }
}

