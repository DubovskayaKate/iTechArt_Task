using System;
using System.Collections.Generic;
using System.IO;

namespace LoggerClassLibrary
{
    class TextLogger : ILogger
    {
        private readonly string _filePath;

        public TextLogger(string path = "information.log")
        {
            this._filePath = path;
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
