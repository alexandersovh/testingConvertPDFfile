using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using System.IO;

namespace testingConvertPDFfile
{
    internal class PDFToString
    {
        public string ReadPdfFile(string pathPDF)
        {
            StringBuilder text = new StringBuilder();

            PdfReader pdfReader = new PdfReader(pathPDF);

            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, 1, strategy);

            return currentText;
        }
        public void NewPDFReadr(string fileName)
        {

        }
    }
}
