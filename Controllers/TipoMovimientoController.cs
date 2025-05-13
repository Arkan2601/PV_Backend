using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using System.Collections.Generic;
using System.Linq;


namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class TipoMovimientoController : ControllerBase
    {
        private readonly TipoMovimientoService _TipoMovimientoService;

        public TipoMovimientoController(TipoMovimientoService tipoMovimientoService)
        {
            _TipoMovimientoService = tipoMovimientoService;
        }





        [HttpPost("Insert")]
        public JsonResult InsertTipoMovimiento([FromBody] InsertTipoMovimientoModel tipoMovimiento)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _TipoMovimientoService.InsertTipoMovimiento(tipoMovimiento);

                string msgDefault = "Registro insertado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        // Método auxiliar para extraer el ID del mensaje de respuesta
        //private int ExtractIdFromResponse(string response)
        //{
        // Suponiendo que la respuesta tiene el formato: "Registro insertado con éxito. ID: 123"
        //  var parts = response.Split(new[] { "Id: " }, StringSplitOptions.None);
        //if (parts.Length > 1 && int.TryParse(parts[1], out int id))
        //{
        //  return id; // Devuelve el ID extraído
        //}
        //return 0; // Devuelve 0 si no se puede extraer el ID
        //}



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetTipoMovimiento()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseTipoMovimiento result = new ResponseTipoMovimiento();
            result.Response = new ResponseBodyTipoMovimiento();
            result.Response.data = new List<GetTipoMovimientoModel>();

            var TipoMovimientoResponse = _TipoMovimientoService.GetTipoMovimiento();

            if (TipoMovimientoResponse != null && TipoMovimientoResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = TipoMovimientoResponse;
                objectResponse.response = new
                {
                    data = result.Response.data
                };
            }
            else
            {
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Error = true;
                result.Success = false;
                result.Message = "Error al obtener la información.";
            }

            return new JsonResult(result);
        }


        [HttpPut("Update")]
        public JsonResult UpdateTipoMovimiento([FromBody] UpdateTipoMovimientoModel tipoMovimiento)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _TipoMovimientoService.UpdateTipoMovimiento(tipoMovimiento);

                string msgDefault = "Registro actualizado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }






        [HttpPut("Delete")]
        public JsonResult DeleteTipoMovimiento([FromBody] DeleteTipoMovimientoModel tipoMovimiento)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var catClienteResponse = _TipoMovimientoService.DeleteTipoMovimiento(tipoMovimiento);

                // Suponemos que el mensaje de éxito contiene la frase "Registro eliminado con éxito"
                if (catClienteResponse.Contains("Registro eliminado con éxito", StringComparison.OrdinalIgnoreCase))
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = catClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = false; // Cambiado a false para indicar un error
                    objectResponse.message = "Error: " + catClienteResponse; // Incluye el mensaje de error de la SP

                    objectResponse.response = new
                    {
                        data = catClienteResponse
                    };
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError; // Cambia a 500 en caso de excepción
                objectResponse.success = false;
                objectResponse.message = "Error interno del servidor: " + ex.Message;
            }

            return new JsonResult(objectResponse);
        }

    }
}