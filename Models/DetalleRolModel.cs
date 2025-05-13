using System;
using System.Collections.Generic;
namespace marcatel_api.Models


{
    public class ResponseDetalleRol
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyDetalleRol Response { get; set; }
    }

    public class ResponseBodyDetalleRol
    {
        public List<GetDetalleRolModel> data { get; set; }
    }
    public class InsertDetalleRolModel
    {
        public int IdRol { get; set; }
        public int IdModulo { get; set; }
        public int UsuarioActualiza { get; set; }


    }





    public class GetDetalleRolModel
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string Modulo { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Estatus { get; set; }

        //public string Mensaje { get; set; }

    }



    public class UpdateDetalleRolModel
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdModulo { get; set; }
        public int UsuarioActualiza { get; set; }
        public int Estatus { get; set; }

    }




    public class DeleteDetalleRolModel
    {
        public int Id { get; set; }
    }

}