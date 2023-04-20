using RtfPipe.Tokens;
using System;
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
            string[] allFolder = Directory.GetDirectories(folderPath);
            string[] allElement = allfiles.Concat(allFolder).ToArray();
            foreach (string filename in allElement)
            {
                FileAttributes attr = File.GetAttributes(filename);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    FiltrFail(filename, muveToFail, chek);
                }
                else
                {
                    dataCteat = File.GetCreationTime(filename);
                    if (filename.Contains(".rtf") && !filename.Contains("$"))
                    {
                        File.Copy(filename, checkFail.CheckFail(muveToFail, "УПД", dataCteat, chek) + "\\" + Path.GetFileName(filename));
                    }
                    else if (filename.Contains("Заявление"))
                    {
                        File.Copy(filename, checkFail.CheckFail(muveToFail, "Заявление", dataCteat, chek) + "\\" + Path.GetFileName(filename));
                    }
                    else if (filename.Contains("statement_attachment ") || filename.Contains("confirm_") || filename.Contains("~$"))
                    {
                        File.Copy(filename, checkFail.CheckFail(muveToFail, "trashcan", dataCteat, chek) + "\\" + Path.GetFileName(filename));
                    }
                }
            }

        }
    }
}
