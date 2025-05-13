using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class CfgDepartamentosService
    {
        private string connection;
        public CfgDepartamentosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


 public string InsertCfgDepartamentos(InsertCfgDepartamentosModel cfgDepartamentos)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = cfgDepartamentos.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pExtension", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.Extension });
        parametros.Add(new SqlParameter { ParameterName = "@IdPersona", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.IdPersona});
        parametros.Add(new SqlParameter { ParameterName = "@Abreviatura", SqlDbType = SqlDbType.VarChar, Value = cfgDepartamentos.Abreviatura });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.UsuarioActualiza });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertCfgDepartamentos", parametros);

        // Asegúrate de que hay al menos una tabla devuelta
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["Mensaje"].ToString(); // Retorna el mensaje del SP
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

    // Retorno por defecto
    return "Error: Ocurrió un problema al insertar la unidad de medida."; // Valor por defecto en caso de fallo
}

        public List<GetCfgDepartamentosModel> GetCfgDepartamentos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCfgDepartamentosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetCfgDepartamentos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetCfgDepartamentosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NOMBRE= row["NOMBRE"].ToString(),
                            EXTENSION= row["EXTENSION"].ToString(),
                            ID_PERSONA = row["ID_PERSONA"].ToString(),
                            ABREVIATURA = row["ABREVIATURA"].ToString(),
                            HORA = row["HORA"].ToString(),
                            FECHA = row["FECHA"].ToString(),
                            UsuarioActualiza = row["USUARIO"].ToString()
                            
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

        public string UpdateCfgDepartamentos(UpdateCfgDepartamentosModel cfgDepartamentos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateCfgDepartamentosModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.Id });
         parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = cfgDepartamentos.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pExtension", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.Extension });
        parametros.Add(new SqlParameter { ParameterName = "@IdPersona", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.IdPersona});
        parametros.Add(new SqlParameter { ParameterName = "@Abreviatura", SqlDbType = SqlDbType.VarChar, Value = cfgDepartamentos.Abreviatura });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateCfgDepartamentos", parametros);
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




          


        public string DeleteCfgDepartamentos(DeleteCfgDepartamentosModel cfgDepartamentos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteCfgDepartamentosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = cfgDepartamentos.Id });
                DataSet ds = dac.Fill("sp_DeleteCfgDepartamentos", parametros);
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