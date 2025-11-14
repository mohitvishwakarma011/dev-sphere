
namespace DS.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]UserModel userModel)
         {
            try
            {
                await userManager.AddUser(userModel);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
