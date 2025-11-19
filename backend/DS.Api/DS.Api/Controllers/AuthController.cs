using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DS.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IUserManager userManager, IValidator<UserModel> userValidator, IPasswordHasher<UserModel> passwordHasher,IAuthRepository authRepository) : ControllerBase
    {
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            try
            {
                var result = userValidator.Validate(userModel);

                if (!result.IsValid)
                {
                    return BadRequest(result.Errors.Select(x => x).ToList());
                }

                var isUserExists = await userManager.IsExistAsyncByUserEmail(userModel.UserEmail);

                if (isUserExists)
                {
                    return BadRequest("The UserEmail is taken.");
                }

                userModel.Password = passwordHasher.HashPassword(userModel, userModel.Password);

                await userManager.AddUser(userModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                return Ok(await authRepository.UserLogin(loginModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
