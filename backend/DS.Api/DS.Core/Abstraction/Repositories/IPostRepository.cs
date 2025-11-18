namespace DS.Core.Abstraction.Repositories
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task<bool> IsExistAsync(int id);
        Task Update(Post post);
    }
}
