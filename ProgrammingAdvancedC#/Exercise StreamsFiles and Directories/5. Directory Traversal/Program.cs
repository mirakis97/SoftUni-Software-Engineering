using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesData = new Dictionary<string, Dictionary<string, double>>();
            foreach (string fullFileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fullFileName);

                var extension = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbSize = Math.Round(size / 1024.0, 3);
                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }


                filesData[extension].Add(fileInfo.Name, kbSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedDict = filesData.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            List<string> res = new List<string>();

            foreach (var item in sortedDict)
            {
                res.Add(item.Key);

                foreach (var fileData in item.Value.OrderBy(x => x.Value))
                {
                    res.Add($"--{fileData.Key} - {fileData.Value}kb");
                }
            }
            var path = Path.Combine (Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"output.txt");
            File.WriteAllLines(path, res);
        }
    }
}
