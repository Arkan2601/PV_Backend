using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;
using ClosedXML.Excel;
using System.IO;


namespace marcatel_api.Services
{
    public class DetalleEntradaService
    {
        private string connection;
        public DetalleEntradaService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

public byte[] ExportarReportEntradasAExcel()
        {
  
       var drk = new GetReportEntradasModel(); // Crea una instancia de GetReportKardexMovModel
    var ReportKardexList = GetReportKardex(drk); 


        using (var workbook = new XLWorkbook())
    {
        var worksheet = workbook.Worksheets.Add("ReportKardex");


        worksheet.Cell(1, 1).Value = "Id";
        worksheet.Cell(1, 2).Value = "Entrada Ligada";
        worksheet.Cell(1, 3).Value = "Codigo";
        worksheet.Cell(1, 4).Value = "Nombre Proveedor";
        worksheet.Cell(1, 5).Value = "Nombre Sucursal";
        worksheet.Cell(1, 6).Value = "Cantidad";
        worksheet.Cell(1, 7).Value = "Costo";
        worksheet.Cell(1, 8).Value = "Descuento";
        worksheet.Cell(1, 9).Value = "Monto Descuento";
        worksheet.Cell(1, 10).Value = "Cantidad Sin Cargo";
        worksheet.Cell(1, 11).Value = "Total";
        worksheet.Cell(1, 12).Value = "Fecha Registro";
        worksheet.Cell(1, 13).Value = "Usuario Actualiza";
        worksheet.Cell(1, 14).Value = "Estatus";
        
    


        for (int i = 0; i < ReportKardexList.Count; i++)
        {
            var reportkardex = ReportKardexList[i];
            worksheet.Cell(i + 2, 1).Value = reportkardex.Id;
            worksheet.Cell(i + 2, 2).Value = reportkardex.Entrada_Ligada;
            worksheet.Cell(i + 2, 3).Value = reportkardex.Codigo;
            worksheet.Cell(i + 2, 4).Value = reportkardex.NombreProveedor;
            worksheet.Cell(i + 2, 5).Value = reportkardex.NombreSucursal;
            worksheet.Cell(i + 2, 6).Value = reportkardex.Cantidad;
            worksheet.Cell(i + 2, 7).Value = reportkardex.Costo;
            worksheet.Cell(i + 2, 8).Value = reportkardex.Descuento;
            worksheet.Cell(i + 2, 9).Value = reportkardex.MontoDescuento;
            worksheet.Cell(i + 2, 10).Value = reportkardex.CantidadSinCargo;
            worksheet.Cell(i + 2, 11).Value = reportkardex.Total;
             worksheet.Cell(i + 2, 12).Value = reportkardex.FechaRegistro;
             worksheet.Cell(i + 2, 13).Value = reportkardex.UsuarioActualiza;
            worksheet.Cell(i + 2, 14).Value = reportkardex.Estatus;
            
        }

         worksheet.Columns().AdjustToContents();

        using (var stream = new MemoryStream())
        {
            workbook.SaveAs(stream);
            return stream.ToArray(); 
        }
    }
        }




 public List<GetReportEntradasModel> GetReportKardex(GetReportEntradasModel drk)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    var lista = new List<GetReportEntradasModel>();

    if (string.IsNullOrEmpty(drk.FechaInicio))
    {
        drk.FechaInicio = DateTime.MinValue.ToString("yyyy-MM-dd");
    }
    if (string.IsNullOrEmpty(drk.FechaFinal))
    {
        drk.FechaFinal = DateTime.MaxValue.ToString("yyyy-MM-dd");
    }

    parametros.Add(new SqlParameter { ParameterName = "@pFechaInicio", SqlDbType = SqlDbType.Date, Value = drk.FechaInicio });
    parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.Date, Value = drk.FechaFinal });

    try
    {
        DataSet ds = dac.Fill("sp_ReportEntradas", parametros);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(new GetReportEntradasModel
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Entrada_Ligada = int.Parse(row["Entrada_Ligada"].ToString()),
                    Codigo = row["Codigo"].ToString(),
                    NombreProveedor = row["NombreProveedor"].ToString(),
                    NombreSucursal = row["NombreSucursal"].ToString(),
                    Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                    Costo = decimal.Parse(row["Costo"].ToString()),
                    Descuento = decimal.Parse(row["Descuento"].ToString()),
                    MontoDescuento = decimal.Parse(row["MontoDescuento"].ToString()),
                    CantidadSinCargo = decimal.Parse(row["CantidadSinCargo"].ToString()),
                    Total = decimal.Parse(row["Total"].ToString()),
                    FechaRegistro = row["FechaRegistro"].ToString(),
                    UsuarioActualiza = row["UsuarioActualiza"].ToString(),
                    Estatus = row["Estatus"].ToString()
                });
            }
        }
        return lista;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw;
    }
}
        public List<GetDetalleEntradaModel> GetDetalleEntrada(GetDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdEntrada", SqlDbType = SqlDbType.Int, Value = de.IdEntrada });

                DataSet ds = dac.Fill("sp_GetDetalleEntrada", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleEntradaModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdEntrada = int.Parse(row["IdEntrada"].ToString()),
                            Codigo = row["Codigo"].ToString(),
                            Articulo = row["Articulo"].ToString(),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            Costo = decimal.Parse(row["Costo"].ToString()),
                            Descuento = decimal.Parse(row["Descuento"].ToString()),
                            MontoDescuento = decimal.Parse(row["MontoDescuento"].ToString()),
                            CantidadSinCargo = decimal.Parse(row["CantidadSinCargo"].ToString()),
                            Total = decimal.Parse(row["Total"].ToString()),
                            FechaAct = row["FechaActualiza"].ToString(),
                            FechaReg = row["FechaRegistra"].ToString(),
                            UsuarioAct = row["UsuarioActualiza"].ToString()

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

        public string InsertDetalleEntrada(InsertDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdEntrada", SqlDbType = SqlDbType.Int, Value = de.IdEntrada });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = de.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = de.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pCosto", SqlDbType = SqlDbType.Decimal, Value = de.Costo });
                parametros.Add(new SqlParameter { ParameterName = "@pDescuento", SqlDbType = SqlDbType.Decimal, Value = de.Descuento });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = de.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertDetalleEntrada", parametros);

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

        public string UpdateDetalleEntrada(UpdateDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = de.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = de.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = de.Estatus });
                DataSet ds = dac.Fill("sp_UpdateDetalleEntrada", parametros);
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

        public string DeleteDetalleEntrada(DeleteDetalleEntradaModel de)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleEntradaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = de.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleEntrada", parametros);
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

        public string UpdateCantiSinCargo(UpdateCantSinCargoModel csc)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            //var lista = new List<GetDetalleEntradaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = csc.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Int, Value = csc.Cantidad });
                DataSet ds = dac.Fill("sp_UpdateCantSinCargo", parametros);
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
