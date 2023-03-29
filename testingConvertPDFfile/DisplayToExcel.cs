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
        public List<InputZVstring> listForPDFExel = new List<InputZVstring>();
        public List<InputUPDstring> listForUPDExel = new List<InputUPDstring>();
        public void CreateListPDF(InputZVstring listData)
        {
            listForPDFExel.Add(listData);
        }
        public void CreateListUPD(InputUPDstring listData)
        {
            listForUPDExel.Add(listData);
        }
        public void creatorTablePDF(List<InputZVstring> report, ExcelWorksheet sheet)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            DateTime thisDay = DateTime.Today;
            int counter = 1;
            int row = 5;
            int column = 1;

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

            foreach (var item in report)
            {
                if (item == null)
                {
                    sheet.Cells[row, column].Value = counter;
                    sheet.Cells[row, column + 1].Value = "undefined";
                }
                else
                {
                    sheet.Cells[row, column].Value = counter;
                    sheet.Cells[row, column + 1].Value = item.Name;
                    sheet.Cells[row, column + 2].Value = item.INN;
                    sheet.Cells[row, column + 3].Value = item.KPP;
                    sheet.Cells[row, column + 5].Value = item.ZVNuber;
                    sheet.Cells[row, column + 4].Value = item.FaileDate;
                    sheet.Cells[row, column + 6].Value = item.FIO;
                }
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
        public void CreateSheetUPD(List<InputUPDstring> report, ExcelWorksheet sheet)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            DateTime thisDay = DateTime.Today;

            sheet.Cells["A1:H1"].Merge = true;
            sheet.Cells["A1:H1"].Value = "Внутренняя опись бухгалтерских документов Москва - Центральный офис";
            sheet.Cells["A2:H2"].Merge = true;
            sheet.Cells["A2:H2"].Value = "за период - " + thisDay.ToString("d") + "-" + thisDay.ToString("d");

            sheet.Cells["A3:A4"].Merge = true;
            sheet.Cells["A3:A4"].Value = "№";
            sheet.Cells["B3:B4"].Merge = true;
            sheet.Cells["B3:B4"].Value = "Название оргонизации";
            sheet.Cells["C3:C4"].Merge = true;
            sheet.Cells["C3:C4"].Value = "ИНН";
            sheet.Cells["D3:D4"].Merge = true;
            sheet.Cells["D3:D4"].Value = "КПП";
            sheet.Cells["E3:E4"].Merge = true;
            sheet.Cells["E3:E4"].Value = "Присвоенный номер БМ";
            sheet.Cells["F3:F4"].Merge = true;
            sheet.Cells["F3:F4"].Value = "Дата заявления";

            sheet.Cells["G3:H3"].Merge = true;
            sheet.Cells["G3:H3"].Value = "Документы в комплекте (перечисление подписанных бух.доков и доверенностей)";
            sheet.Cells["G4"].Value = "Универсальный передаточный документ";
            sheet.Cells["H4"].Value = "доверенность на Универсальный передаточный документ";

            int counter = 1;
            int row = 5;
            int column = 1;

            foreach (var item in report)
            {
                if (item == null)
                {
                    sheet.Cells[row, column].Value = counter;
                    sheet.Cells[row, column + 1].Value = "undefined";
                }
                else
                {
                    sheet.Cells[row, column].Value = counter;
                    sheet.Cells[row, column + 1].Value = item.Name;
                    sheet.Cells[row, column + 2].Value = item.INN;
                    sheet.Cells[row, column + 3].Value = item.KPP;
                    sheet.Cells[row, column + 4].Value = item.UPDNuber;
                    sheet.Cells[row, column + 5].Value = item.UPDDate;
                    sheet.Cells[row, column + 6].Value = item.АttorneyMen;
                    sheet.Cells[row, column + 7].Value = item.АttorneyFin;
                }
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
