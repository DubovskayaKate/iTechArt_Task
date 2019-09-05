namespace AbstractFactory.Engine
{
    public abstract class BaseEngine : IEngine
    {
        public double  EngineCapacity { get; protected set; }
    }
}