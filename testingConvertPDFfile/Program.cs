﻿using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using RtfPipe;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iText.Commons.Utils;

namespace testingConvertPDFfile
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            DataClient dataClient = new DataClient();
            var prog = new Program();
            var convertors = new FileConvertors();
            string resultst = "";


            //Документ Microsoft Word.pdf//no/Заявление ПД221018045.pdf//юл/Заявление ПЖ221026008.pdf//фл/Заявление ЮБ221022001.pdf
            //длиное/Заявление ПЖ221018001.pdf
            string pathPDF = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Заявление ЮБ221022001.pdf";
            string pathRTF = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\ЛФ220929041_21.rtf";
            string pathRTFToFile = "C:\\Users\\alexandr\\OneDrive\\Рабочий стол\\лаборатрория\\Output.txt";

            //Console.WriteLine(convertors.PDFToText(pathPDF));
            //Console.ReadKey();
            //Console.Clear();
            //Console.WriteLine(convertors.RTFToText(pathRTF));
            //Console.ReadKey();
            //Console.Clear();


            MatchCollection clientData = dataClient.ZVToString(convertors.PDFToText(pathPDF).ToString());
            if (clientData.Count > 0)
            {
                foreach (Match cd in clientData)
                    Console.WriteLine(cd.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
            Console.WriteLine("Yhooooo");
            Console.ReadKey();
        }
    }
}

