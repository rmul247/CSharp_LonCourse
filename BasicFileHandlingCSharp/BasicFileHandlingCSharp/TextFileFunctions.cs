using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFileHandlingCSharp
{
    public class TextFileFunctions
    {
        private string _rootPath = AppDomain.CurrentDomain.BaseDirectory;

        private string _fileName = "TextFileExample1.txt";

        public TextFileFunctions(string fileName)
        {
            _fileName = fileName;

        }

        public void WriteTextToFile(string[] lines)
        {
            using StreamWriter outputFile = new StreamWriter(Path.Combine(_rootPath, _fileName), true);
            foreach (string line in lines)
            {
                outputFile.WriteLine(line);
            }
        }

        public string ReadFile()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(_rootPath, _fileName)))
            {
                string content = sr.ReadToEnd();
                return content;
            }
        }
    }
}
