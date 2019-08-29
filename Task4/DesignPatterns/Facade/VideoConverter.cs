using System;

namespace Facade
{
    public class VideoConverter
    {
        public void Convert(VideoFile videoFile, ICodec codec)
        {
            Console.WriteLine($"Convert {videoFile.Filename} to {codec.Description}");
        }
    }
}