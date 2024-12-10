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
    public class Tur_mensaje_aprobacionService : ITur_mensaje_aprobacionService
    {
        public tur_mensaje_aprobacion getByPk(int id)
        {
            try
            {
                return tur_mensaje_aprobacion.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tur_mensaje_aprobacion> read()
        {
            try
            {
                return tur_mensaje_aprobacion.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(tur_mensaje_aprobacion obj)
        {
            try
            {
                return tur_mensaje_aprobacion.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(tur_mensaje_aprobacion obj)
        {
            try
            {
                tur_mensaje_aprobacion.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int id)
        {
            try
            {
                tur_mensaje_aprobacion.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

