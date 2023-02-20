using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;

namespace testingConvertPDFfile
{
    internal class FileConvertors
    {
        public string PDFToText(string pathPDF)
        {
            StringBuilder text = new StringBuilder();


            PdfReader pdfReader = new PdfReader(pathPDF);
            var pdfDocument = new PdfDocument(pdfReader);
            var contents = iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(pdfDocument.GetFirstPage());

            return contents;
        }
        public string RTFToText(string path)
        {
            System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

            string s = System.IO.File.ReadAllText(path);

            rtBox.Rtf = s;

            string plainText = rtBox.Text;

            return plainText;
        }
    }
}
