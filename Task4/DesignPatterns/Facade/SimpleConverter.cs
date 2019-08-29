namespace Facade
{
    public class SimpleConverter
    {
        public void Convert(string filename, string format)
        {
            var videoFile = new VideoFile(filename);
            ICodec codec;
            if (format == "MPEG4")
                codec = new MPEG4Codec();
            else
                codec = new OGGCodec();
            var videoConverter = new VideoConverter();
            videoConverter.Convert(videoFile, codec);
        }
    }
}