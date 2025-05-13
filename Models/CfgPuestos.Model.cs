using System;
using System.Collections.Generic;
namespace marcatel_api.Models


{
      public class ResponsePuestos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyCfgPuestos Response { get; set; }
    }

    public class ResponseBodyCfgPuestos
    {
        public List<GetCfgPuestosModel> data { get; set; }
    }
     public class InsertCfgPuestosModel
    {
        public string PUESTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int USUARIO { get; set; }
        

    }





    public class GetCfgPuestosModel
    {
        public int Id { get; set; }
        public string PUESTO { get; set; }
        public string DESCRIPCION { get; set; }
       public string FECHAHORA { get; set; }
        public string USUARIO { get; set; }

        //public string Mensaje { get; set; }

    }

    

    public class UpdateCfgPuestosModel
    {
        public int Id { get; set; }
       public string PUESTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int USUARIO { get; set; }

    }

    


    public class DeleteCfgPuestosModel
    {
        public int Id { get; set; }
    }

}