using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ModuloService
    {
        private string connection;
        public ModuloService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertModulos(InsertModulosModel modulos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertModulosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombreModulo", SqlDbType = SqlDbType.VarChar, Value = modulos.NombreModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pRuta", SqlDbType = SqlDbType.VarChar, Value = modulos.Ruta });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = modulos.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pPanelControl", SqlDbType = SqlDbType.Int, Value = modulos.PanelControl });
                parametros.Add(new SqlParameter { ParameterName = "@pCategoria", SqlDbType = SqlDbType.Int, Value = modulos.Categoria });
                parametros.Add(new SqlParameter { ParameterName = "@pIcono", SqlDbType = SqlDbType.VarChar, Value = modulos.Icono });
                parametros.Add(new SqlParameter { ParameterName = "@pTema", SqlDbType = SqlDbType.VarChar, Value = modulos.Tema });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = modulos.Usuario });


                DataSet ds = dac.Fill("sp_InsertModulo", parametros);
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

        public List<GetModulosModel> GetModulos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetModulosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetModulos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetModulosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Modulo = row["Modulo"].ToString(),
                            Ruta = row["Ruta"].ToString(),
                            Descripcion = row["Descripcion"].ToString(),
                            PanelControl = int.Parse(row["PanelControl"].ToString()),
                            Categoria = row["Categoria"].ToString(),
                            Icono = row["Icono"].ToString(),
                            Tema = row["Tema"].ToString(),
                            FechaHora = row["FechaHora"].ToString(),
                            Usuario = row["Usuario"].ToString(),
                            
                           
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

        public string UpdateModulos(UpdateModulosModel modulo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateModulosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = modulo.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombreModulo", SqlDbType = SqlDbType.VarChar, Value = modulo.NombreModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pRuta", SqlDbType = SqlDbType.VarChar, Value = modulo.Ruta });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = modulo.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pPanelControl", SqlDbType = SqlDbType.Int, Value = modulo.PanelControl });
                parametros.Add(new SqlParameter { ParameterName = "@pCategoria", SqlDbType = SqlDbType.Int, Value = modulo.Categoria });
                parametros.Add(new SqlParameter { ParameterName = "@pIcono", SqlDbType = SqlDbType.VarChar, Value = modulo.Icono });
                parametros.Add(new SqlParameter { ParameterName = "@pTema", SqlDbType = SqlDbType.VarChar, Value = modulo.Tema });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = modulo.Usuario });
                DataSet ds = dac.Fill("sp_UpdateModulo", parametros);
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

        public string DeleteModulos(DeleteModulosModel modulos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteModulosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = modulos.Id });
                DataSet ds = dac.Fill("sp_DeleteModulo", parametros);
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
