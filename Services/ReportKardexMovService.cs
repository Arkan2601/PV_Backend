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
    public class ReportKardexMovService
    {
        private string connection;
        public ReportKardexMovService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

public byte[] ExportarReportKardexMovAExcel()
        {
  
       var drk = new GetReportKardexMovModel(); // Crea una instancia de GetReportKardexMovModel
    var ReportKardexMovList = GetReportKardexMov(drk); 


        using (var workbook = new XLWorkbook())
    {
        var worksheet = workbook.Worksheets.Add("ReportKardex");


        worksheet.Cell(1, 1).Value = "Id";
        worksheet.Cell(1, 2).Value = "Movimiento Ligado";
        worksheet.Cell(1, 3).Value = "Tipo Movimiento";
        worksheet.Cell(1, 4).Value = "Sucursal";
        worksheet.Cell(1, 5).Value = "Insumo";
        worksheet.Cell(1, 6).Value = "Cantidad";
        worksheet.Cell(1, 7).Value = "Estatus";
        worksheet.Cell(1, 8).Value = "Fecha Registro";
        worksheet.Cell(1, 9).Value = "Fecha Actualiza";
        worksheet.Cell(1, 10).Value = "Usuario Actualiza";


        for (int i = 0; i < ReportKardexMovList.Count; i++)
        {
            var reportkardex = ReportKardexMovList[i];
            worksheet.Cell(i + 2, 1).Value = reportkardex.Id;
            worksheet.Cell(i + 2, 2).Value = reportkardex.Movimiento_Ligado;
            worksheet.Cell(i + 2, 3).Value = reportkardex.TipoMovimiento;
            worksheet.Cell(i + 2, 4).Value = reportkardex.Sucursal;
            worksheet.Cell(i + 2, 5).Value = reportkardex.Insumo;
            worksheet.Cell(i + 2, 6).Value = reportkardex.Cantidad;
            worksheet.Cell(i + 2, 7).Value = reportkardex.Estatus;
            worksheet.Cell(i + 2, 8).Value = reportkardex.FechaRegistro;
            worksheet.Cell(i + 2, 9).Value = reportkardex.FechaActualiza;
            worksheet.Cell(i + 2, 10).Value = reportkardex.UsuarioActualiza;
        }

         worksheet.Columns().AdjustToContents();

        using (var stream = new MemoryStream())
        {
            workbook.SaveAs(stream);
            return stream.ToArray(); 
        }
    }
        }







        public List<GetReportKardexMovModel> GetReportKardexMov(GetReportKardexMovModel drk)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);
    var lista = new List<GetReportKardexMovModel>();

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
        DataSet ds = dac.Fill("sp_ReportKardexMov", parametros);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(new GetReportKardexMovModel
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Movimiento_Ligado = int.Parse(row["Movimiento_Ligado"].ToString()),
                    TipoMovimiento = row["TipoMovimiento"].ToString(),
                    Sucursal = row["Sucursal"].ToString(),
                    Insumo = row["Insumo"].ToString(),
                    Cantidad = decimal.Parse(row["Cantidad"].ToString()),
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
        Console.WriteLine($"Error: {ex.Message}");
        throw;
    }
}


        }

        


        

    }
