using DS.Core.Dto.Category;
using DS.Core.Dto.SubCategory;

namespace DS.Application.Managers
{
    public class CategoryManager(ICategoryRepository repository, IUnitOfWork unitOfWork) : ICategoryManager
    {
        public async Task AddAsync(CategoryDto categoryDto)
        {
            Category category = new Category
            {
                Description = categoryDto.Description,
                Name = categoryDto.Name,
                Status = Constants.RecordStatus.Active,
                Subcategories = categoryDto.SubCategories.Select(x => new Subcategory
                {
                    Description = x.Description,
                    Name = x.Name,
                    Status = Constants.RecordStatus.Active
                }).ToList()
            };
            await repository.AddAsync(category);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            return await repository.CategoryExistByNameAsync(name);
        }

        public async Task<IList<string>> SubCategoriesExistByNamesAsync(string[] Names)
        {
            return await repository.SubCategoriesExistByNamesAsync(Names);
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            repository.UpdateAsync(categoryDto);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetUntrackedCategoryByIdAsync(int id)
        {
            var category = await repository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                throw new InvalidOperationException("Category does not exist.");
            }

            var categoryDto = new CategoryDto
            {
                Name = category.Name,
                Description = category.Description,
                Id = category.Id,
                Status = category.Status,
                SubCategories = category.Subcategories.Select(sc => new SubCategoryDto
                {
                    Name = sc.Name,
                    CategoryId = sc.CategoryId,
                    Description = sc.Description,
                    Id = sc.Id,
                    Status = sc.Status,
                }).ToList()
            };

            return categoryDto;
        }

        public async Task<IList<CategoryDto>> GetCategoryListAsync()
        {
            return await repository.GetCategoryListAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await repository.DeleteCategoryAsync(id);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
