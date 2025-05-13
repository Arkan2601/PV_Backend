using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class PersonasService
    {
        private string connection;
        public PersonasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertPersonas(InsertPersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pTipo_Persona", SqlDbType = SqlDbType.Int, Value = personas.TipoPersona });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = personas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pSexo", SqlDbType = SqlDbType.VarChar, Value = personas.Sexo });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaNac", SqlDbType = SqlDbType.Date, Value = personas.FechaNac });
                parametros.Add(new SqlParameter { ParameterName = "@pRFC", SqlDbType = SqlDbType.VarChar, Value = personas.RFC });
                parametros.Add(new SqlParameter { ParameterName = "@pCURP", SqlDbType = SqlDbType.VarChar, Value = personas.CURP });
                parametros.Add(new SqlParameter { ParameterName = "@pECIVIL", SqlDbType = SqlDbType.VarChar, Value = personas.ECivil });
                parametros.Add(new SqlParameter { ParameterName = "@pEMail", SqlDbType = SqlDbType.VarChar, Value = personas.Email });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefono", SqlDbType = SqlDbType.VarChar, Value = personas.Telefono });
                parametros.Add(new SqlParameter { ParameterName = "@pColonia", SqlDbType = SqlDbType.VarChar, Value = personas.Colonia });
                parametros.Add(new SqlParameter { ParameterName = "@pCalle", SqlDbType = SqlDbType.VarChar, Value = personas.Calle });
                parametros.Add(new SqlParameter { ParameterName = "@pNumero", SqlDbType = SqlDbType.VarChar, Value = personas.Numero });
                parametros.Add(new SqlParameter { ParameterName = "@pMunicipio", SqlDbType = SqlDbType.VarChar, Value = personas.Municipio });
                parametros.Add(new SqlParameter { ParameterName = "@pEstado", SqlDbType = SqlDbType.VarChar, Value = personas.Estado });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigoPostal", SqlDbType = SqlDbType.VarChar, Value = personas.CodigoPostal });
                parametros.Add(new SqlParameter { ParameterName = "@pSucursal", SqlDbType = SqlDbType.Int, Value = personas.Sucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pTitulo", SqlDbType = SqlDbType.VarChar, Value = personas.Titulo });
                parametros.Add(new SqlParameter { ParameterName = "@pActualizado", SqlDbType = SqlDbType.VarChar, Value = personas.Actualizado });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = personas.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pPass", SqlDbType = SqlDbType.VarChar, Value = personas.Pass });
                DataSet ds = dac.Fill("sp_InsertPersonas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public List<GetPersonasModel> GetPersonas()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetPersonasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetPersonas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetPersonasModel
                        {
                            Id = int.Parse(row["ID"].ToString()),
                            TipoPersona = row["TIPO_PERSONA"].ToString(),
                            Nombre = row["NOMBRE"].ToString(),
                            ApPaterno = row["AP_PATERNO"].ToString(),
                            ApMaterno = row["AP_MATERNO"].ToString(),
                            Sexo = row["SEXO"].ToString(),
                            FechaNac = row["FECHANACIMIENTO"].ToString(),
                            RFC = row["RFC"].ToString(),
                            CURP = row["CURP"].ToString(),
                            ECivil = row["ECIVIL"].ToString(),
                            Email = row["EMAIL"].ToString(),
                            Telefono = row["TELEFONO"].ToString(),
                            Colonia = row["COLONIA"].ToString(),
                            Calle = row["CALLE"].ToString(),
                            Numero = row["NUMERO"].ToString(),
                            Municipio = row["MUNICIPIO"].ToString(),
                            Estado = row["ESTADO"].ToString(),
                            CodigoPostal = row["CODIGOPOSTAL"].ToString(),
                            Sucursal = row["SUCURSAL"].ToString(),
                            Titulo = row["TITULO"].ToString(),
                            Actualizado = row["ACTUALIZADO"].ToString(),
                            FechaHora = row["FECHAHORA"].ToString(),
                            Estatus = row["ACTIVO"].ToString(),
                            UsuarioActualiza = row["USUARIOACTUALIZA"].ToString(),
                            Usuario_Ligado = row["USUARIOLIGADO"].ToString(),

                        });
                    }
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public string UpdatePersonas(UpdatePersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = personas.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pTipo_Persona", SqlDbType = SqlDbType.Int, Value = personas.TipoPersona });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = personas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pSexo", SqlDbType = SqlDbType.VarChar, Value = personas.Sexo });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaNac", SqlDbType = SqlDbType.Date, Value = personas.FechaNac });
                parametros.Add(new SqlParameter { ParameterName = "@pRFC", SqlDbType = SqlDbType.VarChar, Value = personas.RFC });
                parametros.Add(new SqlParameter { ParameterName = "@pCURP", SqlDbType = SqlDbType.VarChar, Value = personas.CURP });
                parametros.Add(new SqlParameter { ParameterName = "@pECIVIL", SqlDbType = SqlDbType.VarChar, Value = personas.ECivil });
                parametros.Add(new SqlParameter { ParameterName = "@pEMail", SqlDbType = SqlDbType.VarChar, Value = personas.Email });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefono", SqlDbType = SqlDbType.VarChar, Value = personas.Telefono });
                parametros.Add(new SqlParameter { ParameterName = "@pColonia", SqlDbType = SqlDbType.VarChar, Value = personas.Colonia });
                parametros.Add(new SqlParameter { ParameterName = "@pCalle", SqlDbType = SqlDbType.VarChar, Value = personas.Calle });
                parametros.Add(new SqlParameter { ParameterName = "@pNumero", SqlDbType = SqlDbType.VarChar, Value = personas.Numero });
                parametros.Add(new SqlParameter { ParameterName = "@pMunicipio", SqlDbType = SqlDbType.VarChar, Value = personas.Municipio });
                parametros.Add(new SqlParameter { ParameterName = "@pEstado", SqlDbType = SqlDbType.VarChar, Value = personas.Estado });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigoPostal", SqlDbType = SqlDbType.VarChar, Value = personas.CodigoPostal });
                parametros.Add(new SqlParameter { ParameterName = "@pSucursal", SqlDbType = SqlDbType.Int, Value = personas.Sucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pTitulo", SqlDbType = SqlDbType.VarChar, Value = personas.Titulo });
                parametros.Add(new SqlParameter { ParameterName = "@pActualizado", SqlDbType = SqlDbType.VarChar, Value = personas.Actualizado });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = personas.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdatePersona", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public string DeletePersonas(DeletePersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = personas.Id });
                DataSet ds = dac.Fill("sp_DeletePersonas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }


    }
}
