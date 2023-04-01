﻿using System;
using System.IO;
using System.Linq;

namespace PidPipen
{
    internal class DistributionFail
    {
        public void FiltrFail(string folderPath, string muveToFail, string chek)
        {
            CheckFailBilder checkFail = new CheckFailBilder();
            DateTime dataCteat;
            string[] allfiles = Directory.GetFiles(folderPath);
            foreach (string filename in allfiles)
            {
                dataCteat = File.GetCreationTime(filename);
                if (filename.Contains(".rtf") && filename.Contains("~$")!=true)
                {
                    File.Move(filename, checkFail.CheckFail(muveToFail, "УПД", dataCteat, chek) + "\\" + Path.GetFileName(filename));
                }
                else if (filename.Contains("Заявление"))
                {
                    File.Move(filename, checkFail.CheckFail(muveToFail, "Заявление", dataCteat, chek) + "\\" + Path.GetFileName(filename));
                }
                else if (filename.Contains("statement_attachment ") || filename.Contains("confirm_") || filename.Contains("~$"))
                {
                    File.Move(filename, checkFail.CheckFail(muveToFail, "trashcan", dataCteat, chek) + "\\" + Path.GetFileName(filename));
                }
            }

        }

    }
}
