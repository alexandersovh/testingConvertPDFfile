using System;
using System.IO;

namespace testingConvertPDFfile
{
    internal class DistributionFail
    {
        public void FiltrFail(string folderPath, string muveToFail)
        {
            var checkFail = new CheckFailBilder();
            DateTime dataCteat;
            string[] allfiles = Directory.GetFiles(folderPath);
            int fileCounter = 0;
            foreach (string filename in allfiles)
            {
                dataCteat = File.GetCreationTime(filename);
                fileCounter++;
                if (filename.EndsWith(".rtf"))
                {
                    File.Move(filename, checkFail.CheckFail(muveToFail, "УПД", dataCteat) + "\\" + Path.GetFileName(filename) + fileCounter.ToString());
                }
                else if (filename.Contains("Заявление"))
                {
                    File.Move(filename, checkFail.CheckFail(muveToFail, "Заявление", dataCteat) + "\\" + Path.GetFileName(filename) + fileCounter.ToString());
                }
                else if (filename.Contains("statement_attachment ") || filename.Contains("confirm_"))
                {
                    File.Move(filename, checkFail.CheckFail(muveToFail, "trashcan", dataCteat) + "\\" + Path.GetFileName(filename) + fileCounter.ToString());
                }
            }
        }

    }
}
