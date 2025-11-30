using DS.Core.Models.FilterModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DS.Api.Controllers
{
    [Route("post")]
    [ApiController]
    public class PostController(
        IPostManager postManager,
        IValidator<PostModel> postValidator, IHttpContextAccessor context): BaseController(context)
    {
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> AddPost([FromBody] PostModel postModel)
        {
            try
            {
                var validationResult = await postValidator.ValidateAsync(postModel);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ToList());
                }

                await postManager.AddAsync(postModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdatePost([FromBody] PostModel postModel)
        {
            try
            {
                var validationResult = await postValidator.ValidateAsync(postModel);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ToList());
                }

                await postManager.Update(postModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PostFilterModel filterModel)
        {
            return Ok(await postManager.GetListAsync(filterModel));
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                return Ok(await postManager.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                await postManager.DeletePost(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
