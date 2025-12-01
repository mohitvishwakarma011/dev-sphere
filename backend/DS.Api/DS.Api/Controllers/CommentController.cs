using DS.Core.Dto.Comment;
using DS.Core.Models.FilterModel;
using Microsoft.AspNetCore.Authorization;

namespace DS.Api.Controllers
{
    [Route("comment")]
    [ApiController]
    public class CommentController(IHttpContextAccessor httpCOntext, ICommentManager commentManager, IValidator<UpsertCommentDto> upsertCommentValidator) : BaseController(httpCOntext)
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment([FromBody] UpsertCommentDto upsertCommentDto)
        {
            try
            {
                var validationResult = await upsertCommentValidator.ValidateAsync(upsertCommentDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ToList());
                }
                await commentManager.AddCommentAsync(upsertCommentDto, UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateComment([FromBody] UpsertCommentDto upsertCommentDto)
        {
            try
            {
                var validationResult = await upsertCommentValidator.ValidateAsync(upsertCommentDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ToList());
                }
                await commentManager.UpdateCommentAsync(upsertCommentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            try
            {
                return Ok(await commentManager.GetCommentByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCommentList([FromQuery] FilterModel filterModel)
        {
            
        }
    }
}
