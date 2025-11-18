

namespace DS.Core.Abstraction.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        void Update(User user);
        Task<User> GetByIdAsync(int id);
        Task<IList<UserDto>> GetListAsync();
        Task DeleteAsync(int id);

    }
}
