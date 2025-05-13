using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
     public class ResponseRecetas
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyRecetas Response { get; set; }
    }

    public class ResponseBodyRecetas
    {
        public List<GetRecetasModel> data { get; set; }
    }
    public class GetRecetasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaActualiza { get; set; }
       public string UsuarioRegistra { get; set; }
        public string UsuarioActualiza { get; set; }

        public string Mensaje { get; set; }

    }

    public class InsertRecetasModel
    {
        public string Nombre { get; set; }
         public int UsuarioRegistra { get; set; } 
        public int UsuarioActualiza { get; set; }

    }

    public class UpdateRecetasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioActualiza {get; set;}

    }

    public class DeleteRecetasModel
    {
        public int Id { get; set; }
    }

}