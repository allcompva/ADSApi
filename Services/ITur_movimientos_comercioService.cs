using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public interface ITur_movimientos_comercioService
    {
        public List<Tur_movimientos_comercio> read();
        public Tur_movimientos_comercio getByPk(int id);
        public int insert(Tur_movimientos_comercio obj);
        public void update(Tur_movimientos_comercio obj);
        public void delete(Tur_movimientos_comercio obj);
    }
}

