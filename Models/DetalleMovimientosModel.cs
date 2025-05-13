using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

    public class ResponseDetalleMovimiento
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyDM Response { get; set; }
    }

    public class ResponseBodyDM
    {
        public List<GetDetalleMovimientosModel> data { get; set; }
    }
    public class GetDetalleMovimientosModel
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public string CodigoInsumo { get; set; }
        public string DescripcionInsumo {get; set;}
        public decimal Cantidad { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }
        public string FechaInicio {get; set;}
        public string FechaFin {get; set;}

    }

    public class InsertDetalleMovimientosModel
    {
        public int IdMovimiento { get; set; }
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateDetalleMovimientosModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public int UsuarioActualiza { get; set; }
        public int Estatus { get; set; }

    }

    public class DeleteDetalleMovimientosModel
    {
        public int Id { get; set; }
    }

}