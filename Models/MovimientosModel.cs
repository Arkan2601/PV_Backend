using System;
using System.Collections.Generic;
namespace marcatel_api.Models



{

    public class ResponseMovimientos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyMov Response { get; set; }
    }

    public class ResponseBodyMov
    {
        public List<GetMovimientosModel> data { get; set; }
    }

    public class GetMovimientosModel
    {
        public int Id { get; set; }
        public string NombreAlmacen { get; set; }
        public string TipoMovimiento { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaAutorizacion { get; set; }
        public string UsuarioRegistra { get; set; }
        public string UsuarioAutoriza { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }

        //Para el filtro

        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int IdSucursal { get; set; }
        public int Usuario { get; set; }

    }

    public class InsertMovimientosModel
    {
        public int IdAlmacen { get; set; }
        public int TipoMovimiento { get; set; }
        public int UsuarioRegistra { get; set; }
        public int UsuarioAutoriza { get; set; }
        public int UsuarioActualiza { get; set; }


    }

    public class UpdateMovimientosModel
    {
        public int Id { get; set; }
        public int IdAlmacen { get; set; }
        public int TipoMovimiento { get; set; }
        public int Estatus { get; set; }
        public int UsuarioRegistra { get; set; }
        public int UsuarioAutoriza { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateMovimientosAutorizaModel
    {
        public int Id { get; set; }

    }


    public class DeleteMovimientosModel
    {
        public int Id { get; set; }
    }

}
