using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using App.Services;
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
            var service = new YoutubeService();
            return Ok(await service.GetFromApi(query));
        }



    }
}
