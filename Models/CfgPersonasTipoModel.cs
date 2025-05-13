using System;
using System.Collections.Generic;
namespace marcatel_api.Models


{
      public class ResponsePersonasT
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyCfgPersonasT Response { get; set; }
    }

    public class ResponseBodyCfgPersonasT
    {
        public List<GetCfgPersonasTModel> data { get; set; }
    }
     public class InsertCfgPersonasTModel
    {
        public string TIPO { get; set; }
        public string CATEGORIA { get; set; }
        public int USUARIO { get; set; }
        

    }





    public class GetCfgPersonasTModel
    {
        public int ID { get; set; }
        public string TIPO { get; set; }
        public string CATEGORIA { get; set; }
       public string FECHA { get; set; }
       public string HORA { get; set; }
        public string USUARIO { get; set; }

        //public string Mensaje { get; set; }

    }

    

    public class UpdateCfgPersonasTModel
    {
        public int ID { get; set; }
        public string TIPO { get; set; }
        public string CATEGORIA { get; set; }
        public int USUARIO { get; set; }

    }

    


    public class DeleteCfgPersonasTModel
    {
        public int ID { get; set; }
    }

}