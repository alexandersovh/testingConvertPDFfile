using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iTextSharp.text.pdf.parser;
using System.Text;
using ITextExtractionStrategy = iText.Kernel.Pdf.Canvas.Parser.Listener.ITextExtractionStrategy;

namespace testingConvertPDFfile
{
    internal class PDFToString
    {
        public string ReadPdfFile(string pathPDF)
        {
            StringBuilder text = new StringBuilder();

            ITextExtractionStrategy strategy = new iText.Kernel.Pdf.Canvas.Parser.Listener.SimpleTextExtractionStrategy();

            var pdfReader = new PdfReader(pathPDF);
            var pdfDocument = new PdfDocument(pdfReader);
            var contents = iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(pdfDocument.GetFirstPage());

            return contents;
        }
        public void NewPDFReadr(string fileName)
        {

        }
    }
}
