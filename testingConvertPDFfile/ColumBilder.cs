using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace testingConvertPDFfile
{
    internal class ColumBilder
    {

        private string rung;
        private void INNChecker(string[] baseText)
        {
            ColumBilder columBilder = new ColumBilder();
            string[] wordArray;

            if (columBilder.RetuenINN(baseText).Length > 10)
            {
                rung = "ФЛ";
            }
            else
            {
                rung = "ЮЛ";
            }

        }
        private string RetuenFIO(string[] baseText)
        {
            string[] wordArray;
            string result = null;
            foreach (string drobText in baseText)
            {
                wordArray = drobText.Split(' ');
                if (wordArray[0] == "Фамилия")
                {
                    for (int i = 3; i < wordArray.Length; i++)
                    {
                        result = result + " " + wordArray[i];
                    }
                }
            }
            return result;
        }
        private string returnName(string[] baseText)
        {
            string[] wordArray;
            string result = null;
            foreach (string drobText in baseText)
            {
                wordArray = drobText.Split(' ');
                if (wordArray[0] == "Наименование")
                {
                    for (int i = 3; i < wordArray.Length; i++)
                    {
                        result = result + " " + wordArray[i];
                    }
                }
                else if (wordArray[0] == "Город")
                {
                    break;
                }
                else
                {
                    for (int i = 3; i < wordArray.Length; i++)
                    {
                        result = result + " " + wordArray[i];
                    }
                }
            }
            return result;
        }
        private string RetuenINN(string[] baseText)
        {
            string[] wordArray;
            string result = null;
            foreach (string drobText in baseText)
            {
                wordArray = drobText.Split(' ');
                if (wordArray[0] == "ИНН")
                {
                    result = wordArray[1];
                }
            }
            return result;
        }
        private string RetuenKPP(string[] baseText)
        {
            string[] wordArray;
            string result = null;
            if (rung == "ЮЛ")
            {
                foreach (string drobText in baseText)
                {
                    wordArray = drobText.Split(' ');
                    if (wordArray[0] == "КПП")
                    {
                        result = wordArray[1];
                    }
                }
            }
            else
            {
                result = " - ";
            }
            return result;
        }
        private string RetuenNumber(string[] baseText)
        {
            string[] wordArray;
            string result = null;
            foreach (string drobText in baseText)
            {
                wordArray = drobText.Split(' ');
                if (wordArray[0] == "Заявление")
                {
                    result = wordArray[2];
                }
            }
            return result;
        }
        private string RetuenData(string path)
        {
            string result = null;
            DateTime faolDate = File.GetCreationTime(path);
            result = faolDate.ToShortDateString().ToString();
            return result;
        }
    }
}
