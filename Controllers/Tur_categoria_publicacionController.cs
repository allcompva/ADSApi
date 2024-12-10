using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ADSWebApi.Services;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_categoria_publicacionController : Controller
    {
        private ITur_categoria_publicacionService _Tur_categoria_publicacionService;
        public Tur_categoria_publicacionController(ITur_categoria_publicacionService Tur_categoria_publicacionService)
        {
            _Tur_categoria_publicacionService = Tur_categoria_publicacionService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Tur_categoria_publicacion = _Tur_categoria_publicacionService.getByPk(id);
            if (Tur_categoria_publicacion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_categoria_publicacion);
        }
        [HttpGet]
        public IActionResult read()
        {
            var Tur_categoria_publicacion = _Tur_categoria_publicacionService.read();
            if (Tur_categoria_publicacion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_categoria_publicacion);
        }
    }
}