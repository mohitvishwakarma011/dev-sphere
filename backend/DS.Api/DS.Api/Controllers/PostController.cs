using DS.Core.Models.FilterModel;

namespace DS.Api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController(
        IPostManager postManager,
        IValidator<PostModel> postValidator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody]PostModel postModel)
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

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromBody]PostFilterModel filterModel)
        {
            await 
        }
    }
}
