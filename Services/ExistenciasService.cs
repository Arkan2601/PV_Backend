using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ExistenciasService
    {
        private string connection;
        public ExistenciasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }
        public string InsertExistencias(InsertExistenciasModel existencias)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = existencias.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = existencias.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = existencias.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = existencias.UsuarioActualiza });




                DataSet ds = dac.Fill("sp_InsertExistencias", parametros);
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

        public List<GetExistenciasModel> GetExistencias()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetExistenciasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetExistencias", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetExistenciasModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Insumo = row["Insumo"].ToString(),
                            IdAlmacen = int.Parse(row["IdAlmacen"].ToString()),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            Fecha = row["Fecha"].ToString(),
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString(),
                           
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

        public string UpdateExistencias(UpdateExistenciasModel existencias)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = existencias.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = existencias.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = existencias.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = existencias.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = existencias.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateExistencias", parametros);
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

        public string DeleteExistencias(DeleteExistenciasModel existencias)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = existencias.Id });
                DataSet ds = dac.Fill("sp_DeleteExistencias", parametros);
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