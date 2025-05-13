using System;
using System.Collections.Generic;
namespace marcatel_api.Models



{

    public class ResponseCatModulo
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyCatModulo Response { get; set; }
    }

    public class ResponseBodyCatModulo
    {
        public List<GetCatModuloModel> data { get; set; }
    }
    public class GetCatModuloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string Usuario { get; set; }
        public string Mensaje { get; set; }

    }

    public class InsertCatModuloModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Usuario { get; set; }
    }

    public class UpdateCatModuloModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Usuario { get; set; }
    }

    public class DeleteCatModuloModel
    {
        public int Id { get; set; }
    }

}
