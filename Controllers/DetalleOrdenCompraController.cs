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
    public class DetalleOrdenCompraController : ControllerBase
    {
        private readonly DetalleOrdenCompraService _detalleOrdenCompraService;

        public DetalleOrdenCompraController(DetalleOrdenCompraService detalleordencompraservice)
        {
            _detalleOrdenCompraService = detalleordencompraservice;
        }





        [HttpPost("Insert")]
        public JsonResult InsertDetalleOrdenCompra([FromBody] InsertDetalleOrdenCompraModel DOC)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _detalleOrdenCompraService.InsertDetalleOrdenCompra(DOC);

                string msgDefault = "Insumo agregado con éxito.";

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



        /*      [Authorize(AuthenticationSchemes = "Bearer")]
         */
        [HttpGet("Get")]
        public IActionResult GetDetalleOrdenCompra([FromQuery] int idOrdenCompra)
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseDetalleOrdenCompra result = new ResponseDetalleOrdenCompra();
            result.Response = new ResponseBodyDOC();
            result.Response.data = new List<GetDetalleOrdenCompraModel>();

            var DOCResponse = _detalleOrdenCompraService.GetDetalleOrdenCompra(new GetDetalleOrdenCompraModel { IdOrdenCompra = idOrdenCompra });

            if (DOCResponse != null && DOCResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = DOCResponse;
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
        public JsonResult UpdateDetalleOrdenCompra([FromBody] UpdateDetalleOrdenCompraModel DOC)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _detalleOrdenCompraService.UpdateDetalleOrdenCompra(DOC);

                string msgDefault = "Insumo actualizado con éxito.";

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
        public JsonResult DeleteDetalleOrdenCompra([FromBody] DeleteDetalleOrdenCompraModel DOC)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _detalleOrdenCompraService.DeleteDetalleOrdenCompra(DOC);

                string msgDefault = "Insumo eliminado con éxito";

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