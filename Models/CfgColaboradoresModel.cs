using System;
using System.Collections.Generic;
namespace marcatel_api.Models


{
      public class ResponseColabo
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyCfgColaboradores Response { get; set; }
    }

    public class ResponseBodyCfgColaboradores
    {
        public List<GetCfgColaboradoresModel> data { get; set; }
    }
     public class InsertCfgColaboradoresModel
    {
        public string NumEmpleado { get; set; }
        public int IdPersona { get; set; }
        public int IdSede { get; set; }
        public int IdPeriodo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdPuesto { get; set; }
        public int TipoPersona { get; set; }
        public int UsuarioActualiza { get; set; }
        

    }





    public class GetCfgColaboradoresModel
    {
        public int Id { get; set; }
        public string NUM_EMPLEADO { get; set; }
        public string ID_PERSONA { get; set; }
       public string ID_SEDE { get; set; }
       public string ID_PERIODO { get; set; }
       public string ID_DEPARTAMENTO { get; set; }
       public string ID_PUESTO { get; set; }
       public string TIPO_PERSONA { get; set; }
       public string FECHA_INGRESO { get; set; }
        public string UsuarioActualiza { get; set; }

        //public string Mensaje { get; set; }

    }

    

    public class UpdateCfgColaboradoresModel
    {
        public int Id { get; set; }
       public string NumEmpleado { get; set; }
        public int IdPersona { get; set; }
        public int IdSede { get; set; }
        public int IdPeriodo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdPuesto { get; set; }
        public int TipoPersona { get; set; }
        public int UsuarioActualiza { get; set; }

    }

    


    public class DeleteCfgColaboradoresModel
    {
        public int Id { get; set; }
    }

}