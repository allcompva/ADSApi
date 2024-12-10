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
    public class Tur_turistaService : ITur_turistaService
    {
        public Tur_turista getByPk(string mail)
        {
            try
            {
                return Tur_turista.getByPk(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_turista> read()
        {
            try
            {
                return Tur_turista.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tur_turista obj)
        {
            try
            {
                int id;
                Tur_turista tur_Turista = Entities.Tur_turista.getByPk(obj.mail);
                if (tur_Turista == null)
                {
                    id = Tur_turista.insert(obj);
                }
                else
                {
                    id = tur_Turista.id;
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(string mail)
        {
            try
            {
                Tur_turista.delete(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setNotificaciones(string mail, bool noti)
        {
            try
            {
                Tur_turista.setNotificaciones(mail, noti);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

