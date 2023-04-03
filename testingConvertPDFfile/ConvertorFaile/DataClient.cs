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


namespace PidPipen
{
    internal class DataClient
    {

        public InputZVstring ZVToEndData(string path)
        {
            FileConvertors convertors = new FileConvertors();
            string stringText = convertors.PDFToText(path).ToString();
            DateTime dateTime = File.GetLastWriteTime(path);
            Regex innCheck = new Regex(@"(?<=ИНН.)\d+");
            MatchCollection innChecker = innCheck.Matches(stringText);

            string inn = Convert.ToString(innChecker[0]);
            if (inn.Length == 10)
            {
                Regex ZVdata = new Regex(@"(?<=Наименование организации\s)([\s\S]+?)(?=\sГород)|(?<=ИНН.)\d{10}|(?<=КПП.)\d{9}|(?<=№.)\D\D\d{9}|(?<=Фамилия\s(\w*\s){2})(\w*.){3}");
                MatchCollection colum = ZVdata.Matches(stringText);
                InputZVstring zVstring = new InputZVstring
                {
                    Name = Convert.ToString(colum[2]),
                    INN = Convert.ToString(colum[3]),
                    KPP = Convert.ToString(colum[4]),
                    ZVNuber = Convert.ToString(colum[0]),
                    FaileDate = dateTime.ToString("d"),
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
                    FaileDate = dateTime.ToString("d"),
                    FIO = Convert.ToString(colum[1])
                };
                return zVstring;
            }
        }

        public InputUPDstring UPDToEndData(string path)
        {
            FileConvertors convertors = new FileConvertors();
            string stringText = convertors.RTFToText(path).ToString();

            Regex innCheck = new Regex(@"(?<=покупателя)\d+(?=\W.*Валюта)");
            MatchCollection innChecker = innCheck.Matches(stringText);

            string inn = Convert.ToString(innChecker[0]);
            if (inn.Length == 10)
            {
                Regex ZVdata = new Regex(@"(?<=Счет-фактура.№\s{5})\D+\d{9}\W\d{2}|(?<=от\s+)\d{2}.\d{2}.\d{4}(?=\s+Исправление)|(?<=3Покупатель)(\S+.+)(?=Адрес)|(?<=3Покупатель)(\S+.+)(?=\sАдрес)|(?<=\sпокупателя)\d+(?=\W\d+Валюта)|(?<=покупателя\d+\W)\d{9}(?=Валюта)");
                MatchCollection colum = ZVdata.Matches(stringText);
                InputUPDstring UPDstring = new InputUPDstring
                {
                    Name = Convert.ToString(colum[2]),
                    INN = Convert.ToString(colum[3]),
                    KPP = Convert.ToString(colum[4]),
                    UPDNuber = Convert.ToString(colum[0]),
                    UPDDate = Convert.ToString(colum[1]),
                    АttorneyMen = "?",
                    АttorneyFin = "?"
                };
                return UPDstring;
            }
            else
            {
                Regex ZVdata = new Regex(@"(?<=Счет-фактура.№\s+)\w+\d{9}\W\d{2}|(?<=от\s+)\d{2}.\d{2}.\d{4}(?=\s+Исправление)|(?<=Покупатель)(.+\s*)(?=Адрес)|(?<=ИНН/КПП\sпокупателя)\d+(?=\W+Валюта)");
                MatchCollection colum = ZVdata.Matches(stringText);
                InputUPDstring UPDstring = new InputUPDstring
                {
                    Name = Convert.ToString(colum[2]),
                    INN = Convert.ToString(colum[3]),
                    KPP = "-",
                    UPDNuber = Convert.ToString(colum[0]),
                    UPDDate = Convert.ToString(colum[1]),
                    АttorneyMen = "?",
                    АttorneyFin = "?"
                };
                return UPDstring;
            }
        }
    }
}
