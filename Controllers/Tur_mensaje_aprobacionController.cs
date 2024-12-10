using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using ADSWebApi.Services;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_mensaje_aprobacionController : Controller
    {
        private ITur_mensaje_aprobacionService _Tur_mensaje_aprobacionService;
        public Tur_mensaje_aprobacionController(ITur_mensaje_aprobacionService Tur_mensaje_aprobacionService)
        {
            _Tur_mensaje_aprobacionService = Tur_mensaje_aprobacionService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Tur_mensaje_aprobacion = _Tur_mensaje_aprobacionService.getByPk(id);
            if (Tur_mensaje_aprobacion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_mensaje_aprobacion);
        }







    }
}

