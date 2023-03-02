using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading.Tasks;
using RtfPipe;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iText.Commons.Utils;
using RtfPipe.Tokens;

namespace testingConvertPDFfile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DistributionFail workFail = new DistributionFail();
            Console.WriteLine("введите фаил с данными");
            string folderPath = Console.ReadLine();
            Console.WriteLine("введите фаил куда копировать");
            string muveToFail = Console.ReadLine();

            workFail.FiltrFail(folderPath, muveToFail); // рабочтий код
            Console.WriteLine("I finish program");

            var CreatExel = new Controller();
            CreatExel.InputControllers();
        }
    }
}

