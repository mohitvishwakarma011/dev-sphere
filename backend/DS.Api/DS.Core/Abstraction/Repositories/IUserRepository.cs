

namespace DS.Core.Abstraction.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<IList<User>> GetListAsync();
        Task DeleteAsync(int id);

    }
}
