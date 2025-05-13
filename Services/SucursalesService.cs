using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class SucursalesService
    {
        private string connection;
        public SucursalesService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertSucursales(InsertSucursalesModel sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = sucursal.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = sucursal.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.Int, Value = sucursal.UsuarioReg });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = sucursal.UsuarioAct });
                parametros.Add(new SqlParameter { ParameterName = "@pAbreviatura", SqlDbType = SqlDbType.VarChar, Value = sucursal.Abreviatura });
                DataSet ds = dac.Fill("sp_InsertSucursales", parametros);
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



        public List<GetSucursalesModel> Getsucursal()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetSucursalesModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetSucursales", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetSucursalesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
                            UsuarioReg = row["UsuarioRegistra"].ToString(),
                            UsuarioAct = row["UsuarioActualiza"].ToString(),
                            Abreviatura = row["Abreviatura"].ToString(),
                            FechaReg = row["FechaRegistro"].ToString(),
                            FechaAct = row["FechaActualiza"].ToString()
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

        public string Updatesucursal(UpdateSucursalesModel sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = sucursal.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = sucursal.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = sucursal.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pAbreviatura", SqlDbType = SqlDbType.VarChar, Value = sucursal.Abreviatura });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = sucursal.UsuarioAct });

                DataSet ds = dac.Fill("sp_UpdateSucursales", parametros);
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

        public string Deletesucursal(DeleteSucursalesModel sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = sucursal.Id });
                DataSet ds = dac.Fill("sp_DeleteSucursales", parametros);
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
