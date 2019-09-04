using AbstractFactory.Engine;
using AbstractFactory.Suspension;
using AbstractFactory.Wheel;

namespace AbstractFactory.Factory
{
    public class EconomyCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new EconomyEngine();
        }

        public ISuspension CreateSuspension()
        {
            return new EconomySuspension();
        }

        public IWheel CreateWheel()
        {
            return new EconomyWheel();
        }
    }
}
