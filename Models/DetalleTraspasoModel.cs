using System;
using System.Collections.Generic;
namespace marcatel_api.Models



{

    public class ResponseDetalleTraspaso
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyDT Response { get; set; }
    }

    public class ResponseBodyDT
    {
        public List<GetDetalleTraspasoModel> data { get; set; }
    }
    public class GetDetalleTraspasoModel
    {
        public int Id { get; set; }
        public int IdTraspaso { get; set; }
        public string Insumo { get; set; }
        public string AlmacenOrigen { get; set; }
        public string AlmacenDestino { get; set; }
        public decimal CantidadEnviada { get; set; }
        public decimal CatidadRecibida { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string UsuarioEnvía { get; set; }
        public string UsuarioRecibe { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }


    }

    public class InsertDetalleTraspasoModel
    {
        public int IdTraspaso { get; set; }
        public string Insumo { get; set; }
        public decimal CantidadEnviada { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateDetalleTraspasoModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public decimal CantidadEnviada { get; set; }
        public decimal CantidadRecibida { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class DeleteDetalleTraspasoModel
    {
        public int Id { get; set; }
    }


}
