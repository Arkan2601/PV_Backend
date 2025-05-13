using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
     public class ResponseRol
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyRol Response { get; set; }
    }

    public class ResponseBodyRol
    {
        public List<GetRolModel> data { get; set; }
    }
    public class GetRolModel
    {
        public int Id { get; set; }
        public string Rol { get; set; }
        public string Descripcion {get; set;}
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }

    }

    public class InsertRolModel
    {
        public string Rol { get; set; }
        public int UsuarioActualiza { get; set; }
        public string Descripcion {get; set;}

    }

    public class UpdateRolModel
    {
        public int Id { get; set; }
        public string Rol { get; set; }
        public string Descripcion {get; set;}
        public int UsuarioActualiza {get; set;}

    }

    public class DeleteRolModel
    {
        public int Id { get; set; }
    }

}
