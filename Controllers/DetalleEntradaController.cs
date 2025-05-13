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
    public class DetalleEntradaController : ControllerBase
    {
        private readonly DetalleEntradaService _DetalleEntradaService;

        public DetalleEntradaController(DetalleEntradaService detalleentradaservice)
        {
            _DetalleEntradaService = detalleentradaservice;

        }





        [HttpPost("Insert")]
        public JsonResult InsertDetalleEntrada([FromBody] InsertDetalleEntradaModel de)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleEntradaService.InsertDetalleEntrada(de);

                string msgDefault = "Factura realizada con éxito.";

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

        [HttpGet("ExportarReportEntradasAExcel")]
        public IActionResult ExportarReportEntradasAExcel()
        {
            try
            {
                var excelData = _DetalleEntradaService.ExportarReportEntradasAExcel();


                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportEntradas.xlsx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error interno del servidor.");
            }
        }
        [HttpGet("GetReportEntradas")]
        public IActionResult GetReportKardex([FromQuery] string FechaInicio, string FechaFinal)
        {
            var DOC = new GetReportEntradasModel { FechaInicio = FechaInicio, FechaFinal = FechaFinal };
            var detalleOC = _DetalleEntradaService.GetReportKardex(DOC);
            return Ok(detalleOC);
        }



        /*      [Authorize(AuthenticationSchemes = "Bearer")]
    */
        [HttpGet("Get")]
        public IActionResult GetDetalleEntrada([FromQuery] int idEntrada)
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseDetalleEntrada result = new ResponseDetalleEntrada();
            result.Response = new ResponseBodyDE();
            result.Response.data = new List<GetDetalleEntradaModel>();

            var DEResponse = _DetalleEntradaService.GetDetalleEntrada(new GetDetalleEntradaModel { IdEntrada = idEntrada });

            if (DEResponse != null && DEResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = DEResponse;
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
        public JsonResult UpdateDetalleEntrada([FromBody] UpdateDetalleEntradaModel de)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleEntradaService.UpdateDetalleEntrada(de);

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
        public JsonResult DeleteDetalleEntrada([FromBody] DeleteDetalleEntradaModel de)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleEntradaService.DeleteDetalleEntrada(de);

                string msgDefault = "Registro eliminado con éxito.";

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


        [HttpPut("UpdateCantSinCArgo")]
        public JsonResult UpdateCantiSinCargo([FromBody] UpdateCantSinCargoModel csc)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleEntradaService.UpdateCantiSinCargo(csc);

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




    }
}