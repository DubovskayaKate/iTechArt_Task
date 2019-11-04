using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        // GET api/values/{q= & token=}
        [HttpGet("{query}")]
        [EnableCors("somepolicy")]
        public async Task<IActionResult> GetAsync(string query)
        {
            var video1 = new YoutubeItem("img", "img", "img", "title", "discrip", "id1");
            var video2 = new YoutubeItem("img", "img", "img", "title", "discrip", "id2");

            //video1.GetFromApi(query);
            return Ok(await video1.GetFromApi(query));
        }

        public class YoutubeItem
        {
            public string imageUrlMedium;
            public string imageUrlHigh;
            public string imageUrlDefault;
            public string title;
            public string description;
            public string id;

            private readonly string API_KEY = "AIzaSyALMiCr_df0KxwdiWxpGeQBSCrczG5RcRs";

            public YoutubeItem(string imageUrlMedium, 
                string imageUrlHigh, string imageUrlDefault,
                string title, string description, string id)
            {
                this.description = description;
                this.id = id;
                this.imageUrlDefault = imageUrlDefault;
                this.imageUrlHigh = imageUrlDefault;
                this.imageUrlMedium = imageUrlMedium;
                this.title = title;
            }

            public async Task<List<YoutubeItem>> GetFromApi(string query)
            {
                HttpClient client = new HttpClient();
                var videoList = new List<YoutubeItem>();
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://www.googleapis.com/youtube/v3/search?part=snippet&key={this.API_KEY}&{query}");
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsAsync<JObject>();

                    for (var i = 0; i < 5; i++) {

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
                    return videoList;
                }
                catch (HttpRequestException e)
                {

                }
                client.Dispose();
                return null;
            }
        }

    }
}
