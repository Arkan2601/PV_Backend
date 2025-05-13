using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]
    public class EstadosController : ControllerBase
    {
        private readonly EstadosService _EstadosService;

        public EstadosController(EstadosService EstadosService)
        {
            _EstadosService = EstadosService;

        }
        [HttpPost("Insert")]
        public JsonResult InsertEstados([FromBody] InsertEstadosModel Estados)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _EstadosService.InsertEstados(Estados);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }



        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")]
        public IActionResult GetEstados()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseEstados result = new ResponseEstados();
            result.Response = new ResponseBodyEstado();
            result.Response.data = new List<GetEstadosModel>();

            var EstadosResponse = _EstadosService.GetEstados();

            if (EstadosResponse != null && EstadosResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = EstadosResponse;
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
        public JsonResult UpdateEstados([FromBody] UpdateEstadosModel Estados)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _EstadosService.UpdateEstados(Estados);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro actualizado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }
    }
}