using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
      public class ResponseUsuario
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyUsuario Response { get; set; }
    }

    public class ResponseBodyUsuario
    {
        public List<GetUsuariosModel> data { get; set; }
    }
    public class GetUsuariosModel
    {
        public int Id { get; set; }
        public string NombreP { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string Theme { get; set; }
        public int IdPersona { get; set; }
        public string Usuario { get; set; }
        public string FechaAct { get; set; }
        public string FechaReg { get; set; }
        public string Mensaje { get; set; }
    }
    public class GetLoginUserModel
    {
        public int Id { get; set; }
        public string Perfil { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
    public class InsertUsuariosModel
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; } = "123456789";
        public int Rol { get; set; }
        public int IdPersona { get; set; }
        public int Usuario { get; set; }
    }
    public class UpdateUsuariosModel
    {
        public int Id { get; set; }
        public string Contrasena { get; set; }
        public int Usuario { get; set; }
    }
    public class DeleteUsuariosModel
    {
        public int Id { get; set; }
    }
        public class UpdateColorUsuariosModel
    {
        public int Id { get; set; }
        public string Theme { get; set; }
    }
}
