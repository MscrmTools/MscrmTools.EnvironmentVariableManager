using Microsoft.Xrm.Sdk;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MscrmTools.EnvironmentVariableManager.AppCode
{
    internal class ExcelManager : IDisposable
    {
        private ExcelPackage package;

        public ExcelManager(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            package = new ExcelPackage(fileName);
        }

        public ExcelPackage Package => package;

        public void Dispose()
        {
            package.Dispose();
        }

        public void ExportToExcel(List<Entity> variables, string sheetName)
        {
            if (package.Workbook.Worksheets[sheetName] != null)
            {
                package.Workbook.Worksheets.Delete(sheetName);
            }
            var worksheet = package.Workbook.Worksheets.Add(sheetName);

            worksheet.Cells[1, 1].Value = "Display Name";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[1, 3].Value = "Description";
            worksheet.Cells[1, 4].Value = "Value";
            worksheet.Cells[1, 5].Value = "Type";

            using (var range = worksheet.Cells[1, 1, 1, 5])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                range.Style.Font.Color.SetColor(Color.White);
            }

            var row = 2;
            foreach (var variable in variables)
            {
                worksheet.Cells[row, 1].Value = variable.GetAttributeValue<string>("displayname");
                worksheet.Cells[row, 2].Value = variable.GetAttributeValue<string>("schemaname");
                worksheet.Cells[row, 3].Value = variable.GetAttributeValue<string>("description");
                worksheet.Cells[row, 4].Value = variable.GetAttributeValue<AliasedValue>("val.value")?.Value?.ToString() ?? "";
                worksheet.Cells[row, 5].Value = variable.FormattedValues["type"];

                row++;
            }

            worksheet.Columns[1].AutoFit();
            worksheet.Columns[2].AutoFit();

            package.Save();
        }
    }
}