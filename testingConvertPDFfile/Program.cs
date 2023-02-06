using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using RtfPipe;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iText.Commons.Utils;

namespace testingConvertPDFfile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            DataClient dataClient = new DataClient();
            var prog = new Program();
            var convertors = new FileConvertors();
            var exel
            var reportExcel = new DisplayToExcel().CreateExel();


            string pathPDF = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Заявление ПЖ221026008.pdf";
            string pathRTF = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\ПГ220923009_48.rtf"; //фл//ПГ220923009_48.rtf //юл//ЛФ220929041_21.rtf
            string pathRTFToFile = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Output.txt";



            File.WriteAllBytes("C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Report1.xlsx", reportExcel);
        }
    }
}

