using System;
using System.Collections.Generic;
namespace marcatel_api.Models



{

    public class ResponseBancos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyBanco Response { get; set; }
    }

    public class ResponseBodyBanco
    {
        public List<GetBancosModel> data { get; set; }
    }
    public class GetBancosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }

    }

    public class InsertBancosModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateBancosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class DeleteBancosModel
    {
        public int Id { get; set; }
    }

}