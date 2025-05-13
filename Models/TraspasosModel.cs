using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
    public class ResponseTraspasos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyTraspasos Response { get; set; }
    }

    public class ResponseBodyTraspasos
    {
        public List<GetTraspasosModel> data { get; set; }
    }
    public class GetTraspasosModel
    {
        public int Id { get; set; }
        public string AlmacenOrigen { get; set; }
        public string AlmacenDestino { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaRecibido { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioEnvia { get; set; }
        public string UsuarioRecibe { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
    }

    public class InsertTraspasosModel
    {
        public int IdAlmacenOrigen { get; set; }
        public int IdAlmacenDestino { get; set; }
        public int UsuarioEnvia { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class UpdateTraspasosModel
    {
        public int Id { get; set; }
        public int IdAlmacenOrigen { get; set; }
        public int IdAlmacenDestino { get; set; }
        public int UsuarioEnvia { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class DeleteTraspasosModel
    {
        public int Id { get; set; }
    }

    public class AutorizarTraspasosModel
    {
        public int Id { get; set; }
        public string FechaRecibido { get; set; }
        public int Estatus { get; set; }
        public int UsuarioRecibe { get; set; }
        public int UsuarioActualiza { get; set; }
    }

}