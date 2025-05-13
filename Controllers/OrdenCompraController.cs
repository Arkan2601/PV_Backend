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
    public class OrdenCompraController : ControllerBase
    {
        private readonly OrdenCompraService _OrdenCompraService;

        public OrdenCompraController(OrdenCompraService ordenCompraService)
        {
            _OrdenCompraService = ordenCompraService;
        }





        [HttpPost("Insert")]
        public JsonResult InsertOrdenCompra([FromBody] InsertarOrdenCompraModel orden)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var ordenModels = _OrdenCompraService.InsertOrdenCompra(orden);

                if (ordenModels.Count > 0)
                {
                    var Id = ordenModels[0].Id;
                    var Msg = ordenModels[0].Mensaje;

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



/*         [Authorize(AuthenticationSchemes = "Bearer")] */
        [HttpGet("Get")]
        public IActionResult GetOrdenCompras()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseOrdenCompra result = new ResponseOrdenCompra();
            result.Response = new ResponseBodyOrdenCompra();
            result.Response.data = new List<GetOrdenCompraModel>();

            var OrdenCompraResponse = _OrdenCompraService.getOrdenCompras();

            if (OrdenCompraResponse != null && OrdenCompraResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = OrdenCompraResponse;
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
        public JsonResult UpdateOrdenCompra([FromBody] UpdateOrdenCompraModel orden)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _OrdenCompraService.UpdateOrdenCompra(orden);

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
        public JsonResult DeleteOrdenCompra([FromBody] DeleteOrdenCompraModel orden)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _OrdenCompraService.DeleteOrdenCompra(orden);

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