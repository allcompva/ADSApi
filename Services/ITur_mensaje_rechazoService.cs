using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSWebApi.Entities;
namespace ADSWebApi.Services
{
    public interface ITur_mensaje_rechazoService
    {
        public List<tur_mensaje_rechazo> read();
        public tur_mensaje_rechazo getByPk(int id);
        public int insert(tur_mensaje_rechazo obj);
        public void update(tur_mensaje_rechazo obj);
        public void delete(tur_mensaje_rechazo obj);
    }
}

