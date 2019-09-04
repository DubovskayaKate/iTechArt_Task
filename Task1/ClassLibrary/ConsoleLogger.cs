using System;

namespace LoggingSection
{
    class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

        public void Error(Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"Info: {message}");
        }
    }
}
