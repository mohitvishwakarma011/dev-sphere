using System.Collections.Generic;

namespace DS.Application.Managers
{
    public class SeedManager(ISeedRepository seedRepository,IUnitOfWork unitOfWork) : ISeedManager
    {
        public async Task SeedData()
        {

            await seedRepository.SeedCategories();
            await unitOfWork.SaveChangesAsync();
            await seedRepository.SeedSubCategories();

            await seedRepository.SeedAdminAndRoleAsync();
            await unitOfWork.SaveChangesAsync();

        }
    }
}
