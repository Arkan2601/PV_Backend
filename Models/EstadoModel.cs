using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

 public class ResponseEstados
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyEstado Response { get; set; }
    }

    public class ResponseBodyEstado
    {
        public List<GetEstadosModel> data { get; set; }
    }


    public class GetEstadosModel
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }
    }

    public class InsertEstadosModel
    {
        public string NombreEstado { get; set; }
    }

    public class UpdateEstadosModel
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }
    }

}