namespace DS.Core.Abstraction.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<bool> CategoryExistByNameAsync(string name);
        Task<IList<string>> SubCategoriesExistByNamesAsync(string[] Names);
    }
}
