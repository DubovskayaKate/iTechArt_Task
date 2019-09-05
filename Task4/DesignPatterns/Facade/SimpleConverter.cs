namespace Facade
{
    public class SimpleConverter
    {
        public void Convert(string filename, string format)
        {
            var videoFile = new VideoFile(filename);
            ICodec codec;
            if (format == "MPEG4")
            {
                codec = new Mpeg4Codec();
            }
            else
            {
                codec = new OggCodec();
            }

            var videoConverter = new VideoConverter();
            videoConverter.Convert(videoFile, codec);
        }
    }
}