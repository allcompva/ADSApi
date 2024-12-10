using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public interface IFavoritosService
    {
        public void insert(int id_publicacion, string mail);
        public void delete(int id_publicacion, string mail);
        public List<Tur_publicaciones> GetByMail(string mail);
    }
}
