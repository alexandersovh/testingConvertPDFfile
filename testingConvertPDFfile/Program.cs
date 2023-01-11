using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Threading.Tasks;


namespace testingConvertPDFfile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var prog = new Program();
            var testObj = new PDFToString();


            //Документ Microsoft Word.pdf//Заявление ПД221018045.pdf
            string path = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Заявление ПЖ221026008adob.pdf";
            string pathTo = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\output1.txt";

            string result = testObj.ReadPdfFile(path);
            Console.WriteLine(result);
            Console.ReadKey();

            
        }
    }
}

