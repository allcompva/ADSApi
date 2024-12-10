using ADSWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ADSWebApi.Services
{
    public interface ITur_notificacionesService
    {
        public List<Tur_notificaciones> read();
        public Tur_notificaciones getByPk(int id);
        public int insert(Tur_notificaciones obj);
        public void update(Tur_notificaciones obj);
        public void delete(Tur_notificaciones obj);
    }
}

