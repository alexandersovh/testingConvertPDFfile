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
using static System.Resources.ResXFileRef;


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
        public InputZVstring ZVToEndData(string path)
        {
            FileConvertors convertors = new FileConvertors();
            string stringText= convertors.PDFToText(path).ToString();
            string dateTime = Convert.ToString(File.GetCreationTime(path));
            Regex innCheck = new Regex(@"(?<=ИНН.)\d+");
            MatchCollection innChecker = innCheck.Matches(stringText);

            if (innChecker.Count > 0)
            {

                string inn = Convert.ToString(innChecker[0]);
                if (inn.Length == 10)
                {
                    Regex ZVdata = new Regex(@"(?<=Наименование организации\s)((.*)*?)(?=\sГород)|(?<=ИНН.)\d{10}|(?<=КПП.)\d{9}|(?<=№.)\D\D\d{9}|(?<=Фамилия\s(\w*\s){2})(\w*.){3}");
                    MatchCollection colum = ZVdata.Matches(stringText);
                    InputZVstring zVstring = new InputZVstring 
                    { 
                        Name = Convert.ToString(colum[2]),
                        INN = Convert.ToString(colum[3]),
                        KPP = Convert.ToString(colum[4]),
                        ZVNuber = Convert.ToString(colum[0]),
                        FaileDate = dateTime,
                        FIO = Convert.ToString(colum[1])
                    };
                    return zVstring;
                }
                else
                {
                    Regex ZVdata = new Regex(@"(?<=ИНН.)\d{10}|(?<=№.)\D\D\d{9}|(?<=Фамилия\s(\w*\s){2})(\w*.){3}");
                    MatchCollection colum = ZVdata.Matches(stringText);
                    InputZVstring zVstring = new InputZVstring 
                    { 
                        Name = Convert.ToString(colum[1]),
                        INN = Convert.ToString(colum[2]),
                        KPP = "-",
                        ZVNuber = Convert.ToString(colum[0]),
                        FaileDate = dateTime,
                        FIO = Convert.ToString(colum[1])
                    };
                    return zVstring;
                }
            }
            else
            {
                return null;
            }
        }
        
        public InputUPDstring UPDToEndData(string path)
        {
            FileConvertors convertors = new FileConvertors();
            string stringText = convertors.PDFToText(path).ToString();
            string dateTime = Convert.ToString(File.GetCreationTime(path));

            Regex innCheck = new Regex(@"(?<=\sИНН/КПП покупателя\s+)\d+(?=.+\s+Валюта)");
            MatchCollection innChecker = innCheck.Matches(stringText);


            if (innChecker.Count > 0)
            { }

                string inn = Convert.ToString(innChecker[0]);
                if (inn.Length == 10)
                {
                    Regex ZVdata = new Regex(@"(?<=Счет-фактура.№.+)\D{2}\d{9}.\d{2}|(?<=от\s+)\d{2}.\d{2}.\d{4}\s+(?=Исправление)|(?<=Покупатель\s+)((.*\s)*?)(?=Адрес)|(?<=\sИНН/КПП покупателя\s+)\d+(?=.+\s+Валюта)|(?<=ИНН/КПП покупателя\s+\d+.)\d{9}(?=\s+Валюта)");
                    MatchCollection colum = ZVdata.Matches(stringText);
                    InputUPDstring UPDstring = new InputUPDstring 
                    { 
                        Name = Convert.ToString(colum[2]),
                        INN = Convert.ToString(colum[3]), 
                        KPP = Convert.ToString(colum[4]),
                        UPDNuber = Convert.ToString(colum[0]), 
                        FaileDate = Convert.ToString(colum[1]),
                        АttorneyMen = "?", АttorneyFin = "?" 
                    };
                    return UPDstring;
                }
                else
                {
                    Regex ZVdata = new Regex(@"(?<=Счет-фактура.№.+)\D{2}\d{9}.\d{2}|(?<=от\s+)\d{2}.\d{2}.\d{4}\s+(?=Исправление)|(?<=Покупатель\s*)\S+\s\S+\s\S+(?=\s+Адрес)|(?<=ИНН/КПП покупателя\s+)\d+(?=.*\s*Валюта)");
                    MatchCollection colum = ZVdata.Matches(stringText);
                    InputUPDstring UPDstring = new InputUPDstring
                    {
                        Name = Convert.ToString(colum[2]),
                        INN = Convert.ToString(colum[3]),
                        KPP = "-",
                        UPDNuber = Convert.ToString(colum[0]),
                        FaileDate = Convert.ToString(colum[1]),
                        АttorneyMen = "-",
                        АttorneyFin = "-"
                    };
                    return UPDstring;
                }
            }
    }
}
