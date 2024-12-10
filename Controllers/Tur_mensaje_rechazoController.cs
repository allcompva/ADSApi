using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using ADSWebApi.Services;


namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_mensaje_rechazoController : Controller
    {
        private ITur_mensaje_rechazoService _Tur_mensaje_rechazoService;
        public Tur_mensaje_rechazoController(ITur_mensaje_rechazoService Tur_mensaje_rechazoService)
        {
            _Tur_mensaje_rechazoService = Tur_mensaje_rechazoService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Tur_mensaje_rechazo = _Tur_mensaje_rechazoService.getByPk(id);
            if (Tur_mensaje_rechazo == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_mensaje_rechazo);
        }







    }
}

