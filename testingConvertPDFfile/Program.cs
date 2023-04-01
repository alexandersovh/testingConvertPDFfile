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
using Microsoft.Office.Core;


namespace PidPipen
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Controller controller = new Controller();
            var baze = new WorkFile();
            var convertion = new Controller();
            DistributionFail workFail = new DistributionFail();
            string operation = "";

            while (operation != "stope")
            {
                Console.WriteLine("Выбирите действие:\n 'fm' - чтобы отфильтровать файлы,\n 'fd' - чтобы отфильтровать файлы, \n 'r' - создать Exel файл с отчетом, \n Enter - для акрытия программы");
                operation = Console.ReadLine();

                switch (operation)
                {
                    case "fm":
                        baze = controller.FailsForWork();
                        workFail.FiltrFail(baze.FileWithData, baze.FileMuveTo, "m");
                        break;
                    case "fd":
                        baze = controller.FailsForWork();
                        workFail.FiltrFail(baze.FileWithData, baze.FileMuveTo, "d");
                        break;
                    case "r":
                        baze = controller.FailsForWork();
                        convertion.InputControllers(baze.FileMuveTo, baze.FileReport);
                        break;
                    case "":
                        Console.WriteLine("закршить программу?");
                        operation = "stope";
                        Console.ReadKey();
                        break;
                    case "t":
                        string path111 = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\drops";//"C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\итог\\УПД 1.2023";   //Console.ReadLine();
                        TestConvert testToText = new TestConvert();
                        testToText.cikleTest(path111);
                        break;
                }

            }
        }
    }
}