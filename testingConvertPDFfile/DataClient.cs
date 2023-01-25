using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using iText.Commons.Utils;

namespace testingConvertPDFfile
{
    internal class DataClient
    {
        private string StringFiltr(string path)
        {
            FileConvertors convertors = new FileConvertors();
            string baseString;
            string[] fileString;
            if (path.EndsWith("pdf"))
            {
                baseString = convertors.PDFToText(path);
            }
            else
            {
                baseString = convertors.RTFToText(path);
            }
            return baseString;
        }
        public MatchCollection ZVToString(string stringText)
        {
            Regex innCheck = new Regex(@"(?<=ИНН.)\d+");
            MatchCollection innChecker = innCheck.Matches(stringText);

            if (innChecker.Count > 0)
            {
                
                string inn = Convert.ToString(innChecker[0]);
                if (inn.Length == 10)
                {
                    Regex ZVdata = new Regex(@"(?<=Наименование организации\s)((.*\s)*?)(?=Город)|(?<=ИНН.)\d{10}|(?<=КПП.)\d{9}|(?<=№.)\D\D\d{9}|(?<=Фамилия\s(\w*\s){2})(\w*.){3}");
                    //Regex testing = new Regex(@""); //testing regex, delit this
                    MatchCollection colum = ZVdata.Matches(stringText);
                    return colum;
                }
                else
                {
                    Regex ZVdata = new Regex(@"(?<=ИНН.)\d{10}|(?<=№.)\D\D\d{9}|(?<=Фамилия\s(\w*\s){2})(\w*.){3}");
                    MatchCollection colum = ZVdata.Matches(stringText);
                    return colum;
                }
            }
            else
            {
                return innChecker;
            }

        }
        //public List<string> ZVFiltr(string path)
        //{
        //    FileConvertors convertors = new FileConvertors();
        //    DataClient filtr = new DataClient();
        //    List<string> finalString = new List<string>();
        //    int result;
        //    string orgName = "";

        //    string resultString = StringFiltr(path);
        //    string[] fileString = resultString.Split('\n');
        //    string dataTimeFile = File.GetLastWriteTime(path).ToString();
        //    string[] dateFile = dataTimeFile.Split(' ');

        //    finalString.Add(dateFile[0]);
        //    foreach (string substring in fileString)
        //    {
        //        string[] substringArray = substring.Split(' ');
        //        result = filtr.ResData(substringArray[0]);
        //        if (result != 0)
        //        {
        //            string stringToLink = "";
        //            for (int i = result; i < substringArray.Length; i++)
        //            {
        //                stringToLink = stringToLink + " " + substringArray[i];
        //            }
        //            finalString.Add(stringToLink);
        //        }
        //        else if (substringArray[0] == "Наименование")
        //        {
        //            for (int i = result + 1; i < substringArray.Length; i++)
        //            {
        //                orgName = orgName + " " + substringArray[i];
        //            }
        //        }
        //        else if (substringArray[0] == "Город")
        //        {
        //            finalString.Add(orgName);
        //        }
        //    }
        //    return finalString;
        //}
        //private int ResData(string substring)
        //{
        //    int numColl = 0;
        //    switch (substring)
        //    {
        //        case "Фамилия":
        //            return numColl = 3;
        //        case "ИНН":
        //            return numColl = 1;
        //        case "КПП":
        //            return numColl = 1;
        //        case "Заявление":
        //            return numColl = 2;
        //    }

        //    return numColl;
        //}
    }
}
