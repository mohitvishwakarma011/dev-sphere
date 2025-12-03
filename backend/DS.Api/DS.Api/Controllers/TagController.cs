using DS.Core.Dto.Tag;
using Microsoft.AspNetCore.Authorization;

namespace DS.Api.Controllers
{
    [Route("tag")]
    [ApiController]
    public class TagController(IHttpContextAccessor context,ITagManager tagManager): BaseController(context)
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTag([FromBody] UpsertTagDto tagDto)
        {
            try
            {
                await tagManager.AddTagAync(tagDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTagAsync([FromBody] UpsertTagDto tagDto)
        {
            try
            {
                await tagManager.UpdateTagAsync(tagDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetTagByIdAsync([FromRoute]int id)
        {
            try
            {
                return Ok(await tagManager.GetTagByIdAsync(id));    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list")]
        [Authorize]
        public async Task<IActionResult> GetTAgListAsync()
        {
            try
            {
                return Ok(await tagManager.GetTagListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTag([FromRoute]int id)
        {
            try
            {
                await tagManager.DeleteTagAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
