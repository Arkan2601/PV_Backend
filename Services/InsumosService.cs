using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class InsumosService
    {
        private string connection;
        public InsumosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertInsumos(InsertInsumosModel insumos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertInsumosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = insumos.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcionInsumo", SqlDbType = SqlDbType.VarChar, Value = insumos.DescripcionInsumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCosto", SqlDbType = SqlDbType.Decimal, Value = insumos.Costo });
                parametros.Add(new SqlParameter { ParameterName = "@pUnidadMedida", SqlDbType = SqlDbType.Int, Value = insumos.UnidadMedida });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = insumos.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumosUP", SqlDbType = SqlDbType.VarChar, Value = insumos.InsumosUP });


                DataSet ds = dac.Fill("sp_InsertInsumos", parametros);
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

        public List<GetInsumosModel> GetInsumos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetInsumosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetInsumos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetInsumosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Insumo= row["Insumo"].ToString(),
                            Descripcion= row["Descripcion"].ToString(),
                            Costo= decimal.Parse(row["Costo"].ToString()),
                            UnidadMedida = row["UnidadMedida"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString(),
                            InsumosUP = row["InsumosUP"].ToString()
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

        public string UpdateInsumos(UpdateInsumosModel insumos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateInsumosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = insumos.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = insumos.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcionInsumo", SqlDbType = SqlDbType.VarChar, Value = insumos.DescripcionInsumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCosto", SqlDbType = SqlDbType.Decimal, Value = insumos.Costo });
                parametros.Add(new SqlParameter { ParameterName = "@pUnidadMedida", SqlDbType = SqlDbType.Int, Value = insumos.UnidadMedida });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = insumos.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumosUP", SqlDbType = SqlDbType.VarChar, Value = insumos.InsumosUP });


                DataSet ds = dac.Fill("sp_UpdateInsumos", parametros);
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

        public string DeleteInsumos(DeleteInsumosModel insumos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteInsumosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = insumos.Id });
                DataSet ds = dac.Fill("sp_DeleteInsumos", parametros);
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