namespace DS.Core.Abstraction.Managers
{
    public interface ILikeManager
    {
        Task<bool> ToggleLike(int postId, int userId);
    }
}
