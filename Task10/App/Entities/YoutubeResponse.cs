using System.Collections.Generic;

namespace App.Entities
{
    public class YoutubeResponse
    {
        public string NextPageToken;
        public List<YoutubeItem> Video;

        public YoutubeResponse(string nextPageToken, List<YoutubeItem> video)
        {
            this.NextPageToken = nextPageToken;
            this.Video = video;
        }
    }
}
