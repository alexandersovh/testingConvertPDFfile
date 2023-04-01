using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Net.Sgoliver.NRtfTree.Core;
using System.Text;
using System.Windows.Forms;

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
            RtfTree tree = new RtfTree();

            tree.LoadRtfFile(path);

            return tree.Text;
        }
    }
}