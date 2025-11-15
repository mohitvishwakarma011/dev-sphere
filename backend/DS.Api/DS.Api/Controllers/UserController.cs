
using DS.Core.Dto.User;

namespace DS.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserManager userManager;
        public IValidator<UserModel> userValidator;

        public UserController(IUserManager userManager, IValidator<UserModel> userValidator)
        {
            this.userManager = userManager;
            this.userValidator = userValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel userModel)
        {
            try
            {
                var validationResult = await userValidator.ValidateAsync(userModel);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                }
                await userManager.AddUser(userModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel userModel)
        {
            try
            {
                var validationResult = await userValidator.ValidateAsync(userModel);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                }
                await userManager.UpdateUserAsync(userModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute]int id)
        {
            try
            {
                return Ok(await userManager.GetByIdAsync(id));

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetUserList()
        {
            return  Ok(await userManager.GetListAsync());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            try
            {
                await userManager.DeleteAsync(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}