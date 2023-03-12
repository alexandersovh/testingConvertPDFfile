using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.Diagnostics.Metrics;
using Excel = Microsoft.Office.Interop.Excel;

namespace testingConvertPDFfile
{
    internal class Controller
    {
        public void InputControllers(string[] pathfolder, string resultExelFile)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var listRowUPD = new DisplayToExcel();
            var listRowPDF = new DisplayToExcel();
            string pathPDFfolder;
            string pthRTFfolder;
            var outputeData = new DisplayToExcel();
            ExcelPackage package = new ExcelPackage();
            DateTime thisDay = DateTime.Today;
            byte[] report;

            foreach (string folder in pathfolder)
            {
                if (folder.Contains("УПД"))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Отчет УПД" + thisDay.ToString("d"));

                    pthRTFfolder = folder;
                    string[] pathUPDs = Directory.GetFiles(pthRTFfolder);

                    foreach (var UPDPath in pathUPDs)
                    {
                        ReportBilderUPTSheet(listRowUPD, UPDPath);
                    }
                    outputeData.CreateSheetUPD(listRowUPD.listForUPDExel, sheet);

                }
                else if (folder.Contains("Заявление"))
                {


                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Отчет сертификатов" + thisDay.ToString("d"));

                    pathPDFfolder = folder;
                    string[] pathPDFs = Directory.GetFiles(pathPDFfolder);


                    foreach (var PDFPath in pathPDFs)
                    {
                        ReportBilderPDFSheet(listRowPDF, PDFPath);
                    }

                    outputeData.creatorTablePDF(listRowPDF.listForPDFExel, sheet);
                }
            }

            report = package.GetAsByteArray();

            File.WriteAllBytes(resultExelFile, report);
        }
        static public void ReportBilderPDFSheet(DisplayToExcel listRowPDF, string pathPDFfail)
        {
            var dataPDF = new DataClient().ZVToEndData(pathPDFfail);
            listRowPDF.CreateListPDF(dataPDF);
        }
        static public void ReportBilderUPTSheet(DisplayToExcel listRowUPD, string pthRTFfile)
        {
            var dataUPD = new DataClient().UPDToEndData(pthRTFfile);
            listRowUPD.CreateListUPD(dataUPD);
        }
    }
}

