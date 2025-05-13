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
    public class DetalleTraspasoController : ControllerBase
    {
        private readonly DetalleTraspasoService _DetalleTraspasoService;

        public DetalleTraspasoController(DetalleTraspasoService detalletraspasoservice)
        {
            _DetalleTraspasoService = detalletraspasoservice;

        }


        [HttpGet("DiferenciasTraspasosExcel")]
        public IActionResult ExportarDetalleTraspasosAExcel([FromQuery] string FechaInicio, string FechaFinal)
        {
            try
            {
                var dtraspaso = new GetDetalleTraspasoModel { FechaInicio = FechaInicio, FechaFinal = FechaFinal };
                var detalleTraspaso = _DetalleTraspasoService.DiferenciaTraspasos(dtraspaso);
                var excelData = _DetalleTraspasoService.ExportarTraspasosAExcel();


                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DiferenciasEntreTraspasos.xlsx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error interno del servidor.");
            }
        }



        [HttpPost("Insert")]
        public JsonResult InsertDetalleTraspaso([FromBody] InsertDetalleTraspasoModel traspaso)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTraspasoService.InsertDetalleTraspaso(traspaso);

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



        /*         [Authorize(AuthenticationSchemes = "Bearer")]
         */
        [HttpGet("Get")]
        public IActionResult GetDetalleTraspaso([FromQuery] int idTraspaso)
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseDetalleTraspaso result = new ResponseDetalleTraspaso();
            result.Response = new ResponseBodyDT();
            result.Response.data = new List<GetDetalleTraspasoModel>();

            var DTResponse = _DetalleTraspasoService.GetDetalleTraspaso(new GetDetalleTraspasoModel { IdTraspaso = idTraspaso });

            if (DTResponse != null && DTResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = DTResponse;
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
        public JsonResult UpdateDetalleTraspaso([FromBody] UpdateDetalleTraspasoModel traspaso)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTraspasoService.UpdateDetalleTrasapaso(traspaso);

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
        public JsonResult DeleteDetalleTraspaso([FromBody] DeleteDetalleTraspasoModel traspaso)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _DetalleTraspasoService.DeleteDetalleTraspaso(traspaso);

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


    }
}