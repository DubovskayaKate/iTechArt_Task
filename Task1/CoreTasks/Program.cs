using System;
using LoggerClassLibrary;

namespace CoreTasks
{
    class Program
    {

        static void Main(string[] args)
        {
            var log = Logger.CreateInstance();

            //----Tests----
            log.Error(new OutOfMemoryException());
            log.Info("Information1");
            log.Error("Error1");
            log.Warning("Waning1");


            
            Console.ReadKey(true);
        }
    }
}