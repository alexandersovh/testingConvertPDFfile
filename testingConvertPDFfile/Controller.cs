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
        public void InputControllers(string pathfolder, string resultExelFile)
        {
            var listRowUPD = new DisplayToExcel();
            var listRowPDF = new DisplayToExcel();
            string pathPDFfolder;
            string pthRTFfolder;
            var outputeData = new DisplayToExcel();
            byte[] report;

            if (pathfolder.Contains("УПД"))
            {
                pthRTFfolder = pathfolder;
                string[] pathUPDs = Directory.GetFiles(pthRTFfolder);

                foreach (var UPDPath in pathUPDs)
                {
                    ReportBilderUPTSheet(listRowUPD, UPDPath);
                }
                report = outputeData.CreateSheet(listRowPDF.listForPDFExel, listRowUPD.listForUPDExel);

                File.WriteAllBytes(resultExelFile, report);
            }
            else if(pathfolder.Contains("Заявление"))
            {
                pathPDFfolder = pathfolder;
                string[] pathPDFs = Directory.GetFiles(pathPDFfolder);

                
                foreach (var PDFPath in pathPDFs)
                {
                    ReportBilderPDFSheet(listRowPDF, PDFPath);
                }
                report = outputeData.CreateSheet(listRowPDF.listForPDFExel, listRowUPD.listForUPDExel);
                File.WriteAllBytes(resultExelFile, report);
            }
            else { return; }

            //var report = new DisplayToExcel().CreateSheetPDF(listRowPDF.listForPDFExel, listRowUPD.listForUPDExel);
            //File.WriteAllBytes(resultExelFile, report);
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

