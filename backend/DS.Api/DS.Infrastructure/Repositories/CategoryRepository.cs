using DS.Core.Dto.Category;
using DS.Core.Dto.SubCategory;
using DS.Core.Entities;
using System.Runtime.CompilerServices;

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
            return await context.Categories.AsNoTracking().AnyAsync(c => c.Name == name);
        }

        public async Task<IList<string>> SubCategoriesExistByNamesAsync(string[] subCatNames)
        {
            return await context.SubCategories.AsNoTracking().Where(sc => subCatNames.Contains(sc.Name)).Select(sc => sc.Name).ToListAsync();
        }

        public async void UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category = await GetCategoryByIdAsync(categoryDto.Id);
            if (category == null)
            {
                throw new InvalidOperationException("Category does not found.");
            }

            //Update primitive values
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;

            //Update relations
            //var subCategoryNoChange = category.Subcategories.Where(sc => categoryDto.SubCategoryIds.Contains(sc.Id)).ToList();
            var subCategoryToRemove = category.Subcategories.Where(sc => !categoryDto.SubCategoryIds.Contains(sc.Id)).ToList();

            foreach (var subCategory in subCategoryToRemove)
            {
                subCategory.Status = Constants.RecordStatus.Deleted;
                subCategory.CategoryId = null;
            }

            //To Add SubCategory
            var existedSubcategoryIds = category.Subcategories.Select(x => x.Id).ToList();
            var subCategoryToAddIds = categoryDto.SubCategoryIds.Where(sc => !existedSubcategoryIds.Contains(sc)).ToList();

            var subcategoriesToAdd = await context.SubCategories
            .Where(sc => subCategoryToAddIds.Contains(sc.Id))
            .ToListAsync();

            category.Subcategories.AddRange(subcategoriesToAdd);

        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await context.Categories.Include(c => c.Subcategories).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetUntrackedCategoryByIdAsync(int id)
        {
            return await context.Categories.AsNoTracking().Include(c => c.Subcategories).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<CategoryDto>> GetCategoryListAsync()
        {
            return await context.Categories.AsNoTracking().Where(c => c.Status != Constants.RecordStatus.Deleted)
                .OrderBy(c => c.Name).Select(c => new CategoryDto
                { Name = c.Name, Description = c.Description, Id = c.Id, Status = c.Status }).ToListAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await context.Categories.Include(c => c.Subcategories)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new InvalidOperationException("Category does not exist.");
            }

            category.Status = Constants.RecordStatus.Deleted;
            foreach(var sc in category.Subcategories)
            {
                sc.CategoryId = null;
            }

            context.Categories.Update(category);

        }
    }
}
