using System;
namespace marcatel_api.Models
{

    public class UpdateImagenModel
    {   
        public int Id{get; set;}
        public string ImagenData { get; set; } 
    }
    public class DeleteImagenModel
    {
        public int Id { get; set; }
    }
}
