using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingConvertPDFfile
{
    internal class Controller
    {
        public void InputControllers(string pathPDFfolder, string pthRTFfolder, string resultExelFile)
        {
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

