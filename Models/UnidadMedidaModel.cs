using System;
using System.Collections.Generic;
namespace marcatel_api.Models


{
      public class ResponseUM
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyUM Response { get; set; }
    }

    public class ResponseBodyUM
    {
        public List<GetUnidadMedidaModel> data { get; set; }
    }
     public class InsertUnidadMedidaModel
    {
        public string Nombre { get; set; }
        public int UsuarioActualiza { get; set; }
        

    }





    public class GetUnidadMedidaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaRegistro { get; set; }
       public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }

        //public string Mensaje { get; set; }

    }

    

    public class UpdateUnidadMedidaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    


    public class DeleteUnidadMedidaModel
    {
        public int Id { get; set; }
    }

}