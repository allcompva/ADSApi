using ADSWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSWebApi.Services
{
    public interface ITur_usuarioService
    {
       
        // public Tur_usuario login(string email, string password);
        public int registro(string email, string password);
        public Tur_usuario getByEmail(string email);
       
    }
}

