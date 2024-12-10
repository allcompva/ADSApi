using Microsoft.AspNetCore.Mvc;
using ADSWebApi.Entities;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ADSWebApi.Services;
using ADSWebApi.Models;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_turistaController : Controller
    {
        private ITur_turistaService _Tur_turistaService;
        public Tur_turistaController(ITur_turistaService Tur_turistaService)
        {
            _Tur_turistaService = Tur_turistaService;
        }
        [HttpGet]
        public IActionResult getByPk(string mail)
        {
            var Tur_turista = _Tur_turistaService.getByPk(mail);
            if (Tur_turista == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_turista);
        }
        [HttpPost]
        public IActionResult insert([FromBody] Turista formData)
        {
            if (formData == null)
            {
                return BadRequest("Los datos del formulario son inválidos.");
            }

            Tur_turista obj = new Tur_turista();
            obj.nombre = formData.nombre;
            obj.mail = formData.mail;
           

            int? id = _Tur_turistaService.insert(obj);
            if (id != null)
                return Ok(new { message = "Turista recibido correctamente" });
            else
                return BadRequest("Los datos del formulario son inválidos.");
        }
    }
}

