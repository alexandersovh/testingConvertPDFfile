using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading.Tasks;
using RtfPipe;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iText.Commons.Utils;
using RtfPipe.Tokens;

namespace testingConvertPDFfile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string pathPDFfolder = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\ZV";
            string pthRTFfolder = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\upd";
            string resultExelFile = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Report2.xlsx";

            string[] pathPDFs = Directory.GetFiles(pathPDFfolder);
            string[] pathUPDs = Directory.GetFiles(pthRTFfolder);

            var listRowPDF = new DisplayToExcel();
            var listRowUPD = new DisplayToExcel();

            foreach (var PDFPath in pathPDFs)
            {
                ReportBilderPDFSheet(listRowPDF, PDFPath);
            }
            foreach (var UPDPath in pathUPDs)
            {
                ReportBilderUPTSheet(listRowUPD, UPDPath);
            }

            var report = new DisplayToExcel().CreateSheetPDF(listRowPDF.listForPDFExel, listRowUPD.listForUPDExel);
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

