using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;


namespace marcatel_api.Services
{
    public class DetalleMovimientosService
    {
        private string connection;
        public DetalleMovimientosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<GetDetalleMovimientosModel> GetDetalleMovimientos(GetDetalleMovimientosModel dm)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleMovimientosModel>();
            if (string.IsNullOrEmpty(dm.FechaInicio))
             {
                dm.FechaInicio = DateTime.MinValue.ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(dm.FechaFin))
            {
                dm.FechaFin = DateTime.MaxValue.ToString("yyyy-MM-dd");
            }
            try
            {
                
                parametros.Add(new SqlParameter { ParameterName = "@pFechaInicio", SqlDbType = SqlDbType.Date, Value = dm.FechaInicio });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaFin", SqlDbType = SqlDbType.Date, Value = dm.FechaFin });

                DataSet ds = dac.Fill("sp_GetDetalleMovimientos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleMovimientosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdMovimiento = int.Parse(row["IdMovimiento"].ToString()),
                            CodigoInsumo = row["CodigoInsumo"].ToString(),
                            DescripcionInsumo =row["DescripcionInsumo"].ToString(),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString()

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

        public string InsertDetalleMovimientos(InsertDetalleMovimientosModel dm)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdMovimiento", SqlDbType = SqlDbType.Int, Value = dm.IdMovimiento });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = dm.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = dm.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = dm.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertDetalleMovimientos", parametros);

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

        public string UpdateDetalleMovimientos(UpdateDetalleMovimientosModel dm)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = dm.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = dm.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = dm.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = dm.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = dm.Estatus });
                DataSet ds = dac.Fill("sp_UpdateDetalleMovimientos", parametros);
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

        public string DeleteDetalleMovimientos(DeleteDetalleMovimientosModel dm)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = dm.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleMovimientos", parametros);
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