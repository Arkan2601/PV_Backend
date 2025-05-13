using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class TraspasosService
    {
        private string connection;
        public TraspasosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<GetTraspasosModel> InsertTraspasos(InsertTraspasosModel traspasos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTraspasosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacenOrigen", SqlDbType = SqlDbType.Int, Value = traspasos.IdAlmacenOrigen });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacenDestino", SqlDbType = SqlDbType.Int, Value = traspasos.IdAlmacenDestino });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioEnvia", SqlDbType = SqlDbType.Int, Value = traspasos.UsuarioEnvia });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = traspasos.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertTraspasos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTraspasosModel
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

        public List<GetTraspasosModel> GetTraspasos(GetTraspasosModel traspasos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTraspasosModel>();
            if (string.IsNullOrEmpty(traspasos.FechaInicio))
             {
                traspasos.FechaInicio = DateTime.MinValue.ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(traspasos.FechaFinal))
            {
                traspasos.FechaFinal = DateTime.MaxValue.ToString("yyyy-MM-dd");
            }
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pAlmacenEnvia", SqlDbType = SqlDbType.Int, Value = traspasos.AlmacenOrigen });
                parametros.Add(new SqlParameter { ParameterName = "@pAlmacenRecibe", SqlDbType = SqlDbType.Int, Value = traspasos.AlmacenDestino });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaInicio", SqlDbType = SqlDbType.Date, Value = traspasos.FechaInicio });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.Date, Value = traspasos.FechaFinal });
                DataSet ds = dac.Fill("sp_GetTraspasos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTraspasosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            AlmacenOrigen = row["AlmacenOrigen"].ToString(),
                            AlmacenDestino = row["AlmacenDestino"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            FechaRecibido = row["FechaRecibido"].ToString(),
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioEnvia = row["UsuarioEnvia"].ToString(),
                            UsuarioRecibe = row["UsuarioRecibe"].ToString(),
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

        public string UpdateTraspasos(UpdateTraspasosModel traspasos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = traspasos.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacenOrigen", SqlDbType = SqlDbType.Int, Value = traspasos.IdAlmacenOrigen });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacenDestino", SqlDbType = SqlDbType.Int, Value = traspasos.IdAlmacenDestino });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioEnvia", SqlDbType = SqlDbType.Int, Value = traspasos.UsuarioEnvia });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = traspasos.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateTraspasos", parametros);
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

        public string DeleteTraspasos(DeleteTraspasosModel traspasos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = traspasos.Id });
                DataSet ds = dac.Fill("sp_DeleteTraspasos", parametros);
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

        public string AutorizarTraspasos(AutorizarTraspasosModel traspasos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = traspasos.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaRecibido", SqlDbType = SqlDbType.VarChar, Value = traspasos.FechaRecibido });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = traspasos.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRecibe", SqlDbType = SqlDbType.Int, Value = traspasos.UsuarioRecibe });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = traspasos.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_AutorizarTraspasos", parametros);
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
