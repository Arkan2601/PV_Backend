using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class CfgPersonasTService
    {
        private string connection;
        public CfgPersonasTService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


 public string InsertCfgPersonastipo(InsertCfgPersonasTModel cfgPersonasT)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pTIPO", SqlDbType = SqlDbType.VarChar, Value = cfgPersonasT.TIPO });
        parametros.Add(new SqlParameter { ParameterName = "@pCATEGORIA", SqlDbType = SqlDbType.VarChar, Value = cfgPersonasT.CATEGORIA });
        parametros.Add(new SqlParameter { ParameterName = "@pUSUARIO", SqlDbType = SqlDbType.Int, Value = cfgPersonasT.USUARIO });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertCfgpersonastipo", parametros);

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

        public List<GetCfgPersonasTModel> GetCfgPersonasT()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCfgPersonasTModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetCfgpersonastipo", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetCfgPersonasTModel
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            TIPO = row["TIPO"].ToString(),
                            CATEGORIA = row["CATEGORIA"].ToString(),
                            FECHA = row["FECHA"].ToString(),
                            HORA = row["HORA"].ToString(),
                            USUARIO = row["USUARIO"].ToString()
                            
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

        public string UpdateCfgPersonasT(UpdateCfgPersonasTModel cfgPersonasT)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateCfgPersonasTModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pID", SqlDbType = SqlDbType.Int, Value = cfgPersonasT.ID });
        parametros.Add(new SqlParameter { ParameterName = "@pTIPO", SqlDbType = SqlDbType.VarChar, Value = cfgPersonasT.TIPO });
        parametros.Add(new SqlParameter { ParameterName = "@pCATEGORIA", SqlDbType = SqlDbType.VarChar, Value = cfgPersonasT.CATEGORIA });
        parametros.Add(new SqlParameter { ParameterName = "@pUSUARIO", SqlDbType = SqlDbType.Int, Value = cfgPersonasT.USUARIO });

                DataSet ds = dac.Fill("sp_UpdateCfgpersonastipo", parametros);
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




          


        public string DeleteCfgPersonasT(DeleteCfgPersonasTModel cfgPersonasT)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteCfgPersonasTModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pID", SqlDbType = SqlDbType.Int, Value = cfgPersonasT.ID });
                DataSet ds = dac.Fill("sp_DeleteCfgpersonastipo", parametros);
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