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
    public class Tur_videosService : ITur_videosService
    {
        public Tur_videos getByPk(int id)
        {
            try
            {
                return Tur_videos.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_videos> read()
        {
            try
            {
                return Tur_videos.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tur_videos obj)
        {
            try
            {
                return Tur_videos.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tur_videos obj)
        {
            try
            {
                Tur_videos.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Tur_videos obj)
        {
            try
            {
                Tur_videos.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

