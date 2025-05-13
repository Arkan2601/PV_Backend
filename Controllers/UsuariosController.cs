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
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _UsuarioService;

        Encrypt enc = new Encrypt();

        public UsuariosController(UsuariosService usuariosService)
        {
            _UsuarioService = usuariosService;
        }





        /*   [HttpPost("Insert")]
          public JsonResult InsertPdersonas([FromBody] InsertUsuariosModel usuarios)
          {
              var objectResponse = Helper.GetStructResponse();
              try
              {
                  usuarios.Contrasena = enc.GetSHA256(usuarios.Contrasena);

                  var CatClienteResponse = _UsuarioService.InsertUsuarios(usuarios);

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
   */


        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Get")]
        public IActionResult GetUsuario()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseUsuario result = new ResponseUsuario();
            result.Response = new ResponseBodyUsuario();
            result.Response.data = new List<GetUsuariosModel>();

            var UsuariosResponse = _UsuarioService.GetUsuarios();

            if (UsuariosResponse != null && UsuariosResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = UsuariosResponse;
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
        public JsonResult UpdatePersonas([FromBody] UpdateUsuariosModel usuarios)
        {


            var objectResponse = Helper.GetStructResponse();
            try
            {
                usuarios.Contrasena = enc.GetSHA256(usuarios.Contrasena);
                var CatClienteResponse = _UsuarioService.UpdateUsuarios(usuarios);
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

        
       [HttpPut("UpdateColor")]
public JsonResult UpdateColor([FromBody] UpdateColorUsuariosModel color)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var CatClienteResponse = _UsuarioService.UpdateColorUsuarios(color);

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
            objectResponse.success = false;
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
        public JsonResult DeletePersonas([FromBody] DeleteUsuariosModel usuarios)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _UsuarioService.DeleteUsuarios(usuarios);
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

        [HttpPost("GetLogin")]
        public JsonResult GetLogin([FromBody] GetLoginUserModel usuarios)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _UsuarioService.GetLogin(usuarios);

                if (CatClienteResponse.Count < 1)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = false;
                    objectResponse.message = "Usuario o contrasena incorrectos";

                    objectResponse.response = null;
                    return new JsonResult(objectResponse);
                }

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro Obtenido con exito";

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