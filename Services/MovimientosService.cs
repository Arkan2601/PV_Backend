using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;
using System.IO;
using ClosedXML.Excel;

namespace marcatel_api.Services
{
    public class MovimientosService
    {
        private string connection;
        public MovimientosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        // public byte[] ExportarMovimientosAExcel()
        // {
        //     var model = new GetMovimientosModel
        //     {

        //         FechaInicio = "",
        //         FechaFin = "",
        //         IdSucursal = 0,
        //         Usuario = 0
        //     };

        //     //var listaMovimientos = GetMovimientos(model);


        //     using (var workbook = new XLWorkbook())
        //     {
        //         var worksheet = workbook.Worksheets.Add("Movimientos");


        //         worksheet.Cell(1, 1).Value = "Id";
        //         worksheet.Cell(1, 2).Value = "Nombre Almacen";
        //         worksheet.Cell(1, 3).Value = "Tipo Movimiento";
        //         worksheet.Cell(1, 4).Value = "Fecha Creacion";
        //         worksheet.Cell(1, 5).Value = "Fecha Autorizacion";
        //         worksheet.Cell(1, 6).Value = "Usuario Registra";
        //         worksheet.Cell(1, 7).Value = "Usuario Autoriza";
        //         worksheet.Cell(1, 8).Value = "Fecha Actualiza";
        //         worksheet.Cell(1, 9).Value = "Usuario Actualiza";


        //         for (int i = 0; i < listaMovimientos.Count; i++)
        //         {
        //             var movimiento = listaMovimientos[i];
        //             worksheet.Cell(i + 2, 1).Value = movimiento.Id;
        //             worksheet.Cell(i + 2, 2).Value = movimiento.NombreAlmacen;
        //             worksheet.Cell(i + 2, 3).Value = movimiento.TipoMovimiento;
        //             worksheet.Cell(i + 2, 4).Value = movimiento.FechaCreacion;
        //             worksheet.Cell(i + 2, 5).Value = movimiento.FechaAutorizacion;
        //             worksheet.Cell(i + 2, 6).Value = movimiento.UsuarioRegistra;
        //             worksheet.Cell(i + 2, 7).Value = movimiento.UsuarioAutoriza;
        //             worksheet.Cell(i + 2, 8).Value = movimiento.FechaActualiza;
        //             worksheet.Cell(i + 2, 9).Value = movimiento.UsuarioActualiza;
        //         }

        //         worksheet.Columns().AdjustToContents();

        //         using (var stream = new MemoryStream())
        //         {
        //             workbook.SaveAs(stream);
        //             return stream.ToArray();
        //         }
        //     }
        // }

        public List<GetMovimientosModel> InsertarMovimientos(InsertMovimientosModel movimientos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = movimientos.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pTipoMovimiento", SqlDbType = SqlDbType.Int, Value = movimientos.TipoMovimiento });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioRegistra });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAutoriza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioAutoriza });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_InsertMovimientos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetMovimientosModel
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


        public List<GetMovimientosModel> GetMovimientos(string FechaInicio, string FechaFin, int IdSucursal, int Usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pFechaInicio", SqlDbType = SqlDbType.VarChar, Value = FechaInicio });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaFin", SqlDbType = SqlDbType.VarChar, Value = FechaFin });
                parametros.Add(new SqlParameter { ParameterName = "@pSucursal", SqlDbType = SqlDbType.Int, Value = IdSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = Usuario });

                DataSet ds = dac.Fill("sp_GetMovimientos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetMovimientosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreAlmacen = row["NombreAlmacen"].ToString(),
                            TipoMovimiento = row["TipoMovimiento"].ToString(),
                            FechaCreacion = row["FechaCreacion"].ToString(),
                            FechaAutorizacion = row["FechaAutorizacion"].ToString(),
                            UsuarioRegistra = row["UsuarioRegistra"].ToString(),
                            UsuarioAutoriza = row["UsuarioAutoriza"].ToString(),
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


        public string UpdateMovimientos(UpdateMovimientosModel movimientos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = movimientos.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = movimientos.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pTipoMovimiento", SqlDbType = SqlDbType.Int, Value = movimientos.TipoMovimiento });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = movimientos.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioRegistra });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAutoriza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioAutoriza });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = movimientos.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateMovimientos", parametros);
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




        public string UpdateMovimientosAutoriza(UpdateMovimientosAutorizaModel movimientos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateMovimientosAutorizaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = movimientos.Id });



                DataSet ds = dac.Fill("sp_UpdateFechaAutorizacion", parametros);
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



        public string DeleteMovimientos(DeleteMovimientosModel movimientos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteMovimientosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = movimientos.Id });
                DataSet ds = dac.Fill("sp_DeleteMovimientos", parametros);
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