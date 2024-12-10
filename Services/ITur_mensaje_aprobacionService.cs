using ADSWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSWebApi.Services
{
    public interface ITur_mensaje_aprobacionService
    {
        public List<tur_mensaje_aprobacion> read();
        public tur_mensaje_aprobacion getByPk(int id);
        public int insert(tur_mensaje_aprobacion obj);
        public void update(tur_mensaje_aprobacion obj);
        public void delete(int id);
    }
}

