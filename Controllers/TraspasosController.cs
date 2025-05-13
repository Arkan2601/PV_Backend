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
    public class TraspasosController : ControllerBase
    {
        private readonly TraspasosService _traspasosService;

        public TraspasosController(TraspasosService traspasosservice)
        {
            _traspasosService = traspasosservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertTraspasos([FromBody] InsertTraspasosModel traspasos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var traspasosModels = _traspasosService.InsertTraspasos(traspasos);

                if (traspasosModels.Count > 0)
                {
                    var Id = traspasosModels[0].Id;
                    var Msg = traspasosModels[0].Mensaje;

                    string msgDefault = "Registro insertado con éxito.";

                    if (msgDefault == Msg)
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.OK;
                        objectResponse.success = true;
                        objectResponse.message = "Éxito.";

                        objectResponse.response = new
                        {
                            data = Id,
                            Msg
                        };
                    }
                    else
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        objectResponse.success = true;
                        objectResponse.message = "Error.";

                        objectResponse.response = new
                        {
                            data = Id,
                            Msg
                        };
                    }
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error: No se devolvió ningún resultado.";

                    objectResponse.response = null;
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);

        }



        /*      [Authorize(AuthenticationSchemes = "Bearer")]
        */
        [HttpGet("Get")]
        public IActionResult GetTraspasos([FromQuery] string pAlmacenOrigen, string pAlmacenDestino, string pFechaInicio, string pFechaFinal)
        {
            //var T = new GetTraspasosModel { AlmacenOrigen = pAlmacenOrigen, AlmacenDestino = pAlmacenDestino, FechaInicio = pFechaInicio, FechaFinal = pFechaFinal };
            //var t = _traspasosService.GetTraspasos(T);
            //return Ok(t);
            var objectResponse = Helper.GetStructResponse();
            ResponseTraspasos result = new ResponseTraspasos();
            result.Response = new ResponseBodyTraspasos();
            result.Response.data = new List<GetTraspasosModel>();

            var TraspasosResponse = _traspasosService.GetTraspasos(new GetTraspasosModel { AlmacenOrigen = pAlmacenOrigen, AlmacenDestino = pAlmacenDestino, FechaInicio = pFechaInicio, FechaFinal = pFechaFinal });

            if (TraspasosResponse != null && TraspasosResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = TraspasosResponse;
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
        public JsonResult UpdateTraspasos([FromBody] UpdateTraspasosModel traspasos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _traspasosService.UpdateTraspasos(traspasos);

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
        public JsonResult DeleteTraspasos([FromBody] DeleteTraspasosModel traspasos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _traspasosService.DeleteTraspasos(traspasos);

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



        [HttpPut("AutorizarTraspaso")]
        public JsonResult AutorizarTraspasos([FromBody] AutorizarTraspasosModel traspasos)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _traspasosService.AutorizarTraspasos(traspasos);

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