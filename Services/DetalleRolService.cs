using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class DetalleRolService
    {
        private string connection;
        public DetalleRolService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public string InsertDetalleRol(InsertDetalleRolModel detalleRol)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            try
            {
                // Agregando los parámetros de inserción
                parametros.Add(new SqlParameter { ParameterName = "@pIdRol", SqlDbType = SqlDbType.Int, Value = detalleRol.IdRol });
                parametros.Add(new SqlParameter { ParameterName = "@pIdModulo", SqlDbType = SqlDbType.Int, Value = detalleRol.IdModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = detalleRol.UsuarioActualiza });

                // Llamando al procedimiento almacenado
                DataSet ds = dac.Fill("sp_InsertDetalleRol", parametros);

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
            return "Error: Ocurrió un problema al insertar el detalle rol."; // Valor por defecto en caso de fallo
        }

        public List<GetDetalleRolModel> GetDetalleRol(GetDetalleRolModel rol)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleRolModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdRol", SqlDbType = SqlDbType.Int, Value = rol.IdRol });
                DataSet ds = dac.Fill("sp_GetDetalleRol", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleRolModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Rol = row["Rol"].ToString(),
                            Modulo = row["Modulo"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString(),
                            Estatus = row["Estatus"].ToString()

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

        public string UpdateDetalleRol(UpdateDetalleRolModel detalleRol)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateDetalleRolModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = detalleRol.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdRol", SqlDbType = SqlDbType.Int, Value = detalleRol.IdRol });
                parametros.Add(new SqlParameter { ParameterName = "@pIdModulo", SqlDbType = SqlDbType.Int, Value = detalleRol.IdModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = detalleRol.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = detalleRol.Estatus });




                DataSet ds = dac.Fill("sp_UpdateDetalleRol", parametros);
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







        public string DeleteDetalleRol(DeleteDetalleRolModel detalleRol)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteDetalleRolModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = detalleRol.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleRol", parametros);
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