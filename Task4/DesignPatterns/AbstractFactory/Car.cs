using System;
using System.Net.NetworkInformation;
using AbstractFactory.Engine;
using AbstractFactory.Factory;
using AbstractFactory.Suspension;
using AbstractFactory.Wheel;

namespace AbstractFactory
{
    public class Car
    {
        private readonly IEngine _engine;
        private readonly ISuspension _suspension;
        private readonly IWheel _wheel;

        public Car(ICarFactory factory)
        {
            _engine = factory.CreateEngine();
            _suspension = factory.CreateSuspension();
            _wheel = factory.CreateWheel();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Engine Capacity: {_engine.EngineCapacity}");
            Console.WriteLine($"Width suspension: {_suspension.Width}");
            Console.WriteLine($"Wheel radius: {_wheel.Radius}");
        }
    }
}