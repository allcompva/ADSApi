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
    public class Tur_movimientos_comercioService : ITur_movimientos_comercioService
    {
        public Tur_movimientos_comercio getByPk(int id)
        {
            try
            {
                return Tur_movimientos_comercio.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_movimientos_comercio> read()
        {
            try
            {
                return Tur_movimientos_comercio.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tur_movimientos_comercio obj)
        {
            try
            {
                return Tur_movimientos_comercio.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tur_movimientos_comercio obj)
        {
            try
            {
                Tur_movimientos_comercio.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Tur_movimientos_comercio obj)
        {
            try
            {
                Tur_movimientos_comercio.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

