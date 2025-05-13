using System;
using System.Collections.Generic;
namespace marcatel_api.Models



{

    public class ResponseDetalleReceta
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyDR Response { get; set; }
    }

    public class ResponseBodyDR
    {
        public List<GetDetalleRecetaModel> data { get; set; }
    }
    public class GetDetalleRecetaModel
    {
        public int Id { get; set; }
        public int IdReceta { get; set; }
        public string Insumo { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public string FechaReg { get; set; }
        public string FechaAct { get; set; }
        public string UsuarioAct { get; set; }
        public string Mensaje { get; set; }
        

    }

    public class InsertDetalleRecetaModel
    {
        public int IdReceta { get; set; }
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class UpdateDetalleRecetaModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public int UsuarioActualiza { get; set; }
        public int Estatus { get; set; }

    }

    public class DeleteDetalleRecetaModel
    {
        public int Id { get; set; }
    }


}