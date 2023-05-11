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
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;


namespace PidPipen
{
    internal class DataClient
    {

        public InputZVstring ZVToEndData(string path)
        {
            FileConvertors convertors = new FileConvertors();
            string stringText = convertors.PDFToText(path);
            string dateTime = File.GetLastWriteTime(path).ToString();

            var inn = ReguxConvert(new Regex(@"(?<=ИНН.)\d+"), stringText) ?? "ошибка ZV";

            string kpp = ReguxConvert(new Regex(@"(?<=КПП.)\d{9}"), stringText) ?? "-";

            string number = ReguxConvert(new Regex(@"(?<=№.)\D\D\d{9}"), stringText) ?? "ошибка ZV";

            string fio = ReguxConvert(new Regex(@"(?<=Фамилия\s(\w*\s){2})(\w*.){3}"), stringText) ?? "ошибка ZV";

            string name = ReguxConvert(new Regex(@"(?<=Наименование организации\s)([\s\S]+?)(?=\sГород)"), stringText) ?? ReguxConvert(new Regex(@"(?<=Фамилия\s(\w*\s){2})(\w*.){3}"), stringText);

            InputZVstring zVstring = new InputZVstring
            {
                Name = name,
                INN = inn,
                KPP = kpp,
                ZVNuber = number,
                FaileDate = dateTime,
                FIO = fio
            };
            return zVstring;
        }
        public InputUPDstring UPDToEndData(string path)
        {
            FileConvertors convertors = new FileConvertors();
            string stringText = convertors.RTFToText(path);

            string numUpd = ReguxConvert(new Regex(@"(?<=Счет-фактура.№\s{5})\D+\d{9}\W\d{2}"), stringText) ?? "ошибка UPD";

            string datе = ReguxConvert(new Regex(@"(?<=от\s+)\d{2}.\d{2}.\d{4}(?=\s+Исправление)"), stringText) ?? "-";

            string name = ReguxConvert(new Regex(@"(?<=Покупатель)(.+)(?=Адрес)|(?<=Покупатель)(.+\s)(?=Адрес)"), stringText) ?? "ошибка UPD";

            string inn = ReguxConvert(new Regex(@"(?<=\sпокупателя)\d+(?=.+Валюта)"), stringText) ?? "ошибка UPD";

            string kpp = ReguxConvert(new Regex(@"(?<=покупателя\d+\W)\d{9}(?=Валюта)"), stringText) ?? "-";

            string АttorneyMen = "-";
            string АttorneyFin = "-";

            if (inn.Length == 10)
            { АttorneyMen = "?"; АttorneyFin = "?"; }

            InputUPDstring UPDstring = new InputUPDstring
            {
                Name = name,
                INN = inn,
                KPP = kpp,
                UPDNuber = numUpd,
                UPDDate = datе,
                АttorneyMen = АttorneyMen,
                АttorneyFin = АttorneyFin
            };
            return UPDstring;
        }

        public string ReguxConvert(Regex reegularExpressions, string genString)
        {
            string result = "";
            MatchCollection matches = reegularExpressions.Matches(genString);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    result = result + match;
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}