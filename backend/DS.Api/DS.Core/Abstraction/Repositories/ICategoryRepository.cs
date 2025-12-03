using DS.Core.Dto.Category;

namespace DS.Core.Abstraction.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<bool> CategoryExistByNameAsync(string name);
        Task<IList<string>> SubCategoriesExistByNamesAsync(string[] Names);
        void UpdateAsync(UpdateCategoryDto category);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category?> GetUntrackedCategoryByIdAsync(int id);
        Task<IList<CategoryDto>> GetCategoryListAsync();
        Task DeleteCategoryAsync(int id);
    }
}
