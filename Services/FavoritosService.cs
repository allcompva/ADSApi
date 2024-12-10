using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public class FavoritosService : IFavoritosService
    {
        public void insert(int id_publicacion, string mail)
        {
            try
            {
                bool opcion = Tur_favoritos.getByPk(id_publicacion, mail);
                if (opcion)
                {
                    Entities.Tur_favoritos.delete(id_publicacion, mail);
                }
                else
                {
                    Entities.Tur_favoritos.insert(id_publicacion, mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int id_publicacion, string mail)
        {
            try
            {
                Entities.Tur_favoritos.delete(id_publicacion, mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Tur_publicaciones> GetByMail(string mail)
        {
            try
            {
                return Entities.Tur_publicaciones.GetByMail(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
