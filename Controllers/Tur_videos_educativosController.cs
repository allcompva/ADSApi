using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ADSWebApi.Services;
using ADSWebApi.Entities;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_videos_educativosController : Controller
    {
        private ITur_videos_educativosService _Tur_videos_educativosService;
        public Tur_videos_educativosController(ITur_videos_educativosService Tur_videos_educativosService)
        {
            _Tur_videos_educativosService = Tur_videos_educativosService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int id)
        {
            var Tur_videos_educativos = _Tur_videos_educativosService.getByPk(id);
            if (Tur_videos_educativos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_videos_educativos);
        }
        [HttpPost]
        public IActionResult insert(Tur_videos_educativos obj)
        {
            try
            {
                int noti = _Tur_videos_educativosService.insert(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult update(Tur_videos_educativos obj)
        {
            try
            {
                _Tur_videos_educativosService.update(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult delete(Tur_videos_educativos obj)
        {
            try
            {
                _Tur_videos_educativosService.delete(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }





    }
}

