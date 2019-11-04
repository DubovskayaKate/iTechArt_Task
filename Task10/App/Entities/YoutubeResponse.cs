using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers;
using static App.Controllers.YoutubeController;

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
