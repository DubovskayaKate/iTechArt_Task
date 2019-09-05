namespace Facade
{
    public class Mpeg4Codec : ICodec
    {
        private readonly string _description = "MPEG4";

        public string Description => _description;
        
    }
}