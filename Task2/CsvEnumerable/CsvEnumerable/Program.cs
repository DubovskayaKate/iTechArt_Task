using System;
using CsvHelper;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using CsvClassLibrary;

namespace CsvEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvEnum = new CsvEnumerable<TestDataRecord>();

            // Tests
            foreach (var record in csvEnum)
            {
                Console.WriteLine($"Name {record.Name}; Surname {record.Surname}");
            }
            Console.WriteLine("--------");

            foreach (var record in csvEnum)
            {
                Console.WriteLine($"Name {record.Name}; Surname {record.Surname}");
            }

            Console.ReadKey(true);
        }
    }
}
