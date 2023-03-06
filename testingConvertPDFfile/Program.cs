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
            var CreatExel = new Controller();
            var convertion = new Controller();
            DistributionFail workFail = new DistributionFail();
            Console.WriteLine("введите фаил с данными");
            string folderPath = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория";  //Console.ReadLine(); //времено
            Console.WriteLine("введите фаил куда копировать или Enter");
            string muveToFail = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаба_2";  //Console.ReadLine(); //времменно
            string firstNameFail = "\\Отчеты.xlsx";
            if (muveToFail == "")
            {
                muveToFail = folderPath;
            }

            workFail.FiltrFail(folderPath, muveToFail);

            string[] folderFolders = Directory.GetDirectories(muveToFail);

            foreach (string folder in folderFolders)
            {
                convertion.InputControllers(folder, muveToFail + firstNameFail);
            }
            

             // рабочтий код
            Console.WriteLine("I finish program");
        }
    }
}

