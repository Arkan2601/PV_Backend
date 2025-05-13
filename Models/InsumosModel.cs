using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

  public class ResponseInsumos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyInsumos Response { get; set; }
    }

    public class ResponseBodyInsumos
    {
        public List<GetInsumosModel> data { get; set; }
    }

public class InsertInsumosModel
    {
        public string Insumo { get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        public int UsuarioActualiza { get; set; }
         public string InsumosUP { get; set; }
    }


    public class GetInsumosModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public string UnidadMedida { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        public string InsumosUP { get; set; }

    }

    

    public class UpdateInsumosModel
    {
        public int Id { get; set; }
        public string Insumo { get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        // public int Estatus { get; set; }
        public int UsuarioActualiza { get; set; }
        public string InsumosUP { get; set; }
        //public DateTime FechaActualiza { get; set; }

    }

    public class DeleteInsumosModel
    {
        public int Id { get; set; }
    }

}