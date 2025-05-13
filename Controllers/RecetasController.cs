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
    public class RecetasController : ControllerBase
    {
        private readonly RecetasService _recetasService;

        public RecetasController(RecetasService recetasservice)
        {
            _recetasService = recetasservice;
        }




 [HttpPost("Insert")]
public JsonResult InsertArticulo([FromBody] InsertRecetasModel receta)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var recetaModels = _recetasService.InsertRecetas(receta);

       if (recetaModels.Count > 0)
                {
                    var Id = recetaModels[0].Id;
                    var msg = recetaModels[0].Mensaje;

                    string msgDefault = "Registro insertado con éxito.";

                    if (msgDefault == msg)
                    {
                        objectResponse.StatusCode = (int)HttpStatusCode.OK;
                        objectResponse.success = true;
                        objectResponse.message = "Éxito.";

                        objectResponse.response = new
                        {
                            data = Id,
                            msg
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
                            msg
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



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetRecetas()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseRecetas result = new ResponseRecetas();
            result.Response = new ResponseBodyRecetas();
            result.Response.data = new List<GetRecetasModel>();

            var RecetasResponse = _recetasService.GetRecetas();

            if (RecetasResponse != null && RecetasResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = RecetasResponse;
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
        public JsonResult UpdateRecetas([FromBody] UpdateRecetasModel recetas)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _recetasService.UpdateRecetas(recetas);

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
        public JsonResult DeletRecetas([FromBody] DeleteRecetasModel recetas)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _recetasService.DeleteRecetas(recetas);

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