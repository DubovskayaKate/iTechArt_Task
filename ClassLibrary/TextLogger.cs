using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace LoggerClassLibrary
{
    class TextLogger : ILogger
    {
        private string filePath;

        public TextLogger(string path = @"information.log")
        {
            this.filePath = path;
        }

        public void Error(Exception ex)
        {
            File.AppendAllText(filePath, $"Error message: {ex.Message}\n");
        }

        public void Error(string message)
        {
            File.AppendAllText(filePath, $"Error: {message}\n");
        }

        public void Info(string message)
        {
            File.AppendAllText(filePath, $"Info: {message}\n");
        }

        public void Warning(string message)
        {
            File.AppendAllText(filePath, $"Warning: {message}\n");
        }
    }
}
