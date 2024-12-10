using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using ADSWebApi.Services;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_videosController : Controller
    {
        private ITur_videosService _Tur_videosService;
        public Tur_videosController(ITur_videosService Tur_videosService)
        {
            _Tur_videosService = Tur_videosService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Tur_videos = _Tur_videosService.getByPk(id);
            if (Tur_videos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_videos);
        }

    }
}