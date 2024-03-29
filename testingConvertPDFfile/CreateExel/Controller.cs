﻿using System;
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


namespace PidPipen
{
    internal class Controller
    {
        public void InputControllers(string pathfolder, string resultExelFile)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DisplayToExcel listRowUPD = new DisplayToExcel();
            DisplayToExcel listRowPDF = new DisplayToExcel();
            string pathPDFfolder;
            string pthRTFfolder;
            DisplayToExcel outputeData = new DisplayToExcel();
            ExcelPackage package = new ExcelPackage();
            byte[] report;
            string[] PathFailList = Directory.GetDirectories(pathfolder);


            foreach (string folder in PathFailList)
            {
                DirectoryInfo dirN = new DirectoryInfo(folder);
                if (folder.Contains("УПД"))
                {
                    listRowUPD.listForUPDExel.Clear();

                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Отчет " + dirN.Name.ToString());
                    pthRTFfolder = folder;
                    string[] pathUPDs = Directory.GetFiles(pthRTFfolder);

                    foreach (var UPDPath in pathUPDs)
                    {
                        if (!UPDPath.Contains("$"))
                        {
                            ReportBilderUPTSheet(listRowUPD, UPDPath);
                        }
                    }
                    outputeData.CreateSheetUPD(listRowUPD.listForUPDExel, sheet);
                    //sheet.Protection.IsProtected = false;
                }
                else if (folder.Contains("Заявление"))
                {
                    listRowPDF.listForPDFExel.Clear();

                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Отчет " + dirN.Name.ToString());
                    pathPDFfolder = folder;

                    string[] pathPDFs = Directory.GetFiles(pathPDFfolder);

                    foreach (var PDFPath in pathPDFs)
                    {
                        ReportBilderPDFSheet(listRowPDF, PDFPath);
                    }
                    outputeData.creatorTablePDF(listRowPDF.listForPDFExel, sheet);
                    //sheet.Protection.IsProtected = false;
                }
            }

            report = package.GetAsByteArray();

            File.WriteAllBytes(resultExelFile, report);
        }
        static private void ReportBilderPDFSheet(DisplayToExcel listRowPDF, string pathPDFfail)
        {
            try
            {
                var dataPDF = new DataClient().ZVToEndData(pathPDFfail);
                listRowPDF.CreateListPDF(dataPDF);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " Заявление " + pathPDFfail);
            }

        }
        static private void ReportBilderUPTSheet(DisplayToExcel listRowUPD, string pthRTFfile)
        {
            try
            {
                var dataUPD = new DataClient().UPDToEndData(pthRTFfile);
                listRowUPD.CreateListUPD(dataUPD);
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " УПД " + pthRTFfile);
            }
}
        public WorkFile FailsForWork()
        {
            DateTime thisDay = DateTime.Today;

            Console.WriteLine("введити иммя папки с файлами для обработки");
            string fileWithData = Console.ReadLine();
            Console.WriteLine("введити фаил куда сохранять или Enter");
            string fileMuveTo = Console.ReadLine();
            if (fileMuveTo == "")
            {
                fileMuveTo = fileWithData;
            }

            string fileReport = fileMuveTo + "\\отчет от " + thisDay.ToString("d") + ".xlsx";

            WorkFile fileBaze = new WorkFile
            {
                FileWithData = fileWithData,
                FileMuveTo = fileMuveTo,
                FileReport = fileReport
            };
            return fileBaze;
        }
        public WorkFile FailsForWork(string path)
        {
            DateTime thisDay = DateTime.Today;

            string fileWithData = path;
            string fileMuveTo = path;

            string fileReport = fileMuveTo + "\\отчет от " + thisDay.ToString("d") + ".xlsx";

            WorkFile fileBaze = new WorkFile
            {
                FileWithData = fileWithData,
                FileMuveTo = fileMuveTo,
                FileReport = fileReport
            };
            return fileBaze;
        }
    }
}