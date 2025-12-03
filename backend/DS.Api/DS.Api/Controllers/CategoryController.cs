using DS.Core.Dto.Category;
using Microsoft.AspNetCore.Authorization;

namespace DS.Api.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController(IHttpContextAccessor context, ICategoryManager categoryManager, IValidator<CategoryDto> categoryValidator, IValidator<UpdateCategoryDto> updateCategoryValidator) : BaseController(context)
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                //Validation
                var validationResult = await categoryValidator.ValidateAsync(categoryDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ToList());
                }

                var doesCategoryExist = await categoryManager.CategoryExistByNameAsync(categoryDto.Name.Trim());
                if (doesCategoryExist)
                {
                    return BadRequest("Category already exists.");
                }

                var subCategoriesFromDto = categoryDto.SubCategories.Select(sc => sc.Name).ToArray();
                var existedSubcategories = await categoryManager.SubCategoriesExistByNamesAsync(subCategoriesFromDto);

                if (existedSubcategories.Any())
                {
                    return BadRequest($"Subcategory(s) \"{String.Join(",", existedSubcategories)}\" already exists.");
                }
                await categoryManager.AddAsync(categoryDto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            try
            {
                var validationResult = await updateCategoryValidator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ToList());
                }
                categoryManager.UpdateCategory(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            try
            {
                return Ok(await categoryManager.GetUntrackedCategoryByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list")]
        [Authorize]
        public async Task<IActionResult> GetCategoryList()
        {
            try
            {
                return Ok(await categoryManager.GetCategoryListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            try
            {
                await categoryManager.DeleteCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
