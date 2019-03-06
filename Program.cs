using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read file in List<string> with removed empty lines and all extra symbols
            var lines = ReadFileInList(@"C:\Users\evgen\source\repos\Task3\Task3\TheIdiot.txt");

            // Write List<string> in new file
            WriteListInFile(lines, @"C:\Users\evgen\source\repos\Task3\Task3\TheIdiot_FromList.txt");

            // Create SortedDictionary<string, List<int>> from List
            var index = CreateDictionary(lines);

            // Write dictionary in file
            WriteDictionaryInFile(index, @"C:\Users\evgen\source\repos\Task3\Task3\TheIdiot_FromDict.txt");

            // Delay...
            Console.ReadKey();
        }

        private static SortedDictionary<string, List<int>> CreateDictionary(List<string> lines)
        {
            Console.WriteLine("Creating dictionary...");
            var index = new SortedDictionary<string, List<int>>();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] words = lines[i].Split(' ');

                foreach (var eachWord in words)
                {
                    if (eachWord.Trim() != "")
                    {
                        string word = eachWord.ToLower();
                        if (index.ContainsKey(word))
                        {
                            index[word].Add(i);
                        }
                        else
                        {
                            // add new word and line number to dictionary
                            index.Add(word, new List<int> { i });
                        }
                    }

                }
            }
            Console.WriteLine("Dictionary is created.\n");
            return index;
        }

        private static void WriteDictionaryInFile(SortedDictionary<string, List<int>> index, string path)
        {
            try
            {
                Console.WriteLine("Writing dictionary in file...");
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    foreach (var entry in index)
                    {
                        
                        string line = "";
                        for (int i = 0; i < entry.Value.Count; i++)
                        {
                            line += i != entry.Value.Count - 1 ? entry.Value[i].ToString() + ", " : entry.Value[i].ToString();
                        }
                        sw.WriteLine(entry.Key + ": " + line);
                    }
                }
                Console.WriteLine("Dictionary file is created.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void WriteListInFile(List<string> lines, string path)
        {
            try
            {
                Console.WriteLine("Creating file from list...");
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    foreach(var line in lines)
                    {
                        sw.WriteLine(line);
                    }
                }
                Console.WriteLine("List file is created.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<string> ReadFileInList(string path)
        {
            Console.WriteLine("Reading file and creating list...");
            var lines = new List<string>();
            var reg = new Regex(@"[^ ’0-9A-Za-z\-]");

            try
            { 
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.Equals(""))
                        {
                            line = reg.Replace(line, "");
                            line = line.Replace("—", " ");
                            lines.Add(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("List is created.\n");
            return lines;
        }
    }
}
