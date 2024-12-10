using ADSWebApi.Entities;
using ADSWebApi.Services;
using ADSWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FavoritosController : Controller
    {
        private IFavoritosService _FavoritosService;
        public FavoritosController(IFavoritosService FavoritosService)
        {
            _FavoritosService = FavoritosService;
        }

        [HttpPost]
        public IActionResult insert([FromBody] Entities.Tur_favoritos formData)
        {
            if (formData == null)
            {
                return BadRequest("Los datos del formulario son inválidos.");
            }

            Tur_favoritos obj = new Tur_favoritos();
            string mail = formData.mail;
            int id_publicacion = formData.id_publicacion;

            _FavoritosService.insert(id_publicacion, mail);

            return Ok();
           
        }
        [HttpPost]
        public IActionResult delete([FromBody] Entities.Tur_favoritos formData)
        {
            if (formData == null)
            {
                return BadRequest("Los datos del formulario son inválidos.");
            }

            Tur_favoritos obj = new Tur_favoritos();
            string mail = formData.mail;
            int id_publicacion = formData.id_publicacion;

            _FavoritosService.delete(id_publicacion, mail);

            return Ok();

        }

        [HttpGet]
        public IActionResult GetByMail(string mail)
        {
            var Tur_publicaciones = _FavoritosService.GetByMail(mail);
            if (Tur_publicaciones == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_publicaciones);
        }
    }
}
