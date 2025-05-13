using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class CfgColaboradoresService
    {
        private string connection;
        public CfgColaboradoresService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


 public string InsertCfgColaboradores(InsertCfgColaboradoresModel cfgColaboradores)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pNumEmpleado", SqlDbType = SqlDbType.VarChar, Value = cfgColaboradores.NumEmpleado });
        parametros.Add(new SqlParameter { ParameterName = "@pIdPersona", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdPersona });
        parametros.Add(new SqlParameter { ParameterName = "@IdSede", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdSede });
        parametros.Add(new SqlParameter { ParameterName = "@IdPeriodo", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdPeriodo });
        parametros.Add(new SqlParameter { ParameterName = "@IdDepartamento", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdDepartamento });
        parametros.Add(new SqlParameter { ParameterName = "@IdPuesto", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdPuesto });
        parametros.Add(new SqlParameter { ParameterName = "@TipoPersona", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.TipoPersona });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.UsuarioActualiza });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertCfgColaboradores", parametros);

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

        public List<GetCfgColaboradoresModel> GetCfgColaboradores()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCfgColaboradoresModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetCfgColaboradores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetCfgColaboradoresModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NUM_EMPLEADO= row["NUM_EMPLEADO"].ToString(),
                            ID_PERSONA= row["ID_PERSONA"].ToString(),
                            ID_SEDE = row["ID_SEDE"].ToString(),
                            ID_PERIODO = row["ID_PERIODO"].ToString(),
                            ID_DEPARTAMENTO = row["ID_DEPARTAMENTO"].ToString(),
                            ID_PUESTO = row["ID_PUESTO"].ToString(),
                            TIPO_PERSONA = row["TIPO_PERSONA"].ToString(),
                            FECHA_INGRESO = row["FECHA_INGRESO"].ToString(),
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

        public string UpdateCfgColaboradores(UpdateCfgColaboradoresModel cfgColaboradores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateCfgColaboradoresModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.Id });
         parametros.Add(new SqlParameter { ParameterName = "@pNumEmpleado", SqlDbType = SqlDbType.VarChar, Value = cfgColaboradores.NumEmpleado });
        parametros.Add(new SqlParameter { ParameterName = "@pIdPersona", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdPersona });
        parametros.Add(new SqlParameter { ParameterName = "@IdSede", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdSede });
        parametros.Add(new SqlParameter { ParameterName = "@IdPeriodo", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdPeriodo });
        parametros.Add(new SqlParameter { ParameterName = "@IdDepartamento", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdDepartamento });
        parametros.Add(new SqlParameter { ParameterName = "@IdPuesto", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.IdPuesto });
        parametros.Add(new SqlParameter { ParameterName = "@TipoPersona", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.TipoPersona });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateCfgColaboradores", parametros);
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




          


        public string DeleteCfgColaboradores(DeleteCfgColaboradoresModel cfgColaboradores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteCfgColaboradoresModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = cfgColaboradores.Id });
                DataSet ds = dac.Fill("sp_DeleteCfgColaboradores", parametros);
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