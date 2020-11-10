using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextFileConverterQuick
{
    class Program
    {
        static bool isReverse = false;

        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var words = File.ReadAllLines(path + "/Words.txt");

            List<string> vs = new List<string>();

            if (!isReverse)
            {
                foreach (var str in words)
                {
                    if (!vs.Contains($"\"{str.ToLower()}\","))
                    {
                        vs.Add($"\"{str.ToLower()}\",");
                    }
                }

                vs.Sort();
            }
            else
            {
                foreach (var str in words)
                {
                    var clean = str.ToLower().Replace("\"", "").Replace(",", "");

                    clean.Trim();

                    if (!vs.Contains($"{clean}"))
                    {
                        vs.Add($"{clean}");
                    }
                }

                vs.Sort();
            }
            File.AppendAllLines(path + "/NewWords.txt", vs);
        }
    }
}
