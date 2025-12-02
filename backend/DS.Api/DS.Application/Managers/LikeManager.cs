namespace DS.Application.Managers
{
    public class LikeManager(ILikeRepository likeRpeository) : ILikeManager
    {
        public async Task<bool> ToggleLike(int postId, int userId)
        {
            return await likeRpeository.ToggleLike(postId, userId);
        }
    }
}
