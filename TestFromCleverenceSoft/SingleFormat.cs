using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestFromCleverenceSoft
{
    public class SingleFormat
    {
        public SingleFormat(){}
        public void Work(string inputPath)
        {
            StreamReader reader = new StreamReader(inputPath);
            List<string> fileLineByLine = new List<string>();
            string line = "";
            while ((line =  reader.ReadLine()) != null)
            {
                fileLineByLine.Add(line);
            }
            if((fileLineByLine[1].Contains("Дата:")) &&
                (fileLineByLine[2].Contains("Время:")) &&
                (fileLineByLine[3].Contains("УровеньЛогирования:")) &&
                (fileLineByLine[fileLineByLine.Count-1].Contains("Сообщение:")))
            {
                StreamWriter writer = new StreamWriter(@"..\..\Files\OutputLogFile.txt", true);
                writer.Write((DateTime.Parse(fileLineByLine[1].Remove(0,6))).ToString("dd-MM-yyyy"));
                writer.Write('\t');
                writer.Write(fileLineByLine[2].Remove(0, 7));
                writer.Write('\t');
                string logLevel = fileLineByLine[3].Remove(0, 20);
                if (logLevel== "INFORMATION")
                {
                    writer.Write("INFO");
                }
                else if(logLevel== "WARNING")
                {
                    writer.Write("WARN");
                }
                else
                {
                    writer.Write(logLevel);
                }
                writer.Write('\t');
                if(fileLineByLine.Count==6)
                {
                    writer.Write(fileLineByLine[4].Remove(0, 16));
                    writer.Write('\t');
                }
                writer.Write(fileLineByLine[fileLineByLine.Count - 1].Remove(0, 11));
                writer.WriteLine("");
                writer.Close();
            }
            else
            {
                StreamWriter writer = new StreamWriter(@"..\..\Files\problems.txt", true);
                for (int i = 0; i < fileLineByLine.Count; i++)
                {
                    writer.WriteLine(fileLineByLine[i]);
                }
                writer.WriteLine("");
                writer.Close();
            }
        }
    }
}