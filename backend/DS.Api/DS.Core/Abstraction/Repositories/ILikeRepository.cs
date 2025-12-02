namespace DS.Core.Abstraction.Repositories
{
    public interface ILikeRepository
    {
        Task<bool> ToggleLike(int postId, int userId);
    }
}
