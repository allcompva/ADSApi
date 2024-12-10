using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public class Tur_categoria_publicacionService : ITur_categoria_publicacionService
    {
        public tur_categoria_publicacion getByPk(int id)
        {
            try
            {
                return tur_categoria_publicacion.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tur_categoria_publicacion> read()
        {
            try
            {
                return tur_categoria_publicacion.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(tur_categoria_publicacion obj)
        {
            try
            {
                return tur_categoria_publicacion.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(tur_categoria_publicacion obj)
        {
            try
            {
                tur_categoria_publicacion.update(obj);
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
                tur_categoria_publicacion.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


