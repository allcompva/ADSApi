using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using ADSWebApi.Services;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_movimientos_comercioController : Controller
    {
        private ITur_movimientos_comercioService _Tur_movimientos_comercioService;
        public Tur_movimientos_comercioController(ITur_movimientos_comercioService Tur_movimientos_comercioService)
        {
            _Tur_movimientos_comercioService = Tur_movimientos_comercioService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Tur_movimientos_comercio = _Tur_movimientos_comercioService.getByPk(id);
            if (Tur_movimientos_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_movimientos_comercio);
        }







    }
}

