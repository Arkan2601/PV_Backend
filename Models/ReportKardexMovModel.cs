using System;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace marcatel_api.Models
{
    public class GetReportKardexMovModel
    {
        public int Id { get; set; }
        public int Movimiento_Ligado { get; set; }
        public string TipoMovimiento { get; set; }
        public string Sucursal { get; set; }
        public string Insumo { get; set; }
        public decimal Cantidad { get; set; }
        public string Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }

        // Use JsonIgnore to prevent serialization
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
        [SwaggerSchema(WriteOnly = true)] // Indicate these fields are for input, not output
        public string FechaInicio { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
        [SwaggerSchema(WriteOnly = true)] // Indicate these fields are for input, not output
        public string FechaFinal { get; set; }
    }
}



