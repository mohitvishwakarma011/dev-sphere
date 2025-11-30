using DS.Core.Dto.Category;

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
    }
}
