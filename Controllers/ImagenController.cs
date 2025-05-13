using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Models;
using marcatel_api.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using marcatel_api.Helpers;

namespace marcatel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private readonly ImagenService _imagenService;

        public ImagenController(ImagenService imagenService)
        {
            _imagenService = imagenService;
        }

        [HttpPost("SubirImagen")]
        public async Task<IActionResult> SubirImagen(int id, IFormFile imagen)
        {
            if (imagen == null || id <= 0)
            {
                return BadRequest("ID de usuario o imagen no proporcionados.");
            }

            try
            {
                // Convertir la imagen a base64
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Crear modelo de actualización
                    var model = new UpdateImagenModel
                    {
                        Id = id,
                        ImagenData = base64String
                    };

                    // Llamar al servicio para almacenar la imagen
                    string resultado = _imagenService.UpdateImagen(model);

                    if (resultado.Contains("Error"))
                    {
                        return StatusCode(500, resultado); // Error interno
                    }

                    return Ok(resultado); // Respuesta de éxito
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al procesar la imagen: " + ex.Message);
            }
        }



          [HttpGet("VerImagen/{id}")]
                public IActionResult VerImagen(int id)
                {
                    var imagenData = _imagenService.ObtenerImagen(id);
                    if (imagenData == null)
                    {
                        return NotFound("Imagen no encontrada.");
                    }


                    string base64String = Convert.ToBase64String(imagenData);
                    byte[] imageBytes = Convert.FromBase64String(base64String);

                    return File(imageBytes, "image/jpeg"); 
                } 


              /*   [HttpGet("GetImagen/{id}")]
            public JsonResult GetImagen(int id)
            {
                var objectResponse = Helper.GetStructResponse(); // Obtener la estructura de respuesta
                try
                {
                    var imagenData = _imagenService.ObtenerImagen(id);

                    if (imagenData != null)
                    {
                        // Convertir la imagen binaria a base64
                        string base64String = Convert.ToBase64String(imagenData);

                        objectResponse.StatusCode = (int)HttpStatusCode.OK;
                        objectResponse.success = true;
                        objectResponse.message = "Imagen obtenida con éxito.";
                        objectResponse.response = new
                        {
                            data = base64String
                        };
                    }
                    else
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.NotFound;
                        objectResponse.success = false;
                        objectResponse.message = "No se encontró una imagen para este usuario.";
                        objectResponse.response = null;
                    }
                }
                catch (System.Exception ex)
                {
                    Console.Write(ex.Message);
                    objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    objectResponse.success = false;
                    objectResponse.message = "Ocurrió un error al obtener la imagen.";
                    objectResponse.response = null;
                }

                return new JsonResult(objectResponse);
            } */

    }
}
