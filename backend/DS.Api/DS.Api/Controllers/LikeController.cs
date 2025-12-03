using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DS.Api.Controllers
{
    [Route("like")]
    [ApiController]
    public class LikeController(IHttpContextAccessor httpContext,ILikeManager likeManager) : BaseController(httpContext)
    {
        [HttpPost("{postId:int}")]
        [Authorize]
        public async Task<IActionResult> ToggleLike([FromRoute]int postId)
        {
            try
            {
                return Ok(await likeManager.ToggleLike(postId, UserId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
