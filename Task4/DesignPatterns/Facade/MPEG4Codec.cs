namespace Facade
{
    public class MPEG4Codec : ICodec
    {
        private readonly string _description = "MPEG4";

        public string Description
        {
            get => _description;
        }
    }
}