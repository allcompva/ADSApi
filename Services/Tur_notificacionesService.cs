using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ADSWebApi.Entities;
using Microsoft.Extensions.Options;

namespace ADSWebApi.Services
{
    public class Tur_notificacionesService : ITur_notificacionesService
    {
        public Tur_notificaciones getByPk(int id)
        {
            try
            {
                return Tur_notificaciones.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_notificaciones> read()
        {
            try
            {
                return Tur_notificaciones.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tur_notificaciones obj)
        {
            try
            {
                return Tur_notificaciones.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tur_notificaciones obj)
        {
            try
            {
                Tur_notificaciones.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Tur_notificaciones obj)
        {
            try
            {
                Tur_notificaciones.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

