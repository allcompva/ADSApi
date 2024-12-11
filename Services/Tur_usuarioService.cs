using ADSWebApi.Entities;

namespace ADSWebApi.Services
{
    public class Tur_usuarioService : ITur_usuarioService
    {
        // public Tur_usuario login(string email, string password)
        // {
        //     try
        //     {
        //         return Tur_comercio.login(email, password);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }

        public int registro(string email, string password)
        {
            try
            {
                //TODO: encriptar password
                return Tur_usuario.registro(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public Tur_usuario getByEmail(string email)
        {
            try
            {
                return Tur_usuario.getByEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

