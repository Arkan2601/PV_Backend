using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class RecetasService
    {
        private string connection;
        public RecetasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<GetRecetasModel> InsertRecetas(InsertRecetasModel recetas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRecetasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = recetas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.Int, Value = recetas.UsuarioRegistra });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = recetas.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertRecetas", parametros);
                     if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRecetasModel
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
        

        public List<GetRecetasModel> GetRecetas()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRecetasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetRecetas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRecetasModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            FechaCreacion = row["FechaCreacion"].ToString(), 
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioRegistra = row["UsuarioRegistra"].ToString(),
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

        public string UpdateRecetas(UpdateRecetasModel recetas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = recetas.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = recetas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = recetas.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateRecetas", parametros);
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

        public string DeleteRecetas(DeleteRecetasModel recetas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = recetas.Id });
                DataSet ds = dac.Fill("sp_DeleteRecetas", parametros);
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