using System;
using OfficeOpenXml;
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
using System.Collections.Generic;
using OfficeOpenXml.Core.ExcelPackage;


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
            string folderPath = Console.ReadLine(); //времено
            Console.WriteLine("введите фаил куда копировать или Enter");
            string muveToFail = Console.ReadLine(); //времменно
            string firstNameFail = "\\Отчеты.xlsx";
            if (muveToFail == "")
            {
                muveToFail = folderPath;
            }

            workFail.FiltrFail(folderPath, muveToFail);

            string[] folderFolders = Directory.GetDirectories(muveToFail);

            convertion.InputControllers(folderFolders, muveToFail + firstNameFail);
        }
    }
}