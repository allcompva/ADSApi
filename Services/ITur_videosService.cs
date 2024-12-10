using ADSWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ADSWebApi.Services
{
    public interface ITur_videosService
    {
        public List<Tur_videos> read();
        public Tur_videos getByPk(int id);
        public int insert(Tur_videos obj);
        public void update(Tur_videos obj);
        public void delete(Tur_videos obj);
    }
}

