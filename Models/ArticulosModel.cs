using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

    public class ResponseArticulos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyArt Response { get; set; }
    }

    public class ResponseBodyArt
    {
        public List<GetArticulosModel> data { get; set; }
    }
    public class GetArticulosModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Familia { get; set; }
        public string UM { get; set; }
        public string UltimoCosto { get; set; }
        public string PrecioVenta { get; set; }
        public string Iva { get; set; }
        public string Ieps { get; set; }
        public string Usuario { get; set; }
        public string FechaAct { get; set; }
        public string FechaReg { get; set; }


    }
    public class InsertArticulosModel
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdFamilia { get; set; }
        public int IdUM { get; set; }
        public decimal UltimoCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IVA { get; set; }
        public int IEPS { get; set; }
        public int IdUsuario { get; set; }
    }
    public class UpdateArticulosModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdFamilia { get; set; }
        public int IdUM { get; set; }
        public decimal UltimoCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IVA { get; set; }
        public int IEPS { get; set; }
        public int IdUsuario { get; set; }
    }
    public class DeleteArticulosModel
    {
        public int Id { get; set; }
    }
}
