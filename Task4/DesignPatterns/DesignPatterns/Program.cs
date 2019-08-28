using System;
using AbstractFactory;
using AbstractFactory.Factory;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySuperCar = new Car(new ExtraCarFactory());
            mySuperCar.ShowInfo();

            Console.ReadKey(true);
        }
    }
}
