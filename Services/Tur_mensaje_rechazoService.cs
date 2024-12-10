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
    public class Tur_mensaje_rechazoService : ITur_mensaje_rechazoService
    {
        public tur_mensaje_rechazo getByPk(int id)
        {
            try
            {
                return tur_mensaje_rechazo.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tur_mensaje_rechazo> read()
        {
            try
            {
                return tur_mensaje_rechazo.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(tur_mensaje_rechazo obj)
        {
            try
            {
                return tur_mensaje_rechazo.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(tur_mensaje_rechazo obj)
        {
            try
            {
                tur_mensaje_rechazo.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(tur_mensaje_rechazo obj)
        {
            try
            {
                tur_mensaje_rechazo.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

