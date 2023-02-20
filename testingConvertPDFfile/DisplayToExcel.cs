using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.Diagnostics.Metrics;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO.Packaging;
using Microsoft.Office.Interop.Excel;


namespace testingConvertPDFfile
{
    internal class DisplayToExcel
    {
        public List<InputZVstring> listForExel = new List<InputZVstring>();
        public void CreateList(InputZVstring listData)
        {
            listForExel.Add(listData);
        }
        public byte[] CreateExel(List<InputZVstring> report)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            var dataList = new List<InputZVstring>();
            DateTime thisDay = DateTime.Today;

            var sheet = package.Workbook.Worksheets.Add("ZV");
            var sheet0 = package.Workbook.Worksheets.Add("дуболь на русском");

            sheet.Cells["A1:G1"].Merge = true;
            sheet.Cells["A1:G1"].Value = "Внутренняя опись документов, предоставленных для оказания услуг УЦ";
            sheet.Cells["A2:G2"].Merge = true;
            sheet.Cells["A2:G2"].Value = "Адрес: Москва, ул. Петровка дом 28";
            sheet.Cells["A3:G3"].Merge = true;
            sheet.Cells["A3:G3"].Value = "за период - " + thisDay.ToString("d") + "-" + thisDay.ToString("d");


            sheet.Cells["A4"].Value = "№";
            sheet.Cells["B4"].Value = "Название оргонизации";
            sheet.Cells["C4"].Value = "ИНН";
            sheet.Cells["D4"].Value = "КПП";
            sheet.Cells["E4"].Value = "№ Заявления";
            sheet.Cells["F4"].Value = "Дата заявления";
            sheet.Cells["G4"].Value = "ФИО";
           

            int counter = 1;
            int row = 5;
            int column = 1;
            foreach (var item in report)
            {
                sheet.Cells[row, column].Value = counter;
                sheet.Cells[row, column + 1].Value = item.Name;
                sheet.Cells[row, column + 2].Value = item.INN;
                sheet.Cells[row, column + 3].Value = item.KPP;
                sheet.Cells[row, column + 5].Value = item.ZVNuber;
                sheet.Cells[row, column + 4].Value = item.FaileDate;
                sheet.Cells[row, column + 6].Value = item.FIO;
                row++;
                counter++;
            }

            sheet.Cells[row + 3, 1].Value = "Итого";
            sheet.Cells[row + 3, 2].Value = Convert.ToString(counter - 1) + "()";
            sheet.Cells[row + 3, 3].Value = "комплект документов";
            sheet.Cells[row + 5, 2].Value = "Количество листов внутренней описи";
            sheet.Cells[row + 6, 3].Value = "(цифрами и прописью)";
            sheet.Cells[row + 8, 2].Value = "Технический специалист УЦ";
            sheet.Cells[row + 8, 5].Value = "Сивохин А.А.";
            sheet.Cells[row + 9, 2].Value = "(должность составившего опись)";
            sheet.Cells[row + 9, 5].Value = "(подпись)";
            sheet.Cells[row + 9, 6].Value = "(расшифровка)";
            sheet.Cells[row + 11, 1].Value = "Дата";
            sheet.Cells[row + 11, 2].Value = thisDay.ToString("d");



            sheet.Protection.IsProtected = true;
            return package.GetAsByteArray();
        }
        public void CreateSheetZV(ExcelPackage sheet)
        {
            sheet.Cells["A1:G1"].Merge = true;
            sheet.Cells["A1:G1"].Value = "Внутренняя опись документов, предоставленных для оказания услуг УЦ";
            sheet.Cells["A2:G2"].Merge = true;
            sheet.Cells["A2:G2"].Value = "Адрес: Москва, ул. Петровка дом 28";
            sheet.Cells["A3:G3"].Merge = true;
            sheet.Cells["A3:G3"].Value = "за период - " + thisDay.ToString("d") + "-" + thisDay.ToString("d");


            sheet.Cells["A4"].Value = "№";
            sheet.Cells["B4"].Value = "Название оргонизации";
            sheet.Cells["C4"].Value = "ИНН";
            sheet.Cells["D4"].Value = "КПП";
            sheet.Cells["E4"].Value = "№ Заявления";
            sheet.Cells["F4"].Value = "Дата заявления";
            sheet.Cells["G4"].Value = "ФИО";


            int counter = 1;
            int row = 5;
            int column = 1;
            foreach (var item in report)
            {
                sheet.Cells[row, column].Value = counter;
                sheet.Cells[row, column + 1].Value = item.Name;
                sheet.Cells[row, column + 2].Value = item.INN;
                sheet.Cells[row, column + 3].Value = item.KPP;
                sheet.Cells[row, column + 5].Value = item.ZVNuber;
                sheet.Cells[row, column + 4].Value = item.FaileDate;
                sheet.Cells[row, column + 6].Value = item.FIO;
                row++;
                counter++;
            }

            sheet.Cells[row + 3, 1].Value = "Итого";
            sheet.Cells[row + 3, 2].Value = Convert.ToString(counter - 1) + "()";
            sheet.Cells[row + 3, 3].Value = "комплект документов";
            sheet.Cells[row + 5, 2].Value = "Количество листов внутренней описи";
            sheet.Cells[row + 6, 3].Value = "(цифрами и прописью)";
            sheet.Cells[row + 8, 2].Value = "Технический специалист УЦ";
            sheet.Cells[row + 8, 5].Value = "Сивохин А.А.";
            sheet.Cells[row + 9, 2].Value = "(должность составившего опись)";
            sheet.Cells[row + 9, 5].Value = "(подпись)";
            sheet.Cells[row + 9, 6].Value = "(расшифровка)";
            sheet.Cells[row + 11, 1].Value = "Дата";
            sheet.Cells[row + 11, 2].Value = thisDay.ToString("d");

        }
    }
}
