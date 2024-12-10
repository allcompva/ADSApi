using Microsoft.AspNetCore.Mvc;
using System;

namespace ADSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataDeletionController : ControllerBase
    {
        [HttpPost("delete-data-callback")]
        public IActionResult DeleteDataCallback([FromBody] DataDeletionRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                return BadRequest(new { error = "ID de usuario no proporcionado." });
            }

            // Lógica para eliminar los datos del usuario
            EliminarDatosDelUsuario(request.UserId);

            // Crear URL para verificar el estado de la eliminación
            var statusUrl = $"https://ads.somee.com/datadelete.html/{request.UserId}";
    
            // Generar un código de confirmación único
            var confirmationCode = GenerarCodigoConfirmacion();

            // Devolver la respuesta JSON requerida
            return Ok(new
            {
                url = statusUrl,
                confirmation_code = confirmationCode
            });
        }

        private void EliminarDatosDelUsuario(string userId)
        {
            // Aquí agregarías la lógica para eliminar todos los datos del usuario en tu sistema
            Console.WriteLine($"Eliminando datos para el usuario con ID: {userId}");
            // Ejemplo: Puedes usar Entity Framework para eliminar registros en la base de datos
        }

        private string GenerarCodigoConfirmacion()
        {
            return Guid.NewGuid().ToString("N"); // Código único alfanumérico
        }
    }

    // Clase de solicitud para deserializar el JSON de la petición
    public class DataDeletionRequest
    {
        public string UserId { get; set; }
    }
}
