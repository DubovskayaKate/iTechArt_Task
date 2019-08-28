using AbstractFactory.Engine;
using AbstractFactory.Suspension;
using AbstractFactory.Wheel;

namespace AbstractFactory.Factory
{
    public class ExtraCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new ExtraEngine();
        }

        public ISuspension CreateSuspension()
        {
            return new ExtraSuspension();
        }

        public IWheel CreateWheel()
        {
            return new ExtraWheel();
        }
    }
}