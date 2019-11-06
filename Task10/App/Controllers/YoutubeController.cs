using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        public YoutubeService YoutubeService { get; }
        public YoutubeController(YoutubeService youtubeService)
        {
            YoutubeService = youtubeService;
        }

        // GET api/values/{q= & token=}
        [HttpGet("{query}")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetAsync(string query)
        {
            return Ok(await YoutubeService.GetFromApi(query));
        }
    }
}
