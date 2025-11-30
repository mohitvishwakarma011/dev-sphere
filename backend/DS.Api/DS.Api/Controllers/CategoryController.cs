using DS.Core.Dto.Category;
using Microsoft.AspNetCore.Authorization;

namespace DS.Api.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController(IHttpContextAccessor context, ICategoryManager categoryManager) : BaseController(context)
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
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
    }
}
