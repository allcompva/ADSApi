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
    public class Tur_comercioController : Controller
    {
        private ITur_comercioService _Tur_comercioService;
        public Tur_comercioController(ITur_comercioService Tur_comercioService)
        {
            _Tur_comercioService = Tur_comercioService;
        }

        //https://recreas.net/BackEnd/Tur_publicaciones/GetByCategoria?id=1

        [HttpGet]
        public IActionResult getByEmail(string email)
        {
            var Tur_comercio = _Tur_comercioService.getByEmail(email);
            if (Tur_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_comercio);
        }

        [HttpGet]
        public IActionResult getByPk(string cuit)
        {
            var Tur_comercio = _Tur_comercioService.getByPk(cuit);
            if (Tur_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_comercio);
        }
        [HttpGet]
        public IActionResult getDetails(string cuit)
        {
            var Tur_comercio = _Tur_comercioService.getDetails(cuit);
            if (Tur_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Tur_comercio);
        }
        [HttpGet]
        public IActionResult read(int idCate)
        {
            List<Entities.Tur_comercio> Tur_comercio =
                _Tur_comercioService.read(idCate);

            Models.solicitudes objS = new Models.solicitudes();
            List<Models.solicitudes> lst = new List<Models.solicitudes>();
            string estado = string.Empty;

            foreach (var item in Tur_comercio)
            {
                objS = new Models.solicitudes();
                objS.estado = item.estado;
                objS.fechaSolicitud = DateTime.Now.ToShortDateString();
                objS.nombreComercio = item.nombre_fantacia;
                objS.solicitudId = item.cuit.ToString();
                lst.Add(objS);
            }
            if (Tur_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(lst);
        }

        [HttpGet]
        public IActionResult readAll(int idCate)
        {
            List<Entities.Tur_comercio> Tur_comercio =
                _Tur_comercioService.readAll(idCate);

            Models.solicitudes objS = new Models.solicitudes();
            List<Models.solicitudes> lst = new List<Models.solicitudes>();
            string estado = string.Empty;

            foreach (var item in Tur_comercio)
            {
                objS = new Models.solicitudes();
                objS.estado = item.estado;
                objS.fechaSolicitud = DateTime.Now.ToShortDateString();
                objS.nombreComercio = item.nombre_fantacia;
                objS.solicitudId = item.cuit.ToString();
                lst.Add(objS);
            }
            if (Tur_comercio == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(lst);
        }
        [HttpDelete]
        public IActionResult delete(string cuit)
        {
            _Tur_comercioService.delete(cuit);
            return Ok();
        }
        [HttpPost]
        public IActionResult insert()
        {
            try
            {
                Tur_comercio obj = new Tur_comercio();
                if (Request.Form.Keys.Contains("telefono"))
                    obj.cel = Request.Form["telefono"].ToString();
                else
                    obj.cel = string.Empty;
                if (Request.Form.Keys.Contains("googleMaps"))
                    obj.codigo_insercion_maps = Request.Form["googleMaps"].ToString();
                else
                    obj.codigo_insercion_maps = string.Empty;
                if (Request.Form.Keys.Contains("dni"))
                    obj.cuit_responsable = Request.Form["dni"].ToString();
                else
                    obj.cuit_responsable = string.Empty;

                obj.estado = "Pendiente";

                if (Request.Form.Keys.Contains("comercioNumero"))
                    obj.nro_comercio_e_industria =
                    Request.Form["comercioNumero"].ToString();
                else
                    obj.nro_comercio_e_industria = string.Empty;

                if (Request.Form.Keys.Contains("razonSocial"))
                    obj.razon_social =
                    Request.Form["razonSocial"].ToString();
                else
                    obj.razon_social = string.Empty;

                if (Request.Form.Keys.Contains("cuit"))
                    obj.cuit = Request.Form["cuit"].ToString();
                else
                    obj.cuit = string.Empty;

                if (Request.Form.Keys.Contains("nombreFantasia"))
                    obj.nombre_fantacia = Request.Form["nombreFantasia"].ToString();
                else
                    obj.nombre_fantacia = string.Empty;

                if (Request.Form.Keys.Contains("direccion"))
                    obj.direccion = Request.Form["direccion"].ToString();
                else
                    obj.direccion = string.Empty;

                if (Request.Form.Keys.Contains("whatsapp"))
                    obj.whatsapp = Request.Form["whatsapp"].ToString();
                else
                    obj.whatsapp = string.Empty;

                if (Request.Form.Keys.Contains("mail"))
                    obj.mail = Request.Form["mail"].ToString();
                else
                    obj.mail = string.Empty;

                if (Request.Form.Keys.Contains("descripcion"))
                    obj.descripcion = Request.Form["descripcion"].ToString();
                else
                    obj.descripcion = string.Empty;

                if (Request.Form.Keys.Contains("categoria"))
                    obj.id_categoria = int.Parse(Request.Form["categoria"].ToString());
                else
                    obj.id_categoria = 0;

                if (Request.Form.Keys.Contains("responsableNombre"))
                    obj.responsablenombre = Request.Form["responsableNombre"].ToString();
                else
                    obj.responsablenombre = string.Empty;


                //responsableNombre
                //


                IFormFileCollection files = Request.Form.Files;

                if (files == null || files.Count == 0)
                {
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                }
                // Obtener la ruta f�sica de la carpeta 'assets/images'
                string appDirectory = Directory.GetCurrentDirectory(); // Ruta f�sica de la app
                string assetsPath = Path.GetFullPath(Path.Combine(appDirectory, "..", "assets", "images"));

                // Crear el directorio 'assets/images' si no existe
                if (!Directory.Exists(assetsPath))
                {
                    Directory.CreateDirectory(assetsPath);
                }
                List<string> images = new List<string>();
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Generar un nombre �nico para cada archivo
                        string fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                        // Validar extensi�n si es necesario (opcional)
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" }; // Ejemplo
                        if (!allowedExtensions.Contains(fileExtension))
                        {
                            return BadRequest($"El archivo {file.FileName} tiene una extensi�n no permitida.");
                        }
                        string fileName = $"{obj.cuit}{"_"}{Guid.NewGuid()}{fileExtension}";
                        images.Add(fileName);
                        // Ruta completa del archivo en 'assets/images'
                        string filePath = Path.Combine(assetsPath, fileName);

                        // Guardar el archivo en disco
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                obj.images = string.Join(",", images);//JsonConvert.SerializeObject(images);
                _Tur_comercioService.insert(obj);
                return Ok(new { Message = "Archivos cargados exitosamente.", FileCount = files.Count });


            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult update()
        {
            try
            {
                if (!Request.Form.Keys.Contains("cuit"))
                {
                    return BadRequest(new { message = "Parametro cuit faltante" });
                }

                Tur_comercio obj = Tur_comercio.getByPk(Request.Form["cuit"].ToString());

                if (Request.Form.Keys.Contains("telefono"))
                    obj.cel = Request.Form["telefono"].ToString();
                else
                    obj.cel = string.Empty;
                if (Request.Form.Keys.Contains("googleMaps"))
                    obj.codigo_insercion_maps = Request.Form["googleMaps"].ToString();
                else
                    obj.codigo_insercion_maps = string.Empty;
                if (Request.Form.Keys.Contains("dni"))
                    obj.cuit_responsable = Request.Form["dni"].ToString();
                else
                    obj.cuit_responsable = string.Empty;


                if (Request.Form.Keys.Contains("comercioNumero"))
                    obj.nro_comercio_e_industria =
                    Request.Form["comercioNumero"].ToString();
                else
                    obj.nro_comercio_e_industria = string.Empty;

                if (Request.Form.Keys.Contains("razonSocial"))
                    obj.razon_social =
                    Request.Form["razonSocial"].ToString();
                else
                    obj.razon_social = string.Empty;

                if (Request.Form.Keys.Contains("cuit"))
                    obj.cuit = Request.Form["cuit"].ToString();
                else
                    obj.cuit = string.Empty;

                if (Request.Form.Keys.Contains("nombreFantasia"))
                    obj.nombre_fantacia = Request.Form["nombreFantasia"].ToString();
                else
                    obj.nombre_fantacia = string.Empty;

                if (Request.Form.Keys.Contains("direccion"))
                    obj.direccion = Request.Form["direccion"].ToString();
                else
                    obj.direccion = string.Empty;

                if (Request.Form.Keys.Contains("whatsapp"))
                    obj.whatsapp = Request.Form["whatsapp"].ToString();
                else
                    obj.whatsapp = string.Empty;

                if (Request.Form.Keys.Contains("mail"))
                    obj.mail = Request.Form["mail"].ToString();
                else
                    obj.mail = string.Empty;

                if (Request.Form.Keys.Contains("descripcion"))
                    obj.descripcion = Request.Form["descripcion"].ToString();
                else
                    obj.descripcion = string.Empty;

                if (Request.Form.Keys.Contains("categoria"))
                    obj.id_categoria = int.Parse(Request.Form["categoria"].ToString());
                else
                    obj.id_categoria = 0;

                if (Request.Form.Keys.Contains("responsableNombre"))
                    obj.responsablenombre = Request.Form["responsableNombre"].ToString();
                else
                    obj.responsablenombre = string.Empty;

                IFormFileCollection files = Request.Form.Files;

                if (files == null || files.Count == 0)
                {
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                }
                // Obtener la ruta f�sica de la carpeta 'assets/images'
                string appDirectory = Directory.GetCurrentDirectory(); // Ruta f�sica de la app
                string assetsPath = Path.GetFullPath(Path.Combine(appDirectory, "..", "assets", "images"));

                // Crear el directorio 'assets/images' si no existe
                if (!Directory.Exists(assetsPath))
                {
                    Directory.CreateDirectory(assetsPath);
                }
                List<string> images = new List<string>();
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Generar un nombre �nico para cada archivo
                        string fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                        // Validar extensi�n si es necesario (opcional)
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" }; // Ejemplo
                        if (!allowedExtensions.Contains(fileExtension))
                        {
                            return BadRequest($"El archivo {file.FileName} tiene una extensi�n no permitida.");
                        }
                        string fileName = $"{obj.cuit}{"_"}{Guid.NewGuid()}{fileExtension}";
                        images.Add(fileName);
                        // Ruta completa del archivo en 'assets/images'
                        string filePath = Path.Combine(assetsPath, fileName);

                        // Guardar el archivo en disco
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyToAsync(stream);
                        }
                    }
                }
                List<string> lstActuales = new List<string>();
                lstActuales = JsonConvert.DeserializeObject<List<string>>(obj.images);
                lstActuales.AddRange(images);
                obj.images = JsonConvert.SerializeObject(lstActuales);
                _Tur_comercioService.update(obj);
                return Ok(new { Message = "Archivos cargados exitosamente.", FileCount = files.Count });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CambioEstado(string cuit, string estado, string mensaje)
        {
            try
            {
                _Tur_comercioService.CambioEstado(cuit, estado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}

