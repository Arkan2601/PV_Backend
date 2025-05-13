using System;
using System.Collections.Generic;
namespace marcatel_api.Models


{
      public class ResponseDepa
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyCfgDepartamentos Response { get; set; }
    }

    public class ResponseBodyCfgDepartamentos
    {
        public List<GetCfgDepartamentosModel> data { get; set; }
    }
     public class InsertCfgDepartamentosModel
    {
        public string Nombre { get; set; }
        public int Extension { get; set; }
        public int IdPersona { get; set; }
        public string Abreviatura { get; set; }
        public int UsuarioActualiza { get; set; }
        

    }





    public class GetCfgDepartamentosModel
    {
        public int Id { get; set; }
        public string NOMBRE { get; set; }
        public string EXTENSION { get; set; }
       public string ID_PERSONA { get; set; }
       public string ABREVIATURA { get; set; }
       public string HORA { get; set; }
       public string FECHA { get; set; }
        public string UsuarioActualiza { get; set; }

        //public string Mensaje { get; set; }

    }

    

    public class UpdateCfgDepartamentosModel
    {
        public int Id { get; set; }
       public string Nombre { get; set; }
        public int Extension { get; set; }
        public int IdPersona { get; set; }
        public string Abreviatura { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    


    public class DeleteCfgDepartamentosModel
    {
        public int Id { get; set; }
    }

}