using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

 public class ResponseModulos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyModulos Response { get; set; }
    }

    public class ResponseBodyModulos
    {
        public List<GetModulosModel> data { get; set; }
    }

    public class GetModulosModel
    {
        public int Id {get; set;}
        public string Modulo {get; set;}
        public string Ruta {get; set;}
        public string Descripcion {get; set;}
        public int PanelControl {get; set;}
        public string Categoria {get; set;}
        public string Icono {get; set;}
        public string Tema {get; set;}
        public string FechaHora {get; set;}
        public string Usuario {get; set;}
    }
    public class InsertModulosModel
    {
        public string NombreModulo {get; set;}
        public string Ruta {get; set;}
        public string Descripcion {get; set;}
        public int PanelControl {get; set;}
        public int Categoria {get; set;}
        public string Icono {get; set;}
        public string Tema {get; set;}
        public int Usuario {get; set;}
  
    } 
    public class UpdateModulosModel
    {
        public int Id {get; set;}
        public string NombreModulo {get; set;}
        public string Ruta {get; set;}
        public string Descripcion {get; set;}
        public int PanelControl {get; set;}
        public int Categoria {get; set;}
        public string Icono {get; set;}
        public string Tema {get; set;}
        public int Usuario {get; set;}
    }
    public class DeleteModulosModel
    {
        public int Id {get; set;}
    }
}
