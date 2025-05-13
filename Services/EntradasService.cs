using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class EntradasService
    {
        private string connection;
        public EntradasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<GetEntradasModel> InsertEntradas(InsertEntradasModel entradas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEntradasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdProveedor", SqlDbType = SqlDbType.Int, Value = entradas.IdProveedor });
                parametros.Add(new SqlParameter { ParameterName = "@pFactura", SqlDbType = SqlDbType.VarChar, Value = entradas.Factura });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.Int, Value = entradas.IdSurcursal });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = entradas.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertEntradas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEntradasModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Mensaje = row["Mensaje"].ToString()
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

        public List<GetEntradasModel> GetEntradas()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEntradasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetEntradas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEntradasModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Proveedor = row["Proveedor"].ToString(),
                            Factura = row["Factura"].ToString(),
                            Surcursal = row["Sucursal"].ToString(),
                            FechaEntrega = row["FechaEntrega"].ToString(),
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

        public string UpdateEntradas(UpdateEntradasModel entradas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = entradas.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdProveedor", SqlDbType = SqlDbType.VarChar, Value = entradas.IdProveedor });
                parametros.Add(new SqlParameter { ParameterName = "@pFactura", SqlDbType = SqlDbType.VarChar, Value = entradas.Factura });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.Int, Value = entradas.IdSurcursal });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaEntrega", SqlDbType = SqlDbType.Date, Value = entradas.FechaEntrega });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = entradas.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateEntradas", parametros);
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

        public string DeleteEntradas(DeleteEntradasModel entradas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = entradas.Id });
                DataSet ds = dac.Fill("sp_DeleteEntradas", parametros);
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
