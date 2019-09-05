using AbstractFactory.Engine;
using AbstractFactory.Suspension;
using AbstractFactory.Wheel;

namespace AbstractFactory.Factory
{
    public interface ICarFactory
    {
        IEngine CreateEngine();
        ISuspension CreateSuspension();
        IWheel CreateWheel();
    }
}