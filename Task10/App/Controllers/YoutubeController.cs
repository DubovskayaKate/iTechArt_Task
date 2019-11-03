using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        //// GET api/youtube
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/{q= & token=}
        [HttpGet("{query}")]
        [EnableCors]
        public IActionResult GetAsync(string query)
        {
            var video = new YoutubeItem("img", "img", "img", "title", "discrip", "id");

            //await video.GetFromApi(query);
            return Ok(video);
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

            public async Task GetFromApi(string query)
            {
                HttpClient client = new HttpClient();
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://www.googleapis.com/youtube/v3/search?part=snippet&key={this.API_KEY}&q=css");
                    response.EnsureSuccessStatusCode();
                    object responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {

                }
                client.Dispose();
            }
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
