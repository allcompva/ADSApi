using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using ADSWebApi.Services;
using Microsoft.SqlServer.Server;
using ADSWebApi.Models;
using ADSWebApi.Entities;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_visitas_x_turistaController : Controller
    {
        private ITur_visitas_x_turistaService _Tur_visitas_x_turistaService;
        public Tur_visitas_x_turistaController(ITur_visitas_x_turistaService Tur_visitas_x_turistaService)
        {
            _Tur_visitas_x_turistaService = Tur_visitas_x_turistaService;
        }
        [HttpGet]
        public IActionResult getByPk(string mail)
        {
            var Tur_visitas_x_turista = _Tur_visitas_x_turistaService.getByPk(mail);
            if (Tur_visitas_x_turista == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_visitas_x_turista);
        }
        [HttpGet]
        public IActionResult IsFormComplete(string mail)
        {
            try
            {
                bool exist = _Tur_visitas_x_turistaService.isFormComplete(mail);
                    return Ok(exist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public IActionResult insert([FromBody] Formulario formData)
        {
            /*{ {"":"El fin de semana","":"Hasta 4 Acompañantes","":"turismo","":"Movilidad_Propia","":"no","mail_turista":"allcompva@gmail.com"}'
Request URL*/

            if (formData == null)
            {
                return BadRequest("Los datos del formulario son inválidos.");
            }

            Tur_visitas_x_turista obj = new Tur_visitas_x_turista();
            obj.cant_acompaniantes = formData.people;
            obj.dias_permanencia = formData.days;
            obj.fecha = DateTime.Now;
            obj.mail_turista = formData.mail_turista;
            obj.motivo_visita = formData.purpose;
            if (formData.IsFirstVisit == "Si")
                obj.primera_visita = true;
            else
                obj.primera_visita = false;
            obj.tipo_transporte = formData.TravelMethod;

            int? id = _Tur_visitas_x_turistaService.insert(obj);
            if (id != null)
                return Ok(new { message = "Formulario recibido correctamente" });
            else
                return BadRequest("Los datos del formulario son inválidos.");
        }
    }
}

