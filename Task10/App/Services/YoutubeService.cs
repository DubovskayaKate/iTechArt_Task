using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using App.Entities;
using App.Settings;
using Newtonsoft.Json.Linq;

namespace App.Services
{
    public class YoutubeService
    {
        private readonly YoutubeSettings _youtubeSettings;
        public YoutubeService(YoutubeSettings settings)
        {
            _youtubeSettings = settings;
        }

        public async Task<YoutubeResponse> GetFromApi(string query)
        {
            HttpClient client = new HttpClient();
            var videoList = new List<YoutubeItem>();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_youtubeSettings.Url}?part=snippet&key={_youtubeSettings.ApiKey}&{query}");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsAsync<JObject>();

                var nextPageToken = (string)responseBody["nextPageToken"];
                
                for (var i = 0; i < 5; i++)
                {
                    var item = responseBody["items"][i];
                    string id = (string)item["id"]["videoId"];
                    videoList.Add(new YoutubeItem { 
                            ImageUrlMedium = (string)item["snippet"]["thumbnails"]["medium"]["url"],
                            ImageUrlHigh = (string)item["snippet"]["thumbnails"]["high"]["url"],
                            ImageUrlDefault = (string)item["snippet"]["thumbnails"]["default"]["url"],
                            Title = (string)item["snippet"]["title"],
                            Description = (string)item["snippet"]["description"],
                            Id = id ?? (string)item["id"]["channelId"]
                        }
                    );
                }

                var youtubeResponse = new YoutubeResponse(nextPageToken, videoList);
                return youtubeResponse;
            }
            catch (HttpRequestException)
            {

            }
            client.Dispose();
            return null;
        }
    }
}
