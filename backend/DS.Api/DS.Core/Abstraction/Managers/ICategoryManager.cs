using DS.Core.Dto.Category;

namespace DS.Core.Abstraction.Managers
{
    public interface ICategoryManager
    {
        Task AddAsync(CategoryDto categoryDto);
        Task<bool> CategoryExistByNameAsync(string name);
        Task<IList<string>> SubCategoriesExistByNamesAsync(string[] Names);
    }
}
