using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class TipoMovimientoService
    {
        private string connection;
        public TipoMovimientoService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public string InsertTipoMovimiento(InsertTipoMovimientoModel tipoMovimiento)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            try
            {
                // Agregando los parámetros de inserción
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = tipoMovimiento.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = tipoMovimiento.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pEntradaSalida", SqlDbType = SqlDbType.Int, Value = tipoMovimiento.EntradaoSalida });

                // Llamando al procedimiento almacenado
                DataSet ds = dac.Fill("sp_InsertTipoMovimiento", parametros);

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

        public List<GetTipoMovimientoModel> GetTipoMovimiento()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTipoMovimientoModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetTipoMovimiento", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTipoMovimientoModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Descripcion = row["Descripcion"].ToString(),
                            EntradaoSalida = row["Tipo"].ToString(),
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

        public string UpdateTipoMovimiento(UpdateTipoMovimientoModel tipoMovimiento)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateTipoMovimientoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = tipoMovimiento.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = tipoMovimiento.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pEntradaSalida", SqlDbType = SqlDbType.VarChar, Value = tipoMovimiento.EntradaoSalida });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.VarChar, Value = tipoMovimiento.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = tipoMovimiento.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateTipoMovimiento", parametros);
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







        public string DeleteTipoMovimiento(DeleteTipoMovimientoModel tipoMovimiento)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteTipoMovimientoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = tipoMovimiento.Id });
                DataSet ds = dac.Fill("sp_DeleteTipoMovimiento", parametros);
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