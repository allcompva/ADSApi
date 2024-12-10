using System;
using System.Collections.Generic;
using System.Linq;
using ADSWebApi.Entities;
using System.Threading.Tasks;

namespace ADSWebApi.Services
{
    public interface ITur_turistaService
    {
        public List<Tur_turista> read();
        public Tur_turista getByPk(string mail);
        public int insert(Tur_turista obj);
        public void delete(string mail);
        public void setNotificaciones(string mail, bool noti);
    }
}

