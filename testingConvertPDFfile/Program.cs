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
            Controller convertion = new Controller();
            Console.WriteLine("введлите команду:\n f - фильтрация файлов;\n r - создание отчета exel");
            var cheker = "";
            switch (cheker)
            {
                case "f":

                    break;
                case "r":
                    break;
                case
            }


            string[] folderFolders = Directory.GetDirectories(muveToFail);

            convertion.InputControllers(folderFolders, muveToFail + firstNameFail);
        }
    }
}