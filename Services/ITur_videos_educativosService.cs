using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public interface ITur_videos_educativosService
    {
        public List<Tur_videos_educativos> read();
        public Tur_videos_educativos getByPk(int id);
        public int insert(Tur_videos_educativos obj);
        public void update(Tur_videos_educativos obj);
        public void delete(Tur_videos_educativos obj);
    }
}

