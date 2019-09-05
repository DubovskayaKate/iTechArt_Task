using System;
using AbstractFactory;
using AbstractFactory.Factory;
using Adapter;
using Facade;
using Proxy;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySuperCar = new Car(new ExtraCarFactory());
            mySuperCar.ShowInfo();
            
            var library = new Library();
            var xml = library.GetBooksXML();
            var adapter = new BookAnalyzerAdapter(new BookAnalyzer());
            var book = adapter.GetOldestBook(xml);

            var convert = new SimpleConverter();
            convert.Convert("cats.mp4", "MPEG4");

            IYesterdayRate yesterdayRate = new YesterdayRateProxy(new YesterdayRate());
            var list = yesterdayRate.GetRate();
            foreach (var rate in list)
            {
                Console.WriteLine(rate);
            }

            Console.ReadKey(true);


        }
    }
}
