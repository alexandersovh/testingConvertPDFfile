using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.Diagnostics.Metrics;

namespace testingConvertPDFfile
{
    internal class DisplayToExcel
    {
        List<InputZVstring> listForExel = new List<InputZVstring>();
        private void CreateList(InputZVstring listData)
        {
            listForExel.Add(listData);
        }
        public byte[] CreateExel(InputZVstring report)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("ZV");
            var sheet0 = package.Workbook.Worksheets.Add("дуболь на русском");


            var counter = 1;
            sheet.Cells[1, 1, 2, 3].LoadFromArrays(new object[][] { new[] { "Название оргонизации", "ИНН", "КПП","№ заявления","Дата","ФИО владельца сертификата" } });
            var row = 2;
            var column = 1;
            foreach (var item in listForExel)
            {
                sheet.Cells[row, column].Value = counter;
                sheet.Cells[row, column + 1].Value = item.Name;
                sheet.Cells[row, column + 2].Value = item.INN;
                sheet.Cells[row, column + 3].Value = item.KPP;
                sheet.Cells[row, column + 4].Value = item.ZVNuber;
                sheet.Cells[row, column + 5].Value = item.FIO;
                row++;
            }

            sheet.Protection.IsProtected = true;
            return package.GetAsByteArray();
        }
    }
}
