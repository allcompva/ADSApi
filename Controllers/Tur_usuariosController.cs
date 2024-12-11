using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using ADSWebApi.Services;
using ADSWebApi.Entities;
using Microsoft.AspNetCore.Hosting;

namespace ADSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tur_usuariosController : Controller
    {
        private ITur_comercioService _Tur_comercioService;
        private ITur_usuarioService _Tur_usuarioService;
        public Tur_usuariosController(ITur_usuarioService Tur_usuarioService, ITur_comercioService Tur_comercioService)
        {
            _Tur_comercioService = Tur_comercioService;
            _Tur_usuarioService = Tur_usuarioService;
        }

        //https://recreas.net/BackEnd/Tur_publicaciones/GetByCategoria?id=1

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDtoIn loginDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginDto.Email))
                {
                    return BadRequest("Email es requerido");
                }

                if (string.IsNullOrWhiteSpace(loginDto.Password))
                {
                    return BadRequest("Password es requerido");
                }
                var Tur_usuario = _Tur_usuarioService.getByEmail(loginDto.Email);

                if (Tur_usuario == null)
                {
                    return BadRequest("Comercio no encontrado");
                }

                if (Tur_usuario.password != loginDto.Password)
                {
                    return BadRequest("Password incorrecto");
                }

                UserLoginDtoOut userLoginDtoOut = new UserLoginDtoOut();
                userLoginDtoOut.Email = Tur_usuario.email;
                userLoginDtoOut.Id = Tur_usuario.id.ToString();

                return Ok(userLoginDtoOut);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult Registro(UserLoginDtoIn registroDto)
        {
            if (string.IsNullOrWhiteSpace(registroDto.Email))
            {
                return BadRequest("Email es requerido");
            }

            if (string.IsNullOrWhiteSpace(registroDto.Password))
            {
                return BadRequest("Password es requerido");
            }
            var createdUser = _Tur_usuarioService.registro(registroDto.Email, registroDto.Password);
            return Ok();
        }

    }

    public class UserLoginDtoIn
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class UserLoginDtoOut
    {
        public string? Email { get; set; }
        public string? Id { get; set; }
    }
}

