using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using RtfPipe;


namespace testingConvertPDFfile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var prog = new Program();
            var testObj = new PDFToString();


            //Документ Microsoft Word.pdf//Заявление ПД221018045.pdf
            string path = "C:\\Users\\aa.sivohin\\Desktop\\лаба\\Заявление ЮБ230106001.pdf";
            string pathTo = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\output1.txt";

            string result = testObj.ReadPdfFile(path);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public string Convert(Stream stream)
        {
            stream.Position = 0;
            string rtf = string.Empty;
            using (StreamReader sr = new StreamReader(stream))
            {
                rtf = sr.ReadToEnd();
            }
            // Эта строчка необходима для работы RtfPipe в Core 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // С помощью либы RtfPipe создаем html
            var html = Rtf.ToHtml(rtf);
            // очищаем html от лишних тегов и атрибутов, возвращем готовую xml
            return ClearHtml(html);
        }
    }
}

