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
    public class Tur_publicacionesService : ITur_publicacionesService
    {
        public Tur_publicaciones getByPk(string cuit)
        {
            try
            {
                return Tur_publicaciones.getByPk(cuit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_publicaciones> GetByCategoriaMail(int id, string mail)
        {
            try
            {
                return Entities.Tur_publicaciones.GetByCategoriaMail(id, mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Models.Details getByDetails(string cuit, string mail)
        {
            try
            {
                Tur_publicaciones obj = Tur_publicaciones.getByDetails(cuit, mail);
                Models.Details objD = null;
                if (obj != null)
                {
                    objD = new Models.Details();
                    objD.cuit = obj.id_comercio;
                    objD.descripcion = obj.descripcion;
                    objD.direccion = obj.ubicacion;
                    objD.images = obj.fotos;
                    objD.maps = obj.georeferencia;
                    objD.titulo = obj.nombre;
                    objD.whatsapp = obj.whatsapp;
                }
                return objD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_publicaciones> GetByCategoria(int id)
        {
            try
            {
                return Tur_publicaciones.GetByCategoria(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Models.Details getDetails(string cuit)
        {
            try
            {
                Tur_publicaciones obj = Tur_publicaciones.getByPk(cuit);
                Models.Details objD = null;
                if (obj != null)
                {
                    objD = new Models.Details();
                    objD.cuit = obj.id_comercio;
                    objD.descripcion = obj.descripcion;
                    objD.direccion = obj.ubicacion;
                    objD.images = obj.fotos;
                    objD.maps = obj.georeferencia;
                    objD.titulo = obj.nombre;
                    objD.whatsapp = obj.whatsapp;
                }
                return objD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_publicaciones> read()
        {
            try
            {
                return Tur_publicaciones.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tur_publicaciones obj)
        {
            try
            {
                return Tur_publicaciones.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tur_publicaciones obj)
        {
            try
            {
                Tur_publicaciones.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Tur_publicaciones obj)
        {
            try
            {
                Tur_publicaciones.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}