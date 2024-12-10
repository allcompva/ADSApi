using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public class Tur_videos_educativosService : ITur_videos_educativosService
    {
        public Tur_videos_educativos getByPk(int id)
        {
            try
            {
                return Tur_videos_educativos.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_videos_educativos> read()
        {
            try
            {
                return Tur_videos_educativos.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tur_videos_educativos obj)
        {
            try
            {
                return Tur_videos_educativos.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tur_videos_educativos obj)
        {
            try
            {
                Tur_videos_educativos.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Tur_videos_educativos obj)
        {
            try
            {
                Tur_videos_educativos.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

