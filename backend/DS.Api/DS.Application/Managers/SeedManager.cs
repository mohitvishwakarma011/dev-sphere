namespace DS.Application.Managers
{
    public class SeedManager(ISeedRepository seedRepository,IUnitOfWork unitOfWork) : ISeedManager
    {
        public async Task SeedData()
        {

            await seedRepository.SeedCategories();
            await unitOfWork.SaveChangesAsync();
            await seedRepository.SeedSubCategories();
            await unitOfWork.SaveChangesAsync();

        }
    }
}
