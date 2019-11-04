using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using App.Entities;
using Newtonsoft.Json.Linq;
using static App.Controllers.YoutubeController;

namespace App.Services
{
    public class YoutubeService
    {
        private readonly string API_KEY = "AIzaSyALMiCr_df0KxwdiWxpGeQBSCrczG5RcRs";

        public async Task<YoutubeResponse> GetFromApi(string query)
        {
            HttpClient client = new HttpClient();
            var videoList = new List<YoutubeItem>();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://www.googleapis.com/youtube/v3/search?part=snippet&key={this.API_KEY}&{query}");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsAsync<JObject>();

                var nextPageToken = (string)responseBody["nextPageToken"];
                
                for (var i = 0; i < 5; i++)
                {
                    var item = responseBody["items"][i];
                    string id = (string)item["id"]["videoId"];
                    videoList.Add(new YoutubeItem(
                            (string)item["snippet"]["thumbnails"]["medium"]["url"],
                            (string)item["snippet"]["thumbnails"]["high"]["url"],
                            (string)item["snippet"]["thumbnails"]["default"]["url"],
                            (string)item["snippet"]["title"],
                            (string)item["snippet"]["description"],
                            id ?? (string)item["id"]["channelId"]
                        )
                    );
                }

                var youtubeResponse = new YoutubeResponse(nextPageToken, videoList);
                return youtubeResponse;
            }
            catch (HttpRequestException e)
            {

            }
            client.Dispose();
            return null;
        }
    }
}
