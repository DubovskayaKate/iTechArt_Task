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
        // GET api/values/{q= & token=}
        [HttpGet("{query}")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetAsync(string query)
        {
            var service = new YoutubeService();
            return Ok(await service.GetFromApi(query));
        }
    }
}
