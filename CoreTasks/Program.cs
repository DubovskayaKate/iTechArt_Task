using System;
using LoggerClassLibrary;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace CoreTasks
{
    class Program
    {

        static void Main(string[] args)
        {
            var startUp = new StartUp();
            var log = new Logger(startUp.DictSettings);

            //----Tests----
            log.Error(new OutOfMemoryException());
            log.Info("Information1");
            log.Error("Error1");
            log.Warning("Waning1");


            
            Console.ReadKey(true);
        }
    }
}