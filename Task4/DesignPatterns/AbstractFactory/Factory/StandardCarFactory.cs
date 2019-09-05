using AbstractFactory.Engine;
using AbstractFactory.Suspension;
using AbstractFactory.Wheel;

namespace AbstractFactory.Factory
{
    public class StandardCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new StandardEngine();
        }

        public ISuspension CreateSuspension()
        {
            return new StandardSuspension();
        }

        public IWheel CreateWheel()
        {
            return new StandardWheel();
        }
    }
}