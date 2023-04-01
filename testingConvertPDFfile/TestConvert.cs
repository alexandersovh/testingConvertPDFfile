using RtfPipe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using RichTextBox = System.Windows.Forms.RichTextBox;
using SautinSoft.Document;
using Net.Sgoliver.NRtfTree.Core;

namespace PidPipen
{
    internal class TestConvert
    {
        public void cikleTest(string path)
        {
            string s;
            string[] pathsFile = Directory.GetFiles(path);
            foreach (var file in pathsFile)
            {
                //ConvertFromFile(file);
                string resStr = ConvertFromFileSD(file);
                //ConvertFromFileSD(file);
                string intoRTF = "text - \n\n\n" + ConvertFromFileSD(file) + "\n\n\n - End text.";
                Console.WriteLine(intoRTF);
                Console.ReadKey();
                Console.Clear();
            }
        }
        public string SelectString(string path)
        {
            RichTextBox rtBox = new RichTextBox();

            string s = File.ReadAllText(path, Encoding.UTF8);

            return s;
        }

        public string conToRTF(string srt)
        {
            RichTextBox rtBox = new RichTextBox();

            rtBox.Rtf = srt;

            //string plainText = rtBox.Text;

            return rtBox.Text;
        }
        static string ConvertFromFileSD(string path)
        {
            RtfTree tree = new RtfTree();

            tree.LoadRtfFile(path);

            return tree.Text;
        }
    }
}
