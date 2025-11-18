namespace DS.Core.Abstraction.Managers
{
    public interface  IPostManager
    {
        Task AddAsync(PostModel postModel);
        Task Update(PostModel postModel);
        Task<bool> IsExistAsync(int id);
    }
}
