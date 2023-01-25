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
    }
}
