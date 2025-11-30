namespace DS.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public async Task AddAsync(Category category)
        {
            await context.Categories.AddAsync(category); 
        }

        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            return await context.Categories.AsNoTracking().AnyAsync(c=>c.Name == name);
        }

        public async Task<IList<string>> SubCategoriesExistByNamesAsync(string[] subCatNames)
        {
            return await context.SubCategories.AsNoTracking().Where(sc=> subCatNames.Contains(sc.Name)).Select(sc=> sc.Name).ToListAsync();
        }
    }
}
