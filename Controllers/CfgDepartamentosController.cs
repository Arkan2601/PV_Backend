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
    public class CfgDepartamentosController : ControllerBase
    {
        private readonly CfgDepartamentosService _CfgDepartamentosService;

        public CfgDepartamentosController(CfgDepartamentosService cfgDepartamentos)
        {
            _CfgDepartamentosService = cfgDepartamentos;
        }





    [HttpPost("Insert")]
public JsonResult InsertCfgDepartamentos([FromBody] InsertCfgDepartamentosModel cfgDepartamentos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        // Llamada al servicio que ejecuta el procedimiento almacenado
        var catClienteResponse = _CfgDepartamentosService.InsertCfgDepartamentos(cfgDepartamentos);

        // Verificar si la respuesta del SP indica éxito o error
        bool esExito = catClienteResponse.Contains("Registro insertado con éxito", StringComparison.OrdinalIgnoreCase);

        objectResponse.StatusCode = esExito ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;
        objectResponse.success = esExito;
        objectResponse.message = esExito ? "Éxito." : "Error.";

        objectResponse.response = new
        {
            data = catClienteResponse // Mensaje devuelto por el SP
        };
    }
    catch (System.Exception ex)
    {
        Console.Write(ex.Message);
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        objectResponse.success = false;
        objectResponse.message = "Error interno del servidor.";
        objectResponse.response = new { data = ex.Message };
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
        public IActionResult GetCfgDepartamentos() 
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseDepa result = new ResponseDepa();
            result.Response = new ResponseBodyCfgDepartamentos();
            result.Response.data = new List<GetCfgDepartamentosModel>();

            var CfgDepartamentosResponse = _CfgDepartamentosService.GetCfgDepartamentos();

            if (CfgDepartamentosResponse != null && CfgDepartamentosResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = CfgDepartamentosResponse;
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
public JsonResult UpdateCfgDepartamentosResponse([FromBody] UpdateCfgDepartamentosModel cfgDepartamentos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        // Ejecuta el procedimiento almacenado y obtiene el mensaje de respuesta
        var resultado = _CfgDepartamentosService.UpdateCfgDepartamentos(cfgDepartamentos);

        // Verifica si el mensaje devuelto por el SP indica éxito o error
        bool esExito = resultado == "Registro actualizado con éxito.";

        objectResponse.StatusCode = esExito ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;
        objectResponse.success = esExito;
        objectResponse.message = esExito ? "Éxito" : "Error.";

        objectResponse.response = new
        {
            data = resultado // Mensaje real del SP
        };
    }
    catch (System.Exception ex)
    {
        Console.Write(ex.Message);
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        objectResponse.success = false;
        objectResponse.message = "Error.";
        objectResponse.response = new { data = "Ocurrió un error en el servidor." };
    }

    return new JsonResult(objectResponse);
}






        [HttpPut("Delete")]
public JsonResult DeleteCfgDepartamentos([FromBody] DeleteCfgDepartamentosModel cfgDepartamentos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        // Llamada al servicio que ejecuta el procedimiento almacenado
        var catClienteResponse = _CfgDepartamentosService.DeleteCfgDepartamentos(cfgDepartamentos);

        // Verificar si la respuesta del SP indica éxito o error
        bool esExito = catClienteResponse.Contains("Registro eliminado con éxito", StringComparison.OrdinalIgnoreCase);

        objectResponse.StatusCode = esExito ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest;
        objectResponse.success = esExito;
        objectResponse.message = esExito ? "Éxito." : "Error.";

        objectResponse.response = new
        {
            data = catClienteResponse // Mensaje devuelto por el SP
        };
    }
    catch (System.Exception ex)
    {
        Console.Write(ex.Message);
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        objectResponse.success = false;
        objectResponse.message = "Error interno del servidor.";
        objectResponse.response = new { data = ex.Message };
    }

    return new JsonResult(objectResponse);
}

} 
}