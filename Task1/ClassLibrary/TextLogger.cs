using System;
using System.Collections.Generic;
using System.IO;

namespace LoggingSection
{
    class TextLogger : ILogger
    {
        private readonly string _filePath = "information.log";

        public TextLogger()
        {

        }

        public void Error(Exception ex)
        {
            File.AppendAllLines(_filePath, new List<string>(){$"Error message: {ex.Message}"});
        }

        public void Error(string message)
        {
            File.AppendAllLines(_filePath, new List<string>(){$"Error: {message}"});
        }

        public void Info(string message)
        {
            File.AppendAllLines(_filePath, new List<string>(){ $"Info: {message}"});
        }

        public void Warning(string message)
        {
            File.AppendAllLines(_filePath,  new List<string>(){$"Warning: {message}"});
        }
    }
}
