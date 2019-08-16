using System;
using System.IO;

namespace LoggerClassLibrary
{
    class TextLogger : ILogger
    {
        private readonly string _filePath;

        public TextLogger(string path = @"information.log")
        {
            this._filePath = path;
        }

        public void Error(Exception ex)
        {
            File.AppendAllText(_filePath, $"Error message: {ex.Message}\n");
        }

        public void Error(string message)
        {
            File.AppendAllText(_filePath, $"Error: {message}\n");
        }

        public void Info(string message)
        {
            File.AppendAllText(_filePath, $"Info: {message}\n");
        }

        public void Warning(string message)
        {
            File.AppendAllText(_filePath, $"Warning: {message}\n");
        }
    }
}
