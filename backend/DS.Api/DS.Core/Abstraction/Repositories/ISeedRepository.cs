namespace DS.Core.Abstraction.Repositories
{
    public interface ISeedRepository
    {
        Task SeedCategories();
        Task SeedSubCategories();
        Task SeedAdminAndRoleAsync();
    }

}