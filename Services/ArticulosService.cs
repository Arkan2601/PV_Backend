using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ArticulosService
    {
        private string connection;
        public ArticulosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InserArticulos(InsertArticulosModel articulos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = articulos.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = articulos.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pIdFamilia", SqlDbType = SqlDbType.Int, Value = articulos.IdFamilia });
                parametros.Add(new SqlParameter { ParameterName = "@pUnidadMedida", SqlDbType = SqlDbType.Int, Value = articulos.IdUM });
                parametros.Add(new SqlParameter { ParameterName = "@pUltimoCosto", SqlDbType = SqlDbType.VarChar, Value = articulos.UltimoCosto });
                parametros.Add(new SqlParameter { ParameterName = "@pPrecioVenta", SqlDbType = SqlDbType.VarChar, Value = articulos.PrecioVenta });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = articulos.IdUsuario });
                parametros.Add(new SqlParameter { ParameterName = "@pPorcentajeIva", SqlDbType = SqlDbType.Int, Value = articulos.IVA });
                parametros.Add(new SqlParameter { ParameterName = "@pPorcentajeIeps", SqlDbType = SqlDbType.Int, Value = articulos.IEPS });

                DataSet ds = dac.Fill("sp_InsertArticulo", parametros);
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



        public List<GetArticulosModel> GetArticulos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetArticulosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetArticulos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetArticulosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Codigo = row["Codigo"].ToString(),
                            Descripcion = row["Descripcion"].ToString(),
                            Familia = row["IdFamilia"].ToString(),
                            UM = row["UnidadMedida"].ToString(),
                            UltimoCosto = row["UltimoCosto"].ToString(),
                            PrecioVenta = row["PrecioVenta"].ToString(),
                            Iva = row["Iva"].ToString(),
                            Ieps = row["Ieps"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
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

        public string Updatearticulos(UpdateArticulosModel articulos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = articulos.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = articulos.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = articulos.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pIdFamilia", SqlDbType = SqlDbType.Int, Value = articulos.IdFamilia });
                parametros.Add(new SqlParameter { ParameterName = "@pUnidadMedida", SqlDbType = SqlDbType.Int, Value = articulos.IdUM });
                parametros.Add(new SqlParameter { ParameterName = "@pUltimoCosto", SqlDbType = SqlDbType.VarChar, Value = articulos.UltimoCosto });
                parametros.Add(new SqlParameter { ParameterName = "@pPrecioVenta", SqlDbType = SqlDbType.VarChar, Value = articulos.PrecioVenta });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = articulos.IdUsuario });
                parametros.Add(new SqlParameter { ParameterName = "@pPorcentajeIva", SqlDbType = SqlDbType.Int, Value = articulos.IVA });
                parametros.Add(new SqlParameter { ParameterName = "@pPorcentajeIeps", SqlDbType = SqlDbType.Int, Value = articulos.IEPS });

                DataSet ds = dac.Fill("sp_UpdateArticulo", parametros);
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

        public string Deletearticulos(DeleteArticulosModel articulos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = articulos.Id });
                DataSet ds = dac.Fill("sp_DeleteArticulos", parametros);
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
