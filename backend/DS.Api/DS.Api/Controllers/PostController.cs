namespace DS.Api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody])
        {

        }
    }
}
