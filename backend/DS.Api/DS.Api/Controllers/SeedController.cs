namespace DS.Api.Controllers
{
    [Route("api/seed")]
    [ApiController]
    public class SeedController(ISeedManager seedManager) : ControllerBase
    {
        [HttpGet]
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
