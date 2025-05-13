using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;


namespace marcatel_api.Services
{
    public class DetalleRecetaService
    {
        private string connection;
        public DetalleRecetaService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<GetDetalleRecetaModel> GetDetalleReceta(GetDetalleRecetaModel dr)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleRecetaModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdReceta", SqlDbType = SqlDbType.Int, Value = dr.IdReceta });

                DataSet ds = dac.Fill("sp_GetDetalleReceta", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleRecetaModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdReceta = int.Parse(row["IdReceta"].ToString()),
                            Insumo = row["Insumo"].ToString(),
                            Descripcion = row["Descripcion"].ToString(),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            FechaAct = row["FechaActualiza"].ToString(),
                            FechaReg = row["FechaRegistro"].ToString(),
                            UsuarioAct = row["UsuarioActualiza"].ToString()

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

        public string InsertDetalleReceta(InsertDetalleRecetaModel dr)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleRecetaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdReceta", SqlDbType = SqlDbType.Int, Value = dr.IdReceta });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = dr.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = dr.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = dr.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertDetalleReceta", parametros);

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

        public string UpdateDetalleReceta(UpdateDetalleRecetaModel dr)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleRecetaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = dr.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = dr.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = dr.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = dr.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = dr.Estatus });
                DataSet ds = dac.Fill("sp_UpdateDetalleReceta", parametros);
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

        public string DeleteDetalleReceta(DeleteDetalleRecetaModel dr)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleRecetaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = dr.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleReceta", parametros);
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
