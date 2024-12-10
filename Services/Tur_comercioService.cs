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
    public class Tur_comercioService : ITur_comercioService
    {
        public Tur_comercio getByPk(string cuit)
        {
            try
            {
                return Tur_comercio.getByPk(cuit);
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
                Tur_comercio obj = Tur_comercio.getByPk(cuit);
                Models.Details objD = null;
                if (obj != null)
                {
                    objD = new Models.Details();
                    objD.cuit = obj.cuit.ToString();
                    objD.descripcion = obj.descripcion;
                    objD.direccion = obj.direccion;
                    objD.images = obj.images;
                    objD.maps = obj.codigo_insercion_maps;
                    objD.titulo = obj.nombre_fantacia;
                    objD.whatsapp = obj.whatsapp;
                }
                return objD;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_comercio> read(int idCate)
        {
            try
            {
                return Tur_comercio.read(idCate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_comercio> readAll(int idCate)
        {
            try
            {
                return Tur_comercio.readAll(idCate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Tur_comercio obj)
        {
            try
            {
                return Tur_comercio.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Tur_comercio obj)
        {
            try
            {
                Tur_comercio.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(string cuit)
        {
            try
            {
                Tur_comercio.delete(cuit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CambioEstado(string cuit, string estado)
        {
            try
            {
                Tur_comercio objCom = Tur_comercio.getByPk(cuit);
                Tur_publicaciones.deleteComercio(cuit);

                if (estado == "Aprobado")
                {
                    Tur_publicaciones.deleteComercio(cuit);
                    Tur_publicaciones objPub = new Tur_publicaciones();
                    objPub.publicada = true;

                    objPub.descripcion = objCom.descripcion;
                    objPub.georeferencia = objCom.codigo_insercion_maps;
                    objPub.id_categoria = objCom.id_categoria;
                    objPub.id_comercio = objCom.cuit;
                    objPub.img = objCom.images;
                    objPub.nombre = objCom.nombre_fantacia;
                    objPub.resenia = objCom.descripcion;
                    objPub.ubicacion = objCom.direccion;
                    objPub.whatsapp = objCom.whatsapp;
                    objPub.fotos = objCom.images;  
                    Tur_publicaciones.insert(objPub);
                }
                Entities.Tur_comercio.CambioEstado(cuit, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

