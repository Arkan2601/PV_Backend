using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
     public class ResponsDetalleUsuarios
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyDetalleUsuarios Response { get; set; }
    }

    public class ResponseBodyDetalleUsuarios
    {
        public List<GetDetalleUsuariosModel> data { get; set; }
    }
    public class GetDetalleUsuariosModel
    {
        public int Id { get; set; }
        public string Usuario  { get; set; }
          public string Modulo  { get; set; }
          
              public string Categoria  { get; set; }
              public string SOLO_SUCURSAL  { get; set; }
              public string REGISTROS_PROPIOS  { get; set; }
              public string SOLO_LECTURA  { get; set; }
        public string FechaRegistro { get; set; }
          public string Estado  { get; set; }
        public string UsuarioActualiza { get; set; }

    }

    public class InsertDetalleUsuariosModel
    {
        public int IdUsuario { get; set; }
          public int IdModulo { get; set; }
            public int IdCategoria { get; set; }
              public int SoloSucursal { get; set; }
                public int RegistrosPropios { get; set; }
                  public int SoloLectura { get; set; }
                        public int UsuarioActualiza { get; set; }
  

    }

    public class UpdateDetalleUsuariosModel
    {
        public int ID { get; set; }
         public int IDUSUARIO { get; set; }
          public int IDMODULO { get; set; }
           public int IDCATEGORIA { get; set; }
            public int SOLOSUCURSAL { get; set; }
             public int REGISTROSPROPIOS { get; set; }
              public int SOLOLECTURA { get; set; }
              public int ACTIVO { get; set; }
             
    
        public int UsuarioActualiza {get; set;}

    }

    public class DeleteDetalleUsuariosModel
    {
        public int Id { get; set; }
    }
    }
