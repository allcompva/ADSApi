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
    public class Tur_visitas_x_turistaService : ITur_visitas_x_turistaService
    {
        public void setVigenciaMasiva(bool vigencia)
        {
            try
            {
                Entities.Tur_visitas_x_turista.setVigenciaMasiva(vigencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool isFormComplete(string mail)
        {
            try
            {
                return Entities.Tur_visitas_x_turista.IsFormComplete(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setVigencia(int idForm, string mail, bool vigencia)
        {
            try
            {
                Entities.Tur_visitas_x_turista.setVigencia(idForm, mail, vigencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tur_visitas_x_turista getByPk(string mail)
        {
            try
            {
                return Tur_visitas_x_turista.getByPk(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_visitas_x_turista> read()
        {
            try
            {
                return Tur_visitas_x_turista.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insert(Tur_visitas_x_turista obj)
        {
            try
            {
                Tur_visitas_x_turista.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tur_visitas_x_turista obj)
        {
            try
            {
                Tur_visitas_x_turista.update(obj);
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
                Tur_visitas_x_turista.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

