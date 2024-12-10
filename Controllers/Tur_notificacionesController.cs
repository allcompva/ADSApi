using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ADSWebApi.Services;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_notificacionesController : Controller
    {
        private ITur_notificacionesService _Tur_notificacionesService;
        public Tur_notificacionesController(ITur_notificacionesService Tur_notificacionesService)
        {
            _Tur_notificacionesService = Tur_notificacionesService;
        }
        [HttpGet]
        public IActionResult getByPk(int id)
        {
            var Tur_notificaciones = _Tur_notificacionesService.getByPk(id);
            if (Tur_notificaciones == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_notificaciones);
        }
    }
}