using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ImagenService
    {
        private string connection;
        public ImagenService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

   public string UpdateImagen(UpdateImagenModel imagen){
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = imagen.Id });
        parametros.Add(new SqlParameter { ParameterName = "@pImagenBase64", SqlDbType = SqlDbType.NVarChar, Value = imagen.ImagenData });  // Base64
        DataSet ds = dac.Fill("InsertarOActualizarImagen", parametros);
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

public byte[] ObtenerImagen(int id)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
        DataSet ds = dac.Fill("ObtenerImagen", parametros);

        if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["CodImage"] != DBNull.Value)
        {
            return (byte[])ds.Tables[0].Rows[0]["CodImage"];
        }
        else
        {
            return null;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al obtener la imagen: " + ex.Message);
        return null;
    }
}



    }
}
