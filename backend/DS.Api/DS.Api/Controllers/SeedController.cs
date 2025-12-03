using Microsoft.AspNetCore.Authorization;

namespace DS.Api.Controllers
{
    [Route("seed")]
    [ApiController]
    public class SeedController(ISeedManager seedManager ,IHttpContextAccessor context) : BaseController(context)
    {
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> SeedData()
        {
            try
            {
                await seedManager.SeedData();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
