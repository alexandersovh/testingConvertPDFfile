using System;
using System.IO;


namespace testingConvertPDFfile
{
    internal class CheckFailBilder
    {
        public string CheckFail(string сheckFolderPathTo, string firstNameFail, DateTime reportingData, string chek)
        {
            string nameCheker = "";
               if (chek == "m")
            {
                nameCheker = сheckFolderPathTo + "\\" + firstNameFail + " " + reportingData.Month.ToString() + "." + reportingData.Year.ToString();
            }
               else if (chek == "d")
            {
                nameCheker = сheckFolderPathTo + "\\" + firstNameFail + " " + reportingData.Day.ToString()+ "." + reportingData.Month.ToString() + "." + reportingData.Year.ToString();
            }
            string finalPath = null; // убери это нахуй, есть проверка используется в 1м условиив конце там *111
            foreach (var faile in Directory.GetFiles(сheckFolderPathTo))
            {
                if (faile == nameCheker)
                {
                    finalPath = nameCheker;
                    break;
                }
            }
            if (finalPath == null) // проверка на null *111
            {
                CreateFail(nameCheker);
                finalPath = nameCheker;
            }
            return finalPath;
        }
        private void CreateFail(string newFolderPath)
        {
            Directory.CreateDirectory(newFolderPath);
        }
    }
}