using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ProveedoresService
    {
        private string connection;
        public ProveedoresService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertProveedores(InsertProveedoresModel proveedores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertProveedoresModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = proveedores.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = proveedores.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefono", SqlDbType = SqlDbType.VarChar, Value = proveedores.Telefono });
                parametros.Add(new SqlParameter { ParameterName = "@pIdBanco", SqlDbType = SqlDbType.Int, Value = proveedores.IdBanco });
               parametros.Add(new SqlParameter { ParameterName = "@pPlazoPago", SqlDbType = SqlDbType.Int, Value = proveedores.PlazoPago });
                parametros.Add(new SqlParameter { ParameterName = "@pCorreo", SqlDbType = SqlDbType.VarChar, Value = proveedores.Correo });
                parametros.Add(new SqlParameter { ParameterName = "@pRFC", SqlDbType = SqlDbType.VarChar, Value = proveedores.RFC });
                parametros.Add(new SqlParameter { ParameterName = "@pRazonSocial", SqlDbType = SqlDbType.VarChar, Value = proveedores.RazonSocial });
                parametros.Add(new SqlParameter { ParameterName = "@pCLABE", SqlDbType = SqlDbType.VarChar, Value = proveedores.CLABE });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = proveedores.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_InsertProveedores", parametros);
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

        public List<GetProveedoresModel> GetProveedores()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetProveedoresModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetProveedores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetProveedoresModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre= row["Nombre"].ToString(),
                            Direccion= row["Direccion"].ToString(),
                            Telefono= row["Telefono"].ToString(),
                            IdBanco = int.Parse(row["IdBanco"].ToString()),
                            PlazoPago = int.Parse(row["PlazoPago"].ToString()),
                            Correo= row["Correo"].ToString(),
                            RFC= row["RFC"].ToString(),
                            RazonSocial= row["RazonSocial"].ToString(),
                            CLABE= row["CLABE"].ToString(),
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

        public string UpdateProveedores(UpdateProveedoresModel proveedores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateProveedoresModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = proveedores.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = proveedores.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = proveedores.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefono", SqlDbType = SqlDbType.VarChar, Value = proveedores.Telefono });
                parametros.Add(new SqlParameter { ParameterName = "@pIdBanco", SqlDbType = SqlDbType.Int, Value = proveedores.IdBanco });
                parametros.Add(new SqlParameter { ParameterName = "@pPlazoPago", SqlDbType = SqlDbType.Int, Value = proveedores.PlazoPago });
                parametros.Add(new SqlParameter { ParameterName = "@pCorreo", SqlDbType = SqlDbType.VarChar, Value = proveedores.Correo });
                parametros.Add(new SqlParameter { ParameterName = "@pRFC", SqlDbType = SqlDbType.VarChar, Value = proveedores.RFC });
                parametros.Add(new SqlParameter { ParameterName = "@pRazonSocial", SqlDbType = SqlDbType.VarChar, Value = proveedores.RazonSocial });
                parametros.Add(new SqlParameter { ParameterName = "@pCLABE", SqlDbType = SqlDbType.VarChar, Value = proveedores.CLABE });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = proveedores.UsuarioActualiza });
                DataSet ds = dac.Fill("sp_UpdateProveedores", parametros);
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

        public string DeleteProveedores(DeleteProveedoresModel proveedores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteProveedoresModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = proveedores.Id });
                DataSet ds = dac.Fill("sp_DeleteProveedores", parametros);
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
