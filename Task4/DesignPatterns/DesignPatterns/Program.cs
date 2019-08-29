using System;
using System.ComponentModel.DataAnnotations;
using AbstractFactory;
using AbstractFactory.Factory;
using Adapter;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySuperCar = new Car(new ExtraCarFactory());
            mySuperCar.ShowInfo();

            Console.ReadKey(true);


            var library = new Library();
            var xml = library.GetBooksXML();
            Console.WriteLine(xml);

            var adapter = new JsonAdapter(new BookAnalyzer());
            var book = adapter.GetOldestBook(xml);
            Console.ReadKey(true);
        }
    }
}
