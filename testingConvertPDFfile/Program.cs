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
            string resultst = "";


            //Документ Microsoft Word.pdf//no/Заявление ПД221018045.pdf//юл/Заявление ПЖ221026008.pdf//фл/Заявление ЮБ221022001.pdf
            //длиное/Заявление ПЖ221018001.pdf
            string pathPDF = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Заявление ПЖ221026008.pdf";
            string pathRTF = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\ПГ220923009_48.rtf"; //фл//ПГ220923009_48.rtf //юл//ЛФ220929041_21.rtf
            string pathRTFToFile = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Output.txt";

            //Console.WriteLine(convertors.PDFToText(pathPDF));
            //Console.ReadKey();
            //Console.Clear();
            //Console.WriteLine(convertors.RTFToText(pathRTF));
            //Console.ReadKey();
            //Console.Clear();
            int i = -1;
            //InputUPDstring inputUPDstring = new InputUPDstring();

            MatchCollection clientDataP = dataClient.ZVToEndData(pathPDF); //print string with data in PDF file
            if (clientDataP.Count > 0)
            {
                //InputUPDstring inputUPDstring = new InputUPDstring { Name = clientDataP[] };
                foreach (Match cd in clientDataP)
                {
                    i++;
                    Console.Write(i + "  ");
                    Console.WriteLine(cd.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
            Console.WriteLine("Yhooooo PDF");
            MatchCollection clientDataR = dataClient.UPDToEndData(convertors.RTFToText(pathRTF).ToString()); //print string with data in PDF file
            if (clientDataR.Count > 0)
            {
                foreach (Match cd in clientDataR)
                {
                    i++;
                    Console.Write(i + "  ");
                    Console.WriteLine(cd.Value);
                }
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }

                Console.WriteLine("Yhooooo");
            Console.ReadKey();
        }
    }
}

