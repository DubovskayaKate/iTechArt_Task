namespace Facade
{
    public class OggCodec : ICodec
    {
        private readonly string _description = "OGG";

        public string Description => _description;
    }
}