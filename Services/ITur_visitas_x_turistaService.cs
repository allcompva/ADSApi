using ADSWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ADSWebApi.Services
{
    public interface ITur_visitas_x_turistaService
    {
        public List<Tur_visitas_x_turista> read();
        public Tur_visitas_x_turista getByPk(string mail);
        public void insert(Tur_visitas_x_turista obj);
        public void delete(int id);
        public void setVigenciaMasiva(bool vigencia);
        public bool isFormComplete(string mail);
        public void setVigencia(int idForm, string mail, bool vigencia);
    }
}

