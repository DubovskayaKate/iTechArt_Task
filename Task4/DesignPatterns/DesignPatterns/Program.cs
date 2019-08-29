using System;
using System.ComponentModel.DataAnnotations;
using AbstractFactory;
using AbstractFactory.Factory;
using Adapter;
using Facade;
using Proxy;
using Proxy = Proxy.ProxyYesterdayRate;

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
            var adapter = new JsonAdapter(new BookAnalyzer());
            var book = adapter.GetOldestBook(xml);

            var convert = new SimpleConverter();
            convert.Convert("cats.mp4", "MPEG4");

            IYesterdayRate yesterdayRate = new ProxyYesterdayRate(new YesterdayRate());
            var list = yesterdayRate.GetRate();
            foreach (var rate in list)
            {
                Console.WriteLine(rate);
            }

            Console.ReadKey(true);


        }
    }
}
