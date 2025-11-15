using DS.Core.Dto.User;

namespace DS.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.AsNoTracking().SingleAsync(x => x.Id == id);
        }

        public async Task<IList<UserDto>> GetListAsync()
        {
            return await context.Users.AsNoTracking().Select(x => new UserDto
            {
                Id = x.Id,
                UserEmail = x.UserName,
                UserName = x.UserName,
                Role = x.Role
            }).ToListAsync(); 
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await context.Users.SingleAsync(x => x.Id == id);
            if(user != null)
            {
                user.Status = Constants.RecordStatus.Deleted;
            }
        }

    }
}
