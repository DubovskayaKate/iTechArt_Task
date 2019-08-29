namespace Facade
{
    public class OGGCodec : ICodec
    {
        private readonly string _description = "OGG";

        public string Description
        {
            get => _description;
        }
    }
}