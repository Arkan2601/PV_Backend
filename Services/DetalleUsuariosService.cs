using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class DetalleUsuariosService
    {
        private string connection;
        public DetalleUsuariosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public string InsertDetalleUsuariosModel(InsertDetalleUsuariosModel DetalleUsuarioS)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            try
            {
                // Agregando los parámetros de inserción
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.IdUsuario });
                parametros.Add(new SqlParameter { ParameterName = "@pIdModulo", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.IdModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdCategoria", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.IdCategoria });
                parametros.Add(new SqlParameter { ParameterName = "@pSoloSucursal", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.SoloSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pRegistrosPropios", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.RegistrosPropios });
                parametros.Add(new SqlParameter { ParameterName = "@pSoloLectura", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.SoloLectura });
                parametros.Add(new SqlParameter { ParameterName = "pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.UsuarioActualiza });
                // Llamando al procedimiento almacenado
                DataSet ds = dac.Fill("sp_InsertDetalleUsuario", parametros);

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

        public List<GetDetalleUsuariosModel> GetDetalleUsuariosModel(GetDetalleUsuariosModel DetalleUsuarioS)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleUsuariosModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.Id });
                DataSet ds = dac.Fill("sp_GetDetalleUsuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleUsuariosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Usuario = row["Usuario"].ToString(),
                            Modulo = row["Modulo"].ToString(),
                             Categoria = row["Categoria"].ToString(),
                              SOLO_SUCURSAL = row["SOLO_SUCURSAL"].ToString(),
                               REGISTROS_PROPIOS = row["REGISTROS_PROPIOS"].ToString(),
                                SOLO_LECTURA = row["SOLO_LECTURA"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString(),
                            Estado = row["Estado"].ToString()

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

        public string UpdateDetalleUsuariosModel(UpdateDetalleUsuariosModel DetalleUsuarioS)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateDetalleUsuariosModel>();

            try
            {
                 parametros.Add(new SqlParameter { ParameterName = "@pID", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.ID });
                  parametros.Add(new SqlParameter { ParameterName = "@pIDUSUARIO", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.IDUSUARIO });
              parametros.Add(new SqlParameter { ParameterName = "@pIDMODULO", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.IDMODULO });
                parametros.Add(new SqlParameter { ParameterName = "@pIDCATEGORIA", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.IDCATEGORIA });
                parametros.Add(new SqlParameter { ParameterName = "@pSOLOSUCURSAL", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.SOLOLECTURA });
                parametros.Add(new SqlParameter { ParameterName = "@pREGISTROSPROPIOS", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.REGISTROSPROPIOS });
                parametros.Add(new SqlParameter { ParameterName = "@pSOLOLECTURA", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.SOLOLECTURA });
                parametros.Add(new SqlParameter { ParameterName = "@pACTIVO", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.ACTIVO });
                parametros.Add(new SqlParameter { ParameterName = "@pUSUARIO", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.UsuarioActualiza });
                // Llamando al procedimiento almacenado



                DataSet ds = dac.Fill("sp_UpdateDetalleUsuarios", parametros);
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







        public string DeleteDetalleUsuarios(DeleteDetalleUsuariosModel DetalleUsuarioS)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteDetalleUsuariosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = DetalleUsuarioS.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleUsuarios", parametros);
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