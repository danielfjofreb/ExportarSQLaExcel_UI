using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarSQLaExcel_UI
{
    public class Conexion
    {
        public bool Conecta(string connectionString, string query, string excelFilePath, string NombreHoja)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Crear un objeto de conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Crear un comando SQL
                    SqlCommand command = new SqlCommand(query, connection);

                    // Crear un adaptador de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Crear un DataSet para almacenar los resultados de la consulta
                    DataSet dataSet = new DataSet();

                    // Abrir la conexión y llenar el DataSet
                    connection.Open();
                    adapter.Fill(dataSet);

                    // Crear un nuevo archivo de Excel
                    using (var package = new OfficeOpenXml.ExcelPackage())
                    {
                        // Agregar una hoja al archivo de Excel
                        var worksheet = package.Workbook.Worksheets.Add(NombreHoja);

                        // Escribir los datos en la hoja de Excel
                        worksheet.Cells.LoadFromDataTable(dataSet.Tables[0], true);

                        // Aplicar formato a la tabla
                        var tableRange = worksheet.Cells[worksheet.Dimension.Address];
                        var table = worksheet.Tables.Add(tableRange, "Tabla1");

                        // Aplicar estilo al encabezado de la tabla
                        table.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;

                        // Aplicar estilo a las celdas de datos
                        for (int row = table.Address.Start.Row + 1; row <= table.Address.End.Row; row++)
                        {
                            for (int col = table.Address.Start.Column; col <= table.Address.End.Column; col++)
                            {
                                if (row % 2 == 0)
                                {
                                    worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                                }
                                else
                                {
                                    worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
                                }
                            }
                        }

                        // Guardar el archivo de Excel
                        package.SaveAs(new System.IO.FileInfo(excelFilePath));
                    }

                    Console.WriteLine("Los datos se han exportado correctamente a Excel.");
                    connection.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }
        }
    }
}
