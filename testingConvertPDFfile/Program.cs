using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using iText.Layout.Properties;

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
        static void ConvOnTtext(string path)
        {
            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("HEADER")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);
            document.Close();
        }

    }
}

