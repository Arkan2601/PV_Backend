using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

    public class ResponsePersonas
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyPersonas Response { get; set; }
    }

    public class ResponseBodyPersonas
    {
        public List<GetPersonasModel> data { get; set; }
    }
    public class GetPersonasModel
    {
        public int Id { get; set; }
        public string TipoPersona { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Sexo { get; set; }
        public string FechaNac { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string ECivil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Sucursal { get; set; }
        public string Titulo { get; set; }
        public string Actualizado { get; set; }
        public string FechaHora { get; set; }
        public string Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Usuario_Ligado { get; set; }

        public string Mensaje { get; set; }


    }
    public class InsertPersonasModel
    {
        public int TipoPersona { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNac { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string ECivil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public int Sucursal { get; set; }
        public string Titulo { get; set; }
        public int Actualizado { get; set; }
        public int UsuarioActualiza { get; set; }

        public string Pass { get; set; }
    }
    public class UpdatePersonasModel
    {
        public int Id { get; set; }
        public int TipoPersona { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNac { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string ECivil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public int Sucursal { get; set; }
        public string Titulo { get; set; }
        public int Actualizado { get; set; }
        public int UsuarioActualiza { get; set; }

    }
    public class DeletePersonasModel
    {
        public int Id { get; set; }
    }
}
