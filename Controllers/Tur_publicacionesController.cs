using ADSWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_publicacionesController : Controller
    {
        private ITur_publicacionesService _Tur_publicacionesService;
        public Tur_publicacionesController(ITur_publicacionesService Tur_publicacionesService)
        {
            _Tur_publicacionesService = Tur_publicacionesService;
        }
        [HttpGet]
        public IActionResult getByPk(string cuit)
        {
            var Tur_publicaciones = _Tur_publicacionesService.getByPk(cuit);
            if (Tur_publicaciones == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_publicaciones);
        }
        [HttpGet]
        public IActionResult GetByCategoria(int id)
        {
            var Tur_publicaciones = _Tur_publicacionesService.GetByCategoria(id);
            if (Tur_publicaciones == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_publicaciones);
        }
        [HttpGet]
        public IActionResult GetByCategoriaMail(int id, string mail)
        {
            var Tur_publicaciones = _Tur_publicacionesService.GetByCategoriaMail(id, mail);
            if (Tur_publicaciones == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_publicaciones);
        }

        [HttpGet]
        public IActionResult getDetails(string cuit, string mail)
        {
            var Tur_comercio = _Tur_publicacionesService.getByDetails(cuit, mail);
            if (Tur_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_comercio);
        }
    }
}

