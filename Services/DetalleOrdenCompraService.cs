using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;


namespace marcatel_api.Services
{
    public class DetalleOrdenCompraService
    {
        private string connection;
        public DetalleOrdenCompraService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

public List<GetDetalleOrdenCompraModel> GetDetalleOrdenCompra(GetDetalleOrdenCompraModel DOC)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    var lista = new List<GetDetalleOrdenCompraModel>();
    try
    {
        parametros.Add(new SqlParameter { ParameterName = "@pIdOrdenCompra", SqlDbType = SqlDbType.Int, Value = DOC.IdOrdenCompra });
        // Si el procedimiento almacenado no necesita parámetros, no agregues ninguno
        DataSet ds = dac.Fill("sp_GetDetalleOrdenCompra", parametros);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(new GetDetalleOrdenCompraModel
                {
                    Id = int.Parse(row["Id"].ToString()),
                    IdOrdenCompra = int.Parse(row["IdOrdenCompra"].ToString()),
                    Insumo = row["Insumo"].ToString(),
                    Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                    CantidadRecibida = decimal.Parse(row["CantidadRecibida"].ToString()),
                    Costo = decimal.Parse(row["Costo"].ToString()),
                    CostoRenglon = decimal.Parse(row["CostoRenglon"].ToString()),
                    FechaRegistro = row["FechaRegistro"].ToString(),
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


        public string InsertDetalleOrdenCompra(InsertDetalleOrdenCompraModel DOC)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleOrdenCompraModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdOrdenCompra", SqlDbType = SqlDbType.Int, Value = DOC.IdOrdenCompra });
                parametros.Add(new SqlParameter { ParameterName = "@pInsumo", SqlDbType = SqlDbType.VarChar, Value = DOC.Insumo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = DOC.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = DOC.UsuarioActualiza });
               


                DataSet ds = dac.Fill("sp_InsertDetalleOrdenCompra", parametros);

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

        public string UpdateDetalleOrdenCompra(UpdateDetalleOrdenCompraModel DO)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleOrdenCompraModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = DO.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdOrdenCompra", SqlDbType = SqlDbType.Int, Value = DO.IdOrdenCompra });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidadRecibida", SqlDbType = SqlDbType.Decimal, Value = DO.CantidadRecibida });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = DO.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = DO.Estatus });
                DataSet ds = dac.Fill("sp_UpdateDetalleOrdenCompra", parametros);
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

        public string DeleteDetalleOrdenCompra(DeleteDetalleOrdenCompraModel DO)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleOrdenCompraModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = DO.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleOrdenCompra", parametros);
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
