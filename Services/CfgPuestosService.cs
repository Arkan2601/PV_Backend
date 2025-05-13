using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class CfgPuestosService
    {
        private string connection;
        public CfgPuestosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


 public string InsertCfgPuestos(InsertCfgPuestosModel cfgPuestos)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pPUESTO", SqlDbType = SqlDbType.VarChar, Value = cfgPuestos.PUESTO });
        parametros.Add(new SqlParameter { ParameterName = "@pDESCRIPCION", SqlDbType = SqlDbType.VarChar, Value = cfgPuestos.DESCRIPCION });
        parametros.Add(new SqlParameter { ParameterName = "@pUSUARIO", SqlDbType = SqlDbType.Int, Value = cfgPuestos.USUARIO });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertCfgpuestos", parametros);

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

        public List<GetCfgPuestosModel> GetCfgPuestos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCfgPuestosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetCfgpuestos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetCfgPuestosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            PUESTO = row["PUESTO"].ToString(),
                            DESCRIPCION = row["DESCRIPCION"].ToString(),
                            FECHAHORA = row["FECHAHORA"].ToString(),
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

        public string UpdateCfgPuestos(UpdateCfgPuestosModel cfgPuestos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateCfgPuestosModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = cfgPuestos.Id });
         parametros.Add(new SqlParameter { ParameterName = "@pPUESTO", SqlDbType = SqlDbType.VarChar, Value = cfgPuestos.PUESTO });
        parametros.Add(new SqlParameter { ParameterName = "@pDESCRIPCION", SqlDbType = SqlDbType.VarChar, Value = cfgPuestos.DESCRIPCION });
        parametros.Add(new SqlParameter { ParameterName = "@pUSUARIO", SqlDbType = SqlDbType.Int, Value = cfgPuestos.USUARIO });

                DataSet ds = dac.Fill("sp_UpdateCfgpuestos", parametros);
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




          


        public string DeleteCfgPuestos(DeleteCfgPuestosModel cfgPuestos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteCfgPuestosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = cfgPuestos.Id });
                DataSet ds = dac.Fill("sp_DeleteCfgpuestos", parametros);
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